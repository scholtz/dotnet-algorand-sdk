using JsonSubTypes;
using Newtonsoft.Json;

namespace Algorand.Algod.Model
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.FallBackSubType(typeof(KeyRegisterOfflineTransaction))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(KeyRegisterOnlineTransaction), "votekey")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(KeyRegisterOnlineTransaction), "selkey")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(KeyRegisterOnlineTransaction), "votefst")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(KeyRegisterOnlineTransaction), "votelst")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(KeyRegisterOnlineTransaction), "votekd")]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(KeyRegisterOnlineTransaction), "nonpart")]
    public abstract class KeyRegistrationTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string type => "keyreg";


    }
}
