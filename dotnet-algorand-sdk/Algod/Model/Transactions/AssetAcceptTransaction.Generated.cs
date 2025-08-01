
namespace Algorand.Algod.Model.Transactions
{

    using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
    public partial class AssetAcceptTransaction : AssetMovementsTransaction
    {

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
