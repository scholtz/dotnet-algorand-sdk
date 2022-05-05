
namespace Algorand.Algod.Model
{
    using System = global::System;


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class BuildVersion
    {
        [Newtonsoft.Json.JsonProperty("branch", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Branch { get; set; }

        [Newtonsoft.Json.JsonProperty("build_number", Required = Newtonsoft.Json.Required.Always)]
        public ulong Build_number { get; set; }

        [Newtonsoft.Json.JsonProperty("channel", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("commit_hash", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Commit_hash { get; set; }

        [Newtonsoft.Json.JsonProperty("major", Required = Newtonsoft.Json.Required.Always)]
        public ulong Major { get; set; }

        [Newtonsoft.Json.JsonProperty("minor", Required = Newtonsoft.Json.Required.Always)]
        public ulong Minor { get; set; }


    }
}
