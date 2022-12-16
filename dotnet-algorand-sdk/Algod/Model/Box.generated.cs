
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class Box{

    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Name {get;set;}


    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Value {get;set;}

    
}


}
