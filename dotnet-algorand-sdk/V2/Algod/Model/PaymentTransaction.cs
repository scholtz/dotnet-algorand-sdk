

using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public class PaymentTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "pay";

        [JsonProperty(PropertyName = "amt")]
        [DefaultValue(0)]
        public ulong? Amount = 0;

        [JsonProperty(PropertyName = "amount")]
        private ulong? amount { set { Amount = value; } }

        [JsonProperty(PropertyName = "rcv")]
        public Address Receiver = new Address();

        [JsonProperty(PropertyName = "close")]
        public Address CloseRemainderTo = new Address();
        /// <summary>Rewards in microalgos applied to the close remainder to account.</summary>
        [JsonProperty("payment-transaction.close-remainder-to", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? closeRemainderTo_indexer { set { CloseRewards = value; } }

        /// <summary>Rewards in microalgos applied to the close remainder to account.</summary>
        [JsonProperty("close-rewards", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? closeRewards { set { CloseRewards = value; } }
        [JsonIgnore]
        public ulong? CloseRewards { get; private set; }

        /// <summary>Closing amount for the transaction.</summary>
        [JsonProperty("closing-amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ulong? closingAmount { set { ClosingAmount = value; } }
        [JsonIgnore]
        public ulong? ClosingAmount { get; private set; }

    }
}
