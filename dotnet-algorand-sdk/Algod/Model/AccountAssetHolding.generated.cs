
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
#if UNITY
    using UnityEngine;
#endif

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class AccountAssetHolding{

    [Newtonsoft.Json.JsonProperty("asset-holding", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"\[asset\] Details about the asset held by this account.

The raw account uses `AssetHolding` for this type.")]
    [field:InspectorName(@"AssetHolding")]
    public AssetHolding AssetHolding {get;set;}
#else
    public AssetHolding AssetHolding {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("asset-params", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"\[apar\] parameters of the asset held by this account.

The raw account uses `AssetParams` for this type.")]
    [field:InspectorName(@"AssetParams")]
    public AssetParams AssetParams {get;set;}
#else
    public AssetParams AssetParams {get;set;}
#endif


    
}


}
