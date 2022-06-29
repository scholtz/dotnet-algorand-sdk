
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionResponse{

    [Newtonsoft.Json.JsonProperty("current-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CurrentRound {get;set;}


    [Newtonsoft.Json.JsonProperty("transaction", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Transaction Transaction {get;set;}

    
}


}
