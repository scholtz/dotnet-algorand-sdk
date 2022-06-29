
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionAssetFreeze{

    [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Address {get;set;}


    [Newtonsoft.Json.JsonProperty("asset-id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong AssetId {get;set;}


    [Newtonsoft.Json.JsonProperty("new-freeze-status", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool NewFreezeStatus {get;set;}

    
}


}
