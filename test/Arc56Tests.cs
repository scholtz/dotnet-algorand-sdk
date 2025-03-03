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
    }
}
