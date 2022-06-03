


using Algorand.Utils;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

    public  class ApplicationCreateTransaction : ApplicationNoopTransaction
    {



      

        [JsonProperty(PropertyName = "apap", Required = Required.Always)]
        [JsonConverter(typeof(BytesConverter))]
        public TEALProgram ApprovalProgram { get; set; } = null;

        [JsonProperty(PropertyName = "apsu", Required = Required.Always)]
        [JsonConverter(typeof(BytesConverter))]
        public TEALProgram ClearStateProgram { get; set; } = null;

        [JsonProperty(PropertyName = "apgs",Required =Required.Always)]
        public StateSchema GlobalStateSchema { get; set; }

        [JsonProperty(PropertyName = "apls", Required = Required.Always)]
        public StateSchema LocalStateSchema { get; set; }

        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? ExtraProgramPages { get; set; } = 0;

        [JsonIgnore]
        public ulong? ApplicationIndex { get; internal set; }


    }
}
