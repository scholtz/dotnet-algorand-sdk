

using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public class AssetFreezeTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "afrz";

        [JsonProperty(PropertyName = "fadd")]
        public Address FreezeTarget = new Address();
        [JsonProperty(PropertyName = "faid")]
        [DefaultValue(0)]
        public ulong? AssetFreezeID = 0;
        [JsonProperty(PropertyName = "afrz")]
        [DefaultValue(false)]
        public bool FreezeState = false;
    }
}
