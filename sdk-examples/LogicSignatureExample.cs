using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples
{
    class LogicSignatureExample
    {
        public static async Task Main(params string[] args)
        {

            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            Account acct1 = new Account("shaft web sell outdoor brick above promote call disease gift fun course grief hurdle key bamboo choice camp law lucky bitter skill term able ignore");
            Account acct2 = new Account("pipe want hockey shoulder gallery inner woman salute wrestle fashion define bonus broom start disease portion salt gesture measure prosper just draw engage ability dizzy");

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            byte[] program = Convert.FromBase64String("ASABASI=");
            var lsig1 = new LogicsigSignature(program);
            lsig1.Sign(acct1);

            var contractSig = Convert.ToBase64String(lsig1.Sig.Bytes);
            var lsig2 = new LogicsigSignature(program, null, Convert.FromBase64String(contractSig));
            
            var transParams = await algodApiInstance.TransactionParamsAsync();
            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, acct2.Address, 1000000, "draw algo with logic signature", transParams);

            var signedTx = tx.Sign(lsig2);

            try
            {
                var response = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                Console.WriteLine("Successfully sent tx logic sig tx id: " + response.Txid);
                Console.WriteLine("Confirmed Round is: " +
                        Utils.WaitTransactionToComplete(algodApiInstance, response.Txid).Result.ConfirmedRound);
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception when calling algod#rawTransaction: " + e.Message);
            }
        }
    }
}
