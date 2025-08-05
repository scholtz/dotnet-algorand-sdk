namespace Algorand.Gossip
{
    public class GossipHttpConfiguration
    {
        public static GossipHttpConfiguration MainNetArchival = new GossipHttpConfiguration()
        {
            Hosts = new string[]{
                "http://a-td.algorand-mainnet.network:4160",
                "http://a-pf.algorand-mainnet.network:4160",
                "http://a-57.algorand-mainnet.network:4160",
                "http://a-sr.algorand-mainnet.network:4160",
                "http://a-3z.algorand-mainnet.network:4160",
                "http://a-lk.algorand-mainnet.network:4160",
                "http://a-ma.algorand-mainnet.network:4160",
                "http://a-m7.algorand-mainnet.network:4160",
                "http://a-av.algorand-mainnet.network:4160",
                "http://a-fq.algorand-mainnet.network:4160",
                "http://a-ln.algorand-mainnet.network:4160",
                "http://a-5k.algorand-mainnet.network:4160",
                "http://a-dw.algorand-mainnet.network:4160",
                "http://a-an.algorand-mainnet.network:4160",
                "http://a-yo.algorand-mainnet.network:4160",
                "http://a-mn.algorand-mainnet.network:4160",
                "http://a-mm.algorand-mainnet.network:4160",
                "http://a-ym.algorand-mainnet.network:4160",
                "http://a-7n.algorand-mainnet.network:4160"
            },
            GenesisId = "mainnet-v1.0"
        };

        public string GenesisId { get; set; } = "mainnet-v1.0";

        public string[] Hosts { get; set; } = new string[]{
            "http://a-td.algorand-mainnet.network:4160",
        };
    }
}
