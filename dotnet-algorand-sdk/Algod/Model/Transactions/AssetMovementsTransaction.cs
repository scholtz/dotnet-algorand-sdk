
using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{

    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetTransferTransaction), "aamt")]
    [JsonSubtypes.FallBackSubType(typeof(AssetAcceptTransaction))]

    public abstract class AssetMovementsTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type",Required =Required.Always)]
        public string type => "axfer";


        [JsonProperty(PropertyName = "xaid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? XferAsset { get; set; }  = 0;
                  
    }
}
