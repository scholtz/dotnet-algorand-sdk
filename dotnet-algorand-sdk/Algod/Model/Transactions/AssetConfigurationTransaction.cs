using JsonSubTypes;
using Newtonsoft.Json;


namespace Algorand.Algod.Model.Transactions
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetUpdateTransaction), "caid")]
    [JsonSubtypes.FallBackSubType(typeof(AssetCreateTransaction))]
    public abstract partial class AssetConfigurationTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public  string type => "acfg";



    }
}
