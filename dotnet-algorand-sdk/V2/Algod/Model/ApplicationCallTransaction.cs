


using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model { 

    public abstract class ApplicationCallTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "appl";

        

        [JsonProperty(PropertyName = "apat")]
        public List<Address> Accounts = new List<Address>();

        [JsonProperty(PropertyName = "apaa")]
        public List<byte[]> ApplicationArgs = new List<byte[]>();
        
        [JsonProperty(PropertyName = "apfa")]
        public List<ulong> ForeignApps = new List<ulong>();

        [JsonProperty(PropertyName = "apas")]
        public List<ulong> ForeignAssets = new List<ulong>();

        /// <summary>\[ld\] Local state key/value changes for the application being executed by this transaction.</summary>
        [JsonIgnore]
        public ICollection<AccountStateDelta> LocalStateDelta { get; private set; }
        
        [JsonProperty("local-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ICollection<AccountStateDelta> localStateDelta_pending { set { LocalStateDelta = value; } }

        [JsonIgnore]
        public StateDelta GlobalStateDelta { get; private set; }
        /// <summary>\[gd\] Global state key/value changes for the application being executed by this transaction.</summary>
        [JsonProperty("global-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private StateDelta globalStateDelta_pending { set { GlobalStateDelta = value; } }
        
        /// <summary>\[lg\] Logs for the application being executed by this transaction.</summary>
        public ICollection<byte[]> Logs { get; private set; }
        [JsonProperty("logs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ICollection<byte[]> logs_pending { set { Logs = value; } }

        public ICollection<Transaction> InnerTxns { get; private set; }
        /// <summary>Inner transactions produced by application execution.</summary>
        [JsonProperty("inner-txns", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ICollection<Transaction> innerTxns_pending { get; set; }



    }
}
