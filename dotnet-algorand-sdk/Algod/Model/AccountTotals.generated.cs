
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AccountTotals{

    [Newtonsoft.Json.JsonProperty("not-participating", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong NotParticipating {get;set;}


    [Newtonsoft.Json.JsonProperty("offline", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Offline {get;set;}


    [Newtonsoft.Json.JsonProperty("online", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Online {get;set;}


    [Newtonsoft.Json.JsonProperty("rewards-level", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong RewardsLevel {get;set;}

    
}


}
