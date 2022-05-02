
namespace Algorand.V2.Algod.Model
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
        [Newtonsoft.Json.JsonProperty("genesis-hash")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] GenesisHash { get; set; }

        /// <summary>\[gen\] ID to which this block belongs.</summary>
        [Newtonsoft.Json.JsonProperty("genesis-id")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string GenesisId { get; set; }

        /// <summary>\[prev\] Previous block hash.</summary>
        [Newtonsoft.Json.JsonProperty("previous-block-hash")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] PreviousBlockHash { get; set; }

        [Newtonsoft.Json.JsonProperty("rewards", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BlockRewards Rewards { get; set; }

        /// <summary>\[rnd\] Current round on which this block was appended to the chain.</summary>
        [Newtonsoft.Json.JsonProperty("round")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong Round { get; set; }

        /// <summary>\[seed\] Sortition seed.</summary>
        [Newtonsoft.Json.JsonProperty("seed")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] Seed { get; set; }

        /// <summary>\[ts\] Block creation timestamp in seconds since eposh</summary>
        [Newtonsoft.Json.JsonProperty("timestamp")] //, Required = Newtonsoft.Json.Required.Always)]
        public ulong Timestamp { get; set; }

        /// <summary>\[txns\] list of transactions corresponding to a given round.</summary>
        [Newtonsoft.Json.JsonProperty("transactions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Transaction> Transactions { get; set; }

        /// <summary>\[txn\] TransactionsRoot authenticates the set of transactions appearing in the block. More specifically, it's the root of a merkle tree whose leaves are the block's Txids, in lexicographic order. For the empty block, it's 0. Note that the TxnRoot does not authenticate the signatures on the transactions, only the transactions themselves. Two blocks with the same transactions but in a different order and with different signatures will have the same TxnRoot.</summary>
        [Newtonsoft.Json.JsonProperty("transactions-root")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] TransactionsRoot { get; set; }

        /// <summary>\[tc\] TxnCounter counts the number of transactions committed in the ledger, from the time at which support for this feature was introduced.
        /// <br/>
        /// <br/>Specifically, TxnCounter is the number of the next transaction that will be committed after this block.  It is 0 when no transactions have ever been committed (since TxnCounter started being supported).</summary>
        [Newtonsoft.Json.JsonProperty("txn-counter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TxnCounter { get; set; }

        [Newtonsoft.Json.JsonProperty("upgrade-state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BlockUpgradeState UpgradeState { get; set; }

        [Newtonsoft.Json.JsonProperty("upgrade-vote", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BlockUpgradeVote UpgradeVote { get; set; }


    }
}
