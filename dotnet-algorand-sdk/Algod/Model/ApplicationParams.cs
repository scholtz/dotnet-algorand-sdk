namespace Algorand.V2.Algod.Model
{
    using System = global::System;

    /// <summary>Stores the global information associated with an application.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class ApplicationParams
    {
        /// <summary>The address that created this application. This is the address where the parameters and global state for this application can be found.</summary>
        [Newtonsoft.Json.JsonProperty("creator", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Creator { get; set; }

        /// <summary>\[approv\] approval program.</summary>
        [Newtonsoft.Json.JsonProperty("approval-program", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] ApprovalProgram { get; set; }

        /// <summary>\[clearp\] approval program.</summary>
        [Newtonsoft.Json.JsonProperty("clear-state-program", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] ClearStateProgram { get; set; }

        /// <summary>\[epp\] the amount of extra program pages available to this app.</summary>
        [Newtonsoft.Json.JsonProperty("extra-program-pages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ExtraProgramPages { get; set; }

        /// <summary>[\lsch\] local schema</summary>
        [Newtonsoft.Json.JsonProperty("local-state-schema", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ApplicationStateSchema LocalStateSchema { get; set; }

        /// <summary>[\gsch\] global schema</summary>
        [Newtonsoft.Json.JsonProperty("global-state-schema", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ApplicationStateSchema GlobalStateSchema { get; set; }

        /// <summary>[\gs\] global schema</summary>
        [Newtonsoft.Json.JsonProperty("global-state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TealKeyValueStore GlobalState { get; set; }


    }
}
