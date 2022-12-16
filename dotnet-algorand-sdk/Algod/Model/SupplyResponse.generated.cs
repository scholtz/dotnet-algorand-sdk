
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class SupplyResponse{

    [Newtonsoft.Json.JsonProperty("current_round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Current_round {get;set;}


    [Newtonsoft.Json.JsonProperty("online-money", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong OnlineMoney {get;set;}


    [Newtonsoft.Json.JsonProperty("total-money", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TotalMoney {get;set;}

    
}


}
