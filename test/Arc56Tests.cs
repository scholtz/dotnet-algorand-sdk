using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.AVM.ClientGenerator.ABI.ARC56;
using Algorand.KMD;
using Algorand.Utils;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static AVMTypes.AvmTypesProxy.Structs;

namespace test
{
    [TestFixture]
    public class Arc56Tests
    {

        [Test]
        public async Task GenerateAVMTypesClient()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/AVMTypes/refs/heads/main/projects/AVMTypes/smart_contracts/artifacts/avm_types/AvmTypes.arc56.json");
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content.Trim().StartsWith("{"), Is.True, "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = await generator.ToProxy("AVMTypes");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("AVMTypesProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateARC200Client()
        {
            using var client = new HttpClient();
            //var response = await client.GetAsync("https://raw.githubusercontent.com/SatishGAXL/arc200-ts/refs/heads/main/projects/arc200-ts/contracts/artifacts/arc200.arc56_draft.json");
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/arc200/refs/heads/main/contracts/artifacts/Arc200.arc56.json");
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content.Trim().StartsWith("{"), Is.True, "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = await generator.ToProxy("ARC200");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("ARC200Proxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClientAmm()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecClammPool.arc56.json");

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content.Trim().StartsWith("{"), Is.True, "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = await generator.ToProxy("BiatecClammPoolArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecClammPoolProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClientPP()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecPoolProvider.arc56.json");

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content.Trim().StartsWith("{"), Is.True, "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = await generator.ToProxy("BiatecPoolProviderArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecPoolProviderProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClientConf()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecConfigProvider.arc56.json");

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content.Trim().StartsWith("{"), Is.True, "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = await generator.ToProxy("BiatecConfigArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecConfigProxy.cs", appProxy);
        }
        [Test]
        public async Task GenerateClientBI()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/scholtz/BiatecCLAMM/refs/heads/main/contracts/artifacts/BiatecIdentityProvider.arc56.json");

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Failed to download file");
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content.Trim().StartsWith("{"), Is.True, "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = await generator.ToProxy("BiatecIdentityArc56");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("Arc56BiatecIdentityProxy.cs", appProxy);
        }

        [Test]
        public async Task GenerateClientGasStation()
        {
            var content = File.ReadAllText("Arc56/GasStation.arc56.json");
            Assert.That(content.Trim().StartsWith("{"), Is.True, "File content is not valid JSON");

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(content));
            var appProxy = await generator.ToProxy("AVMGasStation.GeneratedClients");
            Assert.That(appProxy.Length, Is.GreaterThan(1));
            File.WriteAllText("GasStationProxy.cs", appProxy);
        }

        private async Task<Account> GetAccount(int index = 0)
        {

            //A standard sandbox connection
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-KMD-API-Token", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            var kmdApi = new Api(client);
            kmdApi.BaseUrl = @"http://localhost:4002";
            var handle = await getWalletHandleToken(kmdApi);
            var accs = await kmdApi.ListKeysInWalletAsync(new ListKeysRequest() { Wallet_handle_token = handle });
            while (accs.Addresses.Count <= index)
            {
                await kmdApi.GenerateKeyAsync(new GenerateKeyRequest() { Wallet_handle_token = handle });
                accs = await kmdApi.ListKeysInWalletAsync(new ListKeysRequest() { Wallet_handle_token = handle });
            }
            var a = accs.Addresses.Reverse().Skip(index).First();
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
            var obj = new BiatecIdentityArc56.BiatecIdentityProviderProxy.Structs.IdentityInfo()
            {
                VerificationStatus = 1,
                VerificationClass = 2,
                IsCompany = true,
                PersonUuid = "00000000-0000-0000-0000-000000000000",
                LegalEntityUuid = "00000000-0000-0000-0000-000000000000",
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
                FeeMultiplier = 2_000_000_000,
                FeeMultiplierBase = 1_000_000_000,

            };
            var data = BitConverter.ToString(obj.ToByteArray()).Replace("-", "").ToLower();
            Assert.That(data, Is.EqualTo("0000000000000002800000000077359400000000003b9aca000000000000000009000000000000000a0000000000000001800067008d00000000000000030000000000000004000000000000000500000000000000060000000000000007000000000000000880002430303030303030302d303030302d303030302d303030302d303030303030303030303030002430303030303030302d303030302d303030302d303030302d303030303030303030303030"));

            obj = new BiatecIdentityArc56.BiatecIdentityProviderProxy.Structs.IdentityInfo()
            {
                VerificationStatus = 1,
                VerificationClass = 2,
                IsCompany = false,
                PersonUuid = "00000000-0000-0000-0000-000000000000",
                LegalEntityUuid = "00000000-0000-0000-0000-000000000000",
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
                FeeMultiplier = 2_000_000_000,
                FeeMultiplierBase = 1_000_000_000,

            };
            data = BitConverter.ToString(obj.ToByteArray()).Replace("-", "").ToLower();
            Assert.That(data, Is.EqualTo("0000000000000002000000000077359400000000003b9aca000000000000000009000000000000000a0000000000000001000067008d00000000000000030000000000000004000000000000000500000000000000060000000000000007000000000000000800002430303030303030302d303030302d303030302d303030302d303030303030303030303030002430303030303030302d303030302d303030302d303030302d303030303030303030303030"));

            obj = new BiatecIdentityArc56.BiatecIdentityProviderProxy.Structs.IdentityInfo()
            {
                LegalEntityUuid = "00000000-0000-0000-0000-000000000000",
                PersonUuid = "00000000-0000-0000-0000-000000000000",
                VerificationStatus = 1

            };
            data = BitConverter.ToString(obj.ToByteArray()).Replace("-", "").ToLower();
            Assert.That(data, Is.EqualTo("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000067008d00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002430303030303030302d303030302d303030302d303030302d303030303030303030303030002430303030303030302d303030302d303030302d303030302d303030303030303030303030"));
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
                await contractConf.CreateApplication(acct1, 1000, "", _tx_callType: AVM.ClientGenerator.Core.OnCompleteType.CreateApplication);
                await contractBI.CreateApplication(acct1, 1000, "", _tx_callType: AVM.ClientGenerator.Core.OnCompleteType.CreateApplication);
                await contractPP.CreateApplication(acct1, 1000, "", _tx_callType: AVM.ClientGenerator.Core.OnCompleteType.CreateApplication);

                await contractConf.Bootstrap(
                    _tx_sender: acct1,
                    _tx_fee: 1000,
                    biatecFee: new AVM.ClientGenerator.ABI.ARC4.Types.UInt256(1),
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
                    acct1.Address, acct1.Address, acct1.Address,
                    _tx_sender: acct1,
                    _tx_fee: 1000,
                    appBiatecConfigProvider: contractConf.appId,
                    _tx_note: "",
                    _tx_apps: new List<ulong>() { contractConf.appId }
                    );
                
                Console.WriteLine($"contractConf: {contractConf.appId}");
                Console.WriteLine($"contractBI: {contractBI.appId}");

                var transParams = await algodApiInstance.TransactionParamsAsync();
                var tx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(acct1.Address, contractBI.AppAddress, 1_000_000, "", transParams);
                var signedTx = tx.Sign(acct1);

                var id = await Utils.SubmitTransaction(algodApiInstance, signedTx);

                byte[] prefix = new byte[] { (byte)'i' };
                byte[] box = prefix.Concat(acct1.Address.Bytes).ToArray();
                var ulongV = (ulong)DateTimeOffset.Now.Ticks;
                await contractBI.SelfRegistration(acct1.Address, new BiatecIdentityArc56.BiatecIdentityProviderProxy.Structs.IdentityInfo()
                {
                    LegalEntityUuid = "00000000-0000-0000-0000-000000000000",
                    PersonUuid = "00000000-0000-0000-0000-000000000000",
                    VerificationStatus = 1,
                    IsCompany = false,
                    AvmEngagementPoints = 0,
                    IsLocked = false,
                    KycExpiration = 0,
                    FeeMultiplierBase = 1_000_000_000,
                    FeeMultiplier = 2_000_000_000
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

                var data = await contractBI.GetUser(acct1.Address, (byte)1, acct1, 1000,
                    _tx_boxes: new List<BoxRef>()
                    {
                        new BoxRef()
                        {
                            App = 0,
                            Name = box,

                        }
                    }
                    );
                Assert.That(data.Version, Is.EqualTo(1));
                Assert.That(data.VerificationStatus, Is.EqualTo(1));
                Assert.That(data.LegalEntityUuid, Is.EqualTo("00000000-0000-0000-0000-000000000000"));
                Assert.That(data.PersonUuid, Is.EqualTo("00000000-0000-0000-0000-000000000000"));

                await contractBI.SetInfo(acct1.Address, new BiatecIdentityArc56.BiatecIdentityProviderProxy.Structs.IdentityInfo()
                {
                    LegalEntityUuid = "00000000-0000-0000-0000-000000000001",
                    PersonUuid = "00000000-0000-0000-0000-000000000002",
                    VerificationStatus = 1,
                    IsCompany = true,
                    AvmEngagementPoints = 123,
                    IsLocked = false,
                    KycExpiration = ulongV,
                    FeeMultiplierBase = 1_000_000_000,
                    FeeMultiplier = 1_000_000_000
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

                data = await contractBI.GetUser(acct1.Address, (byte)1, acct1, 1000,
                   _tx_boxes: new List<BoxRef>()
                   {
                        new BoxRef()
                        {
                            App = 0,
                            Name = box,

                        }
                   }
                   );
                Assert.That(data.Version, Is.EqualTo(1));
                Assert.That(data.VerificationStatus, Is.EqualTo(1));
                Assert.That(data.LegalEntityUuid, Is.EqualTo("00000000-0000-0000-0000-000000000001"));
                Assert.That(data.PersonUuid, Is.EqualTo("00000000-0000-0000-0000-000000000002"));
                Assert.That(data.IsCompany, Is.EqualTo(true));
                Assert.That(data.IsLocked, Is.EqualTo(false));
                Assert.That(data.AvmEngagementPoints, Is.EqualTo(123));
                Assert.That(data.KycExpiration, Is.EqualTo(ulongV));

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
            catch (AVM.ClientGenerator.ProxyException e)
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
        public async Task AVMTypesTests()
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            var trans = await algodApiInstance.TransactionParamsAsync();
            Account acct1 = await GetAccount();

            var contractConf = new AVMTypes.AvmTypesProxy(algodApiInstance, 0);
            await contractConf.CreateApplication(acct1, 1000, "", _tx_callType: AVM.ClientGenerator.Core.OnCompleteType.CreateApplication);

            Assert.That(contractConf.appId, Is.GreaterThan(0));
            Assert.That(contractConf.AppAddress, Is.Not.Null);

            Assert.That(await contractConf.Arc4Byte(255, acct1, 1000), Is.EqualTo(255));

            Assert.That(await contractConf.Arc4Byte(0, acct1, 1000), Is.EqualTo(0));
            Assert.That(await contractConf.Arc4Byte(255, acct1, 1000), Is.EqualTo(255));

            Assert.That(await contractConf.Boolean(false, acct1, 1000), Is.EqualTo(false));
            Assert.That(await contractConf.Boolean(true, acct1, 1000), Is.EqualTo(true));


            Assert.That(await contractConf.Arc4Bool(false, acct1, 1000), Is.EqualTo(false));
            Assert.That(await contractConf.Arc4Bool(true, acct1, 1000), Is.EqualTo(true));


            Assert.That(await contractConf.Arc4UintN8(0, acct1, 1000), Is.EqualTo(0));
            Assert.That(await contractConf.Arc4UintN8(255, acct1, 1000), Is.EqualTo(255));
            Assert.That(await contractConf.Arc4UintN16Alias(0, acct1, 1000), Is.EqualTo(0));
            Assert.That(await contractConf.Arc4UintN16Alias(65535, acct1, 1000), Is.EqualTo(65535));

            Assert.That(await contractConf.Arc4UintN64Alias(0, acct1, 1000), Is.EqualTo(0));
            Assert.That(await contractConf.Arc4UintN64Alias(18446744073709551615, acct1, 1000), Is.EqualTo(18446744073709551615));
            var UInt256 = new AVM.ClientGenerator.ABI.ARC4.Types.UInt256(BigInteger.Parse("0"));
            Assert.That(await contractConf.Arc4UintN256Alias(UInt256, acct1, 1000), Is.EqualTo(UInt256));
            UInt256 = new AVM.ClientGenerator.ABI.ARC4.Types.UInt256(BigInteger.Parse("18446744073709551616"));
            Assert.That(await contractConf.Arc4UintN256Alias(UInt256, acct1, 1000), Is.EqualTo(UInt256));

            var UInt512 = new AVM.ClientGenerator.ABI.ARC4.Types.UInt512(BigInteger.Parse("13407807929942597099574024998205846127479365820592393377723561443721764030073546976801874298166903427690031858186486050853753882811946569946433649006084095"));
            Assert.That(await contractConf.Arc4UintN512(UInt512, acct1, 1000), Is.EqualTo(UInt512));
            UInt512 = new AVM.ClientGenerator.ABI.ARC4.Types.UInt512(BigInteger.Parse("0"));
            Assert.That(await contractConf.Arc4UintN512(UInt512, acct1, 1000), Is.EqualTo(UInt512));


            var UInt128 = new AVM.ClientGenerator.ABI.ARC4.Types.UInt128(BigInteger.Parse("18446744073709551616"));
            Assert.That(await contractConf.Arc4UintN128Alias(UInt128, acct1, 1000), Is.EqualTo(UInt128));
            UInt128 = new AVM.ClientGenerator.ABI.ARC4.Types.UInt128(BigInteger.Parse("0"));
            Assert.That(await contractConf.Arc4UintN128Alias(UInt128, acct1, 1000), Is.EqualTo(UInt128));

            Assert.That(await contractConf.Arc4UintN16Alias(0, acct1, 1000), Is.EqualTo(0));
            Assert.That(await contractConf.Arc4UintN16Alias(65535, acct1, 1000), Is.EqualTo(65535));
            Assert.That(await contractConf.Arc4UintN8Alias(0, acct1, 1000), Is.EqualTo(0));
            Assert.That(await contractConf.Arc4UintN8Alias(255, acct1, 1000), Is.EqualTo(255));
            var bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Assert.That(await contractConf.Arc4StaticBytes8(bytes, acct1, 1000), Is.EqualTo(bytes));
            Assert.That(await contractConf.Arc4DynamicBytes(bytes, acct1, 1000), Is.EqualTo(bytes));
            Assert.That(await contractConf.Bytes(bytes, acct1, 1000), Is.EqualTo(bytes));
            bytes = new byte[32];
            RandomNumberGenerator.Fill(bytes);
            Assert.That(await contractConf.Arc4StaticBytes32(bytes, acct1, 1000), Is.EqualTo(bytes));
            Assert.That(await contractConf.Arc4DynamicBytes(bytes, acct1, 1000), Is.EqualTo(bytes));
            Assert.That(await contractConf.Bytes(bytes, acct1, 1000), Is.EqualTo(bytes));
            bytes = new byte[1018];
            RandomNumberGenerator.Fill(bytes);
            Assert.That(await contractConf.Arc4DynamicBytes(bytes, acct1, 1000), Is.EqualTo(bytes));
            Assert.That(await contractConf.Bytes(bytes, acct1, 1000), Is.EqualTo(bytes));

            bytes = new byte[1020];
            RandomNumberGenerator.Fill(bytes);
            Assert.That(await contractConf.Arc4StaticBytes1020(bytes, acct1, 1000), Is.EqualTo(bytes));

            Assert.That(await contractConf.String("Test", acct1, 1000), Is.EqualTo("Test"));

            Assert.That(await contractConf.StringArray(["Hello", "world"], acct1, 1000), Is.EqualTo(["Hello", "world"]));


            bytes = new byte[] { 1, 2 };
            Assert.That(await contractConf.Arc4StaticArrayOf2Bytes(bytes, acct1, 1000), Is.EqualTo(bytes));


            Assert.That(await contractConf.Arc4Address(acct1.Address, acct1, 1000), Is.EqualTo(acct1.Address));


            var innerStruct = new InnerStruct()
            {
                Num = 1,
                Struct = new StructAddressUint256()
                {
                    Address = acct1.Address,
                    Uint256 = new AVM.ClientGenerator.ABI.ARC4.Types.UInt256(1)
                }
            };
            Assert.That(await contractConf.InnerStruct(innerStruct, acct1, 1000), Is.EqualTo(innerStruct));

            /**/
        }
        [Test]
        public async Task Arc200Tests()
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            var trans = await algodApiInstance.TransactionParamsAsync();
            Account acct1 = await GetAccount();
            Account acct2 = await GetAccount(1);

            var contractConf = new ARC200.Arc200Proxy(algodApiInstance, 0);
            await contractConf.CreateApplication(acct1, 1000, "", _tx_callType: AVM.ClientGenerator.Core.OnCompleteType.CreateApplication);
            await acct1.MakePaymentTo(contractConf.AppAddress, 1_000_000, "", algodApiInstance); // fund MBR

            Assert.That(contractConf.appId, Is.GreaterThan(0));
            Assert.That(contractConf.AppAddress, Is.Not.Null);
            var boxes = new List<BoxRef>()
                {
                    new BoxRef()
                    {
                        App = 0,
                        Name = Encoding.ASCII.GetBytes("b").Concat(acct1.Address.Bytes).ToArray(),
                    },
                    new BoxRef()
                    {
                        App = 0,
                        Name = Encoding.ASCII.GetBytes("b").Concat(acct2.Address.Bytes).ToArray(),
                    }
                };
            await contractConf.Bootstrap(
                name: Encoding.ASCII.GetBytes("MyToken"),
                symbol: Encoding.ASCII.GetBytes("T"),
                decimals: 6,
                totalSupply: new AVM.ClientGenerator.ABI.ARC4.Types.UInt256(BigInteger.Parse("10000000000") * BigInteger.Parse("1000000")),
                _tx_sender: acct1,
                _tx_fee: 1000,
                _tx_note: "",
                _tx_boxes: boxes
                );
            var am = new AVM.ClientGenerator.ABI.ARC4.Types.UInt256();

            var balance = await contractConf.Arc200BalanceOf(acct1.Address, acct1, 1000, _tx_boxes: boxes);
            Assert.That(balance, Is.EqualTo(new AVM.ClientGenerator.ABI.ARC4.Types.UInt256(BigInteger.Parse("10000000000") * BigInteger.Parse("1000000"))));

            await contractConf.Arc200Transfer(acct2.Address, AVM.ClientGenerator.ABI.ARC4.Types.UInt256.FromValue(1_000_000_000), acct1, 1000, _tx_boxes: boxes);

            balance = await contractConf.Arc200BalanceOf(acct2.Address, acct1, 1000, _tx_boxes: boxes);
            Assert.That(balance, Is.EqualTo(new AVM.ClientGenerator.ABI.ARC4.Types.UInt256(BigInteger.Parse("1000000000"))));

        }
    }
}
