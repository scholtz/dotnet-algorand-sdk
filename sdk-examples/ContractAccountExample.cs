using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples
{
    class ContractAccountExample
    {
        public static async Task Main(params string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var destAddress = "7XVBE6T6FMUR6TI2XGSVSOPJHKQE2SDVPMFA3QUZNWM7IY6D4K2L23ZN2A";

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var transParams = await algodApiInstance.TransactionParamsAsync();
            

            // format and send logic sig
            byte[] program = Convert.FromBase64String("ASABASI=");
            LogicsigSignature lsig = new LogicsigSignature(program);
            Console.WriteLine("Escrow address: " + lsig.Address.ToString());

            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(lsig.Address, new Address(destAddress), 10000000, "draw algo from contract", transParams);

            if (!lsig.Verify(tx.Sender))
            {
                Console.WriteLine("Verification failed");
                Environment.Exit(0);
            }

            try
            {
                var signedTx = tx.Sign(lsig);
                var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                Console.WriteLine("Successfully sent tx logic sig tx id: " + id);
                Console.WriteLine("Confirmed Round is: " +
                    Utils.WaitTransactionToComplete(algodApiInstance, id.Txid).Result.ConfirmedRound);
            }
            catch (ApiException<ErrorResponse> e)
            {
                // This is generally expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#sendTransaction: " + e.Result.Message);
            }
        }
    }
}
