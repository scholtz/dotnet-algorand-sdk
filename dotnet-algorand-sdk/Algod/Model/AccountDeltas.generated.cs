
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
public partial class AccountDeltas{

    [Newtonsoft.Json.JsonProperty("accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Array of Account updates for the round")]
    [field:InspectorName(@"Accounts")]
    public System.Collections.Generic.List<AccountBalanceRecord> Accounts {get;set;} = new System.Collections.Generic.List<AccountBalanceRecord>();
#else
    public System.Collections.Generic.ICollection<AccountBalanceRecord> Accounts {get;set;} = new System.Collections.ObjectModel.Collection<AccountBalanceRecord>();
#endif

    [Newtonsoft.Json.JsonProperty("apps", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Array of App updates for the round.")]
    [field:InspectorName(@"Apps")]
    public System.Collections.Generic.List<AppResourceRecord> Apps {get;set;} = new System.Collections.Generic.List<AppResourceRecord>();
#else
    public System.Collections.Generic.ICollection<AppResourceRecord> Apps {get;set;} = new System.Collections.ObjectModel.Collection<AppResourceRecord>();
#endif

    [Newtonsoft.Json.JsonProperty("assets", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"Array of Asset updates for the round.")]
    [field:InspectorName(@"Assets")]
    public System.Collections.Generic.List<AssetResourceRecord> Assets {get;set;} = new System.Collections.Generic.List<AssetResourceRecord>();
#else
    public System.Collections.Generic.ICollection<AssetResourceRecord> Assets {get;set;} = new System.Collections.ObjectModel.Collection<AssetResourceRecord>();
#endif
    
}


}
