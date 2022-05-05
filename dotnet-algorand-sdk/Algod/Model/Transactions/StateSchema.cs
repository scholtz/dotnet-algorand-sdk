using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{
    public class StateSchema
    {
        /// <summary>Maximum number of TEAL uints that may be stored in the key/value store.</summary>
        [JsonProperty("nui", DefaultValueHandling = DefaultValueHandling.Ignore)] //, Required = Newtonsoft.Json.Required.Always)]
        [DefaultValue(0)]
        public ulong? NumUint { get; set; }

        /// <summary>Maximum number of TEAL byte slices that may be stored in the key/value store.</summary>
        [JsonProperty("nbs", DefaultValueHandling = DefaultValueHandling.Ignore)] //, Required = Newtonsoft.Json.Required.Always)]
        [DefaultValue(0)]
        public ulong? NumByteSlice { get; set; }

    }
}
