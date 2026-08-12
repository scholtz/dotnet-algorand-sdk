# Algorand .NET SDK

A comprehensive .NET SDK (`netstandard2.1`) for the [Algorand](https://www.algorand.co/) blockchain and AVM-compatible networks (Voi, Aramid): build, sign, and submit transactions, query the chain via Algod and Indexer, manage keys with KMD, connect to the gossip network, and generate fully typed C# clients from ARC56 smart-contract specs. Includes a dedicated Unity build and post-quantum Falcon-1024 account support.

## Get started

Install the [`Algorand5`](https://www.nuget.org/packages/Algorand5/) package from NuGet:

```powershell
dotnet add package Algorand5
```

Connect and submit a transaction:

```cs
using var httpClient = HttpClientConfigurator.ConfigureHttpClient(AlgodConfiguration.MainNet);
var algod = new AlgodClient(httpClient);

var transParams = await algod.TransactionParamsAsync();
var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
    sender.Address, receiver, amount, "note", transParams);

var submit = await algod.SubmitTransaction(tx.Sign(sender));
var result = await algod.WaitTransactionToComplete(submit.Txid);
```

## Explore

- [API Documentation](api/index.md) — the full class library reference.
- [Runnable examples](https://github.com/scholtz/dotnet-algorand-sdk/tree/master/sdk-examples) — payments, assets, smart contracts, atomic transfers, post-quantum accounts, and more.
- [README](https://github.com/scholtz/dotnet-algorand-sdk#readme) — features, quick start, and building from source.
