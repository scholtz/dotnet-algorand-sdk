

using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
namespace Algorand.Algod.Model
{

    internal class ReturnedTransaction 
    {
        
        [JsonProperty("txn")]
        internal SignedTransaction Transaction { get; set; }

        /// <summary>The round where this transaction was confirmed, if present.</summary>
        [JsonProperty("confirmed-round", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal ulong? ConfirmedRound { get; set; }

        /// <summary>Indicates that the transaction was kicked out of this node's transaction pool (and specifies why that happened).  An empty string indicates the transaction wasn't kicked out of this node's txpool due to an error.
        /// <br/></summary>
        [JsonProperty("pool-error", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        internal string PoolError { get; set; }


        /// <summary>Rewards in microalgos applied to the receiver account.</summary>
        [JsonProperty("receiver-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal ulong? ReceiverRewards { get; set; }

        /// <summary>Rewards in microalgos applied to the sender account.</summary>
        [JsonProperty("sender-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal ulong? SenderRewards { get; set; }

        /// <summary>Rewards in microalgos applied to the close remainder to account.</summary>
        [JsonProperty("close-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal ulong? CloseRewards { get; set; }
        /// <summary>\[ld\] Local state key/value changes for the application being executed by this transaction.</summary>

        [JsonProperty("local-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal ICollection<AccountStateDelta> LocalStateDelta { get; set; }

        /// <summary>\[gd\] Global state key/value changes for the application being executed by this transaction.</summary>
        [JsonProperty("global-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal StateDelta GlobalStateDelta { get; set; }


        [JsonProperty("logs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal ICollection<byte[]> Logs { get; set; }


        /// <summary>Inner transactions produced by application execution.</summary>
        [JsonProperty("inner-txns", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        internal ICollection<IReturnableTransaction> InnerTxns { get; set; }


        /// <summary>The round where this transaction was confirmed, if present.</summary>
        [JsonProperty("application-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(0)]
        internal ulong? ApplicationIndex { get; set; }

        /// <summary>The number of the asset's unit that were transferred to the close-to address..</summary>
        [JsonProperty("asset-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(0)]
        internal ulong? AssetIndex { get; set; }


        /// <summary>The number of the asset's unit that were transferred to the close-to address..</summary>
        [JsonProperty("asset-closing-amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(0)]
        internal ulong? AssetClosingAmount { get; set; }




    }
}
