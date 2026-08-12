#nullable enable annotations
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class GetPeersResponse{

    [Newtonsoft.Json.JsonProperty("Peers", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Peers")]
    public System.Collections.Generic.List<PeerStatus> Peers {get;set;} = new System.Collections.Generic.List<PeerStatus>();
#else
    public System.Collections.Generic.ICollection<PeerStatus> Peers {get;set;} = new System.Collections.ObjectModel.Collection<PeerStatus>();
#endif
    
}


}
