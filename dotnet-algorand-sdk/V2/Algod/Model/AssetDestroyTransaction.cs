using Newtonsoft.Json;

namespace Algorand.V2.Algod.Model
{
    internal class AssetDestroyTransaction
    {
        [JsonProperty(PropertyName = "caid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong AssetIndex = 0;

        /// <summary>The asset index if the transaction was found and it created an asset.</summary>
        [JsonProperty("asset-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? assetIndex_pending { set { AssetIndex = value??0; } }
    }
}
