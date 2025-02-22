using Algorand.Algod;
using Algorand;
using Algorand.Utils;
using AlgoStudio.ABI.ARC32;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestNamespace;
using Algorand.Algod.Model;
using System.Diagnostics;
using Algorand.KMD;
using System.Reflection.Metadata;
using System.Linq;

namespace test
{
    [TestFixture]
    public class Arc4Tests
    {
        private const string URL = "https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecClammPool.arc32.json";

        [Test]
        public async Task GenerateClient()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(URL);

            Assert.AreEqual(200, (int)response.StatusCode, "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Trim().StartsWith("{"), "File content is not valid JSON");

            var app = AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(content));

            Assert.That(app.Bare_call_config.No_op, Is.EqualTo(CallConfig.NEVER));
            Assert.That(app.Hints.Keys.Count, Is.GreaterThan(1));
            Assert.That(app.State.Global, Is.Not.Null);
            Assert.That(app.Contract.Methods.Count, Is.GreaterThan(1));

            var appref = app.ToSmartContractReference("TestNamespace", "");
            Assert.That(appref.Length, Is.GreaterThan(1));
            var appProxy = app.ToProxy("TestNamespace");
            Assert.That(appProxy.Length, Is.GreaterThan(1));

            File.WriteAllText("SmartContractReference.cs", appref);
            File.WriteAllText("SmartContractProxy.cs", appProxy);
        }
        private async Task<Account> GetAccount()
        {
        
            //A standard sandbox connection
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-KMD-API-Token", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            var kmdApi = new Api(client);
            kmdApi.BaseUrl = @"http://localhost:4002";
            var handle = await getWalletHandleToken(kmdApi);
            var accs = await kmdApi.ListKeysInWalletAsync(new ListKeysRequest() { Wallet_handle_token = handle });
            var a = accs.Addresses.First();
            var resp = await kmdApi.ExportKeyAsync(new ExportKeyRequest() { Address = a, Wallet_handle_token = handle, Wallet_password = "" });
            return new Account(resp.Private_key);
        }
        private static async Task<string> getWalletHandleToken(Api kmdApi)
        {
            var wallets = await kmdApi.ListWalletsAsync(null);
            var wallet = wallets.Wallets.FirstOrDefault();
            var handle = await kmdApi.InitWalletHandleTokenAsync(new InitWalletHandleTokenRequest() { Wallet_id = wallet.Id, Wallet_password = "" });
            return handle.Wallet_handle_token;
        }

        [Test]
        public async Task DeployProxiedApp()
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            Account acct1 = await GetAccount();


            var contract = new BiatecClammPoolProxy(algodApiInstance, 0);
            try
            {
                await contract.createApplication(acct1, 1000, "", new List<BoxRef>(), AlgoStudio.Core.OnCompleteType.CreateApplication);
            }
            catch (Algorand.ApiException<Algorand.Algod.Model.ErrorResponse> e)
            {
                Trace.TraceError(e.Message);
                throw;
            }
            catch (Algorand.ApiException e)
            {

                Trace.TraceError(e.Message);
                throw;
            }
            catch (AlgoStudio.ProxyException e)
            {
                var eApi = e.InnerException as Algorand.ApiException<Algorand.Algod.Model.ErrorResponse>;
                if(eApi != null)
                {
                    Trace.TraceError(eApi.Result.Message.ToString());
                }
                Trace.TraceError(e.Message);
                throw;
            }

        }
    }
}
