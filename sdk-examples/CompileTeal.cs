using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace sdk_examples
{
    public class CompileTeal
    {
        public static async Task Main(string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            byte[] data = Encoding.ASCII.GetBytes(TEALContractsForExamples.Sample());

            using (var datams = new MemoryStream(data))
            {
                var response = await algodApiInstance.TealCompileAsync(datams);
                Console.WriteLine("response: " + response);
                Console.WriteLine("Hash: " + response.Hash);
                Console.WriteLine("Result: " + response.Result);
            }
        }
    }
}
