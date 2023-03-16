using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples.contract
{
    class DryrunDebugging
    {
        public static async Task Main(params string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var acct1 = new Account("lift gold aim couch filter amount novel scrap annual grow amazing pioneer disagree sense phrase menu unknown dolphin style blouse guide tell also about case");
            var acct2 = new Account("oval brown real consider grow someone impulse palace elegant code elegant victory observe nerve thunder trash mutual viable patient ask below imitate gallery able text");

            //byte[] source = File.ReadAllBytes("V2\\contract\\sample.teal");
            byte[] program = Convert.FromBase64String("ASABASI=");

            LogicsigSignature lsig = new LogicsigSignature(program, null);

            // sign the logic signaure with an account sk
            lsig.Sign(acct1);

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            TransactionParametersResponse transParams;
            try
            {
                transParams = await algodApiInstance.TransactionParamsAsync();
            }
            catch (ApiException e)
            {
                throw new Exception("Could not get params", e);
            }

            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, acct2.Address, 1000000, "tx using in dryrun", transParams);

            try
            {
                //bypass verify for non-lsig
                var signedTx = tx.Sign(lsig);

                // dryrun logic sig transaction
                var dryrunResponse2 = await Utils.GetDryrunResponse(algodApiInstance, signedTx);
                Console.WriteLine("Dryrun source response : " + dryrunResponse2.ToJson());
            }
            catch (ApiException e)
            {
                // This is generally expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#rawTransaction: " + e.Message);
            }
        }
    }
}
