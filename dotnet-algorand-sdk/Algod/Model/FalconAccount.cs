using Org.BouncyCastle.Pqc.Crypto.Falcon;
using Org.BouncyCastle.Security;
using System;

namespace Algorand.Algod.Model
{
    /// <summary>
    /// A post-quantum Falcon-1024 account ("f1" scheme, algod 5.0.0 / consensus v42).
    ///
    /// The account's address is derived from its Falcon-1024 public key together with the canonical
    /// 1-byte salt (the lowest salt whose derived address is not an Edwards25519 curve point - the
    /// node rejects non-compliant PQ authorizer addresses at admission). Signatures follow the
    /// deterministic Falcon profile's wire format ("unsalted" compressed format: 0xBA header,
    /// salt-version byte, compressed s2) and verify under go-algorand's falcon_det1024 verifier.
    ///
    /// Key material uses the same raw layout as go-algorand / `algokey pq`: a 1793-byte public key
    /// (0x0A header + modq-encoded h) and a 2305-byte private key (0x5A header + f || g || F), so
    /// keys generated elsewhere can be imported directly.
    ///
    /// Backup/recovery follows the algokey standard: a classic 25-word Algorand mnemonic encodes
    /// 32 bytes of entropy; the Falcon keygen seed is SHA-512/256("PQK" || "f1" || entropy) and the
    /// key pair is regenerated with the deterministic reference keygen. Accounts created with
    /// FromMnemonic / FromEntropy / the default constructor are therefore fully interoperable with
    /// `algokey pq import -m "..."` and any other SDK implementing the same derivation.
    ///
    /// Note: a transaction authorized by a Falcon-1024 pqsig owes an additional 2x the network min
    /// fee on top of the base fee (3x min fee in total for an otherwise plain transaction).
    /// </summary>
    public class FalconAccount : IDisposable
    {
        /// <summary>Size in bytes of a Falcon-1024 public key, including the 0x0A header byte.</summary>
        public const int PublicKeySize = 1793;
        /// <summary>Size in bytes of a Falcon-1024 private key, including the 0x5A header byte.</summary>
        public const int PrivateKeySize = 2305;
        /// <summary>Size in bytes of a keygen seed.</summary>
        public const int SeedSize = 32;

        private const byte PublicKeyHeader = 0x0A;  // 0x00 + logn(10)
        private const byte PrivateKeyHeader = 0x5A; // 0x50 + logn(10)
        private const int FLen = 640;               // trim_i8(f), 5 bits/coeff * 1024 / 8
        private const int GLen = 640;               // trim_i8(g)
        private const int BigFLen = 1024;           // trim_i8(F), 8 bits/coeff * 1024 / 8

        private readonly byte[] publicKey;
        private readonly byte[] privateKey;
        private bool disposed;

        /// <summary>The full 1793-byte Falcon-1024 public key (0x0A header + h). Returns a
        /// defensive copy on every access.</summary>
        public byte[] PublicKey => (byte[])publicKey.Clone();

        /// <summary>The full 2305-byte Falcon-1024 private key (0x5A header + f || g || F).
        /// Returns a defensive copy on every access - clear it after use, and see
        /// <see cref="Dispose"/> for wiping the account's own copy.</summary>
        public byte[] PrivateKey
        {
            get
            {
                ThrowIfDisposed();
                return (byte[])privateKey.Clone();
            }
        }

        /// <summary>The canonical address salt for this public key.</summary>
        public byte Salt { get; }

        /// <summary>The post-quantum account address.</summary>
        public Address Address { get; }

        private readonly byte[] entropy; // 25-word mnemonic entropy; null for raw/seed imports

        /// <summary>
        /// Creates a new Falcon-1024 account from fresh random mnemonic entropy. Back it up with
        /// <see cref="ToMnemonic"/>.
        /// </summary>
        public FalconAccount() : this(RandomSeed(), asEntropy: true) { }

        /// <summary>
        /// Creates a Falcon-1024 account deterministically from a 32-byte keygen seed, exactly like
        /// go-algorand's crypto.GenerateFalconSigner(seed): the deterministic reference keygen is
        /// driven by SHAKE256(seed). For mnemonic-level interop with `algokey pq`, prefer
        /// <see cref="FromMnemonic"/> / <see cref="FromEntropy"/>, which add the standard
        /// SHA-512/256("PQK" || "f1" || entropy) seed derivation on top.
        /// </summary>
        public FalconAccount(byte[] seed) : this(seed, asEntropy: false) { }

        private FalconAccount(byte[] seedOrEntropy, bool asEntropy)
        {
            if (seedOrEntropy == null || seedOrEntropy.Length != SeedSize)
                throw new ArgumentException($"seed must be {SeedSize} bytes", nameof(seedOrEntropy));

            byte[] seed;
            if (asEntropy)
            {
                entropy = (byte[])seedOrEntropy.Clone();
                seed = SeedFromEntropy(entropy);
            }
            else
            {
                entropy = null;
                seed = seedOrEntropy;
            }

            var (pk, sk) = ReferenceKeygen(seed);
            if (asEntropy)
                Array.Clear(seed, 0, seed.Length); // this copy was derived here; the entropy field is the backup
            publicKey = pk;
            privateKey = sk;
            Salt = PQSignature.FindCanonicalSalt(PQSignature.SchemeFalcon1024, publicKey, out var address);
            Address = address;
        }

        /// <summary>
        /// Recovers a Falcon-1024 account from a classic 25-word Algorand mnemonic, following the
        /// algokey standard: mnemonic -> 32-byte entropy -> keygen seed
        /// SHA-512/256("PQK" || "f1" || entropy) -> deterministic reference keygen. Mnemonics
        /// produced by `algokey pq generate` (and other SDKs implementing this derivation) recover
        /// the identical key pair and address here, and vice versa.
        /// </summary>
        public static FalconAccount FromMnemonic(string mnemonic)
        {
            return FromEntropy(Utils.Mnemonic.ToKey(mnemonic));
        }

        /// <summary>
        /// Derives a Falcon-1024 account from 32 bytes of mnemonic entropy using the standard
        /// SHA-512/256("PQK" || "f1" || entropy) keygen-seed derivation.
        /// </summary>
        public static FalconAccount FromEntropy(byte[] entropy)
        {
            if (entropy == null || entropy.Length != SeedSize)
                throw new ArgumentException($"entropy must be {SeedSize} bytes", nameof(entropy));
            return new FalconAccount(entropy, asEntropy: true);
        }

        /// <summary>
        /// Returns the 25-word mnemonic backing this account (algokey-compatible). Only available
        /// for accounts created from entropy (FromMnemonic / FromEntropy / the default
        /// constructor); accounts imported from a raw key pair or keygen seed carry no entropy.
        /// Never print or log the result - persist it via a secure channel only.
        /// </summary>
        public string ToMnemonic()
        {
            ThrowIfDisposed();
            if (entropy == null)
                throw new InvalidOperationException(
                    "this account was imported from raw keys or a keygen seed, so no mnemonic entropy is available");
            return Utils.Mnemonic.FromKey(entropy);
        }

        /// <summary>
        /// Maps mnemonic entropy to the Falcon-1024 keygen seed the way algokey does:
        /// SHA-512/256("PQK" || scheme "f1" || entropy).
        /// </summary>
        private static byte[] SeedFromEntropy(byte[] entropy)
        {
            var prefix = System.Text.Encoding.UTF8.GetBytes("PQK");
            var input = new byte[prefix.Length + 2 + entropy.Length];
            Array.Copy(prefix, 0, input, 0, prefix.Length);
            Array.Copy(PQSignature.SchemeFalcon1024, 0, input, prefix.Length, 2);
            Array.Copy(entropy, 0, input, prefix.Length + 2, entropy.Length);
            return Utils.Digester.Digest(input);
        }

        /// <summary>
        /// Imports an existing Falcon-1024 key pair in go-algorand / algokey raw layout
        /// (1793-byte public key with 0x0A header, 2305-byte private key with 0x5A header).
        /// </summary>
        public FalconAccount(byte[] publicKey, byte[] privateKey)
        {
            if (publicKey == null || publicKey.Length != PublicKeySize || publicKey[0] != PublicKeyHeader)
                throw new ArgumentException($"public key must be {PublicKeySize} bytes with 0x0A header", nameof(publicKey));
            if (privateKey == null || privateKey.Length != PrivateKeySize || privateKey[0] != PrivateKeyHeader)
                throw new ArgumentException($"private key must be {PrivateKeySize} bytes with 0x5A header", nameof(privateKey));

            this.publicKey = (byte[])publicKey.Clone();
            this.privateKey = (byte[])privateKey.Clone();
            Salt = PQSignature.FindCanonicalSalt(PQSignature.SchemeFalcon1024, this.publicKey, out var address);
            Address = address;
        }

        /// <summary>
        /// Signs raw message bytes (already carrying their domain-separation prefix, e.g.
        /// Transaction.BytesToSign()) and returns the complete "pqsig" authorization proof.
        /// </summary>
        public PQSignature SignPQRawBytes(byte[] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            ThrowIfDisposed();

            var compressed = DetSignCompressed(data);
            var sig = new byte[2 + compressed.Length];
            sig[0] = PQSignature.UnsaltedHeader;
            sig[1] = PQSignature.DefaultSaltVersion;
            Array.Copy(compressed, 0, sig, 2, compressed.Length);

            return new PQSignature
            {
                Scheme = PQSignature.SchemeFalcon1024,
                Salt = Salt,
                PublicKey = (byte[])publicKey.Clone(),
                Signature = sig,
            };
        }

        /// <summary>
        /// Reference-exact falcon_det1024_sign_compressed (go-algorand's algorand/falcon
        /// deterministic.c + falcon_sign_dyn_finish), producing the compressed s2 bytes. Signatures
        /// must be BIT-IDENTICAL to every other det1024 implementation, not merely valid: the
        /// verifier re-adds the fixed salt and cannot police deterministic sampling, so two
        /// implementations emitting different valid signatures for the same (key, message) would
        /// publish two distinct GPV preimages of one hash target - their difference is a short
        /// vector of the secret NTRU lattice (key-recovery-grade leakage). BouncyCastle's public
        /// FalconSigner cannot be used here: FalconNist.crypto_sign draws a 48-byte seed from its
        /// SecureRandom and re-hashes it through a fresh SHAKE256 before seeding the sampler PRNG,
        /// whereas the reference passes the det-RNG SHAKE directly to prng_init (which extracts
        /// 56 bytes into ChaCha8) - so its output diverges from det1024 even when fed the det RNG
        /// stream. Instead this drives BC's internal, faithfully-ported sign_dyn with the det-RNG
        /// SHAKE itself. Pinned bit-for-bit against `algokey pq sign` by the golden vectors in
        /// test/PQSignatureTests.DetSignaturesAreBitCompatibleWithAlgokey.
        /// </summary>
        private byte[] DetSignCompressed(byte[] data)
        {
            const uint logn = 10;
            const int n = 1 << 10;
            var r = FalconReflection.Instance;

            // detrng = SHAKE256(logn || privkey || data), flipped to output mode.
            object detrng = Activator.CreateInstance(r.Shake256Type, nonPublic: true);
            r.ShakeInit.Invoke(detrng, null);
            r.ShakeInject.Invoke(detrng, new object[] { new byte[] { (byte)logn }, 0, 1 });
            r.ShakeInject.Invoke(detrng, new object[] { privateKey, 0, privateKey.Length });
            r.ShakeInject.Invoke(detrng, new object[] { data, 0, data.Length });
            r.ShakeFlip.Invoke(detrng, null);

            // hm = hash_to_point_vartime(SHAKE256(fixed salt || data)).
            var salt = PQSignature.MakeSalt(PQSignature.DefaultSaltVersion);
            object hd = Activator.CreateInstance(r.Shake256Type, nonPublic: true);
            r.ShakeInit.Invoke(hd, null);
            r.ShakeInject.Invoke(hd, new object[] { salt, 0, salt.Length });
            r.ShakeInject.Invoke(hd, new object[] { data, 0, data.Length });
            r.ShakeFlip.Invoke(hd, null);
            var hm = new ushort[n];
            r.HashToPointVartime.Invoke(r.CommonInstance, new object[] { hd, hm, 0, logn });

            // Decode f || g || F from the private key and complete the basis with G.
            var f = new sbyte[n];
            var g = new sbyte[n];
            var F = new sbyte[n];
            var G = new sbyte[n];
            try
            {
                int u = 1;
                u += InvokeDecode(r.TrimI8Decode, r.CodecInstance, f, logn, r.MaxFgBits, privateKey, u, "f");
                u += InvokeDecode(r.TrimI8Decode, r.CodecInstance, g, logn, r.MaxFgBits, privateKey, u, "g");
                u += InvokeDecode(r.TrimI8Decode, r.CodecInstance, F, logn, r.MaxFGBits, privateKey, u, "F");
                if (u != PrivateKeySize)
                    throw new InvalidOperationException($"falcon private key decoding consumed {u} bytes, want {PrivateKeySize}");
                if ((int)r.CompletePrivate.Invoke(r.VrfyInstance,
                        new object[] { G, 0, f, 0, g, 0, F, 0, logn, new ushort[2 * n], 0 }) == 0)
                    throw new InvalidOperationException("falcon private key completion (G) failed");

                // sign_dyn samples s2, seeding its inner ChaCha8 PRNG from detrng per attempt,
                // exactly like the reference do_sign_dyn loop.
                var s2 = new short[n];
                var tmp = Array.CreateInstance(r.FprType, 10 * n);
                r.SignDyn.Invoke(r.SignInstance,
                    new object[] { s2, 0, detrng, f, 0, g, 0, F, 0, G, 0, hm, 0, logn, tmp, 0 });

                // Compressed encoding of s2 (variable length).
                var esig = new byte[1409]; // FALCON_SIG_COMPRESSED_MAXSIZE(10) minus header/salt
                int v = (int)r.CompEncode.Invoke(r.CodecInstance, new object[] { esig, 0, esig.Length, s2, 0, logn });
                if (v == 0)
                    throw new InvalidOperationException("falcon signature compression failed");
                var outSig = new byte[v];
                Array.Copy(esig, 0, outSig, 0, v);
                return outSig;
            }
            finally
            {
                Array.Clear(f, 0, f.Length);
                Array.Clear(g, 0, g.Length);
                Array.Clear(F, 0, F.Length);
                Array.Clear(G, 0, G.Length);
            }
        }

        private static int InvokeDecode(System.Reflection.MethodInfo trim, object codec, sbyte[] dst, uint logn, uint bits, byte[] src, int off, string what)
        {
            int len = (int)trim.Invoke(codec, new object[] { dst, 0, logn, bits, src, off, src.Length - off });
            if (len == 0) throw new InvalidOperationException($"falcon {what} decoding failed");
            return len;
        }

        /// <summary>
        /// Best-effort wipe of the key material held by this instance: zeroes the private key
        /// and the mnemonic entropy. Like <see cref="Crypto.KeyPair.Dispose"/>, this cannot
        /// guarantee no copy remains elsewhere in process memory (GC compaction history,
        /// BouncyCastle's own per-signature copies, defensive copies handed out by
        /// <see cref="PrivateKey"/>), but it removes the copies this instance keeps live
        /// references to. The account cannot sign or export after disposal.
        /// </summary>
        public void Dispose()
        {
            Array.Clear(privateKey, 0, privateKey.Length);
            if (entropy != null)
                Array.Clear(entropy, 0, entropy.Length);
            disposed = true;
        }

        private void ThrowIfDisposed()
        {
            if (disposed)
                throw new ObjectDisposedException(nameof(FalconAccount));
        }

        private static byte[] RandomSeed()
        {
            var seed = new byte[SeedSize];
            new SecureRandom().NextBytes(seed);
            return seed;
        }

        // BouncyCastle's public FalconKeyPairGenerator always draws a 48-byte seed from its
        // SecureRandom and injects those 48 bytes into the keygen SHAKE256, whereas the reference
        // implementation (and go-algorand's cfalcon.GenerateKey) injects the caller's seed bytes
        // directly. To derive keys byte-identical to algokey's, drive BC's internal keygen (a
        // faithful port of the reference falcon_keygen_make) with a SHAKE256 seeded the reference
        // way, via reflection. BouncyCastle.Cryptography is pinned to 2.6.2 in the csproj; the
        // KeygenReflection cache fails fast at first use if these internals ever change shape.
        private static (byte[] pk, byte[] sk) ReferenceKeygen(byte[] seed)
        {
            const uint logn = 10;
            const int n = 1 << 10;
            var r = FalconReflection.Instance;

            object shake = Activator.CreateInstance(r.Shake256Type, nonPublic: true);
            r.ShakeInit.Invoke(shake, null);
            r.ShakeInject.Invoke(shake, new object[] { seed, 0, seed.Length });
            r.ShakeFlip.Invoke(shake, null);

            var f = new sbyte[n];
            var g = new sbyte[n];
            var F = new sbyte[n];
            var h = new ushort[n];
            r.Keygen.Invoke(r.KeygenInstance, new object[] { shake, f, 0, g, 0, F, 0, null, 0, h, 0, logn });

            var sk = new byte[PrivateKeySize];
            sk[0] = PrivateKeyHeader;
            int u = 1;
            u += InvokeEncode(r.TrimI8Encode, r.CodecInstance, sk, u, PrivateKeySize - u, f, logn, r.MaxFgBits, "f");
            u += InvokeEncode(r.TrimI8Encode, r.CodecInstance, sk, u, PrivateKeySize - u, g, logn, r.MaxFgBits, "g");
            u += InvokeEncode(r.TrimI8Encode, r.CodecInstance, sk, u, PrivateKeySize - u, F, logn, r.MaxFGBits, "F");
            if (u != PrivateKeySize)
                throw new InvalidOperationException($"falcon private key encoding produced {u} bytes, want {PrivateKeySize}");

            var pk = new byte[PublicKeySize];
            pk[0] = PublicKeyHeader;
            int v = (int)r.ModqEncode.Invoke(r.CodecInstance, new object[] { pk, 1, PublicKeySize - 1, h, 0, logn });
            if (v != PublicKeySize - 1)
                throw new InvalidOperationException($"falcon public key encoding produced {v} bytes, want {PublicKeySize - 1}");

            return (pk, sk);
        }

        private static int InvokeEncode(System.Reflection.MethodInfo trim, object codec, byte[] dst, int off, int max, sbyte[] src, uint logn, uint bits, string what)
        {
            int len = (int)trim.Invoke(codec, new object[] { dst, off, max, src, 0, logn, bits });
            if (len == 0) throw new InvalidOperationException($"falcon {what} encoding failed");
            return len;
        }

        private sealed class FalconReflection
        {
            internal static readonly FalconReflection Instance = new FalconReflection();

            internal readonly Type Shake256Type, FprType;
            internal readonly System.Reflection.MethodInfo ShakeInit, ShakeInject, ShakeFlip;
            internal readonly System.Reflection.MethodInfo Keygen, TrimI8Encode, ModqEncode;
            internal readonly System.Reflection.MethodInfo TrimI8Decode, CompEncode, CompletePrivate, HashToPointVartime, SignDyn;
            internal readonly object KeygenInstance, CodecInstance, CommonInstance, VrfyInstance, SignInstance;
            internal readonly uint MaxFgBits, MaxFGBits;

            private FalconReflection()
            {
                const System.Reflection.BindingFlags flags =
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public;
                var asm = typeof(FalconParameters).Assembly;
                const string ns = "Org.BouncyCastle.Pqc.Crypto.Falcon.";

                Shake256Type = RequireType(asm, ns + "SHAKE256");
                FprType = RequireType(asm, ns + "FalconFPR");
                var codecType = RequireType(asm, ns + "FalconCodec");
                var commonType = RequireType(asm, ns + "FalconCommon");
                var vrfyType = RequireType(asm, ns + "FalconVrfy");
                var keygenType = RequireType(asm, ns + "FalconKeygen");
                var signType = RequireType(asm, ns + "FalconSign");

                ShakeInit = Require(Shake256Type.GetMethod("i_shake256_init", flags), "SHAKE256.i_shake256_init");
                ShakeInject = Require(Shake256Type.GetMethod("i_shake256_inject", flags), "SHAKE256.i_shake256_inject");
                ShakeFlip = Require(Shake256Type.GetMethod("i_shake256_flip", flags), "SHAKE256.i_shake256_flip");

                CodecInstance = Activator.CreateInstance(codecType, nonPublic: true);
                CommonInstance = Activator.CreateInstance(commonType, nonPublic: true);
                VrfyInstance = Activator.CreateInstance(vrfyType, flags, null, new[] { CommonInstance }, null);
                KeygenInstance = Activator.CreateInstance(keygenType, flags, null, new[] { CodecInstance, VrfyInstance }, null);
                SignInstance = Activator.CreateInstance(signType, flags, null, new[] { CommonInstance }, null);

                Keygen = Require(keygenType.GetMethod("keygen", flags), "FalconKeygen.keygen");
                TrimI8Encode = Require(codecType.GetMethod("trim_i8_encode", flags), "FalconCodec.trim_i8_encode");
                ModqEncode = Require(codecType.GetMethod("modq_encode", flags), "FalconCodec.modq_encode");
                TrimI8Decode = Require(codecType.GetMethod("trim_i8_decode", flags), "FalconCodec.trim_i8_decode");
                CompEncode = Require(codecType.GetMethod("comp_encode", flags), "FalconCodec.comp_encode");
                CompletePrivate = Require(vrfyType.GetMethod("complete_private", flags), "FalconVrfy.complete_private");
                HashToPointVartime = Require(commonType.GetMethod("hash_to_point_vartime", flags), "FalconCommon.hash_to_point_vartime");
                SignDyn = Require(signType.GetMethod("sign_dyn", flags), "FalconSign.sign_dyn");

                var fgField = Require(codecType.GetField("max_fg_bits", flags), "FalconCodec.max_fg_bits");
                var fGField = Require(codecType.GetField("max_FG_bits", flags), "FalconCodec.max_FG_bits");
                MaxFgBits = ((byte[])fgField.GetValue(CodecInstance))[10];
                MaxFGBits = ((byte[])fGField.GetValue(CodecInstance))[10];
            }

            private static Type RequireType(System.Reflection.Assembly asm, string name)
                => asm.GetType(name) ?? throw new NotSupportedException($"BouncyCastle internal type {name} not found; the pinned BouncyCastle.Cryptography version may have changed");

            private static T Require<T>(T member, string name) where T : class
                => member ?? throw new NotSupportedException($"BouncyCastle internal member {name} not found; the pinned BouncyCastle.Cryptography version may have changed");
        }

    }
}
