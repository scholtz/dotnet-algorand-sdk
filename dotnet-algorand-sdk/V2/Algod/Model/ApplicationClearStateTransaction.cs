


using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model { 

    public abstract class ApplicationClearStateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong ApplicationId = 0;

        [JsonProperty(PropertyName = "apan")]
        public V2.Indexer.Model.OnCompletion OnCompletion = V2.Indexer.Model.OnCompletion.Clear;

        
    

    }
}
