
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class Application{

    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Id {get;set;}


    [Newtonsoft.Json.JsonProperty("params", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ApplicationParams Params {get;set;}

    
}


}
