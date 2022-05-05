
using Newtonsoft.Json;

namespace Algorand.Algod.Model
{

    public abstract class AssetConfigurationTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        private  string type => "acfg";



    }
}
