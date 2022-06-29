
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class BlockUpgradeVote{
    [Newtonsoft.Json.JsonProperty("upgrade-approve", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? UpgradeApprove {get;set;}

    [Newtonsoft.Json.JsonProperty("upgrade-delay", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? UpgradeDelay {get;set;}

    [Newtonsoft.Json.JsonProperty("upgrade-propose", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string UpgradePropose {get;set;}

    
}


}
