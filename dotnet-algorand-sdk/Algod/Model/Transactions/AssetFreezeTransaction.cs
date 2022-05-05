

using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{
    public class AssetFreezeTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        private string type => "afrz";

        [JsonProperty(PropertyName = "fadd", Required = Required.Always)]
        public Address FreezeTarget;
        [JsonProperty(PropertyName = "faid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? AssetFreezeID = 0;
        [JsonProperty(PropertyName = "afrz", Required=Required.Default)]
        [DefaultValue(false)]
        public bool FreezeState = false;
    }
}
