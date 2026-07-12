---
description: Run the main unit and serialisation test suites, or a filtered subset
argument-hint: [optional dotnet test --filter expression]
---

Run:

```powershell
dotnet test test/test.csproj $ARGUMENTS
dotnet test SerialisationTests/serialisation-tests.csproj $ARGUMENTS
```

(gossip-client-tests and specflow/algorand_tests are excluded by default — they require live network/node access. Ask before running those.)

Report failures grouped by fixture, with the assertion message. Do not modify code unless asked.
