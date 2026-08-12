# API Reference

Welcome to the Algorand .NET SDK technical reference. The complete class-library catalogue is available in the sidebar.

## Key entry points

- `Algorand.Algod.AlgodClient` — the primary Algod API client. Submit transactions with the `SubmitTransaction` / `SubmitTransactions` extension methods and await confirmation with `WaitTransactionToComplete`.
- `Algorand.Algod.Model.Account` — ed25519 accounts: create, restore from a 25-word mnemonic, and sign transactions.
- `Algorand.Algod.Model.FalconAccount` — post-quantum Falcon-1024 accounts (algod 5.0.0+): mnemonic backup/recovery interoperable with `algokey pq`, and `pqsig` transaction signing.
- `Algorand.Algod.Model.Transactions` — strongly typed transaction builders (`PaymentTransaction`, `AssetCreateTransaction`, `ApplicationCallTransaction`, ...), each with static factory helpers.
- `Algorand.Indexer` — historical queries over blocks, transactions, accounts, assets, and applications.
- `Algorand.KMD.Api` — wallet and key management via a node's KMD service.
- `AVM.ClientGenerator` — the ARC4/ARC56 smart-contract client generator producing fully typed C# proxies.

## Runnable examples

Complete, runnable examples live in the [`sdk-examples/`](https://github.com/scholtz/dotnet-algorand-sdk/tree/master/sdk-examples) project — payments, assets, atomic transfers, multisig, logic signatures, smart contracts, key registration, rekeying, post-quantum accounts, and more. Each example is selectable via the dispatcher:

```bash
dotnet run --project sdk-examples -- BasicExample
```

Most examples assume an [AlgoKit LocalNet](https://dev.algorand.co/algokit/algokit-intro/) running locally (`algokit localnet start`).
