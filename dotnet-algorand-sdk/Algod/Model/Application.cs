namespace Algorand.V2.Algod.Model
{
    using System = global::System;

    /// <summary>Application index and its parameters</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Application
    {
        /// <summary>\[appidx\] application index.</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        public ulong Id { get; set; }

        /// <summary>\[appparams\] application parameters.</summary>
        [Newtonsoft.Json.JsonProperty("params", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ApplicationParams Params { get; set; } = new ApplicationParams();


    }
}
