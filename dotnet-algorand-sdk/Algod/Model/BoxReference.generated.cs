
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
public partial class BoxReference{

    [Newtonsoft.Json.JsonProperty("app", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Application ID which this box belongs to")]
    [field:InspectorName(@"App")]
    public ulong App {get;set;}
#else
    public ulong App {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Base64 encoded box name")]
    [field:InspectorName(@"Name")]
    public byte[] Name {get;set;}
#else
    public byte[] Name {get;set;}
#endif


    
}


}
