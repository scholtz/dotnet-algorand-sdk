
using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetTransferTransaction), "aamt")]
    [JsonSubtypes.FallBackSubType(typeof(AssetAcceptTransaction))]

    public abstract partial class AssetMovementsTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [MessagePack.Key("type")]
        public string type => "axfer";
    }
}
