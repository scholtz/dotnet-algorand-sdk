
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
#if UNITY
    using UnityEngine;
#endif

    /* DESIGN - Block as an entity was missing from Algod but it was visible in Indexer
     */

    using System = global::System;
    /// <summary>Block information.
    /// <br/>
    /// <br/>Definition:
    /// <br/>data/bookkeeping/block.go : Block</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
#if UNITY
[System.Serializable]
#endif
    public partial class Block
    {
        /// <summary>\[gh\] hash to which this block belongs.</summary>
        [Newtonsoft.Json.JsonProperty("gh")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"hash to which this block belongs")]
    [field:InspectorName(@"GenesisHash")]  
#endif
        public byte[] GenesisHash { get; set; }

        /// <summary>\[gen\] ID to which this block belongs.</summary>
        [Newtonsoft.Json.JsonProperty("gen")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"ID to which this block belongs.")]
    [field:InspectorName(@"GenesisId")]  
#endif
        public string GenesisId { get; set; }

        /// <summary>\[prev\] Previous block hash.</summary>
        [Newtonsoft.Json.JsonProperty("prev")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Previous block hash.")]
    [field:InspectorName(@"PreviousBlockHash")]  
#endif
        public string PreviousBlockHash { get; set; }

        /// <summary>\[fees\] accepts transaction fees, it can only spend to the incentive pool.</summary>
        [Newtonsoft.Json.JsonProperty("fees")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"accepts transaction fees, it can only spend to the incentive pool.")]
    [field:InspectorName(@"FeeSink")]  
#endif
        public Address FeeSink { get; set; }

        /// <summary>\[rwcalr\] number of leftover MicroAlgos after the distribution of rewards-rate MicroAlgos for every reward unit in the next round.</summary>
        [Newtonsoft.Json.JsonProperty("rwcalcr")] //, Required = Newtonsoft.Json.Required.Always)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"number of leftover MicroAlgos after the distribution of rewards-rate MicroAlgos")]
    [field:InspectorName(@"RewardsCalculationRound")]  
#endif
        public ulong RewardsCalculationRound { get; set; }

        /// <summary>\[earn\] How many rewards, in MicroAlgos, have been distributed to each RewardUnit of MicroAlgos since genesis.</summary>
        [Newtonsoft.Json.JsonProperty("earn")] //, Required = Newtonsoft.Json.Required.Always)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"How many rewards, in MicroAlgos, have been distributed to each RewardUnit of MicroAlgos since genesis")]
    [field:InspectorName(@"RewardsLevel")]  
#endif
        public ulong RewardsLevel { get; set; }

        /// <summary>\[rwd\] accepts periodic injections from the fee-sink and continually redistributes them as rewards.</summary>
        [Newtonsoft.Json.JsonProperty("rwd")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@" accepts periodic injections from the fee-sink and continually redistributes them as rewards")]
    [field:InspectorName(@"RewardsPool")]  
#endif
        public string RewardsPool { get; set; }

        /// <summary>\[rate\] Number of new MicroAlgos added to the participation stake from rewards at the next round.</summary>
        [Newtonsoft.Json.JsonProperty("rate")] //, Required = Newtonsoft.Json.Required.Always)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@" Number of new MicroAlgos added to the participation stake from rewards at the next round")]
    [field:InspectorName(@"RewardsRate")]  
#endif
        public ulong RewardsRate { get; set; }

        /// <summary>\[frac\] Number of leftover MicroAlgos after the distribution of RewardsRate/rewardUnits MicroAlgos for every reward unit in the next round.</summary>
        [Newtonsoft.Json.JsonProperty("frac")] //, Required = Newtonsoft.Json.Required.Always)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@" Number of leftover MicroAlgos after the distribution of RewardsRate/rewardUnits MicroAlgos for every reward unit in the next round")]
    [field:InspectorName(@"RewardsResidue")]  
#endif
        public ulong RewardsResidue { get; set; }


        /// <summary>\[rnd\] Current round on which this block was appended to the chain.</summary>
        [Newtonsoft.Json.JsonProperty("rnd")] //, Required = Newtonsoft.Json.Required.Always)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"  Current round on which this block was appended to the chain")]
    [field:InspectorName(@"Round")]  
#endif
        public ulong Round { get; set; }

        /// <summary>\[seed\] Sortition seed.</summary>
        [Newtonsoft.Json.JsonProperty("seed")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"  Sortition seed.")]
    [field:InspectorName(@"Seed")]  
#endif
        public byte[] Seed { get; set; }

        /// <summary>\[ts\] Block creation timestamp in seconds since eposh</summary>
        [Newtonsoft.Json.JsonProperty("ts")] //, Required = Newtonsoft.Json.Required.Always)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"  Block creation timestamp as unix time")]
    [field:InspectorName(@"Timestamp")]  
#endif
        public ulong Timestamp { get; set; }

        /// <summary>\[txns\] list of transactions corresponding to a given round.</summary>
        [Newtonsoft.Json.JsonProperty("txns", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"  list of transactions corresponding to a given round.")]
    [field:InspectorName(@"Transactions")]  
    public System.Collections.Generic.List<SignedTransaction> Transactions { get; set; }
#else
        public System.Collections.Generic.ICollection<SignedTransaction> Transactions { get; set; }
#endif
        /// <summary>\[txn\] TransactionsRoot authenticates the set of transactions appearing in the block. More specifically, it's the root of a merkle tree whose leaves are the block's Txids, in lexicographic order. For the empty block, it's 0. Note that the TxnRoot does not authenticate the signatures on the transactions, only the transactions themselves. Two blocks with the same transactions but in a different order and with different signatures will have the same TxnRoot.</summary>
        [Newtonsoft.Json.JsonProperty("txn")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@" TransactionsRoot authenticates the set of transactions appearing in the block. ")]
    [field:InspectorName(@"TransactionsRoot")]  
#endif
        public byte[] TransactionsRoot { get; set; }

        /// <summary>\[tc\] TxnCounter counts the number of transactions committed in the ledger, from the time at which support for this feature was introduced.
        /// <br/>
        /// <br/>Specifically, TxnCounter is the number of the next transaction that will be committed after this block.  It is 0 when no transactions have ever been committed (since TxnCounter started being supported).</summary>
        [Newtonsoft.Json.JsonProperty("tc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"  Counts the number of transactions committed in the ledger, from the time at which support for this feature was introduced")]
    [field:InspectorName(@"TxnCounter")]  
    public int TxnCounter { get; set; }
#else
        public ulong? TxnCounter { get; set; }
#endif


        /// <summary>\[proto\] The current protocol version.</summary>
        [Newtonsoft.Json.JsonProperty("proto")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@" he current protocol version ")]
    [field:InspectorName(@"CurrentProtocol")]  
#endif
        public string CurrentProtocol { get; set; }

        //[Newtonsoft.Json.JsonProperty("upgrade-state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public BlockUpgradeState UpgradeState { get; set; }

        //[Newtonsoft.Json.JsonProperty("upgrade-vote", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public BlockUpgradeVote UpgradeVote { get; set; }


    }
}
