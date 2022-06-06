
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class ApplicationLocalState{

    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Id {get;set;}

    [Newtonsoft.Json.JsonProperty("key-value", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<TealKeyValue> KeyValue {get;set;} = new System.Collections.ObjectModel.Collection<TealKeyValue>();


    [Newtonsoft.Json.JsonProperty("schema", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ApplicationStateSchema Schema {get;set;}

    
}


}
