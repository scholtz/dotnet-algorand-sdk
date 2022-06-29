
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class ApplicationLogData{

    [Newtonsoft.Json.JsonProperty("logs", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<byte[]> Logs {get;set;} = new System.Collections.ObjectModel.Collection<byte[]>();


    [Newtonsoft.Json.JsonProperty("txid", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Txid {get;set;}

    
}


}
