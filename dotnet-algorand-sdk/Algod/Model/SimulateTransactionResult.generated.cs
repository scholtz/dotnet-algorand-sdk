
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
public partial class SimulateTransactionResult{

    [Newtonsoft.Json.JsonProperty("missing-signature", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"A boolean indicating whether this transaction is missing signatures")]
    [field:InspectorName(@"MissingSignature")]
    public bool MissingSignature {get;set;}
#else
    public bool? MissingSignature {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("txn-result", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeReference]
    [Tooltip(@"Details about a pending transaction. If the transaction was recently confirmed, includes confirmation details like the round and reward details.")]
    [field:InspectorName(@"TxnResult")]
    public IReturnableTransaction TxnResult {get;set;}
#else
    public IReturnableTransaction TxnResult {get;set;}
#endif


    
}


}
