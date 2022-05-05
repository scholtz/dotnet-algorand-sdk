using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class CertifiedBlock
    {
        /// <summary>Block header data.</summary>
        [Newtonsoft.Json.JsonProperty("block", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public Block Block { get; set; } = new Block();

        /// <summary>Optional certificate object. This is only included when the format is set to message pack.</summary>
        [Newtonsoft.Json.JsonProperty("cert", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object Cert { get; set; }


    }
}
