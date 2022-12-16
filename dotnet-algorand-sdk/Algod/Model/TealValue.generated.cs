
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class TealValue{

    [Newtonsoft.Json.JsonProperty("bytes", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Bytes {get;set;}


    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Type {get;set;}


    [Newtonsoft.Json.JsonProperty("uint", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Uint {get;set;}

    
}


}
