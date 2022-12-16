
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class TealKeyValue{

    [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Key {get;set;}


    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public TealValue Value {get;set;}

    
}


}
