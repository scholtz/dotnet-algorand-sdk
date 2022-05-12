using Algorand;
using Algorand.Indexer;
using Algorand.Indexer.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace sdk_examples
{
    public class IndexerExample
    {
        public static async Task Main(string[] args)
        {

            string ALGOD_API_ADDR = "http://localhost:8980/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            LookupApi lookupApi = new LookupApi(httpClient);
            SearchApi searchApi = new SearchApi(httpClient);
            CommonApi commonApi = new CommonApi(httpClient);

            //AlgodApi algodApiInstance = new AlgodApi(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            var health = await commonApi.HealthAsync();
            Console.WriteLine("Make Health Check: " + health.ToJson());

            System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
            var address = "KV2XGKMXGYJ6PWYQA5374BYIQBL3ONRMSIARPCFCJEAMAHQEVYPB7PL3KU";
            var acctInfo = await lookupApi.AccountsAsync(address);
            Console.WriteLine("Look up account by id: " + acctInfo.ToJson());

            System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
            var transInfos = await lookupApi.TransactionsGetAsync(address, limit: 10);
            Console.WriteLine("Look up account transactions(limit 10): " + transInfos.ToJson());

            System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
            var appsInfo = await searchApi.ApplicationsAsync(limit: 10);
            Console.WriteLine("Search for application(limit 10): " + appsInfo.ToJson());

            var appIndex = appsInfo.Applications?.FirstOrDefault()?.Id;
            if (appIndex != null)
            {
                System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
                var appInfo = await lookupApi.ApplicationsAsync(appIndex.Value);
                Console.WriteLine("Look up application by id: " + appInfo.ToJson());
            }

            System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
            try
            {
                var assetsInfo = await searchApi.AssetsAsync(limit: 10, name: "latikum22");
                var assetIndex = assetsInfo.Assets.FirstOrDefault().Index;

                System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
                var assetInfo = await lookupApi.AssetsAsync(assetIndex);
                Console.WriteLine("Look up asset by id:" + assetInfo.ToJson());
                Console.WriteLine("Search for assets" + assetsInfo.ToJson());
            }
            catch (ApiException<IndexerError> ex)
            {
               Console.WriteLine(ex.Result.Message);
            }
            

         

            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
            Console.ReadKey();
        }
    }
}
