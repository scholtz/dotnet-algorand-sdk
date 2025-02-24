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
using Algorand.Algod.Model.Transactions;

namespace test
{
    [TestFixture]
    public class Arc4Tests
    {
        private const string URL_CLAMM = "https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecClammPool.arc32.json";
        private const string URL_CONFIG = "https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecConfigProvider.arc32.json";

        [Test]
        public async Task GenerateClient1()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(URL_CLAMM);

            Assert.AreEqual(200, (int)response.StatusCode, "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Trim().StartsWith("{"), "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var app = await AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(content), algodApiInstance);

            Assert.That(app.Bare_call_config.No_op, Is.EqualTo(CallConfig.NEVER));
            Assert.That(app.Hints.Keys.Count, Is.GreaterThan(1));
            Assert.That(app.State.Global, Is.Not.Null);
            Assert.That(app.Contract.Methods.Count, Is.GreaterThan(1));
            Assert.That(app.Source.Approval.Length, Is.GreaterThan(1));

            var appref = app.ToSmartContractReference("TestNamespace", "");
            Assert.That(appref.Length, Is.GreaterThan(1));
            var appProxy = app.ToProxy("TestNamespace");
            Assert.That(appProxy.Length, Is.GreaterThan(1));

            //File.WriteAllText("SmartContractReference.cs", appref);
            File.WriteAllText("SmartContractProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClient2()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(URL_CONFIG);

            Assert.AreEqual(200, (int)response.StatusCode, "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Trim().StartsWith("{"), "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var app = await AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(content), algodApiInstance);

            Assert.That(app.Bare_call_config.No_op, Is.EqualTo(CallConfig.NEVER));
            Assert.That(app.Hints.Keys.Count, Is.GreaterThan(1));
            Assert.That(app.State.Global, Is.Not.Null);
            Assert.That(app.Contract.Methods.Count, Is.GreaterThan(1));
            Assert.That(app.Source.Approval.Length, Is.GreaterThan(1));

            var appref = app.ToSmartContractReference("TestNamespace", "");
            Assert.That(appref.Length, Is.GreaterThan(1));
            var appProxy = app.ToProxy("TestNamespace");
            Assert.That(appProxy.Length, Is.GreaterThan(1));

            File.WriteAllText("BiatecConfigProviderRef.cs", appref);
            File.WriteAllText("BiatecConfigProviderProxy.cs", appProxy);
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
                if (eApi != null)
                {
                    Trace.TraceError(eApi.Result.Message.ToString());
                }
                Trace.TraceError(e.Message);
                throw;
            }

        }

        [Test]
        public async Task DeployAppMakeAppCall()
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            var trans = await algodApiInstance.TransactionParamsAsync();
            Account acct1 = await GetAccount();


            var contract = new BiatecConfigProviderProxy(algodApiInstance, 0);
            try
            {
                await contract.createApplication(acct1, 1000, "", new List<BoxRef>(), AlgoStudio.Core.OnCompleteType.CreateApplication);
                await contract.bootstrap(
                    sender: acct1,
                    fee: 1000,
                    biatecFee: new AlgoStudio.ABI.ARC4.Types.UInt256(1),
                    appBiatecIdentityProvider: 101,
                    appBiatecPoolProvider: 102,
                    note: "",
                    boxes: new List<BoxRef>()
                    );
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
                if (eApi != null)
                {
                    Trace.TraceError(eApi.Result.Message.ToString());
                }
                Trace.TraceError(e.Message);
                throw;
            }

        }
        //[Test]
        //public async Task DeployAppMakeAppCall()
        //{
        //    var ALGOD_API_ADDR = "http://localhost:4001/";
        //    var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        //    var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
        //    DefaultApi algodApiInstance = new DefaultApi(httpClient);
        //    var trans = await algodApiInstance.TransactionParamsAsync();
        //    Account acct1 = await GetAccount();


        //    var contract = new BiatecClammPoolProxy(algodApiInstance, 0);
        //    try
        //    {
        //        await contract.createApplication(acct1, 1000, "", new List<BoxRef>(), AlgoStudio.Core.OnCompleteType.CreateApplication);
        //        await contract.bootstrap(
        //            acct1,
        //            2000,
        //            PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, contract.AppAddress, 400000, "", trans),
        //            assetA: 100,
        //            assetB: 101,
        //            appBiatecConfigProvider: 110,
        //            appBiatecPoolProvider: 111,
        //            fee: 2000,
        //            priceMin: 0,
        //            priceMax: 1000,
        //            currentPrice: 1000,
        //            verificationClass: 2,
        //            note: "",
        //            boxes: new List<BoxRef>()
        //        );
        //    }
        //    catch (Algorand.ApiException<Algorand.Algod.Model.ErrorResponse> e)
        //    {
        //        Trace.TraceError(e.Message);
        //        throw;
        //    }
        //    catch (Algorand.ApiException e)
        //    {

        //        Trace.TraceError(e.Message);
        //        throw;
        //    }
        //    catch (AlgoStudio.ProxyException e)
        //    {
        //        var eApi = e.InnerException as Algorand.ApiException<Algorand.Algod.Model.ErrorResponse>;
        //        if (eApi != null)
        //        {
        //            Trace.TraceError(eApi.Result.Message.ToString());
        //        }
        //        Trace.TraceError(e.Message);
        //        throw;
        //    }

        //}
    }
}
