
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class EvalDeltaKeyValue{

    [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Key {get;set;}


    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public EvalDelta Value {get;set;}

    
}


}
