


using Algorand.Utils;
using Newtonsoft.Json;
using System.ComponentModel;
using UnityEngine;

namespace Algorand.Algod.Model.Transactions
{

    public partial class ApplicationCreateTransaction : ApplicationNoopTransaction
    {

        public bool ShouldSerializeGlobalstateschema()
        {
            return GlobalStateSchema.NumByteSlice != 0 || GlobalStateSchema.NumUint != 0;
        }

        public bool ShouldSerializeLocalStateSchema()
        {
            return LocalStateSchema.NumByteSlice != 0 || LocalStateSchema.NumUint != 0;
        }

#if UNITY
        [field: SerializeField]
        [Tooltip(@"")]
        [field: InspectorName(@"ApplicationIndex")]
        [JsonIgnore]
        public ulong ApplicationIndex { get; internal set; }
#else
        [JsonIgnore]
        public ulong? ApplicationIndex { get; internal set; }
#endif


    }
}
