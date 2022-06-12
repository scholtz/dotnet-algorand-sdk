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

        [Given("mock server recording request paths")]
        public void MockServerRecordingRequestPaths()
        {
            algodDefaultApiInstance = new DefaultApi(httpClient);
            algodCommonApiInstance = new CommonApi(httpClient);

            //HttpClientTestInformation contains the last request called.


        }
    }
}
