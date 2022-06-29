using Algorand;
using Algorand.Indexer;
using Algorand.Indexer.Model;
using Newtonsoft.Json;
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


            var health = await commonApi.makeHealthCheckAsync();
            Console.WriteLine("Make Health Check: " + JsonConvert.SerializeObject(health));

            var address = "KV2XGKMXGYJ6PWYQA5374BYIQBL3ONRMSIARPCFCJEAMAHQEVYPB7PL3KU";
            var acctInfo = await lookupApi.lookupAccountByIDAsync(address,null,null,null);
            Console.WriteLine("Look up account by id: " + JsonConvert.SerializeObject(acctInfo));


            var transInfos = await lookupApi.lookupAccountTransactionsAsync(address, limit: 10);
            Console.WriteLine("Look up account transactions(limit 10): " + JsonConvert.SerializeObject(transInfos));


            var appsInfo = await searchApi.searchForApplicationsAsync(limit: 10);
            Console.WriteLine("Search for application(limit 10): " + JsonConvert.SerializeObject(appsInfo));

            var appIndex = appsInfo.Applications?.FirstOrDefault()?.Id;
            if (appIndex != null)
            {
                System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
                var appInfo = await lookupApi.lookupApplicationByIDAsync(appIndex.Value);
                Console.WriteLine("Look up application by id: " + JsonConvert.SerializeObject(appInfo));
            }

            try
            {
                var assetsInfo = await searchApi.searchForAssetsAsync(limit: 10, name: "latikum22");
                var assetIndex = assetsInfo.Assets.FirstOrDefault().Index;

                System.Threading.Thread.Sleep(1200); //test in purestake, imit 1 req/sec
                var assetInfo = await lookupApi.lookupAssetByIDAsync(assetIndex);
                Console.WriteLine("Look up asset by id:" + JsonConvert.SerializeObject(assetInfo));
                Console.WriteLine("Search for assets" + JsonConvert.SerializeObject(assetsInfo));
            }
            catch (ApiException<ErrorResponse> ex)
            {
               Console.WriteLine(ex.Result.Message);
            }
            

         

            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
            Console.ReadKey();
        }
    }
}
