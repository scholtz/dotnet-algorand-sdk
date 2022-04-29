using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    internal class AssetUpdateTransaction
    {
        [JsonProperty(PropertyName = "apar", Required = Required.Always)]
        public AssetParams AssetParams = new AssetParams();

        [JsonProperty(PropertyName = "caid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong AssetIndex = 0;

    }
}
