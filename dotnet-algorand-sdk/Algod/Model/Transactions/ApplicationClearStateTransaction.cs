


using JsonSubTypes;
using Newtonsoft.Json;

using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions {

    [MessagePack.MessagePackObject]
    public partial  class ApplicationClearStateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apan")]
        [MessagePack.Key("apan")]
        public OnCompletion OnCompletion => OnCompletion.Clear;
    }
}
