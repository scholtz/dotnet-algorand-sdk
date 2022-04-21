using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public class AssetConfigurationTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "acfg";

        [JsonProperty(PropertyName = "apar")]
        public AssetParams assetParams = new AssetParams();
        [JsonProperty(PropertyName = "caid")]
        [DefaultValue(0)]
        public ulong? assetIndex = 0;
    }
}
