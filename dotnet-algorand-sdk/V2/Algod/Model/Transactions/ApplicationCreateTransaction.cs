


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{

    public  class ApplicationCreateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apan")]
        [DefaultValue(OnCompletion.Noop)]
        public OnCompletion OnCompletion => OnCompletion.Noop;

        [JsonProperty(PropertyName = "apap", Required = Required.Always)]
        public TEALProgram ApprovalProgram = null;

        [JsonProperty(PropertyName = "apsu", Required = Required.Always)]
        public TEALProgram ClearStateProgram = null;

        [JsonProperty(PropertyName = "apgs",Required =Required.Always)]
        public StateSchema GlobalStateSchema = new StateSchema();

        [JsonProperty(PropertyName = "apls", Required = Required.Always)]
        public StateSchema LocalStateSchema = new StateSchema();

        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? ExtraProgramPages = 0;

      



    }
}
