
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
    using Newtonsoft.Json.Linq;
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
public partial class CompileResponse{

    [Newtonsoft.Json.JsonProperty("hash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"base32 SHA512_256 of program bytes (Address style)")]
    [field:InspectorName(@"Hash")]
    public string Hash {get;set;}
#else
    public string Hash {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("result", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"base64 encoded program bytes")]
    [field:InspectorName(@"Result")]
    public string Result {get;set;}
#else
    public string Result {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("sourcemap", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"JSON of the source map")]
    [field:InspectorName(@"Sourcemap")]
    public byte[] Sourcemap {get;set;}
#else
    public JObject Sourcemap {get;set;}
#endif


    
}


}
