using MessagePack;
using Newtonsoft.Json;
using System.ComponentModel;
#if UNITY
using UnityEngine;
#endif

namespace Algorand.Algod.Model.Transactions
{
    [MessagePackObject]
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
        [IgnoreMember]
        public ulong? AssetIndex { get; internal set; }
#endif
    }
}
