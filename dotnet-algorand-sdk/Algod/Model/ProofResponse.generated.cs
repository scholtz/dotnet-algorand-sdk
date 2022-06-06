
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class ProofResponse{
    [Newtonsoft.Json.JsonProperty("hashtype", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Hashtype {get;set;}


    [Newtonsoft.Json.JsonProperty("idx", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Idx {get;set;}


    [Newtonsoft.Json.JsonProperty("proof", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Proof {get;set;}


    [Newtonsoft.Json.JsonProperty("stibhash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Stibhash {get;set;}


    [Newtonsoft.Json.JsonProperty("treedepth", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Treedepth {get;set;}

    
}


}
