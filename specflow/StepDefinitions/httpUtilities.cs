using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.KMD;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace specflow.StepDefinitions
{
    [Binding]
    public sealed class httpUtilities
    {
        const string ALGOD_API_ADDR = "http://localhost:60000/";
        const string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        private static HttpClient httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);

        internal static DefaultApi algodDefaultApiInstance;

        internal static Algorand.KMD.Api kmdApi;

        [Given("mock server recording request paths")]
        public void MockServerRecordingRequestPaths()
        {
            setUp();

        }

        
        public static void setUp()
        { 
            if (algodDefaultApiInstance == null) algodDefaultApiInstance = new DefaultApi(httpClient);
     
           
        }

        public static void setUpKmd()
        {
            if (kmdApi == null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("X-KMD-API-Token", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

                kmdApi = new Api(client);
                kmdApi.BaseUrl = @"http://localhost:4002";
            }
        }
    }
}
