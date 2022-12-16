
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AppResourceRecord{

    [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Address {get;set;}


    [Newtonsoft.Json.JsonProperty("app-deleted", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool AppDeleted {get;set;}


    [Newtonsoft.Json.JsonProperty("app-index", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong AppIndex {get;set;}

    [Newtonsoft.Json.JsonProperty("app-local-state", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ApplicationLocalState AppLocalState {get;set;}


    [Newtonsoft.Json.JsonProperty("app-local-state-deleted", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool AppLocalStateDeleted {get;set;}

    [Newtonsoft.Json.JsonProperty("app-params", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ApplicationParams AppParams {get;set;}

    
}


}
