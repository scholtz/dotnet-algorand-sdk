
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionKeyreg{
    [Newtonsoft.Json.JsonProperty("non-participation", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? NonParticipation {get;set;}

    [Newtonsoft.Json.JsonProperty("selection-participation-key", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] SelectionParticipationKey {get;set;}

    [Newtonsoft.Json.JsonProperty("state-proof-key", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] StateProofKey {get;set;}

    [Newtonsoft.Json.JsonProperty("vote-first-valid", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? VoteFirstValid {get;set;}

    [Newtonsoft.Json.JsonProperty("vote-key-dilution", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? VoteKeyDilution {get;set;}

    [Newtonsoft.Json.JsonProperty("vote-last-valid", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? VoteLastValid {get;set;}

    [Newtonsoft.Json.JsonProperty("vote-participation-key", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] VoteParticipationKey {get;set;}

    
}


}
