

using Algorand.Internal.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class ApplicationCallTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "appl";

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? ApplicationId = 0;

        [JsonProperty(PropertyName = "apan")]
        public V2.Indexer.Model.OnCompletion OnCompletion = V2.Indexer.Model.OnCompletion.Noop;


        [JsonProperty(PropertyName = "apat")]
        public List<Address> Accounts = new List<Address>();

        [JsonProperty(PropertyName = "apap")]
        public TEALProgram ApprovalProgram = null;

        [JsonProperty(PropertyName = "apaa")]
        public List<byte[]> ApplicationArgs = new List<byte[]>();

        [JsonProperty(PropertyName = "apsu")]
        public TEALProgram ClearStateProgram = null;


        [JsonProperty(PropertyName = "apfa")]
        public List<ulong> ForeignApps = new List<ulong>();

        [JsonProperty(PropertyName = "apas")]
        public List<ulong> ForeignAssets = new List<ulong>();

        [JsonProperty(PropertyName = "apgs")]
        public V2.Indexer.Model.StateSchema GlobalStateSchema = new V2.Indexer.Model.StateSchema();


        [JsonProperty(PropertyName = "apls")]
        public V2.Indexer.Model.StateSchema localStateSchema = new V2.Indexer.Model.StateSchema();


        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? extraProgramPages = 0;


        /// <summary>The application index if the transaction was found and it created an application.</summary>
        [JsonProperty("application-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? applicationIndex { set { ApplicationId = value; } }


        // ***


        /// <summary>\[ld\] Local state key/value changes for the application being executed by this transaction.</summary>
        [JsonProperty("local-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private System.Collections.Generic.ICollection<AccountStateDelta> localStateDelta_pending { set { LocalStateDelta = value; } }
        public System.Collections.Generic.ICollection<AccountStateDelta> LocalStateDelta { get; private set; }

        /// <summary>\[gd\] Global state key/value changes for the application being executed by this transaction.</summary>
        [JsonProperty("global-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private StateDelta globalStateDelta_pending { get; set; }
        [JsonIgnore]
        public StateDelta GlobalStateDelta { get; private set; }

        /// <summary>\[lg\] Logs for the application being executed by this transaction.</summary>
        [JsonProperty("logs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<byte[]> logs_pending { get; set; }
        public ICollection<byte[]> Logs { get; private set; }

        /// <summary>Inner transactions produced by application execution.</summary>
        [JsonProperty("inner-txns", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ICollection<Transaction> innerTxns_pending { get; set; }
        public ICollection<Transaction> InnerTxns { get; set; }

    }
}
