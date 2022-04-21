using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public abstract class Transaction
    {

        /* DESIGN - The Pending Transaction fields, apart from Pool Error, also belong to the Indexer model. 
         * They can therefore be seen as properties of a Transaction. For this reason they are included as properties of the
         * Transaction type.
         */
        #region Sent Transaction Properties
        /// <summary>The asset index if the transaction was found and it created an asset.</summary>
        [JsonProperty("asset-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? assetIndex { set { AssetIndex = value; } }
        [JsonIgnore]
        public ulong? AssetIndex { get; private set; }


        /// <summary>The application index if the transaction was found and it created an application.</summary>
        [JsonProperty("application-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? applicationIndex { set { ApplicationIndex = value; } }
        [JsonIgnore]
        public ulong? ApplicationIndex { get; private set; }

        /// <summary>Rewards in microalgos applied to the close remainder to account.</summary>
        [JsonProperty("close-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? closeRewards { set { CloseRewards = value;  } }
        [JsonIgnore]
        public ulong? CloseRewards { get; private set; }

        /// <summary>Closing amount for the transaction.</summary>
        [JsonProperty("closing-amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? closingAmount { set { ClosingAmount = value; } }
        [JsonIgnore]
        public ulong? ClosingAmount { get; private set; }

        /// <summary>The number of the asset's unit that were transferred to the close-to address.</summary>
        [JsonProperty("asset-closing-amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? assetClosingAmount { set { AssetClosingAmount = value; } }
        [JsonIgnore]
        public ulong? AssetClosingAmount { get; private set; }

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

        /// <summary>\[ld\] Local state key/value changes for the application being executed by this transaction.</summary>
        [JsonProperty("local-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private System.Collections.Generic.ICollection<AccountStateDelta> localStateDelta { set { LocalStateDelta = value; } }
        public System.Collections.Generic.ICollection<AccountStateDelta> LocalStateDelta { get; private set; }

        /// <summary>\[gd\] Global state key/value changes for the application being executed by this transaction.</summary>
        [JsonProperty("global-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private StateDelta globalStateDelta { get; set; }
        [JsonIgnore]
        public StateDelta GlobalStateDelta { get; private set; }

        /// <summary>\[lg\] Logs for the application being executed by this transaction.</summary>
        [JsonProperty("logs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<byte[]> logs { get; set; }
        public System.Collections.Generic.ICollection<byte[]> Logs { get; private set; }

        /// <summary>Inner transactions produced by application execution.</summary>
        [JsonProperty("inner-txns", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private System.Collections.Generic.ICollection<Transaction> innerTxns { get; set; }
        public System.Collections.Generic.ICollection<Transaction> InnerTxns { get; set; }

        #endregion

       


        [JsonProperty(PropertyName = "snd")]
        public Address sender = new Address();
        //@JsonProperty("fee")
        [JsonProperty(PropertyName = "fee")]
        [DefaultValue(0)]
        public ulong? fee = 0;
        //@JsonProperty("fv")
        [JsonProperty(PropertyName = "fv")]
        [DefaultValue(0)]
        public ulong? firstValid = 0;
        //@JsonProperty("lv")
        [JsonProperty(PropertyName = "lv")]
        [DefaultValue(0)]
        public ulong? lastValid = 0;
        //@JsonProperty("note")
        [JsonIgnore]
        private byte[] _note;
        [JsonProperty(PropertyName = "note")]
        public byte[] note
        {
            get
            {
                return _note;
            }
            set
            {
                if (value != null && value.Length > 0)
                    _note = value;
            }
        }

        [JsonProperty(PropertyName = "gen")]
        [DefaultValue("")]
        public string genesisID = "";
        [JsonProperty(PropertyName = "gh")]
        public Digest genesisHash = new Digest();
        [JsonProperty(PropertyName = "grp")]
        public Digest group = new Digest();
        [JsonIgnore]
        private byte[] _lease;
        [JsonProperty(PropertyName = "lx")]
        public byte[] lease
        {
            get
            {
                return _lease;
            }
            set
            {
                if (value != null && value.Length > 0)
                    _lease = value;
            }
        }
        [JsonProperty("rekey")]
        public Address RekeyTo = new Address();

            

        public bool Committed => ConfirmedRound.HasValue && ConfirmedRound > 0;
    }
}
