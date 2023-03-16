using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System.Threading.Tasks;

namespace sdk_examples
{
    class RekeyExample
    {
        public static async Task Main(string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var account1 = new Account("stone heavy gossip quick swing vast raw hover sock butter onion intact dune latin beef captain ceiling grape belt marble example broken sustain about cigar");
            var account2 = new Account("glue pipe try outside nose grunt train trick claw polar that project mass chronic elbow odor local minimum put betray spot misery rare abandon army");
            var account3 = new Account("country hybrid awkward avocado double speak cream ski mimic slogan immense industry purchase unit grab moment oppose ridge other pink rack burger bus absorb gadget");

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var transParams = await algodApiInstance.TransactionParamsAsync();

            ulong amount = 1000000;

            var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(account3.Address, account2.Address, amount, "pay message", transParams);

            tx.RekeyTo = account1.Address;
            var signedTx = tx.Sign(account1);
            await Utils.SubmitTransaction(algodApiInstance, signedTx);
        }
    }
}