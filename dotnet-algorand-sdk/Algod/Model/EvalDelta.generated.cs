
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class EvalDelta{

    [Newtonsoft.Json.JsonProperty("action", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Action {get;set;}

    [Newtonsoft.Json.JsonProperty("bytes", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Bytes {get;set;}

    [Newtonsoft.Json.JsonProperty("uint", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? Uint {get;set;}

    
}


}
