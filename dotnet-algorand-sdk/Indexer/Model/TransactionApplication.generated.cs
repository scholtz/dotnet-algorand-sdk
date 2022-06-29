
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionApplication{
    [Newtonsoft.Json.JsonProperty("accounts", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Address> Accounts {get;set;} = new System.Collections.ObjectModel.Collection<Address>();

    [Newtonsoft.Json.JsonProperty("application-args", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<byte[]> ApplicationArgs {get;set;} = new System.Collections.ObjectModel.Collection<byte[]>();


    [Newtonsoft.Json.JsonProperty("application-id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong ApplicationId {get;set;}

    [Newtonsoft.Json.JsonProperty("approval-program", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TEALProgram ApprovalProgram {get;set;}

    [Newtonsoft.Json.JsonProperty("clear-state-program", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TEALProgram ClearStateProgram {get;set;}

    [Newtonsoft.Json.JsonProperty("extra-program-pages", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ExtraProgramPages {get;set;}

    [Newtonsoft.Json.JsonProperty("foreign-apps", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ulong> ForeignApps {get;set;} = new System.Collections.ObjectModel.Collection<ulong>();

    [Newtonsoft.Json.JsonProperty("foreign-assets", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ulong> ForeignAssets {get;set;} = new System.Collections.ObjectModel.Collection<ulong>();

    [Newtonsoft.Json.JsonProperty("global-state-schema", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public StateSchema GlobalStateSchema {get;set;}

    [Newtonsoft.Json.JsonProperty("local-state-schema", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public StateSchema LocalStateSchema {get;set;}

    [Newtonsoft.Json.JsonProperty("on-completion", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string OnCompletion {get;set;}

    
}


}
