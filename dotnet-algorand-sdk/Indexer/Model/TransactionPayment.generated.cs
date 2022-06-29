
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionPayment{

    [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Amount {get;set;}

    [Newtonsoft.Json.JsonProperty("close-amount", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CloseAmount {get;set;}

    [Newtonsoft.Json.JsonProperty("close-remainder-to", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string CloseRemainderTo {get;set;}


    [Newtonsoft.Json.JsonProperty("receiver", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Receiver {get;set;}

    
}


}
