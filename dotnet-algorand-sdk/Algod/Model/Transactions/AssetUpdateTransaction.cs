using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetUpdateTransaction),"apar")]
    [JsonSubtypes.FallBackSubType(typeof(AssetDestroyTransaction))]

    public class AssetUpdateTransaction : AssetConfigurationTransaction
    {
        [JsonProperty(PropertyName = "apar")]
        public AssetParams AssetParams;

        [JsonProperty(PropertyName = "caid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong AssetIndex = 0;

    }
}
