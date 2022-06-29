
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class ApplicationLocalState{
    [Newtonsoft.Json.JsonProperty("closed-out-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ClosedOutAtRound {get;set;}

    [Newtonsoft.Json.JsonProperty("deleted", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? Deleted {get;set;}


    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Id {get;set;}

    [Newtonsoft.Json.JsonProperty("key-value", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<TealKeyValue> KeyValue {get;set;} = new System.Collections.ObjectModel.Collection<TealKeyValue>();

    [Newtonsoft.Json.JsonProperty("opted-in-at-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? OptedInAtRound {get;set;}


    [Newtonsoft.Json.JsonProperty("schema", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ApplicationStateSchema Schema {get;set;}

    
}


}
