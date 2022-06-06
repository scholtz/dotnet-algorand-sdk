
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class CertifiedBlock{

    [Newtonsoft.Json.JsonProperty("block", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Block Block {get;set;}

    [Newtonsoft.Json.JsonProperty("cert", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Cert {get;set;}

    
}


}
