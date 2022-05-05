


using JsonSubTypes;
using Newtonsoft.Json;

using System.ComponentModel;

namespace Algorand.Algod.Model { 


    public  class ApplicationClearStateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong ApplicationId = 0;

        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Clear;

        
    

    }
}
