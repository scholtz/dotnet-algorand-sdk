
using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetClawbackTransaction), "asnd")]
    [JsonSubtypes.FallBackSubType(typeof(AssetTransferTransaction))]
    public partial class AssetTransferTransaction : AssetMovementsTransaction
    {
    




    }
}
