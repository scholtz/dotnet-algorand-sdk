
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class Asset{

    [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Index {get;set;}


    [Newtonsoft.Json.JsonProperty("params", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public AssetParams Params {get;set;}

    
}


}
