using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{
    public class AssetCreateTransaction : AssetConfigurationTransaction
    {
        [JsonProperty(PropertyName = "apar",Required =Required.Always)]
        public AssetParams AssetParams;

       
    }
}
