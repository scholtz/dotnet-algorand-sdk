
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AccountAssetResponse{
    [Newtonsoft.Json.JsonProperty("asset-holding", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AssetHolding AssetHolding {get;set;}

    [Newtonsoft.Json.JsonProperty("created-asset", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AssetParams CreatedAsset {get;set;}


    [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Round {get;set;}

    
}


}
