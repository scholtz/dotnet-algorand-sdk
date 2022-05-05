using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{
    internal class AssetUpdateTransaction : AssetConfigurationTransaction
    {
        [JsonProperty(PropertyName = "apar", Required = Required.Always)]
        public AssetParams AssetParams;

        [JsonProperty(PropertyName = "caid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong AssetIndex = 0;

    }
}
