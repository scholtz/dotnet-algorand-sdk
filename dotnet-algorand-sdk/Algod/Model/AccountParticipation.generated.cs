
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AccountParticipation{

    [Newtonsoft.Json.JsonProperty("selection-participation-key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] SelectionParticipationKey {get;set;}

    [Newtonsoft.Json.JsonProperty("state-proof-key", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] StateProofKey {get;set;}


    [Newtonsoft.Json.JsonProperty("vote-first-valid", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong VoteFirstValid {get;set;}


    [Newtonsoft.Json.JsonProperty("vote-key-dilution", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong VoteKeyDilution {get;set;}


    [Newtonsoft.Json.JsonProperty("vote-last-valid", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong VoteLastValid {get;set;}


    [Newtonsoft.Json.JsonProperty("vote-participation-key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] VoteParticipationKey {get;set;}

    
}


}
