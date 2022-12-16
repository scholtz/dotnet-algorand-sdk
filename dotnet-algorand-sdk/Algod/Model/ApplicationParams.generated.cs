
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class ApplicationParams{

    [Newtonsoft.Json.JsonProperty("approval-program", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public TEALProgram ApprovalProgram {get;set;}


    [Newtonsoft.Json.JsonProperty("clear-state-program", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public TEALProgram ClearStateProgram {get;set;}


    [Newtonsoft.Json.JsonProperty("creator", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Address Creator {get;set;}

    [Newtonsoft.Json.JsonProperty("extra-program-pages", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ExtraProgramPages {get;set;}

    [Newtonsoft.Json.JsonProperty("global-state", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<TealKeyValue> GlobalState {get;set;} = new System.Collections.ObjectModel.Collection<TealKeyValue>();

    [Newtonsoft.Json.JsonProperty("global-state-schema", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ApplicationStateSchema GlobalStateSchema {get;set;}

    [Newtonsoft.Json.JsonProperty("local-state-schema", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ApplicationStateSchema LocalStateSchema {get;set;}

    
}


}
