
namespace Algorand.Algod.Model.Transactions
{

    using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
    public partial class AssetTransferTransaction : AssetMovementsTransaction
    {

        [Newtonsoft.Json.JsonProperty("aamt", Required = Newtonsoft.Json.Required.Always)]
        [MessagePack.Key("aamt")]
        [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AssetAmount")]
    public ulong AssetAmount {get;set;}
#else
        public ulong AssetAmount { get; set; }
#endif



        [Newtonsoft.Json.JsonProperty("aclose", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("aclose")]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AssetCloseTo")]
    public Algorand.Address AssetCloseTo {get;set;}
#else
        public Algorand.Address AssetCloseTo { get; set; }
#endif



        [Newtonsoft.Json.JsonProperty("arcv", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [MessagePack.Key("arcv")]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AssetReceiver")]
    public Algorand.Address AssetReceiver {get;set;}
#else
        public Algorand.Address AssetReceiver { get; set; }
#endif



    }


}
