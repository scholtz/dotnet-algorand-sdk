using Algorand.Internal.Json;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class AssetConfigurationTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "acfg";

        [JsonProperty(PropertyName = "apar")]
        public AssetParams AssetParams = new AssetParams();
        
        [JsonProperty(PropertyName = "caid")]
        [DefaultValue(0)]
        public ulong? AssetIndex = 0;


        /// <summary>The asset index if the transaction was found and it created an asset.</summary>
        [JsonProperty("asset-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? assetIndex_pending { set { AssetIndex = value; } }


    }
}
