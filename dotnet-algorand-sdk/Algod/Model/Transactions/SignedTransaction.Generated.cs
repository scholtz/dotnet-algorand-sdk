
namespace Algorand.Algod.Model.Transactions
{

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class SignedTransaction{

    [Newtonsoft.Json.JsonProperty("lsig", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"LSig")]
    public Algorand.LogicsigSignature LSig {get;set;}
#else
    public Algorand.LogicsigSignature LSig {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("msig", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"MSig")]
    public Algorand.MultisigSignature MSig {get;set;}
#else
    public Algorand.MultisigSignature MSig {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("sgnr", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"AuthAddr")]
    public Algorand.Address AuthAddr {get;set;}
#else
    public Algorand.Address AuthAddr {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("sig", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Sig")]
    public Algorand.Signature Sig {get;set;}
#else
    public Algorand.Signature Sig {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("txn", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Tx")]
    public Transaction Tx {get;set;}
#else
    public Transaction Tx {get;set;}
#endif


    
}


}
