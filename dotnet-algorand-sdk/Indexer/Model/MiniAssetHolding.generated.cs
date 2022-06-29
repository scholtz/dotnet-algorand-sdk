
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class MiniAssetHolding{

    [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Address {get;set;}


    [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Amount {get;set;}

    [Newtonsoft.Json.JsonProperty("deleted", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? Deleted {get;set;}


    [Newtonsoft.Json.JsonProperty("is-frozen", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool IsFrozen {get;set;}

    [Newtonsoft.Json.JsonProperty("opted-in-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? OptedInAtRound {get;set;}

    [Newtonsoft.Json.JsonProperty("opted-out-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? OptedOutAtRound {get;set;}

    
}


}
