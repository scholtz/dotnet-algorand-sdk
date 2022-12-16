
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class PostTransactionsResponse{

    [Newtonsoft.Json.JsonProperty("txId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Txid {get;set;}

    
}


}
