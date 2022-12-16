
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class AccountBalanceRecord{

    [Newtonsoft.Json.JsonProperty("account-data", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Account AccountData {get;set;}


    [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Address {get;set;}

    
}


}
