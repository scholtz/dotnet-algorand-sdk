
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AccountDeltas{
    [Newtonsoft.Json.JsonProperty("accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AccountBalanceRecord> Accounts {get;set;} = new System.Collections.ObjectModel.Collection<AccountBalanceRecord>();

    [Newtonsoft.Json.JsonProperty("apps", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AppResourceRecord> Apps {get;set;} = new System.Collections.ObjectModel.Collection<AppResourceRecord>();

    [Newtonsoft.Json.JsonProperty("assets", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AssetResourceRecord> Assets {get;set;} = new System.Collections.ObjectModel.Collection<AssetResourceRecord>();

    
}


}
