
using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{

    [JsonConverter(typeof(JsonSubtypes), "aamt")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetClawbackTransaction), "asnd")]
    [JsonSubtypes.KnownSubType(typeof(AssetAcceptTransaction), "0")]
    [JsonSubtypes.FallBackSubType(typeof(AssetTransferTransaction))]

    public abstract class AssetMovementsTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type",Required =Required.Always)]
        private string type => "axfer";


        [JsonProperty(PropertyName = "xaid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? XferAsset = 0;
                  
    }
}
