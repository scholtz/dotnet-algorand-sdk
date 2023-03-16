using System;
using System.Threading.Tasks;
using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;

namespace sdk_examples
{
    // This SDK Example shows how to connect to the Algorand Sandbox node
    // and retrieve information about an account.
    class AccountExample
    {
        public static async Task Main(string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            // This boilerplate creates an Account object with a private key represented by a mnemnonic.
            //
            //   If using Sandbox, please use the following commands to replace the below mnemonic:
            //   ./sandbox goal account list
            //   ./sandbox goal account export -a <address>
            var srcAccount = new Account("move sell junior vast verb stove bracket filter place child fame bone story science miss injury put cancel already session cheap furnace void able minimum");

            // Create a connection to our sandbox node
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            try
            {
                // Call the sandbox node via the http api to get information about our Account
                var accountInfo = await algodApiInstance.AccountInformationAsync(srcAccount.Address.ToString(), null, null);

                // Display the info
                Console.WriteLine($"For account address {srcAccount.Address} the account balance is {accountInfo.Amount}");
            }
            catch (ApiException<ErrorResponse> apiException)
            {
                Console.WriteLine($"An error was returned by the Sandbox: {apiException.Result.Message}");
            }
        }
    }
}
