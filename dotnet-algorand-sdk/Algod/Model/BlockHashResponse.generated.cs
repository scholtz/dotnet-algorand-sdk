
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class BlockHashResponse{

    [Newtonsoft.Json.JsonProperty("blockHash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Blockhash {get;set;}

    
}


}
