

using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;

namespace Algorand.Algod.Model.Transactions
{
    public partial class PaymentTransaction : Transaction
    {
      

        [JsonProperty(PropertyName = "amt")]
        [DefaultValue(0)]
        public ulong? Amount { get; set; }  = 0;

        [JsonProperty(PropertyName = "amount")]
        internal ulong? amount { set { Amount = value; } }

        [JsonProperty(PropertyName = "rcv")]
        public Address Receiver { get; set; }

        [JsonProperty(PropertyName = "close")]
        public Address CloseRemainderTo { get; set; }





        [JsonIgnore]
        public ulong? ClosingAmount { get; internal set; }

      

    }
}
