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
            Account acct1 = new Account("arrive transfer silent pole congress loyal snap dirt dwarf relief easily plastic federal found siren point know polar quit very vanish ensure humor abstract broken");
            Account acct2 = new Account("pole pudding actor purpose spend agree erode account discover chapter adapt supreme excite lamp gospel guilt helmet wrestle meat sustain orphan certain mixture able disease");
            Account acct3 = new Account("cricket outside win obey swap useless spread detail shallow sunset birth fall innocent deal kiwi bounce okay rude social book brush lava correct abandon innocent");

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