
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
public partial class AvmValue{

    [Newtonsoft.Json.JsonProperty("bytes", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"bytes value.")]
    [field:InspectorName(@"Bytes")]
    public byte[] Bytes {get;set;}
#else
    public byte[] Bytes {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"value type. Value `1` refers to **bytes**, value `2` refers to **uint64**")]
    [field:InspectorName(@"Type")]
    public ulong Type {get;set;}
#else
    public ulong Type {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("uint", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"uint value.")]
    [field:InspectorName(@"Uint")]
    public ulong Uint {get;set;}
#else
    public ulong? Uint {get;set;}
#endif


    
}


}
