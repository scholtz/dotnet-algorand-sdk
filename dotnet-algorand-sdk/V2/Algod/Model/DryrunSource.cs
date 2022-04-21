namespace Algorand.V2.Algod.Model
{
    using System = global::System;

    /// <summary>DryrunSource is TEAL source text that gets uploaded, compiled, and inserted into transactions or application state.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class DryrunSource
    {
        /// <summary>FieldName is what kind of sources this is. If lsig then it goes into the transactions[this.TxnIndex].LogicSig. If approv or clearp it goes into the Approval Program or Clear State Program of application[this.AppIndex].</summary>
        [Newtonsoft.Json.JsonProperty("field-name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string FieldName { get; set; }

        [Newtonsoft.Json.JsonProperty("source", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Source { get; set; }

        [Newtonsoft.Json.JsonProperty("txn-index", Required = Newtonsoft.Json.Required.Always)]
        public ulong TxnIndex { get; set; }

        [Newtonsoft.Json.JsonProperty("app-index", Required = Newtonsoft.Json.Required.Always)]
        public ulong AppIndex { get; set; }


    }
}
