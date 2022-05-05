namespace Algorand.Algod.Model
{
    using System = global::System;

    /// <summary>Stores the TEAL eval step data</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class DryrunState
    {
        /// <summary>Line number</summary>
        [Newtonsoft.Json.JsonProperty("line", Required = Newtonsoft.Json.Required.Always)]
        public ulong Line { get; set; }

        /// <summary>Program counter</summary>
        [Newtonsoft.Json.JsonProperty("pc", Required = Newtonsoft.Json.Required.Always)]
        public ulong Pc { get; set; }

        [Newtonsoft.Json.JsonProperty("stack", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<TealValue> Stack { get; set; } = new System.Collections.ObjectModel.Collection<TealValue>();

        [Newtonsoft.Json.JsonProperty("scratch", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TealValue> Scratch { get; set; }

        /// <summary>Evaluation error if any</summary>
        [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Error { get; set; }


    }
}
