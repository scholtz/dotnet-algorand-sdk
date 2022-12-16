
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class TxLease{

    [Newtonsoft.Json.JsonProperty("expiration", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Expiration {get;set;}


    [Newtonsoft.Json.JsonProperty("lease", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Lease {get;set;}


    [Newtonsoft.Json.JsonProperty("sender", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Sender {get;set;}

    
}


}
