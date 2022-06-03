using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Threading.Tasks;


namespace sdk_examples
{
    /// <summary>
    /// Part 1
    /// rekey from Account 3 to allow to sign from Account 1
    /// Part 2
    /// send from account 3 to account 2 and sign from Account 1
    /// </summary>
    class RekeyExample
    {
        public static async Task Main(string[] args)
        {
            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            string SRC_ACCOUNT = "lift gold aim couch filter amount novel scrap annual grow amazing pioneer disagree sense phrase menu unknown dolphin style blouse guide tell also about case";

            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }

            string account1_mnemonic = SRC_ACCOUNT;
            string account2_mnemonic = "oval brown real consider grow someone impulse palace elegant code elegant victory observe nerve thunder trash mutual viable patient ask below imitate gallery able text";
            string account3_mnemonic = "clog tide item robust bounce fiction axis violin night steel frame pear ice proud consider uphold gaze polar page call infant segment page abstract diamond";

            var account1 = new Account(account1_mnemonic);
            var account2 = new Account(account2_mnemonic);
            var account3 = new Account(account3_mnemonic);

            Console.WriteLine(string.Format("Account 1 : {0}", account1.Address));
            Console.WriteLine(string.Format("Account 2 : {0}", account2.Address));
            Console.WriteLine(string.Format("Account 3 : {0}", account3.Address));

            //Part 1
            //build transaction

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            var trans = await algodApiInstance.ParamsAsync();
            Console.WriteLine("Lastround: " + trans.LastRound.ToString());


            bool firstRun = false;

            if (firstRun)
            {
                ulong amount = 0;
                //opt-in send tx to same address as sender and use 0 for amount w rekey account to account 1
                var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(account3.Address, account3.Address, amount, "pay message", trans);
                tx.RekeyTo = account1.Address;

                var signedTx = tx.Sign(account3);
                
                // send the transaction to the network and
                // wait for the transaction to be confirmed
                try
                {
                    var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                    Console.WriteLine("Transaction ID: " + id);
                    //waitForTransactionToComplete(algodApiInstance, signedTx.transactionID);
                    //Console.ReadKey();
                    Console.WriteLine("Confirmed Round is: " +
                        Utils.WaitTransactionToComplete(algodApiInstance, id.TxId).Result.ConfirmedRound);
                }
                catch (Exception e)
                {
                    //e.printStackTrace();
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var act = await algodApiInstance.AccountsAsync(account3.Address.ToString(), null);
            Console.WriteLine(act);

            ulong amount2 = 1000000;

            var tx2 = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(account3.Address, account2.Address, amount2, "pay message", trans);
            tx2.RekeyTo = account1.Address;
            var signedTx2 = tx2.Sign(account1);
            try
            {
                var id = await Utils.SubmitTransaction(algodApiInstance, signedTx2);
                Console.WriteLine("Transaction ID: " + id);
                Console.WriteLine("Confirmed Round is: " +
                    Utils.WaitTransactionToComplete(algodApiInstance, id.TxId).Result.ConfirmedRound);
            }
            catch (ApiException<ErrorResponse> e)
            {
                Console.WriteLine(e.Result.Message);
                return;
            }
        }
    }
}
