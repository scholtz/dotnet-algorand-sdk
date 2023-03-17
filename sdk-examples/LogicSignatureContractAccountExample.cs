using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples
{
    class LogicSignatureContractAccountExample
    {
        public static async Task Main(params string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";


            var destAcc = new Account("gravity maid again grass ozone execute exotic vapor fringe snack club monitor where jar pyramid receive tattoo science scene high sound degree bless above good");
            
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var transParams = await algodApiInstance.TransactionParamsAsync();
            

            // logic sig that simply approves
            byte[] program = Convert.FromBase64String("ASABASI=");
            LogicsigSignature lsig = new LogicsigSignature(program);
            Console.WriteLine("Escrow address: " + lsig.Address.ToString());

            //pay to the escrow address
            var payEscrow = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(destAcc.Address, lsig.Address, 11000000, "send algo to contract", transParams);
            var payEscrowTx = payEscrow.Sign(destAcc);

            // pay from the escrow address
            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(lsig.Address, destAcc.Address, 10000000, "draw algo from contract", transParams);
            if (!lsig.Verify(tx.Sender))
            {
                Console.WriteLine("Verification failed");
                Environment.Exit(0);
            }

            try
            {
                await Utils.SubmitTransaction(algodApiInstance, payEscrowTx);//Fund the escrow

                var signedTx = tx.Sign(lsig); // sign the payment from the logic signature address with the logic sig itself
                var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                Console.WriteLine("Successfully sent tx logic sig tx id: " + id);
                Console.WriteLine("Confirmed Round is: " +
                    Utils.WaitTransactionToComplete(algodApiInstance, id.Txid).Result.ConfirmedRound);
            }
            catch (ApiException<ErrorResponse> e)
            {
                // This is expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#sendTransaction: " + e.Result.Message);
            }
        }
    }
}
