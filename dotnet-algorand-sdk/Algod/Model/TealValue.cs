namespace Algorand.Algod.Model
{
    using System = global::System;


    /// <summary>Represents a TEAL value.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class TealValue
    {
        /// <summary>\[tt\] value type. Value `1` refers to **bytes**, value `2` refers to **uint**</summary>
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        public ulong Type { get; set; }

        /// <summary>\[tb\] bytes value.</summary>
        [Newtonsoft.Json.JsonProperty("bytes", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Bytes { get; set; }

        /// <summary>\[ui\] uint value.</summary>
        [Newtonsoft.Json.JsonProperty("uint", Required = Newtonsoft.Json.Required.Always)]
        public ulong Uint { get; set; }


    }
}
