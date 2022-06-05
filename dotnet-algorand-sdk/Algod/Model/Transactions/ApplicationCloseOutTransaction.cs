


using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{ 

    public partial  class ApplicationCloseOutTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Closeout;








    }
}
