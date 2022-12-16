
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
    using System = global::System;


public partial class PendingTransactions{

    [Newtonsoft.Json.JsonProperty("top-transactions", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<SignedTransaction> TopTransactions {get;set;} = new System.Collections.ObjectModel.Collection<SignedTransaction>();


    [Newtonsoft.Json.JsonProperty("total-transactions", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TotalTransactions {get;set;}

    
}


}
