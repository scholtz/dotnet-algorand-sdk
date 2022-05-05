

using Newtonsoft.Json;
using System.ComponentModel;
namespace Algorand.Algod.Model
{


    public  class CommittedTransaction 
    {
        [JsonProperty("txn")]
        private SignedTransaction transaction { set { Transaction = value; } }
        [JsonIgnore]
        public SignedTransaction Transaction { get; private set; }

        public bool FullyCommitted => (ConfirmedRound ?? 0 ) > 0;

        /// <summary>The round where this transaction was confirmed, if present.</summary>
        [JsonProperty("confirmed-round", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? confirmedRound { set { ConfirmedRound = value; } }
        [JsonIgnore]
        public ulong? ConfirmedRound { get; private set; }

        /// <summary>Indicates that the transaction was kicked out of this node's transaction pool (and specifies why that happened).  An empty string indicates the transaction wasn't kicked out of this node's txpool due to an error.
        /// <br/></summary>
        [JsonProperty("pool-error", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        private string poolError { set { PoolError = value; } }
        [JsonIgnore]
        public string PoolError { get; private set; }


        /// <summary>Rewards in microalgos applied to the receiver account.</summary>
        [JsonProperty("receiver-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? receiverRewards { set { ReceiverRewards = value; } }
        [JsonIgnore]
        public ulong? ReceiverRewards { get; private set; }

        /// <summary>Rewards in microalgos applied to the sender account.</summary>
        [JsonProperty("sender-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? senderRewards { set { SenderRewards = value; } }
        [JsonIgnore]
        public ulong? SenderRewards { get; private set; }

        /// <summary>Rewards in microalgos applied to the close remainder to account.</summary>
        [JsonProperty("close-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? closeRewards { set { CloseRewards = value; } }
        [JsonIgnore]
        public ulong? CloseRewards { get; private set; }

        protected CommittedTransaction(Transaction tx) { }

    }
}
