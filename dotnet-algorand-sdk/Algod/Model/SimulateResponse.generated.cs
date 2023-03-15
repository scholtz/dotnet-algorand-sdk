
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
public partial class SimulateResponse{

    [Newtonsoft.Json.JsonProperty("last-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The round immediately preceding this simulation. State changes through this round were used to run this simulation.")]
    [field:InspectorName(@"LastRound")]
    public ulong LastRound {get;set;}
#else
    public ulong LastRound {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("txn-groups", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"A result object for each transaction group that was simulated.")]
    [field:InspectorName(@"TxnGroups")]
    public System.Collections.Generic.List<SimulateTransactionGroupResult> TxnGroups {get;set;} = new System.Collections.Generic.List<SimulateTransactionGroupResult>();
#else
    public System.Collections.Generic.ICollection<SimulateTransactionGroupResult> TxnGroups {get;set;} = new System.Collections.ObjectModel.Collection<SimulateTransactionGroupResult>();
#endif

    [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The version of this response object.")]
    [field:InspectorName(@"Version")]
    public ulong Version {get;set;}
#else
    public ulong Version {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("would-succeed", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Indicates whether the simulated transactions would have succeeded during an actual submission. If any transaction fails or is missing a signature, this will be false.")]
    [field:InspectorName(@"WouldSucceed")]
    public bool WouldSucceed {get;set;}
#else
    public bool WouldSucceed {get;set;}
#endif


    
}


}
