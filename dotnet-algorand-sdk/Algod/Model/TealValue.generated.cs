
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
public partial class TealValue{

    [Newtonsoft.Json.JsonProperty("bytes", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"\[tb\] bytes value.")]
    [field:InspectorName(@"Bytes")]
    public string Bytes {get;set;}
#else
    public string Bytes {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"\[tt\] value type. Value `1` refers to **bytes**, value `2` refers to **uint**")]
    [field:InspectorName(@"Type")]
    public ulong Type {get;set;}
#else
    public ulong Type {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("uint", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"\[ui\] uint value.")]
    [field:InspectorName(@"Uint")]
    public ulong Uint {get;set;}
#else
    public ulong Uint {get;set;}
#endif


    
}


}
