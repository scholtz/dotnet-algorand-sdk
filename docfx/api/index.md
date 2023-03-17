# Algorand .NET SDK


Welcome to the .NET SDK technical reference.

The complete SDK technical documentation catalogue is available in the sidebar.

## SDK Examples

The .NET SDK for Algorand includes a number of [usage examples](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/tree/master/sdk-examples).

All of them can be run by **changing the startup object** in the csproj file.

They all assume you have the sandbox installed.

### Account Example
[Account Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/AccountExample.cs)

This shows how to query Algod for information on a particular Account.

### Asset Example
[Asset Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/AssetExample.cs)

A number of operations using Algorand Standard Assets.

### Atomic Transfer Example
[Atomic Transfer Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/AtomicTransferExample.cs)

An example of two transactions grouped into an atomic transaction.


### Basic Example
[Basic Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/BasicExample.cs)

A simple payment transaction and example of SDK usage.

### Compile Teal
[Compile Teal](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/CompileTeal.cs)

How to use a local or development Algod instance to compile a TEAL program.

### Dryrun Debugging
[Dryrun Debugging](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/DryrunDebuggingExample.cs)

How to currently dry-run execute logic on a transaction.

### Indexer Example
[Indexer](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/IndexerExample.cs)

Indexer usage, though in future the .NET SDK will encourage the use of Conduit and other approaches.

### KMD Example
[KMD Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/KMDExample.cs)

KMD key management via the Algod endpoints. 

### Logic Signature as Contract Example
[Logic Signature as Contract Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/LogicSignatureContractAccountExample.cs)

How to use logic signatures as smart contracts.

### Logic Signature Example
[Logic Signature Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/LogicSignatureExample.cs)

A basic logic signature example, where the logic signature is used for delegated access to an Account.

### Multisig Example
[Multisig Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/MultisigExample.cs)

How to work with multisignatures.

### Rekey Example
[Rekey Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/RekeyExample.cs)

Changing the signing keys of an Account.

### Stateful Contract Example
[Stateful Contract Example](https://github.com/FrankSzendzielarz/dotnet-algorand-sdk/blob/master/sdk-examples/StatefulContractExample.cs)

Smart Contracts, their creation, opt-in and other operations.

