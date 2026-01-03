using Algorand;
using Algorand.Algod;
using Algorand.Gossip;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdk_examples
{
    public class ConnectToGossipNetwork
    {
        public static async Task Main(params string[] args)
        {
            var gossipClient = new Algorand.Gossip.GossipHttpClient(GossipHttpConfiguration.MainNetArchival);
            var block = await gossipClient.FetchBlockAsync(123);
            Console.WriteLine($"Fetched block {block.Block.Round} from mainnet archival gossip node");


            var _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            var clientConfig = new GossipWebsocketClientConfiguration()
            {
                Host = "ws://r-pl.algorand-mainnet.network:4160/v1/mainnet-v1.0/gossip"
            };
            var client = new GossipWebsocketClient(_loggerFactory.CreateLogger<GossipWebsocketClient>(), clientConfig);
            client.AgreementVoteReceivedEvent += Client_AgreementVoteReceivedEvent;
            client.MsgDigestSkipReceivedEvent += Client_MsgDigestSkipReceivedEvent;
            client.MsgOfInterestReceivedEvent += Client_MsgOfInterestReceivedEvent;
            client.NetPrioResponseReceivedEvent += Client_NetPrioResponseReceivedEvent;
            client.PingReceivedEvent += Client_PingReceivedEvent;
            client.PingReplyReceivedEvent += Client_PingReplyReceivedEvent;
            client.TransactionReceivedEvent += Client_TransactionReceivedEvent;
            client.ProposalPayloadReceivedEvent += Client_ProposalPayloadReceivedEvent;
            client.StateProofSigReceivedEvent += Client_StateProofSigReceivedEvent;
            client.TopicMsgRespReceivedEvent += Client_TopicMsgRespReceivedEvent;
            client.UniEnsBlockReqReceivedEvent += Client_UniEnsBlockReqReceivedEvent;
            client.VoteBundleReceivedEvent += Client_VoteBundleReceivedEvent;

            await client.Start();
            await Task.Delay(60000);
        }

        private static async Task Client_VoteBundleReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"VoteBundleReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_UniEnsBlockReqReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"UniEnsBlockReqReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_TopicMsgRespReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"TopicMsgRespReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_StateProofSigReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"StateProofSigReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_ProposalPayloadReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"ProposalPayloadReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_PingReplyReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"PingReplyReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_PingReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"PingReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_NetPrioResponseReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"NetPrioResponseReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_MsgOfInterestReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"MsgOfInterestReceivedEvent: {bytes.Length}");
        }

        private static async Task Client_AgreementVoteReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"AgreementVoteReceived: {bytes.Length}");
        }
        private static async Task Client_MsgDigestSkipReceivedEvent(object sender, byte[] bytes)
        {
            Console.WriteLine($"MsgDigestSkipReceivedEvent: {bytes.Length}");
        }


        private static async Task Client_TransactionReceivedEvent(object sender, IEnumerable<Algorand.Algod.Model.Transactions.SignedTransaction> tx)
        {
            Console.WriteLine($"Transactions received: {tx.Count()}");
        }
    }
}
