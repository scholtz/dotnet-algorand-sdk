
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class AccountResponse{

    [Newtonsoft.Json.JsonProperty("account", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Account Account {get;set;}


    [Newtonsoft.Json.JsonProperty("current-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CurrentRound {get;set;}

    
}


}
