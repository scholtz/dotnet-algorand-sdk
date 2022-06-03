using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetUpdateTransaction),"apar")]
    [JsonSubtypes.FallBackSubType(typeof(AssetDestroyTransaction))]

    public class AssetUpdateTransaction : AssetChangeTransaction
    {
        [JsonProperty(PropertyName = "apar")]
        public AssetParams AssetParams { get; set; }



    }
}
