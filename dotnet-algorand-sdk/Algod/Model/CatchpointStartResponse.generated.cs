
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class CatchpointStartResponse{

    [Newtonsoft.Json.JsonProperty("catchup-message", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string CatchupMessage {get;set;}

    
}


}
