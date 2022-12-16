
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class ModifiedAsset{

    [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool Created {get;set;}


    [Newtonsoft.Json.JsonProperty("creator", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Creator {get;set;}


    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Id {get;set;}

    
}


}
