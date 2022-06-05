


using JsonSubTypes;
using Newtonsoft.Json;

using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions { 


    public partial  class ApplicationClearStateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Clear;




    }
}
