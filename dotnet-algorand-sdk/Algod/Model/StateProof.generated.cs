
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class StateProof{

    [Newtonsoft.Json.JsonProperty("Message", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public StateProofMessage Message {get;set;}


    [Newtonsoft.Json.JsonProperty("StateProof", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Stateproof {get;set;}

    
}


}
