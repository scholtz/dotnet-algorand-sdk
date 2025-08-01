
namespace Algorand.Algod.Model.Transactions
{

    using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
    [MessagePack.MessagePackObject]
    public partial class AssetClawbackTransaction : AssetMovementsTransaction
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



        [Newtonsoft.Json.JsonProperty("arcv", Required = Newtonsoft.Json.Required.Always)]
        [MessagePack.Key("arcv")]
        [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AssetReceiver")]
    public Algorand.Address AssetReceiver {get;set;}
#else
        public Algorand.Address AssetReceiver { get; set; }
#endif



        [Newtonsoft.Json.JsonProperty("asnd", Required = Newtonsoft.Json.Required.Always)]
        [MessagePack.Key("asnd")]
        [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AssetSender")]
    public Algorand.Address AssetSender {get;set;}
#else
        public Algorand.Address AssetSender { get; set; }
#endif
    }
}
