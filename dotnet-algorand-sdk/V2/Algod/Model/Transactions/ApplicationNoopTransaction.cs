


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{

    public  class ApplicationNoopTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? ApplicationId = 0;


        [JsonProperty(PropertyName = "apan")]
        public V2.Indexer.Model.OnCompletion OnCompletion => V2.Indexer.Model.OnCompletion.Noop;





    }
}
