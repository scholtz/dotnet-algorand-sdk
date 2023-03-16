using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace sdk_examples
{
    class MultisigExample
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var ALGOD_API_ADDR = "http://localhost:4001/";
                var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

                // This boilerplate creates an Account object with a private key represented by a mnemnonic.
                //
                //   If using Sandbox, please use the following commands to replace the below mnemonic:
                //   ./sandbox goal account list
                //   ./sandbox goal account export -a <address>
                var acc1 = new Account("gravity maid again grass ozone execute exotic vapor fringe snack club monitor where jar pyramid receive tattoo science scene high sound degree bless above good");
                var acc2 = new Account("move sell junior vast verb stove bracket filter place child fame bone story science miss injury put cancel already session cheap furnace void able minimum");
                var acc3 = new Account("pencil ostrich net alpha need vivid elevator gadget bundle meadow flash hamster pig young ten clown before grace arch tennis absent knock peanut ability alarm");
                var randomAccount = new Account();

                var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
                DefaultApi algodApiInstance = new DefaultApi(httpClient);

                // A multisig address is the hash of the following information
                // Note that the second argument (2) means in this case "2 of 3 signatures are required"
                MultisigAddress multiAddress = new MultisigAddress(1, 2, new List<byte[]> { acc1.Address.Bytes, acc2.Address.Bytes, acc3.Address.Bytes });

                // Send *to* the multisig address
                var transParams = await algodApiInstance.TransactionParamsAsync();
                var payment = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acc1.Address, multiAddress.ToAddress(), 100000, "to multsig", transParams);
                var signedTx = payment.Sign(acc1);
                var tx = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                await Utils.WaitTransactionToComplete(algodApiInstance,tx.Txid);

                // now to send *from* the multi-address we need a certain number of signatures specified by the threshold
                transParams = await algodApiInstance.TransactionParamsAsync();
                var payment2 = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(multiAddress.ToAddress(),randomAccount.Address, 100000, "from multisig", transParams);

                // sign with 2 addresses (2 of 3 threshold)
                var signedTx1 = payment2.Sign(multiAddress,acc1);
                var signedTx2 = payment2.Sign(multiAddress,acc2);
                signedTx = SignedTransaction.MergeMultisigTransactions(signedTx1, signedTx2);
               
                tx = await Utils.SubmitTransaction(algodApiInstance, signedTx);
                var result= await Utils.WaitTransactionToComplete(algodApiInstance, tx.Txid);

                // now let's check the account received the amount
                var accountInfo = await algodApiInstance.AccountInformationAsync(randomAccount.Address.ToString(), null, null);
                Console.WriteLine($"For account address {randomAccount.Address} the account balance is {accountInfo.Amount}");



            }
            catch (ApiException<ErrorResponse> apiException)
            {
                Console.WriteLine($"An error was returned by the Sandbox: {apiException.Result.Message}");
            }
        }
    }
}
