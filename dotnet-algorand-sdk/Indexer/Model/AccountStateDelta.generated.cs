
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class AccountStateDelta{

    [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Address {get;set;}


    [Newtonsoft.Json.JsonProperty("delta", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<EvalDeltaKeyValue> Delta {get;set;} = new System.Collections.ObjectModel.Collection<EvalDeltaKeyValue>();

    
}


}
