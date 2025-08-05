using Algorand;
using Algorand.Algod;
using Algorand.Gossip;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Gossip
{
    [TestFixture]
    public class BlockFetcherTests
    {
        [Test]
        public async Task FetchBlocks0To100()
        {
            var gossipClient = new Algorand.Algod.GossipHttpClient(GossipHttpConfiguration.MainNetArchival);

            for (ulong i = 0; i < 100; i++)
            {
                var block = await gossipClient.FetchBlockAsync(i);
                Assert.That(block, Is.Not.Null, $"Block {i} should not be null.");
                Assert.That(block.Block.Round, Is.EqualTo(i));
            }
        }
        [Test]
        public async Task FetchBlocksAreEqualToAlgodNode()
        {
            using var httpClient = HttpClientConfigurator.ConfigureHttpClient(AlgodConfiguration.MainNet);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);
            var status = await algodApiInstance.GetStatusAsync();

            ulong round = 52402526; //50_000_440;


            var gossipClient = new Algorand.Algod.GossipHttpClient(GossipHttpConfiguration.MainNetArchival);

            var block = await gossipClient.FetchBlockAsync(round);
            Assert.That(block, Is.Not.Null, $"Block {round} should not be null.");
            Assert.That(block.Block.Round, Is.EqualTo(round));

            long durationJson = 0;
            long durationMsgPack = 0;
            long durationMsgPackGossip = 0;

            await algodApiInstance.WaitForBlockAsync(round);
            var watchJson = new Stopwatch();
            watchJson.Start();
            var blockJson = await algodApiInstance.GetBlockAsync(round, Algorand.Algod.Model.Format.Json, false);
            watchJson.Stop();
            durationJson += watchJson.ElapsedMilliseconds;

            var watchMsgPack = new Stopwatch();
            watchMsgPack.Start();
            var blockMsgPack = await algodApiInstance.GetBlockAsync(round, Algorand.Algod.Model.Format.Msgpack, false);
            watchMsgPack.Stop();
            durationMsgPack += watchMsgPack.ElapsedMilliseconds;
            blockMsgPack.Cert = null;

            var watchMsgPackGossip = new Stopwatch();
            watchMsgPackGossip.Start();
            var blockMsgPackGossip = await gossipClient.FetchBlockAsync(round);
            watchMsgPackGossip.Stop();
            durationMsgPackGossip += watchMsgPackGossip.ElapsedMilliseconds;
            blockMsgPackGossip.Cert = null;

            var jsonFromJson = Algorand.Utils.Encoder.EncodeToJson(blockJson);
            var jsonFromMsgPack = Algorand.Utils.Encoder.EncodeToJson(blockMsgPack);
            var jsonFromMsgPackGossip = Algorand.Utils.Encoder.EncodeToJson(blockMsgPackGossip);
            Assert.That(jsonFromJson, Is.EqualTo(jsonFromMsgPack), $"Block round failed {round}");
            Assert.That(jsonFromMsgPackGossip, Is.EqualTo(jsonFromMsgPack), $"Block round failed {round}");

            Console.WriteLine($"Json: {durationJson} ms, MsgPack: {durationMsgPack} ms, MsgPackGossip: {durationMsgPackGossip} ms");

        }
    }
}
