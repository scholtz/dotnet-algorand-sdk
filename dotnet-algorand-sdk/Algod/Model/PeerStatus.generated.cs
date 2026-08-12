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
public partial class PeerStatus{

    [Newtonsoft.Json.JsonProperty("connection-type", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Connection type")]
    [field:InspectorName(@"ConnectionType")]
    public string ConnectionType {get;set;}
#else
    public string ConnectionType {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("network-address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Network address of the peer")]
    [field:InspectorName(@"NetworkAddress")]
    public string NetworkAddress {get;set;}
#else
    public string NetworkAddress {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("network-type", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Network type")]
    [field:InspectorName(@"NetworkType")]
    public string NetworkType {get;set;}
#else
    public string NetworkType {get;set;}
#endif


    
}


}
