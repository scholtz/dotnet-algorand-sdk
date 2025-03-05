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
using Algorand.Algod.Model;
using System.Diagnostics;
using Algorand.KMD;
using System.Reflection.Metadata;
using System.Linq;
using Algorand.Algod.Model.Transactions;
using System.Diagnostics.Contracts;
using BiatecClammPool;
using BiatecConfig;
using BiatecIdentity;
using BiatecPoolProvider;
using Algorand.AlgoStudio.ABI.ARC56;
using NUnit.Framework.Internal;
using System.Collections;

namespace test
{
    [TestFixture]
    public class Arc56Tests
    {

        [Test]
        public async Task GenerateClientAmm()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecClammPool.arc56.json");

            Assert.AreEqual(200, (int)response.StatusCode, "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Trim().StartsWith("{"), "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = generator.ToProxy("BiatecClammPoolArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecClammPoolProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClientPP()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecPoolProvider.arc56.json");

            Assert.AreEqual(200, (int)response.StatusCode, "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Trim().StartsWith("{"), "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = generator.ToProxy("BiatecPoolProviderArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecPoolProviderProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClientConf()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecConfigProvider.arc56.json");

            Assert.AreEqual(200, (int)response.StatusCode, "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Trim().StartsWith("{"), "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = generator.ToProxy("BiatecConfigArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecConfigProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClientBI()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecIdentityProvider.arc56.json");

            Assert.AreEqual(200, (int)response.StatusCode, "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Trim().StartsWith("{"), "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = generator.ToProxy("BiatecIdentityArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecIdentityProxy.cs", appProxy);
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
        public void ObjectConversionToByteArray()
        {
            var obj = new BiatecIdentityArc56.BiatecIdentityProviderProxy.IdentityInfo()
            {
                VerificationStatus = 1,
                VerificationClass = 2,
                IsCompany = true,
                PersonUUID = "00000000-0000-0000-0000-000000000000",
                LegalEntityUUID = "00000000-0000-0000-0000-000000000000",
                BiatecEngagementPoints = 3,
                BiatecEngagementRank = 4,
                AvmEngagementPoints = 5,
                AvmEngagementRank = 6,
                TradingEngagementPoints = 7,
                TradingEngagementRank = 8,
                IsLocked = true,
                KycExpiration = 9,
                InvestorForExpiration = 10,
                IsProfessionalInvestor = true,

            };
            var data = BitConverter.ToString(obj.ToByteArray()).Replace("-", "").ToLower();
            Assert.That(data, Is.EqualTo("00000000000000010000000000000002800057007d000000000000000300000000000000040000000000000005000000000000000600000000000000070000000000000008800000000000000009000000000000000a80002430303030303030302d303030302d303030302d303030302d303030303030303030303030002430303030303030302d303030302d303030302d303030302d303030303030303030303030"));

            obj = new BiatecIdentityArc56.BiatecIdentityProviderProxy.IdentityInfo()
            {
                VerificationStatus = 1,
                VerificationClass = 2,
                IsCompany = false,
                PersonUUID = "00000000-0000-0000-0000-000000000000",
                LegalEntityUUID = "00000000-0000-0000-0000-000000000000",
                BiatecEngagementPoints = 3,
                BiatecEngagementRank = 4,
                AvmEngagementPoints = 5,
                AvmEngagementRank = 6,
                TradingEngagementPoints = 7,
                TradingEngagementRank = 8,
                IsLocked = false,
                KycExpiration = 9,
                InvestorForExpiration = 10,
                IsProfessionalInvestor = false,

            };
            data = BitConverter.ToString(obj.ToByteArray()).Replace("-", "").ToLower();
            Assert.That(data, Is.EqualTo("00000000000000010000000000000002000057007d000000000000000300000000000000040000000000000005000000000000000600000000000000070000000000000008000000000000000009000000000000000a00002430303030303030302d303030302d303030302d303030302d303030303030303030303030002430303030303030302d303030302d303030302d303030302d303030303030303030303030"));

            obj = new BiatecIdentityArc56.BiatecIdentityProviderProxy.IdentityInfo()
            {
                LegalEntityUUID = "00000000-0000-0000-0000-000000000000",
                PersonUUID = "00000000-0000-0000-0000-000000000000",
                VerificationStatus = 1

            }; 
            data = BitConverter.ToString(obj.ToByteArray()).Replace("-", "").ToLower();

            Assert.That(data, Is.EqualTo("00000000000000010000000000000000000057007d000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002430303030303030302d303030302d303030302d303030302d303030303030303030303030002430303030303030302d303030302d303030302d303030302d303030303030303030303030"));
        }

        [Test]
        public async Task DeployBI()
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            var trans = await algodApiInstance.TransactionParamsAsync();
            Account acct1 = await GetAccount();

            var contractConf = new BiatecConfigArc56.BiatecConfigProviderProxy(algodApiInstance, 0);
            var contractBI = new BiatecIdentityArc56.BiatecIdentityProviderProxy(algodApiInstance, 0);
            var contractPP = new BiatecPoolProviderArc56.BiatecPoolProviderProxy(algodApiInstance, 0);
            try
            {
                await contractConf.CreateApplication(acct1, 1000, "", _tx_callType: AlgoStudio.Core.OnCompleteType.CreateApplication);
                await contractBI.CreateApplication(acct1, 1000, "", _tx_callType: AlgoStudio.Core.OnCompleteType.CreateApplication);
                await contractPP.CreateApplication(acct1, 1000, "", _tx_callType: AlgoStudio.Core.OnCompleteType.CreateApplication);

                await contractConf.Bootstrap(
                    _tx_sender: acct1,
                    _tx_fee: 1000,
                    biatecFee: new AlgoStudio.ABI.ARC4.Types.UInt256(1),
                    appBiatecIdentityProvider: contractBI.appId,
                    appBiatecPoolProvider: contractPP.appId,
                    _tx_note: "",
                    _tx_boxes: new List<BoxRef>()
                    );
                await contractPP.Bootstrap(
                    _tx_sender: acct1,
                    _tx_fee: 1000,
                    appBiatecConfigProvider: contractConf.appId,
                    _tx_note: "",
                    _tx_apps: new List<ulong>() { contractConf.appId }
                    );
                await contractBI.Bootstrap(

                    _tx_sender: acct1,
                    _tx_fee: 1000,
                    appBiatecConfigProvider: contractConf.appId,
                    _tx_note: "",
                    _tx_apps: new List<ulong>() { contractConf.appId }
                    );

                var transParams = await algodApiInstance.TransactionParamsAsync();
                var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, contractBI.AppAddress, 1_000_000, "", transParams);
                var signedTx = tx.Sign(acct1);

                var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);

                byte[] prefix = new byte[] { (byte)'i' };
                byte[] box = prefix.Concat(acct1.Address.Bytes).ToArray();

                await contractBI.SelfRegistration(acct1.Address, new BiatecIdentityArc56.BiatecIdentityProviderProxy.IdentityInfo()
                {
                    LegalEntityUUID = "00000000-0000-0000-0000-000000000000",
                    PersonUUID = "00000000-0000-0000-0000-000000000000",
                    VerificationStatus = 1

                }, acct1, 1000, _tx_apps: new List<ulong>() { contractConf.appId, contractBI.appId },
                _tx_boxes: new List<BoxRef>()
                {
                    new BoxRef()
                    {
                        App = 0,
                        Name = box,

                    }
                }
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
    }
}
