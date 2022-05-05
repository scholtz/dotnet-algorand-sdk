namespace Algorand.Algod.Model
{
    using System = global::System;

    /// <summary>Describes an asset held by an account.
    /// <br/>
    /// <br/>Definition:
    /// <br/>data/basics/userBalance.go : AssetHolding</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AssetHolding
    {
        /// <summary>\[a\] number of units held.</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        public ulong Amount { get; set; }

        /// <summary>Asset ID of the holding.</summary>
        [Newtonsoft.Json.JsonProperty("asset-id", Required = Newtonsoft.Json.Required.Always)]
        public ulong AssetId { get; set; }

        /// <summary>Address that created this asset. This is the address where the parameters for this asset can be found, and also the address where unwanted asset units can be sent in the worst case.</summary>
        [Newtonsoft.Json.JsonProperty("creator", Required = Newtonsoft.Json.Required.Default)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Creator { get; set; }

        /// <summary>\[f\] whether or not the holding is frozen.</summary>
        [Newtonsoft.Json.JsonProperty("is-frozen", Required = Newtonsoft.Json.Required.Always)]
        public bool IsFrozen { get; set; }

    }
}
