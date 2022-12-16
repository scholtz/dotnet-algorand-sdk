
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class LightBlockHeaderProof{

    [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Index {get;set;}


    [Newtonsoft.Json.JsonProperty("proof", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Proof {get;set;}


    [Newtonsoft.Json.JsonProperty("treedepth", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Treedepth {get;set;}

    
}


}
