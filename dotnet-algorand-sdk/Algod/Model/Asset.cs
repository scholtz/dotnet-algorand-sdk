namespace Algorand.V2.Algod.Model
{
    using System = global::System;

    /// <summary>Specifies both the unique identifier and the parameters for an asset</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Asset
    {
        /// <summary>unique asset identifier</summary>
        [Newtonsoft.Json.JsonProperty("index", Required = Newtonsoft.Json.Required.Always)]
        public ulong Index { get; set; }

        [Newtonsoft.Json.JsonProperty("params", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public AssetParams Params { get; set; } = new AssetParams();


    }

}
