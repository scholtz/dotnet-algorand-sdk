
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
  
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



        #endregion




        [JsonProperty(PropertyName = "snd")]
        public Address Sender = new Address();
       


        
        [JsonProperty(PropertyName = "fee")]
        [DefaultValue(0)]
        public ulong? Fee = 0;
  

        [JsonProperty(PropertyName = "fv")]
        [DefaultValue(0)]
        public ulong? FirstValid = 0;


        [JsonProperty(PropertyName = "lv")]
        [DefaultValue(0)]
        public ulong? LastValid = 0;


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



        [JsonProperty(PropertyName = "gh")]
        public Digest GenesisHash = new Digest();



        [JsonProperty(PropertyName = "grp")]
        public Digest Group = new Digest();



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


        [JsonProperty("rekey")]
        public Address RekeyTo = new Address();
        


        public bool Committed => ConfirmedRound.HasValue && ConfirmedRound > 0;
    }
}
