using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{
    public  class StateProofTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        public string type => "stpf";
    }
}
