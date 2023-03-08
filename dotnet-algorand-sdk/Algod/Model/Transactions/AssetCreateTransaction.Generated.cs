
namespace Algorand.Algod.Model.Transactions
{

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class AssetCreateTransaction : AssetConfigurationTransaction{

    [Newtonsoft.Json.JsonProperty("apar", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AssetParams")]
    public Algorand.Algod.Model.AssetParams AssetParams {get;set;}
#else
    public Algorand.Algod.Model.AssetParams AssetParams {get;set;}
#endif


    
}


}
