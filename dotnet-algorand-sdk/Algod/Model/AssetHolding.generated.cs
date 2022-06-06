
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AssetHolding{

    [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Amount {get;set;}


    [Newtonsoft.Json.JsonProperty("asset-id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong AssetId {get;set;}


    [Newtonsoft.Json.JsonProperty("is-frozen", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool IsFrozen {get;set;}

    
}


}
