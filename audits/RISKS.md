# Risk Register — dotnet-algorand-sdk

Living register of risks faced by developers and end-users of this SDK and of code
produced by its ARC56 client generator, maintained per
`audits/AUDITS-INSTRUCTIONS.md`. Includes risks this repository has **no ability to
mitigate** — the goal is a complete threat picture for downstream developers, not just
a changelog of fixes. Percentages are estimates of the likelihood the risk is actually
exploited/misused *somewhere* across the SDK's user base within the next 5 years (see
estimation method in the instructions file); they are judgment calls, kept methodologically
consistent across audits, not measured statistics.

Never delete a row. Mark it Mitigated and keep it for historical traceability.

---

## RISK-001 — Private key bytes are never zeroed/disposed from process memory

- **Description**: `KeyPair.ClearTextPrivateKey` and related BouncyCastle
  `Ed25519PrivateKeyParameters` objects held by `Account` are plain, long-lived
  `byte[]`/managed objects with no `Dispose`/explicit-clear support. The raw private
  key can remain in process memory (and be copied during GC compaction) for the
  lifetime of the `Account` object and potentially beyond.
- **Who is exposed**: End users whose keys are held in a long-running developer
  application (e.g. a signer service, a bot, a backend wallet).
- **Mitigable by this repo?**: Partially — best-effort key wiping can be added (see
  `AUDIT-2026-07-16.md` F1), but the CLR provides no strong guarantee that all copies
  are scrubbed (string interning, GC compaction history, swap/hibernation files are
  outside the SDK's control).
- **Current mitigation status**: Mitigated (best-effort) — `KeyPair`/`Account` now
  implement `IDisposable`; `Dispose()` zeroes `ClearTextPrivateKey` and drops
  BouncyCastle key object references. Still only best-effort per the CLR caveats above,
  and callers must remember to call `Dispose()` themselves.
- **5-year misuse likelihood**: **1%** (down from 3%) — the fix removes the "no way to
  even try" gap; residual risk is now only (a) a memory-read attacker catching a copy
  before `Dispose()` is called, or (b) a developer never calling `Dispose()` at all.
  Lowered, not eliminated, since disposal is opt-in and the CLR guarantee remains
  inherently partial.
- **Impact if realized**: Loss of the specific key(s) held by the compromised process.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-08-12 — classic `Account`/`KeyPair` unchanged, mitigation
  intact; note that the new post-quantum `FalconAccount` (added this cycle) has the same
  class of gap *without* the mitigation — tracked separately as `RISK-015`.

## RISK-002 — BouncyCastle crypto dependency vendored as an unpinned local DLL

- **Description**: The Ed25519 signing implementation this SDK's entire key security
  model depends on ships as `Libs\BouncyCastle.Crypto.dll`, referenced via a raw
  `HintPath`, not the official versioned NuGet package. No automated tooling
  (Dependabot, `dotnet list package --vulnerable`) can track CVEs against it, and its
  provenance can't be verified from source control alone.
- **Who is exposed**: All developers depending on `Algorand4`, transitively all their
  end users.
- **Mitigable by this repo?**: Yes — migrate to the official pinned NuGet package (see
  `AUDIT-2026-07-16.md` F2).
- **Current mitigation status**: Mitigated — `dotnet-algorand-sdk.csproj` now references
  `BouncyCastle.Cryptography` v2.6.2 via `PackageReference`; the vendored
  `Libs\BouncyCastle.Crypto.dll` was deleted. Standard NuGet/Dependabot-style CVE
  tracking now applies. Verified via full Release build, `AccountTests` golden-transaction
  signing test, and the full `SerialisationTests` suite (23/23), all passing with the new
  package. The Unity build's ILRepack filename filter was updated to match, but could not
  be end-to-end verified in this environment due to an unrelated, pre-existing Unity
  build issue (confirmed present before this fix too) — flagged for a maintainer with a
  working Unity toolchain to confirm.
- **5-year misuse likelihood**: **1%** (down from 4%) — the primary risk (no CVE
  tracking / unverifiable provenance) is resolved; residual risk is only the small
  chance of the Unity ILRepack path silently breaking in a way this environment
  couldn't verify, which would be a build/functionality issue rather than a security
  one.
- **Impact if realized**: Depending on the nature of a hypothetical crypto flaw, up to
  full key compromise across all consumers on the vulnerable version.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-08-12 — still on the official pinned `BouncyCastle.Cryptography`
  2.6.2 NuGet package. Note: the pin is now additionally load-bearing because the new
  Falcon-1024 keygen reflects into BC internals (`RISK-016`) — a future CVE-driven
  upgrade needs the Falcon golden-vector tests to pass, not just a version bump.

## RISK-003 — Exception messages can carry exported key material into application logs

- **Description**: `ApiException.Message`/`.ToString()` embeds up to 512 characters of
  the raw HTTP response body; `ExportKeyAsync`/`ExportMasterKeyAsync` on the Kmd client
  return private/master key material in that body. An application that logs caught
  exceptions verbosely (a very common default pattern) could write key material to
  logs, log aggregators, or crash-reporting services.
- **Who is exposed**: Developers who call Kmd's export endpoints and use conventional
  exception logging; downstream, the end users whose keys were exported.
- **Mitigable by this repo?**: Yes — redact response bodies from exception messages for
  export endpoints, or add explicit doc warnings (see `AUDIT-2026-07-16.md` F3).
- **Current mitigation status**: Mitigated — `ApiException.Message`/`.ToString()` no
  longer embed the raw HTTP response body (only its length); the full body remains
  available via the `Response` property for callers who deliberately want it. Verified
  via new `ApiExceptionTests` covering both the redaction and the null-response case.
  Because `ApiException.cs` is technically NSwag-generated (though not currently
  regenerated in the normal `regen-model` flow), a code comment flags that this patch
  must be reapplied if the file is ever regenerated from scratch.
- **5-year misuse likelihood**: **2%** (down from 12%) — the accidental-logging vector
  via `Message`/`ToString()` is closed; residual risk is now only (a) a caller
  explicitly logging the `.Response` property itself (a deliberate action, not an
  accident) or (b) the fix being silently reverted by a future full regeneration of
  `ApiException.cs` if a maintainer isn't aware of the code comment.
- **Impact if realized**: Loss of the specific exported key(s) that ended up in a log
  sink, plus any secondary exposure from that log sink's own access controls (e.g. a
  shared logging dashboard, a third-party log aggregator).
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-08-12 — `ApiException.cs` was edited this cycle
  (using-directive cleanup only); verified the redaction behavior and its warning
  comment survived intact.

## RISK-004 — Kmd's remote-custody model means keys are sent over the wire by design

- **Description**: `Kmd.ImportKeyAsync` sends a raw private key to whatever endpoint
  the developer configured the Kmd client with. This is inherent to Kmd's documented
  purpose (a remote key-management daemon) and is not something this SDK can safely
  change without breaking Kmd's own API contract.
- **Who is exposed**: End users whose keys are imported into a Kmd instance the
  developer chose to point at — if that instance is compromised, misconfigured to
  listen on a public interface, or is not actually the trusted local daemon the
  developer thought it was, the key is directly exposed.
- **Mitigable by this repo?**: No (inherent to Kmd's design) — Partially, in that the
  SDK could add prominent documentation/warnings on the relevant methods.
  Documentation is the achievable mitigation; the underlying network transmission is
  not something this repo can remove.
- **Current mitigation status**: Not applicable (inherent, out of scope) — Partially
  mitigated via recommended documentation (not yet added as of this audit).
- **5-year misuse likelihood**: **8%** — Kmd is typically run locally (AlgoKit
  LocalNet) and rarely exposed to untrusted networks in production Algorand
  deployments, but misconfiguration (e.g. binding Kmd to `0.0.0.0` in a container
  without a firewall rule) is a realistic, previously-seen category of cloud
  misconfiguration across many ecosystems.
- **Impact if realized**: Full compromise of any key imported into the exposed Kmd
  instance.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-07-16

## RISK-005 — Developers hardcode or log mnemonics/private keys in their own application code

- **Description**: Nothing about using this SDK prevents a developer from hardcoding a
  mnemonic in source control, embedding it in client-side JS/mobile code (e.g. via a
  generated ARC56 client used in a frontend), printing it via `Console.WriteLine`, or
  committing a `.env` file containing it. `Account.ToString()` is safely redacted, but
  `Account.ToMnemonic()` returns a plain `string` a developer can do anything with.
- **Who is exposed**: End users of applications built with this SDK, whenever the
  building developer makes this mistake.
- **Mitigable by this repo?**: No — this is a downstream developer practice issue. The
  SDK can only reduce the odds via documentation/samples that model secure patterns
  and never show insecure ones (e.g. sample code should never print a mnemonic to
  console or hardcode one in an example meant to be copy-pasted).
- **Current mitigation status**: Not applicable (inherent, out of scope)
- **5-year misuse likelihood**: **45%** — hardcoded secrets and accidental logging of
  sensitive values are among the most common security mistakes across all ecosystems
  (see e.g. widespread hardcoded-API-key/secret-scanning findings industry-wide); with
  a large enough developer population using this SDK over 5 years, it is near-certain
  that *some* developer somewhere makes this mistake. This is deliberately scored high
  per the instructions' >35% band ("near-certain to be hit by someone at scale").
- **Impact if realized**: Loss of the specific key(s)/mnemonic(s) exposed by the
  affected developer's mistake — bounded to that application's users, not systemic.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-07-16

## RISK-006 — Malicious or compromised Algod/Indexer/Kmd node operator

- **Description**: This SDK, by design, sends signed transactions and (for Kmd)
  signing requests to a node endpoint the developer configures. If that node is
  malicious (e.g. a "free public Algod API" run by an untrustworthy third party) or
  compromised, it can lie about network state (stale/forged block data, censoring
  transactions) and, in the Kmd case specifically, has direct custody of any imported
  keys.
- **Who is exposed**: End users, if the developer chose an untrustworthy node
  provider.
- **Mitigable by this repo?**: No — node trust is an inherent architectural choice made
  by the developer integrating this SDK, not something a client library can enforce.
- **Current mitigation status**: Not applicable (inherent, out of scope)
- **5-year misuse likelihood**: **6%** — most production integrations use well-known
  node providers (Algonode, Nodely, AlgoNode, PureStake historically, or
  self-hosted/AlgoKit nodes); the realistic misuse case is a smaller developer picking
  an unvetted free/public endpoint, which happens but is not the dominant pattern.
- **Impact if realized**: Ranges from transaction censorship/stale-data served to full
  key compromise (if Kmd custody is involved).
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-07-16

## RISK-007 — Host/OS-level compromise (malware, debugger, memory scraping)

- **Description**: Any malware or attacker with code execution on the same host as a
  process using this SDK can read process memory, intercept the CSPRNG output, or hook
  the signing calls directly, regardless of anything this SDK does correctly.
- **Who is exposed**: End users, whenever their device or the developer's server
  hosting keys is compromised at the OS level.
- **Mitigable by this repo?**: No — entirely outside a client library's control.
- **Current mitigation status**: Not applicable (inherent, out of scope)
- **5-year misuse likelihood**: **20%** — host-level malware/infostealers targeting
  crypto wallets are a large and growing, well-documented category across the
  industry; scored in the "common, not the default path, but not requiring an unusual
  misconfiguration" band because it depends on a host being compromised through some
  other channel each time, not zero-click against this SDK.
- **Impact if realized**: Full compromise of any key material accessible to the
  compromised process/host.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-07-16

## RISK-008 — ARC56 client-generator Docker image / generated code supply chain

- **Description**: The `scholtz2/dotnet-avm-generated-client` Docker image (and the
  underlying `client-generator/Program.cs` CLI it wraps) fetches an ARC56 JSON contract
  spec from a URL the developer supplies and emits generated `.cs` client code that
  gets compiled into the developer's application. This audit found the tool only fetches
  the ABI JSON and writes generated source — no key/account data is touched — but a
  compromised Docker image (e.g. a tag takeover on Docker Hub) or a malicious/tampered
  ARC56 JSON spec injected into the generation process are supply-chain vectors this
  repo has only partial control over (control over the source/Dockerfile, not over
  Docker Hub's registry security or a user's choice to trust an unverified spec URL).
- **Who is exposed**: Developers who use the Docker-based generator and, transitively,
  their end users if generated code is compromised.
- **Mitigable by this repo?**: Partially — pin/sign the Docker image, publish
  checksums, and document that ARC56 spec URLs should only be pointed at trusted
  sources.
- **Current mitigation status**: Unmitigated
- **5-year misuse likelihood**: **2%** — requires a specific, uncommon attack (registry
  tag takeover, or a developer pointing the generator at an untrusted spec URL) and the
  generator's actual code surface (ABI-to-stub generation) offers little obvious
  attacker leverage even if triggered, since it doesn't handle key material.
- **Impact if realized**: Malicious generated code compiled into a developer's
  application — impact depends entirely on what that code is made to do, potentially
  significant if it added a hidden network call to a generated client method.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-07-16

## RISK-009 — Unity ILRepack build omits the `MessagePack` package

- **Description**: `dotnet-algorand-sdk/ILRepack.Targets` merges several dependencies
  into the ILRepacked `Algorand.dll` for the Unity build configurations, but does not
  include `MessagePack` (the NuGet package the SDK's signing-critical serialization
  attributes — `MessagePackObject`/`Key`/`IgnoreMember` — depend on at runtime).
  `Algorand4_Unity.nuspec` also doesn't declare `MessagePack` as something the consumer
  must separately install. This is a build/packaging correctness issue, not a
  crypto-weakening one — see `AUDIT-2026-07-16b.md` finding U1.
- **Who is exposed**: Unity/game developers who install the packed `Algorand4_Unity`
  package and hit a missing-type error the first time they serialize or sign a
  transaction.
- **Mitigable by this repo?**: Yes — add `MessagePack` to the ILRepack merge list
  and/or the nuspec dependency group.
- **Current mitigation status**: Mitigated — `ILRepack.Targets` now also merges
  `MessagePack` and `MessagePack.Annotations` (confirmed as a genuine separate
  transitive assembly, not just an alias) alongside the existing dependencies. The
  nuspec's `<dependencies>` group was left unchanged (Microsoft.CSharp,
  System.ComponentModel.Annotations only) with a comment explaining `MessagePack` is
  intentionally merged rather than declared as a separate consumer-installed
  dependency. Verified: standard Release build and both non-network-dependent test
  suites still pass (`SerialisationTests` 23/23, `test` 96/96 excluding the
  LocalNet-dependent Arc4/Arc56 fixtures). The Unity configuration itself still fails
  to *compile* end-to-end due to the pre-existing, unrelated Unity-stub-DLL issue
  (missing `SerializeField`/`Tooltip`/`InspectorName`), confirmed still present in this
  environment — so the ILRepack step's actual runtime output could not be produced or
  verified here. A maintainer with a working Unity toolchain should confirm the packed
  assembly resolves `MessagePack` types at runtime.
- **5-year misuse likelihood**: **N/A — this is a functional/reliability risk, not a
  security-misuse risk.** Recorded here per the audit instructions' registry scope
  (all risks developers/users of this SDK face), but the percentage framework doesn't
  apply since there's no "misuse" — a Unity developer following the package as
  documented would simply hit a broken build, not a security compromise, until fixed.
- **Impact if realized**: Build/runtime failure (`TypeLoadException` or similar) for
  Unity consumers attempting to sign or serialize a transaction — no key-security
  impact.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-07-16 (remediation update, same day)

## RISK-010 — Official SDK example prints a generated mnemonic to the console

- **Description**: `sdk-examples/OfflineSigningExample.cs:26` calls
  `Console.WriteLine("Backup mnemonic:    " + newAccount.ToMnemonic());` on a freshly
  generated account. This models the exact anti-pattern `RISK-005` warns downstream
  developers against — except here it's in code this repo's maintainers directly
  control, unlike `RISK-005` which is about third-party application code. See
  `AUDIT-2026-07-16b.md` finding E1.
- **Who is exposed**: Developers who copy this example's pattern into applications
  that log console output to a file, terminal-capture tool, or CI log, and end users
  whose mnemonics get exposed as a result.
- **Mitigable by this repo?**: Yes — remove or redact the printed mnemonic in the
  example; trivial, no functional impact on the rest of the example.
- **Current mitigation status**: Mitigated (re-mitigated same day after a recurrence) —
  the original `OfflineSigningExample` fix stands, but the new
  `sdk-examples/FalconKeyInteropExample.cs` (added this cycle, commit `cfbe28b`)
  re-introduced the identical anti-pattern at lines 51 and 54: it printed a freshly
  generated Falcon-1024 account's 25-word mnemonic to the console twice (once directly,
  once interpolated into a printed `algokey pq import -m "..."` command). See
  `AUDIT-2026-08-12-71d6cfc.md` finding F1. Fixed same day: both prints replaced with
  the same redaction approach as the `OfflineSigningExample` fix (comment directing the
  reader to persist the mnemonic securely; the printed `algokey` command now shows a
  `<the 25-word mnemonic>` placeholder). The in-memory round-trip verification is
  unchanged. Verified via full Release solution build.
- **5-year misuse likelihood**: **2%** — the live anti-pattern is removed again, but
  scored above the previous post-fix 1% because the pattern has now recurred once,
  showing new examples can re-introduce it; residual risk also includes developers
  copying the pre-fix version of the file.
- **Impact if realized**: Loss of the specific mnemonic(s) printed and subsequently
  captured by whatever consumed the console output (terminal scrollback, CI logs, a
  captured-output log file).
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-08-12 (second audit, `AUDIT-2026-08-12-727f7f7.md` finding V2 —
  the `FalconKeyInteropExample` fix verified present at HEAD; no mnemonic is printed)

## RISK-011 — `Utils.GetRandomAssetMetaHash()` uses `System.Random`, not a CSPRNG

- **Description**: `dotnet-algorand-sdk/Utils/Utils.cs:89-96` generates a 32-byte value
  for the `AssetParams.MetadataHash` field using `System.Random` (time-seeded,
  predictable) rather than a cryptographic RNG. This is **not** in the key-generation or
  signing path — `Account()`'s real key generation uses BouncyCastle's `SecureRandom`,
  confirmed unaffected — and `MetadataHash` is a public, on-chain value with no
  confidentiality requirement. The risk is purely that the method's name/lack of
  documentation could mislead a developer into assuming its output carries a
  cryptographic guarantee it doesn't have. See `AUDIT-2026-07-16c.md` finding G1.
- **Who is exposed**: Developers who call this helper expecting an unpredictable or
  tamper-evident value for asset metadata; no end-user key or fund is directly at risk.
- **Mitigable by this repo?**: Yes — switch to `RandomNumberGenerator`-backed
  generation, or add an XML-doc caveat that the output has no cryptographic guarantee.
  Trivial, low-priority fix.
- **Current mitigation status**: Mitigated — `GetRandomAssetMetaHash()` now fills the
  32-byte buffer via `System.Security.Cryptography.RandomNumberGenerator.Fill(bts)`
  instead of `System.Random`. Verified: `dotnet build --configuration Release` (0
  errors), `SerialisationTests` (23/23) and `test.csproj` non-LocalNet subset (96/96)
  all still pass.
- **5-year misuse likelihood**: **N/A — this is a functional/API-honesty risk, not a
  key-security risk.** Recorded here per the audit instructions' full-threat-picture
  registry scope, but the percentage framework doesn't apply since no plausible misuse
  path leads to key or fund loss — at worst a developer relies on a weaker-than-expected
  "hash" for a public metadata field.
- **Impact if realized**: No direct impact to key/fund security; at most a predictable
  public asset-metadata value where a developer expected unpredictability.
- **First recorded**: 2026-07-16
- **Last reviewed**: 2026-07-16

## RISK-012 — Canonical transaction encoding depends on an unmaintained, single-maintainer bridge package

- **Description**: `dotnet-algorand-sdk/Utils/Encoder.cs`'s canonical msgpack encode path
  (`EncodeToMsgPackOrdered`/`EncodeToMsgPackNoOrder`, used before every transaction
  signature) and its decode path both go through `Newtonsoft.Msgpack`'s
  `MessagePackWriter`/`MessagePackReader`, not the `MessagePack`-CSharp library. The
  `Newtonsoft.Msgpack` NuGet package (`0.1.11`, pinned in `dotnet-algorand-sdk.csproj`) has
  a single maintainer (`darkl`), 12 releases total, and was last published 2019-08-31 —
  `0.1.11` remains the newest version on nuget.org over 6 years later, and it has no
  strong-named build. See `AUDIT-2026-07-18.md` finding F2.
- **Who is exposed**: All developers depending on `Algorand4` for transaction signing,
  transitively all their end users, if a future vulnerability were ever found in this
  package's encode/decode logic with no maintainer available to patch it.
- **Mitigable by this repo?**: Partially — no immediate action possible (no newer version
  exists), but the repo could eventually replace `Newtonsoft.Msgpack`'s role with
  `MessagePack`-CSharp's own APIs (already a direct dependency) to remove the dependency,
  though this is a non-trivial refactor since the ordered-field-encoding behavior the
  canonical-encoding tests depend on comes from `Newtonsoft.Msgpack`'s
  `JsonSerializer`+`ContractResolver` approach specifically.
- **Current mitigation status**: Unmitigated (no known CVE today; risk is supply-chain
  continuity, not a live exploit)
- **5-year misuse likelihood**: **2%** — no known vulnerability exists in this package
  today; the risk is contingent on one being discovered in a package with no active
  maintainer, which is possible but not the default expected outcome for a narrowly-scoped
  serialization bridge with a small, stable feature surface.
- **Impact if realized**: Depending on the nature of a hypothetical parsing flaw, ranges
  from a denial-of-service (malformed input crash) to, in the worst case, a signing/decoding
  integrity issue affecting consumers who can't upgrade past the vulnerable version.
- **First recorded**: 2026-07-18
- **Last reviewed**: 2026-08-12 — still pinned at 0.1.11, still the newest upstream
  release, no CVE observed; unchanged.

## RISK-013 — Unused Roslyn `using` in a `MessagePack` formatter (dependency itself confirmed legitimate, not bloat)

- **Description**: `dotnet-algorand-sdk/Algod/Model/Converters/MsgPack/NoDefaultsFormatter.cs:5`
  had a stray `using Microsoft.CodeAnalysis.Host;` with no corresponding type usage
  anywhere in that file. This row was originally filed (same day) as a broader claim that
  the main project's unconditional `Microsoft.CodeAnalysis.CSharp`/`.CSharp.Workspaces`/
  `.Workspaces.Common` `PackageReference`s (`4.14.0`) were unnecessary dependency bloat.
  **That broader claim was wrong and is corrected here**: attempting the fix and rebuilding
  showed `ClientGenerator/Compiler/TealSharpSyntaxWalker.cs` and
  `ClientGenerator/Compiler/CompilerStates/*.cs` (which do use Roslyn syntax/symbol types
  extensively) have no `<Compile Remove>` exclusion in `dotnet-algorand-sdk.csproj`, so
  they compile into the main `Algorand4` package via default SDK-style globbing, not only
  into the separate `ClientGenerator/AlgoStudio.csproj` project as originally assumed.
  Removing the three package references produced 819 `CS0246` build errors, confirming they
  are genuinely required. See `AUDIT-2026-07-18.md` finding F1 for the full correction.
- **Who is exposed**: N/A for the dependency itself (legitimate, not exposure). The only
  real issue was the single unused `using` — no exposure once removed.
- **Mitigable by this repo?**: Yes — remove the stray `using` (the `PackageReference`s
  themselves should stay).
- **Current mitigation status**: Mitigated — the stray `using` was removed same day;
  verified via a full `Release` solution build (0 warnings, 0 errors, `Algorand4` package
  builds and packs). The three Roslyn `PackageReference`s were restored/left in place as
  confirmed-necessary.
- **5-year misuse likelihood**: **N/A — this was a dependency-hygiene finding, not a
  misuse-likelihood risk, and the underlying dependencies are legitimate, not bloat.**
- **Impact if realized**: None — no exposure; the corrected understanding is that these
  dependencies are load-bearing for the main package's own code-generation/compilation
  features, not avoidable bloat.
- **First recorded**: 2026-07-18
- **Last reviewed**: 2026-07-18 (corrected and mitigated same day)

## RISK-014 — `Microsoft.Build.Utilities.Core` CVE-2025-55247 in the Unity build-time helper task

- **Description**: `BuildTasks/IlRepackMergeTask/IlRepackMergeTask.csproj` (a build-time-only
  helper, never shipped in either NuGet package — see `AUDIT-2026-07-16d.md`) referenced
  `Microsoft.Build.Utilities.Core` `17.14.8`, within the vulnerable range
  (`>=17.14.0, <=17.14.8`) of `CVE-2025-55247`/`GHSA-w3q9-fxm7-j8fq`. Commit `b912e53`
  bumped it to `17.14.28`, confirmed to be exactly the first patched version for the
  17.14.x branch. See `AUDIT-2026-07-18.md` finding F3.
- **Who is exposed**: Nobody at runtime (build-tooling-only, not distributed in any
  package); at most a developer building the Unity configuration from source with a
  vulnerable cached package.
- **Mitigable by this repo?**: Yes — already done.
- **Current mitigation status**: Mitigated
- **5-year misuse likelihood**: **<1%** — build-tooling-only dependency, never distributed,
  now on a patched version.
- **Impact if realized**: None expected now that this is patched; historically, at most a
  build-environment-local issue, not a distributed-package issue.
- **First recorded**: 2026-07-18
- **Last reviewed**: 2026-07-18

## RISK-015 — `FalconAccount` post-quantum private key is a plain, publicly-gettable, never-cleared `byte[]`

- **Description**: The new Falcon-1024 account class
  (`dotnet-algorand-sdk/Algod/Model/FalconAccount.cs`, added this cycle) holds its
  2305-byte private key and 32-byte mnemonic entropy as ordinary managed arrays for the
  object's whole lifetime, with no `IDisposable`/wiping support — the mitigation
  `Account`/`KeyPair` gained under `RISK-001` was not carried over. `PrivateKey` is a
  public getter returning the *live* internal array (readable and mutable by any code
  handed the account), and each `SignPQRawBytes` call materializes several additional
  uncleared LINQ copies of the key components on the GC heap (plus BouncyCastle's own
  per-signature `FalconPrivateKeyParameters` copies). Same CLR-inherent best-effort
  caveats as `RISK-001`. See `AUDIT-2026-08-12-71d6cfc.md` finding F2.
- **Who is exposed**: End users whose Falcon-1024 keys are held by a long-running
  developer application — notably, PQ keys are chosen precisely for long-lived accounts.
- **Mitigable by this repo?**: Partially — mirror the `RISK-001` remediation:
  `IDisposable` + `Array.Clear` on `PrivateKey`/`entropy`, defensive-copy getters, and
  clearing the transient signing copies. The CLR still gives no strong guarantee all
  copies are scrubbed.
- **Current mitigation status**: Mitigated (best-effort, same day) — `FalconAccount` now
  implements `IDisposable`: `Dispose()` zeroes the private key and mnemonic entropy and
  the account refuses to sign/export afterwards (`ObjectDisposedException`).
  `PublicKey`/`PrivateKey` getters now return defensive copies instead of the live
  internal buffers, the per-signature `f`/`g`/`F` slices are wiped in a `finally` block
  as soon as the signature is produced, and the internally-derived keygen seed is
  cleared after key generation. Residual, per the CLR caveats shared with `RISK-001`:
  BouncyCastle's own per-signature internal copies can't be cleared from here, defensive
  copies handed to callers are the callers' responsibility, and disposal remains opt-in.
  Verified: full Release build (SDK project 0 warnings/0 errors), `PQSignatureTests`
  10/10 including both algokey golden-vector tests, `SerialisationTests` 23/23, and the
  non-LocalNet `test.csproj` subset 107/107.
- **5-year misuse likelihood**: **1%** (down from 2%) — now on par with the mitigated
  classic path (`RISK-001`): wiping is available and the accidental-exposure surface of
  the live-buffer getter is closed; residual risk is a memory-read attacker catching a
  copy before disposal, or a developer never disposing.
- **Impact if realized**: Loss of the specific Falcon key(s) held by the compromised
  process — the account's funds and its authorization role (including accounts rekeyed
  to it).
- **First recorded**: 2026-08-12
- **Last reviewed**: 2026-08-12 (second audit, `AUDIT-2026-08-12-727f7f7.md` finding V2/N1 —
  mitigation re-verified at HEAD; residual caveats extended: `sign_dyn`'s `tmp` working
  buffer holds the secret basis in FFT form and is not cleared, the det-RNG SHAKE256
  state that absorbed the private key is BC-internal and unwipeable from here, and
  `SeedFromEntropy`'s input buffer containing the entropy is not cleared — the first and
  last are SDK-clearable and recommended as a follow-up fix)

## RISK-016 — Falcon keygen depends on BouncyCastle 2.6.2 *internal* APIs via reflection

- **Description**: `FalconAccount.ReferenceKeygen` drives BouncyCastle's non-public
  `SHAKE256`/`FalconKeygen`/`FalconCodec` types by reflection to reproduce algokey's
  deterministic reference keygen bit-for-bit (BC's public generator can't). Lookups
  fail fast with clear exceptions if BC's internals change shape, and BC is pinned at
  2.6.2 — but this couples key *derivation* (and therefore mnemonic-based recovery) to
  unversioned internals of a dependency that `RISK-002` may one day force an urgent
  upgrade of. A shape-compatible internal behavior change could in principle alter
  derivation silently; the golden-vector tests
  (`test/PQSignatureTests.cs` — `AddressDerivationMatchesAlgokey`,
  `MnemonicRecoveryMatchesAlgokey`) are the guardrail that would catch any drift. See
  `AUDIT-2026-08-12-71d6cfc.md` finding F4.
- **Who is exposed**: Developers/users relying on Falcon mnemonic backup-recovery, if a
  future BC upgrade breaks or (worse) silently changes derivation before tests catch it.
  This is a recovery-failure/availability risk, not a key-theft vector.
- **Mitigable by this repo?**: Partially — keep the golden-vector tests as a mandatory
  gate on any BC version bump; document the coupling next to the version pin.
- **Current mitigation status**: Partially mitigated — fail-fast reflection + pinned
  version + golden-vector tests already in the default unit-test pass; as of same-day
  remediation, the csproj now carries a comment on the `BouncyCastle.Cryptography`
  `PackageReference` documenting the coupling and naming the golden-vector tests any
  version bump must keep green. The inherent coupling to BC internals remains (only a
  refactor away from reflection, or an upstream BC public API, would remove it).
- **5-year misuse likelihood**: **N/A — functional/recovery risk, not a security-misuse
  risk.** Recorded per the registry's full-threat-picture scope; the realistic bad
  outcome is a loud keygen failure or a caught test regression, not exploitation.
- **Impact if realized**: Falcon account creation/recovery failure until fixed; in the
  worst (silent-drift, tests-skipped) case, mnemonics that recover to a different key
  pair than the one backed up — loss of access, not theft.
- **First recorded**: 2026-08-12
- **Last reviewed**: 2026-08-12 (second audit, `AUDIT-2026-08-12-727f7f7.md` finding N3 —
  the reflection surface now also covers signing (`FalconSign.sign_dyn`,
  `trim_i8_decode`, `comp_encode`, `complete_private`, `hash_to_point_vartime`), since
  the `RISK-017` fix *depends* on this coupling; the csproj pin comment documenting the
  coupling is verified in place, and the golden-test gate is now 4 named tests including
  `DetSignaturesAreBitCompatibleWithAlgokey` and the 50-account dataset test, all in the
  default unit-test pass)

## RISK-017 — SDK det1024 Falcon signatures were valid but not bit-identical to go-algorand's, enabling a two-preimage key-leak scenario

- **Description**: Discovered 2026-08-12 (after that day's audit was filed, prompted by an
  external security expert's question about deterministic-Falcon implementation
  divergence). Empirical cross-check showed the SDK's `FalconAccount.SignPQRawBytes`
  produced signatures that verified correctly but were **not byte-identical** to
  go-algorand 5.0.0's `algokey pq sign` for the same key, message, and fixed det1024
  salt (e.g. 1225 vs 1232 bytes) — both implementations internally deterministic, but
  divergent. Root cause: BouncyCastle's public signer (`FalconNist.crypto_sign`) draws a
  48-byte seed from its `SecureRandom` and re-hashes it through a fresh SHAKE256 before
  seeding the sampler PRNG, whereas the reference `falcon_sign_dyn_finish` passes the
  det-RNG SHAKE directly to `prng_init` (56 bytes into ChaCha8). The fixed-salt (det1024)
  scheme is only safe **because** signing is deterministic: Algorand's verifier re-adds
  the fixed salt and cannot police sampling, so two different valid signatures over the
  same (key, message) are two distinct GPV preimages of one hash target — their
  difference is a short vector of the secret NTRU lattice, i.e. key-recovery-grade
  leakage. Exploitation required the same key to sign the same message bytes in both a
  go-based tool and this SDK (a realistic mixed-tool scenario given the SDK's advertised
  mnemonic interop with `algokey pq`), with both signatures becoming visible.
- **Who is exposed**: (Before the fix) end users whose Falcon key was used to sign the
  identical message in both this SDK and go-algorand-based tooling; single-implementation
  users were not exposed.
- **Mitigable by this repo?**: Yes — make signing bit-identical to the reference det1024.
- **Current mitigation status**: Mitigated (same day, TDD) — `SignPQRawBytes` now
  replicates `falcon_det1024_sign_compressed` exactly by driving BouncyCastle's
  *internal*, faithfully-ported `FalconSign.sign_dyn` with the det-RNG SHAKE itself
  (`FalconAccount.DetSignCompressed`), bypassing the divergent public wrapper. Verified
  test-first: golden vectors (3 transactions signed by `algokey pq sign` 5.0.0, commit
  `da5946a1`, stored in `test/TestData/algokey-pq-signed-*.stxn`) were pinned in
  `PQSignatureTests.DetSignaturesAreBitCompatibleWithAlgokey` and confirmed failing
  against the old implementation, then passing after the fix — including full
  signed-transaction encoding equality, not just the sig field. Full suites re-verified:
  SDK builds 0 warnings/0 errors, PQ fixture green, non-LocalNet unit tests 109/109,
  `SerialisationTests` 23/23. The logicsig delegation path (`LogicsigSignature.SignPQ`)
  routes through the same fixed method. Note: pre-fix SDK versions remain divergent —
  consumers should upgrade before using Falcon keys across multiple tools.
- **5-year misuse likelihood**: **2%** — post-fix, exploitation requires a consumer
  stuck on a pre-fix version *and* dual-tool signing of identical messages *and* an
  attacker collecting both signatures; scored above <1% only because pre-fix packages
  remain downloadable and the Falcon feature is newly promoted.
- **Impact if realized**: Recovery of the affected Falcon private key (full compromise
  of that account and anything rekeyed to it).
- **First recorded**: 2026-08-12
- **Last reviewed**: 2026-08-12 (second audit, `AUDIT-2026-08-12-727f7f7.md` finding V1 —
  the fix was independently re-verified at HEAD: `DetSignCompressed` traced line-by-line
  against the reference det1024 flow, and the golden-vector suite executed, 12/12
  passing including full signed-transaction byte-equality against `algokey pq sign`)

## RISK-018 — Working Falcon-1024 mnemonics/private keys are committed publicly as test vectors

- **Description**: `test/TestData/algokey-pq-accounts.json` commits 50 complete, working
  Falcon-1024 mnemonics with their raw private/public keys, and `test/PQSignatureTests.cs`
  carries one golden mnemonic inline — all generated by `algokey pq generate` purely as
  interop golden vectors (pinning mnemonic→key→address derivation bit-for-bit against
  go-algorand). This is standard, legitimate golden-vector practice; the keys have no
  funds and no on-chain existence. The residual risk is purely human: the addresses are
  publicly known, so anything ever sent to them is sweepable by anyone, and a developer
  copy-pasting a "working mnemonic" from test data into a prototype builds on a burned
  key. Bounded variant of `RISK-005`. See `AUDIT-2026-08-12-727f7f7.md` finding N2.
- **Who is exposed**: Anyone who funds or reuses one of the committed keys — no exposure
  exists unless someone actively does so.
- **Mitigable by this repo?**: Partially — a "publicly known test keys, never fund"
  comment in the JSON/fixture; the vectors themselves must stay (they are the security
  guardrail for `RISK-016`/`RISK-017`).
- **Current mitigation status**: Unmitigated (comment not yet added; risk inherent to
  golden-vector testing and accepted)
- **5-year misuse likelihood**: **<1%** — requires someone to deliberately or mistakenly
  fund/reuse a key that is visibly test data inside a test directory; no incident pattern
  in comparable SDKs' golden-vector files.
- **Impact if realized**: Loss only of whatever was mistakenly sent to a burned test
  address — no impact on any legitimately generated key.
- **First recorded**: 2026-08-12
- **Last reviewed**: 2026-08-12
