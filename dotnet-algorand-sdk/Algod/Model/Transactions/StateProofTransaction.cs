using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{
    [MessagePackObject]
    public  class StateProofTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        [MessagePack.Key("type")]
        public string type => "stpf";
    }
}
