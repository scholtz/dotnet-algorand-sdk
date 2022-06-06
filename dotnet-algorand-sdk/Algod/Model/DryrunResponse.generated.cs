
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class DryrunResponse{

    [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Error {get;set;}


    [Newtonsoft.Json.JsonProperty("protocol-version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ProtocolVersion {get;set;}


    [Newtonsoft.Json.JsonProperty("txns", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<DryrunTxnResult> Txns {get;set;} = new System.Collections.ObjectModel.Collection<DryrunTxnResult>();

    
}


}
