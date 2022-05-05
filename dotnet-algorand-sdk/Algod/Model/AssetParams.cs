namespace Algorand.Algod.Model
{
    using System = global::System;
    /// <summary>AssetParams specifies the parameters for an asset.
    /// <br/>
    /// <br/>\[apar\] when part of an AssetConfig transaction.
    /// <br/>
    /// <br/>Definition:
    /// <br/>data/transactions/asset.go : AssetParams</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AssetParams
    {
        /// <summary>\[c\] Address of account used to clawback holdings of this asset.  If empty, clawback is not permitted.</summary>
        [Newtonsoft.Json.JsonProperty("clawback", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Address Clawback { get; set; }

        /// <summary>The address that created this asset. This is the address where the parameters for this asset can be found, and also the address where unwanted asset units can be sent in the worst case.</summary>
        [Newtonsoft.Json.JsonProperty("creator", Required = Newtonsoft.Json.Required.Always)]
        
        public Address Creator { get; set; } 

        /// <summary>\[dc\] The number of digits to use after the decimal point when displaying this asset. If 0, the asset is not divisible. If 1, the base unit of the asset is in tenths. If 2, the base unit of the asset is in hundredths, and so on. This value must be between 0 and 19 (inclusive).</summary>
        [Newtonsoft.Json.JsonProperty("decimals", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Range(0, 19)]
        public ulong Decimals { get; set; }

        /// <summary>\[df\] Whether holdings of this asset are frozen by default.</summary>
        [Newtonsoft.Json.JsonProperty("default-frozen", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? DefaultFrozen { get; set; }

        /// <summary>\[f\] Address of account used to freeze holdings of this asset.  If empty, freezing is not permitted.</summary>
        [Newtonsoft.Json.JsonProperty("freeze", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Address Freeze { get; set; }

        /// <summary>\[m\] Address of account used to manage the keys of this asset and to destroy it.</summary>
        [Newtonsoft.Json.JsonProperty("manager", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Address Manager { get; set; }

        /// <summary>\[am\] A commitment to some unspecified asset metadata. The format of this metadata is up to the application.</summary>
        [Newtonsoft.Json.JsonProperty("metadata-hash", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte[] MetadataHash { get; set; }

        /// <summary>\[an\] Name of this asset, as supplied by the creator. Included only when the asset name is composed of printable utf-8 characters.</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>Base64 encoded name of this asset, as supplied by the creator.</summary>
        [Newtonsoft.Json.JsonProperty("name-b64", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte[] NameB64 { get; set; }

        /// <summary>\[r\] Address of account holding reserve (non-minted) units of this asset.</summary>
        [Newtonsoft.Json.JsonProperty("reserve", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Address Reserve { get; set; }

        /// <summary>\[t\] The total number of units of this asset.</summary>
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.Always)]
        public ulong? Total { get; set; }

        /// <summary>\[un\] Name of a unit of this asset, as supplied by the creator. Included only when the name of a unit of this asset is composed of printable utf-8 characters.</summary>
        [Newtonsoft.Json.JsonProperty("unit-name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UnitName { get; set; }

        /// <summary>Base64 encoded name of a unit of this asset, as supplied by the creator.</summary>
        [Newtonsoft.Json.JsonProperty("unit-name-b64", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte[] UnitNameB64 { get; set; }

        /// <summary>\[au\] URL where more information about the asset can be retrieved. Included only when the URL is composed of printable utf-8 characters.</summary>
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>Base64 encoded URL where more information about the asset can be retrieved.</summary>
        [Newtonsoft.Json.JsonProperty("url-b64", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public byte[] UrlB64 { get; set; }


    }
}
