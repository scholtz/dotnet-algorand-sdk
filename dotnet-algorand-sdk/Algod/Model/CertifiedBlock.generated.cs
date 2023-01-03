
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
public partial class CertifiedBlock{

    [Newtonsoft.Json.JsonProperty("block", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Block header data.")]
    [field:InspectorName(@"Block")]
    public Block Block {get;set;}
#else
    public Block Block {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("cert", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Optional certificate object. This is only included when the format is set to message pack.")]
    [field:InspectorName(@"Cert")]
    public byte[] Cert {get;set;}
#else
    public byte[] Cert {get;set;}
#endif


    
}


}
