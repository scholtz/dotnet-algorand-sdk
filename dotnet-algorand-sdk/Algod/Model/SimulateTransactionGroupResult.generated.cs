
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
public partial class SimulateTransactionGroupResult{

    [Newtonsoft.Json.JsonProperty("failed-at", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"If present, indicates which transaction in this group caused the failure. This array represents the path to the failing transaction. Indexes are zero based, the first element indicates the top-level transaction, and successive elements indicate deeper inner transactions.")]
    [field:InspectorName(@"FailedAt")]
    public System.Collections.Generic.List<ulong> FailedAt {get;set;} = new System.Collections.Generic.List<ulong>();
#else
    public System.Collections.Generic.ICollection<ulong> FailedAt {get;set;} = new System.Collections.ObjectModel.Collection<ulong>();
#endif

    [Newtonsoft.Json.JsonProperty("failure-message", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"If present, indicates that the transaction group failed and specifies why that happened")]
    [field:InspectorName(@"FailureMessage")]
    public string FailureMessage {get;set;}
#else
    public string FailureMessage {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("txn-results", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Simulation result for individual transactions")]
    [field:InspectorName(@"TxnResults")]
    public System.Collections.Generic.List<SimulateTransactionResult> TxnResults {get;set;} = new System.Collections.Generic.List<SimulateTransactionResult>();
#else
    public System.Collections.Generic.ICollection<SimulateTransactionResult> TxnResults {get;set;} = new System.Collections.ObjectModel.Collection<SimulateTransactionResult>();
#endif
    
}


}
