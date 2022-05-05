using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{
    public class AssetDestroyTransaction : AssetConfigurationTransaction
    {
        [JsonProperty(PropertyName = "caid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong AssetIndex = 0;

    }
}
