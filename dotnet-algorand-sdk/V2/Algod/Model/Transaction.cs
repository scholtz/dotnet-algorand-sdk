using Algorand.Internal.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    [JsonConverter(typeof(JsonPathConverter))] //TODO - make this a JsonPathConverterForPending/Raw/IndexerTransaction and make it check if 
    //the TXN property is there.
    public abstract class Transaction
    {

        /* DESIGN - The Pending Transaction fields, apart from Pool Error, also belong to the Indexer model. 
         * They can therefore be seen as properties of a Transaction. For this reason they are included as properties of the
         * Transaction type.
         */
        #region Sent Transaction Properties
      
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


        //TODO - Are rewards only payment txn ?

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

        //endtodo

     

        #endregion

       


        [JsonProperty(PropertyName = "snd")]
        public Address Sender = new Address();
       
        [JsonProperty("sender")] //, Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        private Address sender { set { Sender = value; } }

        
        [JsonProperty(PropertyName = "fee")]
        [DefaultValue(0)]
        public ulong? Fee = 0;
  

        [JsonProperty(PropertyName = "fv")]
        [DefaultValue(0)]
        public ulong? FirstValid = 0;
        [JsonProperty("first-valid")] //, Required = Newtonsoft.Json.Required.Always)]
        private ulong? firstValid { set { FirstValid = value; } }

        [JsonProperty(PropertyName = "lv")]
        [DefaultValue(0)]
        public ulong? LastValid = 0;
        [JsonProperty("last-valid")] //, Required = Newtonsoft.Json.Required.Always)]
        private ulong lastValid { set { LastValid = value; } }

        [JsonIgnore]
        private byte[] _note;
        [JsonProperty(PropertyName = "note")]
        public byte[] Note
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
        public string GenesisID = "";
        /// <summary>\[gen\] genesis block ID.</summary>
        [JsonProperty("genesis-id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        private string genesisId { set { GenesisID = value; } }


        [JsonProperty(PropertyName = "gh")]
        public Digest GenesisHash = new Digest();

        [JsonProperty("genesis-hash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Digest genesisHash { set { GenesisHash = value; } }


        [JsonProperty(PropertyName = "grp")]
        public Digest Group = new Digest();
        [JsonProperty("group", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Digest group { set { Group = value; } } //this might need Digest being defined as a type in the json, for codegen


        [JsonIgnore]
        private byte[] _lease;
        [JsonProperty(PropertyName = "lx")]
        public byte[] Lease
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
        [JsonProperty("lease", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte[] lease { set { Lease = value; } }

        [JsonProperty("rekey")]
        public Address RekeyTo = new Address();
        
        [JsonProperty("rekey-to", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Address rekeyTo { set { RekeyTo = value; } }

        public bool Committed => ConfirmedRound.HasValue && ConfirmedRound > 0;
    }
}
