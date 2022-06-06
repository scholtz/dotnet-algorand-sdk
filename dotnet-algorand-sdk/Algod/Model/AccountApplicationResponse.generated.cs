
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AccountApplicationResponse{
    [Newtonsoft.Json.JsonProperty("app-local-state", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ApplicationLocalState AppLocalState {get;set;}

    [Newtonsoft.Json.JsonProperty("created-app", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ApplicationParams CreatedApp {get;set;}


    [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Round {get;set;}

    
}


}
