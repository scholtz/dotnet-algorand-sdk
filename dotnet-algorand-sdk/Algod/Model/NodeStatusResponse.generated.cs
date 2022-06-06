
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class NodeStatusResponse{
    [Newtonsoft.Json.JsonProperty("catchpoint", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Catchpoint {get;set;}

    [Newtonsoft.Json.JsonProperty("catchpoint-acquired-blocks", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CatchpointAcquiredBlocks {get;set;}

    [Newtonsoft.Json.JsonProperty("catchpoint-processed-accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CatchpointProcessedAccounts {get;set;}

    [Newtonsoft.Json.JsonProperty("catchpoint-total-accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CatchpointTotalAccounts {get;set;}

    [Newtonsoft.Json.JsonProperty("catchpoint-total-blocks", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CatchpointTotalBlocks {get;set;}

    [Newtonsoft.Json.JsonProperty("catchpoint-verified-accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CatchpointVerifiedAccounts {get;set;}


    [Newtonsoft.Json.JsonProperty("catchup-time", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CatchupTime {get;set;}

    [Newtonsoft.Json.JsonProperty("last-catchpoint", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string LastCatchpoint {get;set;}


    [Newtonsoft.Json.JsonProperty("last-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong LastRound {get;set;}


    [Newtonsoft.Json.JsonProperty("last-version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string LastVersion {get;set;}


    [Newtonsoft.Json.JsonProperty("next-version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string NextVersion {get;set;}


    [Newtonsoft.Json.JsonProperty("next-version-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong NextVersionRound {get;set;}


    [Newtonsoft.Json.JsonProperty("next-version-supported", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool NextVersionSupported {get;set;}


    [Newtonsoft.Json.JsonProperty("stopped-at-unsupported-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool StoppedAtUnsupportedRound {get;set;}


    [Newtonsoft.Json.JsonProperty("time-since-last-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TimeSinceLastRound {get;set;}

    
}


}
