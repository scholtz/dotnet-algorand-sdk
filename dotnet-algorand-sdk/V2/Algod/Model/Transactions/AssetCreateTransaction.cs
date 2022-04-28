using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    internal class AssetCreateTransaction : AssetConfigurationTransaction
    {
        [JsonProperty(PropertyName = "apar",Required =Required.Always)]
        public AssetParams AssetParams = new AssetParams();

        /**********************************************************
          * Committed fields
          **********************************************************/

        /// <summary>The application index if the transaction was found and it created an application..</summary>
        [JsonProperty("asset-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(0)]
        public ulong? AssetIndex { get; internal set; } //NOTE: make OAS to alias the field

    }
}
