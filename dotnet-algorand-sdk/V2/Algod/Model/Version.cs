

namespace Algorand.V2.Algod.Model
{
    using System = global::System;

    /// <summary>algod version information.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Version
    {
        [Newtonsoft.Json.JsonProperty("build", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public BuildVersion Build { get; set; } = new BuildVersion();

        [Newtonsoft.Json.JsonProperty("genesis_hash_b64", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] Genesis_hash_b64 { get; set; }

        [Newtonsoft.Json.JsonProperty("genesis_id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Genesis_id { get; set; }

        [Newtonsoft.Json.JsonProperty("versions", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<string> Versions { get; set; } = new System.Collections.ObjectModel.Collection<string>();


    }
}
