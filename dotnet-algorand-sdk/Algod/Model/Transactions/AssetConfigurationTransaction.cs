using JsonSubTypes;
using Newtonsoft.Json;


namespace Algorand.Algod.Model
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetUpdateTransaction), "caid")]
    [JsonSubtypes.FallBackSubType(typeof(AssetCreateTransaction))]
    public abstract class AssetConfigurationTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public  string type => "acfg";



    }
}
