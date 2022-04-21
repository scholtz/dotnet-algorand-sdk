namespace Algorand.V2.Algod.Model
{
    using System = global::System;



    /// <summary>Stores local state associated with an application.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class ApplicationLocalState
    {
        /// <summary>The application which this local state is for.</summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        public ulong Id { get; set; }

        /// <summary>\[hsch\] schema.</summary>
        [Newtonsoft.Json.JsonProperty("schema", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public ApplicationStateSchema Schema { get; set; } = new ApplicationStateSchema();

        /// <summary>\[tkv\] storage.</summary>
        [Newtonsoft.Json.JsonProperty("key-value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TealKeyValueStore KeyValue { get; set; }


    }
}
