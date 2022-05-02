


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{

    public  class ApplicationUpdateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? ApplicationId = 0;

        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Update;

        [JsonProperty(PropertyName = "apap")]
        public TEALProgram ApprovalProgram = null;

        [JsonProperty(PropertyName = "apsu")]
        public TEALProgram ClearStateProgram = null;

        [JsonProperty(PropertyName = "apgs")]
        public StateSchema GlobalStateSchema = new StateSchema();

        [JsonProperty(PropertyName = "apls")]
        public StateSchema LocalStateSchema = new StateSchema();

        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? ExtraProgramPages = 0;






    }
}
