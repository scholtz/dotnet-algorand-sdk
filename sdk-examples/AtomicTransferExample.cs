using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace sdk_examples
{
    class AtomicTransferExample
    {
        public static async Task Main(params string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            string DEST_ADDR1 = "DVGHT4N3CNSN6SAJROZ2CI26VCB5L4GKAWIAWZQIA5RRLKTDRXIR27OURQ";
            string DEST_ADDR2 = "OKG56GEYDGDR33TY2D7D37RCHCVQ7PGZL2DQKMPGA5LYYUQPKNBTQ5F3D4";

            var srcAccount = new Account("stone heavy gossip quick swing vast raw hover sock butter onion intact dune latin beef captain ceiling grape belt marble example broken sustain about cigar");

            // Get a connection to the Sandbox node
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var transParams = await algodApiInstance.TransactionParamsAsync();

            // Create a transaction group
            var amount = Utils.AlgosToMicroalgos(1);
            var tx1 = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(srcAccount.Address, new Address(DEST_ADDR1), amount, "pay message", transParams);
            var tx2 = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(srcAccount.Address, new Address(DEST_ADDR2), amount, "pay message", transParams);

            var groupID = TxGroup.ComputeGroupID(new Transaction[] { tx1, tx2 });
            tx1.Group = groupID;
            tx2.Group = groupID;

            var signedTx = tx1.Sign(srcAccount);
            var signedTx2 = tx2.Sign(srcAccount);

            var signedTxGroup = new List<SignedTransaction>() { signedTx, signedTx2 };

            try
            {
                var response = await algodApiInstance.TransactionsAsync(signedTxGroup);
                var round = Utils.WaitTransactionToComplete(algodApiInstance, response.Txid).Result.ConfirmedRound;
                Console.WriteLine($"Transaction ID: {response.Txid}\nConfirmed round: {round}");
            }
            catch (ApiException<ErrorResponse> e)
            {
                Console.WriteLine(e.Result.Message);
            }
        }
    }
}