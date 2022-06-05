


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

    public partial class ApplicationUpdateTransaction : ApplicationCallTransaction
    {
        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Update;




    }
}
