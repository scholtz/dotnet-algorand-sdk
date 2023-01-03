
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
public partial class Box{

    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"\[name\] box name, base64 encoded")]
    [field:InspectorName(@"Name")]
    public byte[] Name {get;set;}
#else
    public byte[] Name {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"\[value\] box value, base64 encoded.")]
    [field:InspectorName(@"Value")]
    public byte[] Value {get;set;}
#else
    public byte[] Value {get;set;}
#endif


    
}


}
