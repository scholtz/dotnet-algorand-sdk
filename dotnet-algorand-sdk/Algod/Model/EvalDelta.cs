namespace Algorand.Algod.Model
{
    using System = global::System;


    /// <summary>Represents a TEAL value delta.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class EvalDelta
    {
        /// <summary>\[at\] delta action.</summary>
        [Newtonsoft.Json.JsonProperty("action", Required = Newtonsoft.Json.Required.Always)]
        public ulong Action { get; set; }

        /// <summary>\[bs\] bytes value.</summary>
        [Newtonsoft.Json.JsonProperty("bytes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Bytes { get; set; }

        /// <summary>\[ui\] uint value.</summary>
        [Newtonsoft.Json.JsonProperty("uint", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ulong? Uint { get; set; }


    }
}
