
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class BoxDescriptor{

    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Name {get;set;}

    
}


}
