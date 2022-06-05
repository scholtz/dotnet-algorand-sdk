using Newtonsoft.Json;

namespace Algorand.Algod.Model.Transactions
{
    public partial class AssetAcceptTransaction : AssetMovementsTransaction
    {

        /// <summary>
        /// The receiver of the transfer.
        /// </summary>
        [JsonProperty(PropertyName = "arcv", Required = Required.Always)]
        public Address AssetReceiver { get; set; }


    }
}
