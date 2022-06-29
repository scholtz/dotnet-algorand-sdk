
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class BlockRewards{

    [Newtonsoft.Json.JsonProperty("fee-sink", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string FeeSink {get;set;}


    [Newtonsoft.Json.JsonProperty("rewards-calculation-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong RewardsCalculationRound {get;set;}


    [Newtonsoft.Json.JsonProperty("rewards-level", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong RewardsLevel {get;set;}


    [Newtonsoft.Json.JsonProperty("rewards-pool", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string RewardsPool {get;set;}


    [Newtonsoft.Json.JsonProperty("rewards-rate", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong RewardsRate {get;set;}


    [Newtonsoft.Json.JsonProperty("rewards-residue", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong RewardsResidue {get;set;}

    
}


}
