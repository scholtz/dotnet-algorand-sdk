


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{

    public abstract class ApplicationUpdateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? ApplicationId = 0;

        [JsonProperty(PropertyName = "apan")]
        public V2.Indexer.Model.OnCompletion OnCompletion => V2.Indexer.Model.OnCompletion.Update;

        [JsonProperty(PropertyName = "apap")]
        public TEALProgram ApprovalProgram = null;

        [JsonProperty(PropertyName = "apsu")]
        public TEALProgram ClearStateProgram = null;

        [JsonProperty(PropertyName = "apgs")]
        public V2.Indexer.Model.StateSchema GlobalStateSchema = new V2.Indexer.Model.StateSchema();

        [JsonProperty(PropertyName = "apls")]
        public V2.Indexer.Model.StateSchema localStateSchema = new V2.Indexer.Model.StateSchema();

        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? extraProgramPages = 0;






    }
}
