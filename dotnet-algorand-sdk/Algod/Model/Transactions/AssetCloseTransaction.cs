using Algorand.Algod.Model.Converters.MsgPack;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{
    [MessagePackObject]
    [MessagePackFormatter(typeof(NoDefaultsFormatter<AssetCloseTransaction>))]
    public class AssetCloseTransaction : AssetMovementsTransaction
    {
        

        [Newtonsoft.Json.JsonProperty("aclose", Required = Newtonsoft.Json.Required.Always)]
        [MessagePack.Key("aclose")]
        [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AssetCloseTo")]
    public Algorand.Address AssetCloseTo {get;set;}
#else
        public Algorand.Address AssetCloseTo { get; set; }
#endif

        

    }
}
