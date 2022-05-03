using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public  class AssetClawbackTransaction : AssetMovementsTransaction
    {

        /// <summary>
        /// The amount of asset to transfer. A zero amount transferred to self
        /// allocates that asset in the account's Assets map.
        /// </summary>
        [JsonProperty(PropertyName = "aamt", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? AssetAmount = 0;

        /// <summary>
        /// The sender of the transfer.  If this is not a zero value, the real
        /// transaction sender must be the Clawback address from the AssetParams. If
        /// this is the zero value, the asset is sent from the transaction's Sender.
        /// </summary>
        [JsonProperty(PropertyName = "asnd", Required = Required.Always)]
        public Address AssetSender;

        /// <summary>
        /// The receiver of the transfer.
        /// </summary>
        [JsonProperty(PropertyName = "arcv", Required = Required.Always)]
        public Address AssetReceiver;

       
    }
}
