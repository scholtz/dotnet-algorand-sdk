using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace sdk_examples.contract
{
    public class CompileTeal
    {
        public static async Task Main(string[] args)
        {
            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
      
            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }
                
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            // read file - int 1
            byte[] data = File.ReadAllBytes("contract\\sample.teal");
            CompileResponse response;
            using (var datams = new MemoryStream(data))
            {
                response = await algodApiInstance.CompileAsync(datams);
            }

            Console.WriteLine("response: " + response);
            Console.WriteLine("Hash: " + response.Hash);
            Console.WriteLine("Result: " + response.Result);
            Console.ReadKey();

            //result
            //Hash: 6Z3C3LDVWGMX23BMSYMANACQOSINPFIRF77H7N3AWJZYV6OH6GWTJKVMXY
            //Result: ASABASI=
        }
    }
}
