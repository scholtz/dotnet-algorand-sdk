using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{
    [Serializable]
    [MessagePackObject]
    public partial class HeartBeatTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [MessagePack.Key("type")]
        public string type => "hb";


        [Newtonsoft.Json.JsonProperty("hb")]
        [MessagePack.Key("hb")]
        public HeartBeat? HeartBeat { get; set; }
    }
}
