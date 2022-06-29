
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class Asset{
    [Newtonsoft.Json.JsonProperty("created-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CreatedAtRound {get;set;}

    [Newtonsoft.Json.JsonProperty("deleted", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? Deleted {get;set;}

    [Newtonsoft.Json.JsonProperty("destroyed-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? DestroyedAtRound {get;set;}


    [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Index {get;set;}


    [Newtonsoft.Json.JsonProperty("params", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public AssetParams Params {get;set;}

    
}


}
