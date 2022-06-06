
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class TransactionParametersResponse{

    [Newtonsoft.Json.JsonProperty("consensus-version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ConsensusVersion {get;set;}


    [Newtonsoft.Json.JsonProperty("fee", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Fee {get;set;}


    [Newtonsoft.Json.JsonProperty("genesis-hash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] GenesisHash {get;set;}


    [Newtonsoft.Json.JsonProperty("genesis-id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string GenesisId {get;set;}


    [Newtonsoft.Json.JsonProperty("last-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong LastRound {get;set;}


    [Newtonsoft.Json.JsonProperty("min-fee", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong MinFee {get;set;}

    
}


}
