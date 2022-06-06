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
    class DryrunDebugging
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
            string account2_mnemonic = "oval brown real consider grow someone impulse palace elegant code elegant victory observe nerve thunder trash mutual viable patient ask below imitate gallery able text";
            Account acct2 = new Account(account2_mnemonic);

            //byte[] source = File.ReadAllBytes("V2\\contract\\sample.teal");
            byte[] program = Convert.FromBase64String("ASABASI=");

            LogicsigSignature lsig = new LogicsigSignature(program, null);

            // sign the logic signaure with an account sk
            lsig.Sign(acct1);

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            Algorand.Algod.Model.TransactionParametersResponse transParams;
            try
            {
                transParams = await algodApiInstance.TransactionParamsAsync();
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                throw new Exception("Could not get params", e);
            }
            Transaction tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, acct2.Address, 1000000, "tx using in dryrun", transParams);
            try
            {
                //bypass verify for non-lsig
                SignedTransaction signedTx = tx.Sign(lsig);

                // dryrun logic sig transaction
                var dryrunResponse2 = await Utils.GetDryrunResponse(algodApiInstance, signedTx);
                Console.WriteLine("Dryrun source response : " + dryrunResponse2.ToJson()); 
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                // This is generally expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#rawTransaction: " + e.Message);
            }

            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
        }
    }
}
