

using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    public partial class AssetFreezeTransaction : Transaction
    {
     

        [JsonProperty(PropertyName = "fadd", Required = Required.Always)]
        public Address FreezeTarget { get; set; }
        [JsonProperty(PropertyName = "faid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? AssetFreezeID { get; set; } = 0;
        [JsonProperty(PropertyName = "afrz", Required=Required.Default)]
        [DefaultValue(false)]
        public bool FreezeState { get; set; } = false;
    }
}
