
namespace Algorand.Algod.Model
{

    /* DESIGN - Block as an entity was missing from Algod but it was visible in Indexer
     */

    using System = global::System;
    /// <summary>Block information.
    /// <br/>
    /// <br/>Definition:
    /// <br/>data/bookkeeping/block.go : Block</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Block
    {
        /// <summary>\[gh\] hash to which this block belongs.</summary>
        [Newtonsoft.Json.JsonProperty("gh")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] GenesisHash { get; set; }

        /// <summary>\[gen\] ID to which this block belongs.</summary>
        [Newtonsoft.Json.JsonProperty("gen")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string GenesisId { get; set; }

        /// <summary>\[prev\] Previous block hash.</summary>
        [Newtonsoft.Json.JsonProperty("prev")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string PreviousBlockHash { get; set; }

        /// <summary>\[fees\] accepts transaction fees, it can only spend to the incentive pool.</summary>
        [Newtonsoft.Json.JsonProperty("fees")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Address FeeSink { get; set; }

        /// <summary>\[rwcalr\] number of leftover MicroAlgos after the distribution of rewards-rate MicroAlgos for every reward unit in the next round.</summary>
        [Newtonsoft.Json.JsonProperty("rwcalcr")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong RewardsCalculationRound { get; set; }

        /// <summary>\[earn\] How many rewards, in MicroAlgos, have been distributed to each RewardUnit of MicroAlgos since genesis.</summary>
        [Newtonsoft.Json.JsonProperty("earn")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong RewardsLevel { get; set; }

        /// <summary>\[rwd\] accepts periodic injections from the fee-sink and continually redistributes them as rewards.</summary>
        [Newtonsoft.Json.JsonProperty("rwd")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string RewardsPool { get; set; }

        /// <summary>\[rate\] Number of new MicroAlgos added to the participation stake from rewards at the next round.</summary>
        [Newtonsoft.Json.JsonProperty("rate")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong RewardsRate { get; set; }

        /// <summary>\[frac\] Number of leftover MicroAlgos after the distribution of RewardsRate/rewardUnits MicroAlgos for every reward unit in the next round.</summary>
        [Newtonsoft.Json.JsonProperty("frac")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong RewardsResidue { get; set; }


        /// <summary>\[rnd\] Current round on which this block was appended to the chain.</summary>
        [Newtonsoft.Json.JsonProperty("rnd")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong Round { get; set; }

        /// <summary>\[seed\] Sortition seed.</summary>
        [Newtonsoft.Json.JsonProperty("seed")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] Seed { get; set; }

        /// <summary>\[ts\] Block creation timestamp in seconds since eposh</summary>
        [Newtonsoft.Json.JsonProperty("ts")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong Timestamp { get; set; }

        /// <summary>\[txns\] list of transactions corresponding to a given round.</summary>
        [Newtonsoft.Json.JsonProperty("txns", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SignedTransaction> Transactions { get; set; }

        /// <summary>\[txn\] TransactionsRoot authenticates the set of transactions appearing in the block. More specifically, it's the root of a merkle tree whose leaves are the block's Txids, in lexicographic order. For the empty block, it's 0. Note that the TxnRoot does not authenticate the signatures on the transactions, only the transactions themselves. Two blocks with the same transactions but in a different order and with different signatures will have the same TxnRoot.</summary>
        [Newtonsoft.Json.JsonProperty("txn")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] TransactionsRoot { get; set; }

        /// <summary>\[tc\] TxnCounter counts the number of transactions committed in the ledger, from the time at which support for this feature was introduced.
        /// <br/>
        /// <br/>Specifically, TxnCounter is the number of the next transaction that will be committed after this block.  It is 0 when no transactions have ever been committed (since TxnCounter started being supported).</summary>
        [Newtonsoft.Json.JsonProperty("tc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TxnCounter { get; set; }

        /// <summary>\[proto\] The current protocol version.</summary>
        [Newtonsoft.Json.JsonProperty("proto")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string CurrentProtocol { get; set; }

        //[Newtonsoft.Json.JsonProperty("upgrade-state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public BlockUpgradeState UpgradeState { get; set; }

        //[Newtonsoft.Json.JsonProperty("upgrade-vote", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public BlockUpgradeVote UpgradeVote { get; set; }


    }
}
