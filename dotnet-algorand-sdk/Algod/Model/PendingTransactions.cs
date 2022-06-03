

namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
    using System = global::System;

    /// <summary>PendingTransactions is an array of signed transactions exactly as they were submitted.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class PendingTransactions
    {
        /// <summary>An array of signed transaction objects.</summary>
        [Newtonsoft.Json.JsonProperty("top-transactions", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<SignedTransaction> TopTransactions { get; set; } = new System.Collections.ObjectModel.Collection<SignedTransaction>();

        /// <summary>Total number of transactions in the pool.</summary>
        [Newtonsoft.Json.JsonProperty("total-transactions", Required = Newtonsoft.Json.Required.Always)]
        public ulong TotalTransactions { get; set; }


    }
}
