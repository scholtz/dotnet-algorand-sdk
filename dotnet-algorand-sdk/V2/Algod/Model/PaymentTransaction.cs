

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
        public ulong? amount = 0;
        [JsonProperty(PropertyName = "rcv")]
        public Address receiver = new Address();
        [JsonProperty(PropertyName = "close")]
        public Address closeRemainderTo = new Address(); 
    }
}
