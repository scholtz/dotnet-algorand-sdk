using System;
using System.Threading.Tasks;
using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;

namespace sdk_examples
{
    class AccountTest
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

      
            Account src = new Account(SRC_ACCOUNT);
            Console.WriteLine("My account address is:" + src.Address.ToString());
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var accountInfo = await algodApiInstance.AccountsAsync(src.Address.ToString(),null);
            Console.WriteLine(string.Format("Account Balance: {0} microAlgos", accountInfo.Amount));

            
            
            
            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
        }
    }
}
