
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public class AssetTransferTransaction : AssetMovementsTransaction
    {
    


        /// <summary>
        /// The amount of asset to transfer. A zero amount transferred to self
        /// allocates that asset in the account's Assets map.
        /// </summary>
        [JsonProperty(PropertyName = "aamt", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? AssetAmount = 0;

    

        /// <summary>
        /// The receiver of the transfer.
        /// </summary>
        [JsonProperty(PropertyName = "arcv", Required = Required.Always)]
        public Address AssetReceiver = new Address();

        /// <summary>
        /// Indicates that the asset should be removed from the account's Assets map,
        /// and specifies where the remaining asset holdings should be transferred.
        /// It's always valid to transfer remaining asset holdings to the AssetID account.
        /// </summary>
        [JsonProperty(PropertyName = "aclose", Required = Required.Always)]
        public Address AssetCloseTo = new Address();


        
      
        


    }
}
