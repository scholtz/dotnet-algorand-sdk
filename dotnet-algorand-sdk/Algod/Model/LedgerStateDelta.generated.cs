
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class LedgerStateDelta{
    [Newtonsoft.Json.JsonProperty("accts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AccountDeltas Accts {get;set;}

    [Newtonsoft.Json.JsonProperty("kv-mods", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<KvDelta> KvMods {get;set;} = new System.Collections.ObjectModel.Collection<KvDelta>();

    [Newtonsoft.Json.JsonProperty("modified-apps", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ModifiedApp> ModifiedApps {get;set;} = new System.Collections.ObjectModel.Collection<ModifiedApp>();

    [Newtonsoft.Json.JsonProperty("modified-assets", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ModifiedAsset> ModifiedAssets {get;set;} = new System.Collections.ObjectModel.Collection<ModifiedAsset>();

    [Newtonsoft.Json.JsonProperty("prev-timestamp", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? PrevTimestamp {get;set;}

    [Newtonsoft.Json.JsonProperty("state-proof-next", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? StateProofNext {get;set;}

    [Newtonsoft.Json.JsonProperty("totals", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AccountTotals Totals {get;set;}

    [Newtonsoft.Json.JsonProperty("tx-leases", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<TxLease> TxLeases {get;set;} = new System.Collections.ObjectModel.Collection<TxLease>();

    
}


}
