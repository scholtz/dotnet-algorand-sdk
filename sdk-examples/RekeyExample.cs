using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;

namespace sdk_examples
{
    class RekeyExample
    {
        public static async Task Main(string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            // These will be our three accounts for the demonstration.
            //
            //   If using Sandbox, please use the following commands to replace the below mnemonics:
            //   ./sandbox goal account list
            //   ./sandbox goal account export -a <address>
            //   Repeat the second command foreach account.
            Account acct1 = new Account("move sell junior vast verb stove bracket filter place child fame bone story science miss injury put cancel already session cheap furnace void able minimum");
            Account acct2 = new Account("gravity maid again grass ozone execute exotic vapor fringe snack club monitor where jar pyramid receive tattoo science scene high sound degree bless above good");
            Account acct3 = new Account("pencil ostrich net alpha need vivid elevator gadget bundle meadow flash hamster pig young ten clown before grace arch tennis absent knock peanut ability alarm");

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var transParams = await algodApiInstance.TransactionParamsAsync();

            ulong amount = 1000000;

            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct3.Address, acct2.Address, amount, "pay message", transParams);
            try
            {
                // this uses the payment transaction to rekey to Acct3 to use Acct1 signing keys
                tx.RekeyTo = acct1.Address;
                var signedTx = tx.Sign(acct3);
                await Utils.SubmitTransaction(algodApiInstance, signedTx);

                // let's try it again with the acct3 signing key
                tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct3.Address, acct2.Address, amount, "pay message", transParams);
                signedTx = tx.Sign(acct3);
                await Utils.SubmitTransaction(algodApiInstance, signedTx); //this should fail

            }
            catch (ApiException<ErrorResponse> e)
            {
                Console.WriteLine(e.Result.Message);

                //rekey it back
                tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct3.Address, acct2.Address, amount, "pay message", transParams);
                tx.RekeyTo = acct3.Address;
                var signedTx = tx.Sign(acct1);
                await Utils.SubmitTransaction(algodApiInstance, signedTx); 
            }
        }
    }
}