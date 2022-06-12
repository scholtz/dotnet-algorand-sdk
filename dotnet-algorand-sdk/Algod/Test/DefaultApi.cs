using Algorand.Algod.Test;

namespace Algorand.Algod
{
    public partial class DefaultApi
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            HttpClientTestInformation.LastRequest = request;
        }
    }
}
