using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
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
        internal static CommonApi algodCommonApiInstance;
        internal static Algorand.Kmd.Api.DefaultApi kmdApi;

        [Given("mock server recording request paths")]
        public void MockServerRecordingRequestPaths()
        {
            setUp();

        }

        
        public static void setUp()
        { 
            if (algodDefaultApiInstance == null) algodDefaultApiInstance = new DefaultApi(httpClient);
            if (algodCommonApiInstance == null) algodCommonApiInstance = new CommonApi(httpClient);
           
        }

        public static void setUpKmd()
        {
            if (kmdApi == null) kmdApi = new Algorand.Kmd.Api.DefaultApi("http://localhost:60001");
            kmdApi.Configuration.AddApiKey("X-KMD-API-Token", ALGOD_API_TOKEN);
        }
    }
}
