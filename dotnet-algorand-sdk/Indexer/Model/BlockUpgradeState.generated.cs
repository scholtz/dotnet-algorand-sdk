
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class BlockUpgradeState{

    [Newtonsoft.Json.JsonProperty("current-protocol", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string CurrentProtocol {get;set;}

    [Newtonsoft.Json.JsonProperty("next-protocol", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string NextProtocol {get;set;}

    [Newtonsoft.Json.JsonProperty("next-protocol-approvals", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? NextProtocolApprovals {get;set;}

    [Newtonsoft.Json.JsonProperty("next-protocol-switch-on", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? NextProtocolSwitchOn {get;set;}

    [Newtonsoft.Json.JsonProperty("next-protocol-vote-before", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? NextProtocolVoteBefore {get;set;}

    
}


}
