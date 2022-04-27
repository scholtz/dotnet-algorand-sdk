


using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model { 

    public abstract class ApplicationCreateTransaction : ApplicationCallTransaction
    {



        [JsonProperty(PropertyName = "apan")]
        [DefaultValue(V2.Indexer.Model.OnCompletion.Noop)]
        public V2.Indexer.Model.OnCompletion OnCompletion = V2.Indexer.Model.OnCompletion.Noop; 
        
        [JsonProperty(PropertyName = "apap")]
        public TEALProgram ApprovalProgram = null;
        
        [JsonProperty(PropertyName = "apsu")]
        public TEALProgram ClearStateProgram = null;

        [JsonProperty(PropertyName = "apgs")]
        public V2.Indexer.Model.StateSchema GlobalStateSchema = new V2.Indexer.Model.StateSchema();

        [JsonProperty(PropertyName = "apls")]
        public V2.Indexer.Model.StateSchema LocalStateSchema = new V2.Indexer.Model.StateSchema();

        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? ExtraProgramPages = 0;



    }
}
