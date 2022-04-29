using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    internal class AssetCreateTransaction : AssetConfigurationTransaction
    {
        [JsonProperty(PropertyName = "apar",Required =Required.Always)]
        public AssetParams AssetParams = new AssetParams();


    }
}
