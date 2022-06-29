
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionsResponse{

    [Newtonsoft.Json.JsonProperty("current-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CurrentRound {get;set;}

    [Newtonsoft.Json.JsonProperty("next-token", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string NextToken {get;set;}


    [Newtonsoft.Json.JsonProperty("transactions", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<Transaction> Transactions {get;set;} = new System.Collections.ObjectModel.Collection<Transaction>();

    
}


}
