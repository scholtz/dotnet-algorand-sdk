using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public class AssetAcceptTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "axfer";


        [JsonProperty(PropertyName = "xaid")]
        [DefaultValue(0)]
        public ulong? xferAsset = 0;

      
        /// <summary>
        /// The receiver of the transfer.
        /// </summary>
        [JsonProperty(PropertyName = "arcv")]
        public Address assetReceiver = new Address();

 
    }
}
