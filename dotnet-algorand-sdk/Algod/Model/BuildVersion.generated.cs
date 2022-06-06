
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class BuildVersion{

    [Newtonsoft.Json.JsonProperty("branch", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Branch {get;set;}


    [Newtonsoft.Json.JsonProperty("build_number", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Build_number {get;set;}


    [Newtonsoft.Json.JsonProperty("channel", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Channel {get;set;}


    [Newtonsoft.Json.JsonProperty("commit_hash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Commit_hash {get;set;}


    [Newtonsoft.Json.JsonProperty("major", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Major {get;set;}


    [Newtonsoft.Json.JsonProperty("minor", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Minor {get;set;}

    
}


}
