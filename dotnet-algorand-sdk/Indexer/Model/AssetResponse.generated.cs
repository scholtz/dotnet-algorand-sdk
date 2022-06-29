
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class AssetResponse{

    [Newtonsoft.Json.JsonProperty("asset", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Asset Asset {get;set;}


    [Newtonsoft.Json.JsonProperty("current-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CurrentRound {get;set;}

    
}


}
