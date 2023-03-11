
using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;
#if UNITY
using UnityEngine;
#endif

namespace Algorand.Algod.Model.Transactions
{

    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(AssetClawbackTransaction), "asnd")]
    [JsonSubtypes.FallBackSubType(typeof(AssetTransferTransaction))]
    public partial class AssetTransferTransaction : AssetMovementsTransaction
    {
#if UNITY
        [field: SerializeField]
        [Tooltip(@"")]
        [field: InspectorName(@"AssetClosingAmount")]
        [JsonIgnore]
        public ulong AssetClosingAmount { get; internal set; }
#else
        [JsonIgnore]
        public ulong? AssetClosingAmount { get; internal set; }
#endif
     



    }
}
