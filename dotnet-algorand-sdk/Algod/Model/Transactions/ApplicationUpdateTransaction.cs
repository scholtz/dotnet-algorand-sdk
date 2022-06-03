


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

    public  class ApplicationUpdateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? ApplicationId { get; set; } = 0;

        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Update;

        [JsonProperty(PropertyName = "apap")]
        public TEALProgram ApprovalProgram { get; set; }

        [JsonProperty(PropertyName = "apsu")]
        public TEALProgram ClearStateProgram { get; set; }

        [JsonProperty(PropertyName = "apgs")]
        public StateSchema GlobalStateSchema { get; set; }

        [JsonProperty(PropertyName = "apls")]
        public StateSchema LocalStateSchema { get; set; }

        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? ExtraProgramPages { get; set; } = 0;


        public bool ShouldSerializeExtraProgramPages () => ExtraProgramPages!=null && ExtraProgramPages != 0;



    }
}
