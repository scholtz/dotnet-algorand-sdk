using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sdk_examples
{
    class AtomicTransferExample
    {
        public static async Task Main(params string[] args)
        {
            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string SRC_ACCOUNT = "lift gold aim couch filter amount novel scrap annual grow amazing pioneer disagree sense phrase menu unknown dolphin style blouse guide tell also about case";

 
            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }
        
            string DEST_ADDR = "KV2XGKMXGYJ6PWYQA5374BYIQBL3ONRMSIARPCFCJEAMAHQEVYPB7PL3KU";
            string DEST_ADDR2 = "OAMCXDCH7LIVYUF2HSNQLPENI2ZXCWBSOLUAOITT47E4FAMFGAMI4NFLYU";

            Account src = new Account(SRC_ACCOUNT);
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            TransactionParametersResponse transParams;
            try
            {
                transParams = await algodApiInstance.ParamsAsync();
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                throw new Exception("Could not get params", e);
            }

            // let's create a transaction group
            var amount = Utils.AlgosToMicroalgos(1);
            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(src.Address, new Address(DEST_ADDR), amount, "pay message", transParams);
            var tx2 = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(src.Address, new Address(DEST_ADDR2), amount, "pay message", transParams);

            Digest gid = TxGroup.ComputeGroupID(new Transaction[] { tx, tx2 });
            tx.Group = gid;
            tx2.Group = gid;

            var signedTx = tx.Sign(src);
            var signedTx2 = tx2.Sign(src);

            try
            {
              
                List<SignedTransaction> group = new List<SignedTransaction>() { signedTx, signedTx2};

                PostTransactionsResponse id; //this only returns the id of the 1st in the list (for backward compatibility apparently)
                id = await algodApiInstance.TransactionsAsync(group);

                Console.WriteLine("Successfully sent tx group with first tx id: " + id);
                Console.WriteLine("Confirmed Round is: " +
                    Utils.WaitTransactionToComplete(algodApiInstance, id.TxId).Result.ConfirmedRound);
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                // This is generally expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#rawTransaction: " + e.Message);
            }
            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
            Console.ReadKey();
        }
    }
}
