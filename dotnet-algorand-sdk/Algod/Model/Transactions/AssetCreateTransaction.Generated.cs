using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    public partial class AssetCreateTransaction : AssetConfigurationTransaction
    {
        [JsonProperty(PropertyName = "apar",Required =Required.Always)]
        public AssetParams AssetParams { get; set; }

        [JsonIgnore]
        public ulong? AssetIndex { get; internal set; }
    }
}
