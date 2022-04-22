using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public  class AssetClawbackTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "axfer";


        [JsonProperty(PropertyName = "xaid")]
        [DefaultValue(0)]
        public ulong? XferAsset = 0;

        /// <summary>
        /// The amount of asset to transfer. A zero amount transferred to self
        /// allocates that asset in the account's Assets map.
        /// </summary>
        [JsonProperty(PropertyName = "aamt")]
        [DefaultValue(0)]
        public ulong? AssetAmount = 0;

        /// <summary>
        /// The sender of the transfer.  If this is not a zero value, the real
        /// transaction sender must be the Clawback address from the AssetParams. If
        /// this is the zero value, the asset is sent from the transaction's Sender.
        /// </summary>
        [JsonProperty(PropertyName = "asnd")]
        public Address AssetSender = new Address();

        /// <summary>
        /// The receiver of the transfer.
        /// </summary>
        [JsonProperty(PropertyName = "arcv")]
        public Address AssetReceiver = new Address();

        /// <summary>
        /// Indicates that the asset should be removed from the account's Assets map,
        /// and specifies where the remaining asset holdings should be transferred.
        /// It's always valid to transfer remaining asset holdings to the AssetID account.
        /// </summary>
        [JsonProperty(PropertyName = "aclose")]
        public Address AssetCloseTo = new Address();


        /// <summary>The number of the asset's unit that were transferred to the close-to address.</summary>
        [JsonProperty("asset-closing-amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? assetClosingAmount_pending { set { AssetClosingAmount = value; } }

        /// <summary>The number of the asset's unit that were transferred to the close-to address.</summary>
        [JsonProperty("asset-clawback-transaction.asset-closing-amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? assetClosingAmount_indexer { set { AssetClosingAmount = value; } }


        [JsonIgnore]
        public ulong? AssetClosingAmount { get; private set; }
    }
}
