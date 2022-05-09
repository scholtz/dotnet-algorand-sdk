using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Client;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples.contract
{
    class DryrunDedugging
    {
        public async Task Main(params string[] args)
        {
            string ALGOD_API_ADDR = args[0];
            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }
            string ALGOD_API_TOKEN = args[1];

            string SRC_ACCOUNT = "buzz genre work meat fame favorite rookie stay tennis demand panic busy hedgehog snow morning acquire ball grain grape member blur armor foil ability seminar";
            Account acct1 = new Account(SRC_ACCOUNT);
            var acct2Address = "QUDVUXBX4Q3Y2H5K2AG3QWEOMY374WO62YNJFFGUTMOJ7FB74CMBKY6LPQ";

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
                transParams = await algodApiInstance.ParamsAsync();
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                throw new Exception("Could not get params", e);
            }
            Transaction tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, new Address(acct2Address), 1000000, "tx using in dryrun", transParams);
            try
            {
                //bypass verify for non-lsig
                SignedTransaction signedTx = tx.Sign(lsig);

                // dryrun logic sig transaction
                var dryrunResponse2 = await Utils.GetDryrunResponse(algodApiInstance, signedTx);
                Console.WriteLine("Dryrun source repsonse : " + dryrunResponse2.ToJson()); // pretty print
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
