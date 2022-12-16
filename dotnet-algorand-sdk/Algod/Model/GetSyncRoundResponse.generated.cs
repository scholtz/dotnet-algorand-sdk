
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class GetSyncRoundResponse{

    [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Round {get;set;}

    
}


}
