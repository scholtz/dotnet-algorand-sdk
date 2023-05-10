using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;


namespace sdk_examples
{
    class BasicExample
    {
        public static async Task Main(string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            // This boilerplate creates an Account object with a private key represented by a mnemnonic.
            //
            //   If using Sandbox, please use the following commands to replace the below mnemonic:
            //   ./sandbox goal account list
            //   ./sandbox goal account export -a <address>
            var src = new Account("chalk pig bleak brave despair pencil spin found pigeon exact attend meadow orange decline scare pen festival dog lunch reduce answer broom brush absent public");

            var DEST_ADDR = "5KFWCRTIJUMDBXELQGMRBGD2OQ2L3ZQ2MB54KT2XOQ3UWPKUU4Y7TQ4X7U";


            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var supply = await algodApiInstance.GetSupplyAsync();
            Console.WriteLine("Total Algorand Supply: " + supply.TotalMoney);
            Console.WriteLine("Online Algorand Supply: " + supply.OnlineMoney);

            var accountInfo = await algodApiInstance.AccountInformationAsync(src.Address.ToString(), null, null);

            Console.WriteLine($"Account Balance: {accountInfo.Amount} microAlgos");

            var transParams = await algodApiInstance.TransactionParamsAsync();

            var amount = Utils.AlgosToMicroalgos(1);
            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(src.Address, new Address(DEST_ADDR), amount, "pay message", transParams);
            var signedTx = tx.Sign(src);

            Console.WriteLine("Signed transaction with transaction ID: " + signedTx.Tx.TxID());

            // send the transaction to the network
            var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
            Console.WriteLine("Successfully sent tx with id: " + id.Txid);

            var resp = await Utils.WaitTransactionToComplete(algodApiInstance, id.Txid);
            Console.WriteLine("Confirmed Round is: " + resp.ConfirmedRound);
        }
    }
}
