using Newtonsoft.Json;
using System.ComponentModel;
using UnityEngine;

namespace Algorand.Algod.Model.Transactions
{
    public partial class AssetCreateTransaction : AssetConfigurationTransaction
    {
#if UNITY
        [field: SerializeField]
        [Tooltip(@"")]
        [field: InspectorName(@"ConfirmedRound")]
        [JsonIgnore]
        public ulong AssetIndex { get; internal set; }
#else
        [JsonIgnore]
        public ulong? AssetIndex { get; internal set; }
#endif

     
    }
}
