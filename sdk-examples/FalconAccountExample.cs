using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using System;
using System.Threading.Tasks;

namespace sdk_examples
{
    /// <summary>
    /// Demonstrates post-quantum Falcon-1024 account signatures ("pqsig"), introduced with
    /// algod 5.0.0 / consensus v42.
    ///
    /// Covered here:
    ///   1. Creating a Falcon-1024 account (random, or deterministically from a seed).
    ///   2. The post-quantum address: derived from the Falcon public key + a canonical salt,
    ///      chosen so the address can never be mistaken for an Edwards25519 public key.
    ///   3. Funding the PQ address with a normal payment.
    ///   4. Spending from the PQ account with a pqsig-authorized transaction. IMPORTANT: a
    ///      Falcon-1024 pqsig owes an extra 2x min fee, so a plain payment needs >= 3x min fee.
    ///   5. Rekeying a classic ed25519 account to a post-quantum authorizer, then spending from
    ///      it with the Falcon key - the migration path for existing accounts.
    ///
    /// Requires an AlgoKit LocalNet running algod 5.0.0+ (`algokit localnet start`, and
    /// `algokit localnet reset` after pulling a new algorand/algod:latest image).
    /// </summary>
    public class FalconAccountExample
    {
        public static async Task Main(string[] args)
        {
            var ALGOD_API_ADDR = Environment.GetEnvironmentVariable("ALGOD_API_ADDR") ?? "http://localhost:4001/";
            var ALGOD_API_TOKEN = Environment.GetEnvironmentVariable("ALGOD_API_TOKEN") ?? "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            var algod = new AlgodClient(httpClient);

            // A funded classic account to dispense from, exported from LocalNet's KMD
            // (the genesis accounts live in the "unencrypted-default-wallet").
            var funder = await GetFundedKmdAccount();

            // 1. Create a post-quantum account. `new FalconAccount()` uses a fresh random seed;
            //    passing a 32-byte seed makes key generation deterministic (SDK-specific
            //    derivation). Keys in go-algorand / `algokey pq` raw layout can be imported with
            //    new FalconAccount(publicKey, privateKey).
            var falcon = new FalconAccount();
            Console.WriteLine($"Falcon-1024 PQ address: {falcon.Address}");
            Console.WriteLine($"Canonical address salt: {falcon.Salt}");
            Console.WriteLine($"Public key: {falcon.PublicKey.Length} bytes, private key: {falcon.PrivateKey.Length} bytes");

            // 2. The PQ address is SHA-512/256("PQA" || "f1" || salt || publicKey) where the salt
            //    is the lowest value making the address NOT decode as an Edwards25519 point - the
            //    node rejects PQ authorizers whose address looks like an ed25519 key.
            Console.WriteLine($"Address is PQ compliant: {!PQSignature.IsEdwards25519Point(falcon.Address.Bytes)}");

            // 3. Fund the PQ address - from the network's perspective it's a normal address.
            var transParams = await algod.TransactionParamsAsync();
            var fundTx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
                funder.Address, falcon.Address, 2_000_000, "fund PQ account", transParams);
            var fundSigned = fundTx.Sign(funder);
            var fundSubmit = await algod.SubmitTransaction(fundSigned);
            await algod.WaitTransactionToComplete(fundSubmit.Txid);
            Console.WriteLine($"Funded {falcon.Address} with 2 Algos (tx {fundSubmit.Txid})");

            // 4. Spend from the PQ account. The Falcon-1024 signature contributes an extra 2x the
            //    network min fee on top of the base 1x, so set a flat fee of at least 3x min fee.
            transParams = await algod.TransactionParamsAsync();
            var minFee = transParams.MinFee == 0 ? 1000 : transParams.MinFee;
            var payTx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
                falcon.Address, funder.Address, 500_000, "post-quantum payment", transParams);
            payTx.Fee = minFee * (1 + PQSignature.Falcon1024FeeContributionFactor); // 3x min fee

            var paySigned = payTx.SignPQ(falcon);
            Console.WriteLine($"pqsig size: {paySigned.PQSig.Signature.Length} bytes (Falcon-1024 compressed)");
            Console.WriteLine($"pqsig verifies locally: {paySigned.PQSig.Verify(payTx.BytesToSign())}");

            var paySubmit = await algod.SubmitTransaction(paySigned);
            var payResult = await algod.WaitTransactionToComplete(paySubmit.Txid);
            Console.WriteLine($"PQ payment confirmed in round {payResult.ConfirmedRound} (tx {paySubmit.Txid})");

            // 5. Migration path: rekey an existing ed25519 account to the PQ address. After the
            //    rekey, transactions from that account are signed by the Falcon key (SignPQ sets
            //    AuthAddr automatically when the sender differs from the PQ address).
            var classic = new Account();
            transParams = await algod.TransactionParamsAsync();
            var seedClassicTx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
                funder.Address, classic.Address, 1_000_000, "seed classic account", transParams);
            var seedSubmit = await algod.SubmitTransaction(seedClassicTx.Sign(funder));
            await algod.WaitTransactionToComplete(seedSubmit.Txid);

            transParams = await algod.TransactionParamsAsync();
            var rekeyTx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
                classic.Address, classic.Address, 0, "rekey to PQ authorizer", transParams);
            rekeyTx.RekeyTo = falcon.Address;
            var rekeySubmit = await algod.SubmitTransaction(rekeyTx.Sign(classic));
            await algod.WaitTransactionToComplete(rekeySubmit.Txid);
            Console.WriteLine($"Rekeyed {classic.Address} -> PQ authorizer {falcon.Address}");

            transParams = await algod.TransactionParamsAsync();
            var spendRekeyedTx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
                classic.Address, funder.Address, 100_000, "spend under PQ authorizer", transParams);
            spendRekeyedTx.Fee = minFee * (1 + PQSignature.Falcon1024FeeContributionFactor);
            var spendRekeyedSigned = spendRekeyedTx.SignPQ(falcon); // AuthAddr = falcon.Address
            var spendRekeyedSubmit = await algod.SubmitTransaction(spendRekeyedSigned);
            var spendRekeyedResult = await algod.WaitTransactionToComplete(spendRekeyedSubmit.Txid);
            Console.WriteLine($"Spent from rekeyed account under PQ authorizer in round {spendRekeyedResult.ConfirmedRound}");
        }

        /// <summary>
        /// Exports the richest account from LocalNet KMD's genesis-funded
        /// "unencrypted-default-wallet" to use as a dispenser.
        /// </summary>
        private static async Task<Account> GetFundedKmdAccount()
        {
            var KMD_API_ADDR = Environment.GetEnvironmentVariable("KMD_API_ADDR") ?? "http://localhost:4002";
            var KMD_API_TOKEN = Environment.GetEnvironmentVariable("KMD_API_TOKEN") ?? "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var ALGOD_API_ADDR = Environment.GetEnvironmentVariable("ALGOD_API_ADDR") ?? "http://localhost:4001/";
            var ALGOD_API_TOKEN = Environment.GetEnvironmentVariable("ALGOD_API_TOKEN") ?? "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var kmdHttpClient = new System.Net.Http.HttpClient();
            kmdHttpClient.DefaultRequestHeaders.Add("X-KMD-API-Token", KMD_API_TOKEN);
            var kmd = new Algorand.KMD.Api(kmdHttpClient) { BaseUrl = KMD_API_ADDR };

            var wallets = await kmd.ListWalletsAsync(null);
            Algorand.KMD.APIV1Wallet wallet = null;
            foreach (var w in wallets.Wallets)
            {
                if (w.Name == "unencrypted-default-wallet") { wallet = w; break; }
            }
            if (wallet == null) throw new InvalidOperationException("LocalNet KMD wallet 'unencrypted-default-wallet' not found - is AlgoKit LocalNet running?");

            var handle = (await kmd.InitWalletHandleTokenAsync(new Algorand.KMD.InitWalletHandleTokenRequest()
            {
                Wallet_id = wallet.Id,
                Wallet_password = ""
            })).Wallet_handle_token;
            var keys = await kmd.ListKeysInWalletAsync(new Algorand.KMD.ListKeysRequest() { Wallet_handle_token = handle });

            // Pick whichever key currently holds the most funds.
            var algod = new AlgodClient(HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN));
            string best = null;
            ulong bestAmount = 0;
            foreach (var address in keys.Addresses)
            {
                var info = await algod.AccountInformationAsync(address, null, null);
                if (info.Amount > bestAmount) { bestAmount = info.Amount; best = address; }
            }
            if (best == null) throw new InvalidOperationException("no funded account found in LocalNet default wallet");

            var exported = await kmd.ExportKeyAsync(new Algorand.KMD.ExportKeyRequest()
            {
                Address = best,
                Wallet_handle_token = handle,
                Wallet_password = ""
            });
            return new Account(exported.Private_key);
        }
    }
}
