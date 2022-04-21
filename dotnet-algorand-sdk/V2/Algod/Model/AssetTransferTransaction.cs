
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public class AssetTransferTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "axfer";


        [JsonProperty(PropertyName = "xaid")]
        [DefaultValue(0)]
        public ulong? xferAsset = 0;

        /// <summary>
        /// The amount of asset to transfer. A zero amount transferred to self
        /// allocates that asset in the account's Assets map.
        /// </summary>
        [JsonProperty(PropertyName = "aamt")]
        [DefaultValue(0)]
        public ulong? assetAmount = 0;

        /// <summary>
        /// The sender of the transfer.  If this is not a zero value, the real
        /// transaction sender must be the Clawback address from the AssetParams. If
        /// this is the zero value, the asset is sent from the transaction's Sender.
        /// </summary>
        [JsonProperty(PropertyName = "asnd")]
        public Address assetSender = new Address();

        /// <summary>
        /// The receiver of the transfer.
        /// </summary>
        [JsonProperty(PropertyName = "arcv")]
        public Address assetReceiver = new Address();

        /// <summary>
        /// Indicates that the asset should be removed from the account's Assets map,
        /// and specifies where the remaining asset holdings should be transferred.
        /// It's always valid to transfer remaining asset holdings to the AssetID account.
        /// </summary>
        [JsonProperty(PropertyName = "aclose")]
        public Address assetCloseTo = new Address();
    }
}
