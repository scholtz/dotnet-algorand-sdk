using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples.contract
{
    class ContractAccount
    {
        public static async Task Main(params string[] args)
        {
            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }


            var toAddress = new Address("7XVBE6T6FMUR6TI2XGSVSOPJHKQE2SDVPMFA3QUZNWM7IY6D4K2L23ZN2A");
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            TransactionParametersResponse transParams;
            try
            {
                transParams = await algodApiInstance.TransactionParamsAsync();
            }
            catch (Algorand.ApiException e)
            {
                throw new Exception("Could not get params", e);
            }
            // format and send logic sig
            byte[] program = Convert.FromBase64String("ASABASI="); 
            LogicsigSignature lsig = new LogicsigSignature(program, null);
            Console.WriteLine("Escrow address: " + lsig.Address.ToString());

            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(lsig.Address, toAddress, 10000000, "draw algo from contract", transParams);
            if (!lsig.Verify(tx.Sender))
            {
                string msg = "Verification failed";
                Console.WriteLine(msg);
            }
            else
            {
                try
                {
                    SignedTransaction signedTx = tx.Sign(lsig);
                    var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                    Console.WriteLine("Successfully sent tx logic sig tx id: " + id);
                    Console.WriteLine("Confirmed Round is: " +
                        Utils.WaitTransactionToComplete(algodApiInstance, id.Txid).Result.ConfirmedRound);
                }
                catch (Algorand.ApiException<ErrorResponse> e)
                {
                    // This is generally expected, but should give us an informative error message.
                    Console.WriteLine("Exception when calling algod#sendTransaction: " + e.Result.Message);
                }
            }
            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
        }
    }
}
