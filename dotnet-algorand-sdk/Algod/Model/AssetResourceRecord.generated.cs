
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AssetResourceRecord{

    [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Address {get;set;}


    [Newtonsoft.Json.JsonProperty("asset-deleted", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool AssetDeleted {get;set;}

    [Newtonsoft.Json.JsonProperty("asset-holding", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AssetHolding AssetHolding {get;set;}


    [Newtonsoft.Json.JsonProperty("asset-holding-deleted", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool AssetHoldingDeleted {get;set;}


    [Newtonsoft.Json.JsonProperty("asset-index", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong AssetIndex {get;set;}

    [Newtonsoft.Json.JsonProperty("asset-params", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AssetParams AssetParams {get;set;}

    
}


}
