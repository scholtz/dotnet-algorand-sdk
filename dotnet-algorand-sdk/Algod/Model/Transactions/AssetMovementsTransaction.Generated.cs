
namespace Algorand.Algod.Model.Transactions
{

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class AssetMovementsTransaction : Transaction{

    



    [Newtonsoft.Json.JsonProperty("xaid", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"XferAsset")]
    public ulong XferAsset {get;set;}
#else
    public ulong XferAsset {get;set;}
#endif


    
}


}
