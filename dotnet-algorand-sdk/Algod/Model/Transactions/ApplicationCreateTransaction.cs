


using Algorand.Utils;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{

    public  class ApplicationCreateTransaction : ApplicationNoopTransaction
    {



      

        [JsonProperty(PropertyName = "apap", Required = Required.Always)]
        [JsonConverter(typeof(BytesConverter))]
        public TEALProgram ApprovalProgram = null;

        [JsonProperty(PropertyName = "apsu", Required = Required.Always)]
        [JsonConverter(typeof(BytesConverter))]
        public TEALProgram ClearStateProgram = null;

        [JsonProperty(PropertyName = "apgs",Required =Required.Always)]
        public StateSchema GlobalStateSchema;

        [JsonProperty(PropertyName = "apls", Required = Required.Always)]
        public StateSchema LocalStateSchema;

        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? ExtraProgramPages = 0;

        [JsonIgnore]
        public ulong? ApplicationIndex { get; internal set; }


    }
}
