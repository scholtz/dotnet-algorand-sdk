
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
public partial class Genesis{

    [Newtonsoft.Json.JsonProperty("alloc", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Alloc")]
    public System.Collections.Generic.List<GenesisAllocation> Alloc {get;set;} = new System.Collections.Generic.List<GenesisAllocation>();
#else
    public System.Collections.Generic.ICollection<GenesisAllocation> Alloc {get;set;} = new System.Collections.ObjectModel.Collection<GenesisAllocation>();
#endif

    [Newtonsoft.Json.JsonProperty("comment", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Comment")]
    public string Comment {get;set;}
#else
    public string Comment {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("devmode", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Devmode")]
    public bool Devmode {get;set;}
#else
    public bool? Devmode {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("fees", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Fees")]
    public string Fees {get;set;}
#else
    public string Fees {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Id")]
    public string Id {get;set;}
#else
    public string Id {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("network", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Network")]
    public string Network {get;set;}
#else
    public string Network {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("proto", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Proto")]
    public string Proto {get;set;}
#else
    public string Proto {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("rwd", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Rwd")]
    public string Rwd {get;set;}
#else
    public string Rwd {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("timestamp", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Timestamp")]
    public ulong Timestamp {get;set;}
#else
    public ulong Timestamp {get;set;}
#endif


    
}


}
