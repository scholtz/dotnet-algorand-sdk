
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
#if UNITY
    using UnityEngine;
#endif

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class NodeStatusResponse{

    [Newtonsoft.Json.JsonProperty("catchpoint", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The current catchpoint that is being caught up to")]
    [field:InspectorName(@"Catchpoint")]
    public string Catchpoint {get;set;}
#else
    public string Catchpoint {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-acquired-blocks", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The number of blocks that have already been obtained by the node as part of the catchup")]
    [field:InspectorName(@"CatchpointAcquiredBlocks")]
    public ulong CatchpointAcquiredBlocks {get;set;}
#else
    public ulong? CatchpointAcquiredBlocks {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-processed-accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The number of accounts from the current catchpoint that have been processed so far as part of the catchup")]
    [field:InspectorName(@"CatchpointProcessedAccounts")]
    public ulong CatchpointProcessedAccounts {get;set;}
#else
    public ulong? CatchpointProcessedAccounts {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-processed-kvs", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The number of key-values (KVs) from the current catchpoint that have been processed so far as part of the catchup")]
    [field:InspectorName(@"CatchpointProcessedKvs")]
    public ulong CatchpointProcessedKvs {get;set;}
#else
    public ulong? CatchpointProcessedKvs {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-total-accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The total number of accounts included in the current catchpoint")]
    [field:InspectorName(@"CatchpointTotalAccounts")]
    public ulong CatchpointTotalAccounts {get;set;}
#else
    public ulong? CatchpointTotalAccounts {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-total-blocks", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The total number of blocks that are required to complete the current catchpoint catchup")]
    [field:InspectorName(@"CatchpointTotalBlocks")]
    public ulong CatchpointTotalBlocks {get;set;}
#else
    public ulong? CatchpointTotalBlocks {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-total-kvs", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The total number of key-values (KVs) included in the current catchpoint")]
    [field:InspectorName(@"CatchpointTotalKvs")]
    public ulong CatchpointTotalKvs {get;set;}
#else
    public ulong? CatchpointTotalKvs {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-verified-accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The number of accounts from the current catchpoint that have been verified so far as part of the catchup")]
    [field:InspectorName(@"CatchpointVerifiedAccounts")]
    public ulong CatchpointVerifiedAccounts {get;set;}
#else
    public ulong? CatchpointVerifiedAccounts {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchpoint-verified-kvs", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The number of key-values (KVs) from the current catchpoint that have been verified so far as part of the catchup")]
    [field:InspectorName(@"CatchpointVerifiedKvs")]
    public ulong CatchpointVerifiedKvs {get;set;}
#else
    public ulong? CatchpointVerifiedKvs {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("catchup-time", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"CatchupTime in nanoseconds")]
    [field:InspectorName(@"CatchupTime")]
    public ulong CatchupTime {get;set;}
#else
    public ulong CatchupTime {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("last-catchpoint", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The last catchpoint seen by the node")]
    [field:InspectorName(@"LastCatchpoint")]
    public string LastCatchpoint {get;set;}
#else
    public string LastCatchpoint {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("last-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"LastRound indicates the last round seen")]
    [field:InspectorName(@"LastRound")]
    public ulong LastRound {get;set;}
#else
    public ulong LastRound {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("last-version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"LastVersion indicates the last consensus version supported")]
    [field:InspectorName(@"LastVersion")]
    public string LastVersion {get;set;}
#else
    public string LastVersion {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("next-version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"NextVersion of consensus protocol to use")]
    [field:InspectorName(@"NextVersion")]
    public string NextVersion {get;set;}
#else
    public string NextVersion {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("next-version-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"NextVersionRound is the round at which the next consensus version will apply")]
    [field:InspectorName(@"NextVersionRound")]
    public ulong NextVersionRound {get;set;}
#else
    public ulong NextVersionRound {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("next-version-supported", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"NextVersionSupported indicates whether the next consensus version is supported by this node")]
    [field:InspectorName(@"NextVersionSupported")]
    public bool NextVersionSupported {get;set;}
#else
    public bool NextVersionSupported {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("stopped-at-unsupported-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"StoppedAtUnsupportedRound indicates that the node does not support the new rounds and has stopped making progress")]
    [field:InspectorName(@"StoppedAtUnsupportedRound")]
    public bool StoppedAtUnsupportedRound {get;set;}
#else
    public bool StoppedAtUnsupportedRound {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("time-since-last-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"TimeSinceLastRound in nanoseconds")]
    [field:InspectorName(@"TimeSinceLastRound")]
    public ulong TimeSinceLastRound {get;set;}
#else
    public ulong TimeSinceLastRound {get;set;}
#endif


    
}


}
