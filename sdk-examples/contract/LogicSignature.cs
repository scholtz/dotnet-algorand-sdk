using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Client;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples.contract
{
    class LogicSignature
    {
        public static async Task Main(params string[] args)
        {

            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }


            string SRC_ACCOUNT = "lift gold aim couch filter amount novel scrap annual grow amazing pioneer disagree sense phrase menu unknown dolphin style blouse guide tell also about case";

            Account acct1 = new Account(SRC_ACCOUNT);
            byte[] program = Convert.FromBase64String("ASABASI="); //int 1
                                                                   //byte[] program = Convert.FromBase64String("ASABACI="); //int 0


            LogicsigSignature lsig = new LogicsigSignature(program, null);
            

            // sign the logic signaure with an account sk

            lsig.Sign(acct1);
            var contractSig = Convert.ToBase64String(lsig.Sig.Bytes);



            string account2_mnemonic = "oval brown real consider grow someone impulse palace elegant code elegant victory observe nerve thunder trash mutual viable patient ask below imitate gallery able text";
            Account acct2 = new Account(account2_mnemonic);



            LogicsigSignature lsig2 = new LogicsigSignature(program, null, Convert.FromBase64String(contractSig));
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            Algorand.Algod.Model.TransactionParametersResponse transParams;
            try
            {
                transParams = await algodApiInstance.TransactionParamsAsync();
            }
            catch (Algorand.ApiException e)
            {
                throw new Exception("Could not get params", e);
            }

            var tx= PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, acct2.Address,1000000, "draw algo with logic signature", transParams);
            
            try
            {
                //bypass verify for non-lsig
                SignedTransaction signedTx = tx.Sign(lsig2);

                var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                Console.WriteLine("Successfully sent tx logic sig tx id: " + id);
                Console.WriteLine("Confirmed Round is: " +
                        Utils.WaitTransactionToComplete(algodApiInstance, id.Txid).Result.ConfirmedRound);
            }
            catch (Algorand.ApiException e)
            {
                // This is generally expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#rawTransaction: " + e.Message);
            }

            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
        }
    }
}
