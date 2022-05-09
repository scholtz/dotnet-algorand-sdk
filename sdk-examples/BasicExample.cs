using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Utils;
using System;
using System.Threading.Tasks;


namespace sdk_examples
{
    class BasicExample
    {
        public static async Task Main(string[] args)
        {
            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            string DEST_ADDR = "KV2XGKMXGYJ6PWYQA5374BYIQBL3ONRMSIARPCFCJEAMAHQEVYPB7PL3KU";
            string SRC_ACCOUNT = "lift gold aim couch filter amount novel scrap annual grow amazing pioneer disagree sense phrase menu unknown dolphin style blouse guide tell also about case";

           

            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }


            Account src = new Account(SRC_ACCOUNT);
            Console.WriteLine("My account address is:" + src.Address.ToString());
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);


            try
            {
                var supply = await algodApiInstance.SupplyAsync();
                Console.WriteLine("Total Algorand Supply: " + supply.TotalMoney);
                Console.WriteLine("Online Algorand Supply: " + supply.OnlineMoney);

            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                Console.WriteLine("Exception when calling algod#getSupply:" + e.Message);
            }

       //     var accountInfo = await algodApiInstance.AccountsAsync(src.Address.ToString(), null);

 

            var accountInfo = await algodApiInstance.AccountsAsync(src.Address.ToString(), null);

            Console.WriteLine(string.Format("Account Balance: {0} microAlgos", accountInfo.Amount));

            try
            {
                var trans = await algodApiInstance.ParamsAsync();
                var lr = trans.LastRound;
                var block = await algodApiInstance.BlocksAsync(lr, null);

                Console.WriteLine("Lastround: " + trans.LastRound.ToString());
                Console.WriteLine("Block txns: " + block.Block.ToString());
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                Console.WriteLine("Exception when calling algod#getSupply:" + e.Message);
            }

            TransactionParametersResponse transParams;
            try
            {
                transParams = await algodApiInstance.ParamsAsync();
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                throw new Exception("Could not get params", e);
            }
            var amount = Utils.AlgosToMicroalgos(1);
            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(src.Address, new Address(DEST_ADDR), amount, "pay message", transParams);
            var signedTx = tx.Sign(src);

            Console.WriteLine("Signed transaction with txid: " + signedTx.transactionID);

            // send the transaction to the network
            try
            {
                var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.TxId);
                var resp = await Utils.WaitTransactionToComplete(algodApiInstance, id.TxId);
                Console.WriteLine("Confirmed Round is: " + resp.ConfirmedRound);
            }
            catch (ApiException<ErrorResponse> e)
            {
                // This is generally expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#rawTransaction: " + e.Result);
            }
            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
        }
    }
}
