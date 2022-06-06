
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class DryrunSource{

    [Newtonsoft.Json.JsonProperty("app-index", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong AppIndex {get;set;}


    [Newtonsoft.Json.JsonProperty("field-name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string FieldName {get;set;}


    [Newtonsoft.Json.JsonProperty("source", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Source {get;set;}


    [Newtonsoft.Json.JsonProperty("txn-index", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TxnIndex {get;set;}

    
}


}
