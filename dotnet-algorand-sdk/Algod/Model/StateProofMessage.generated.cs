
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class StateProofMessage{

    [Newtonsoft.Json.JsonProperty("BlockHeadersCommitment", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Blockheaderscommitment {get;set;}


    [Newtonsoft.Json.JsonProperty("FirstAttestedRound", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Firstattestedround {get;set;}


    [Newtonsoft.Json.JsonProperty("LastAttestedRound", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Lastattestedround {get;set;}


    [Newtonsoft.Json.JsonProperty("LnProvenWeight", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Lnprovenweight {get;set;}


    [Newtonsoft.Json.JsonProperty("VotersCommitment", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Voterscommitment {get;set;}

    
}


}
