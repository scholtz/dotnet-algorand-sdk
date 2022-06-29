
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class Application{
    [Newtonsoft.Json.JsonProperty("created-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CreatedAtRound {get;set;}

    [Newtonsoft.Json.JsonProperty("deleted", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? Deleted {get;set;}

    [Newtonsoft.Json.JsonProperty("deleted-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? DeletedAtRound {get;set;}


    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Id {get;set;}


    [Newtonsoft.Json.JsonProperty("params", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ApplicationParams Params {get;set;}

    
}


}
