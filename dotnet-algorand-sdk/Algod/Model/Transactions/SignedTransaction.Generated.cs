


using Algorand.Utils;
using Newtonsoft.Json;
using System;



namespace Algorand.Algod.Model.Transactions
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public partial class SignedTransaction
    {
        //TODO hgi & hgh flags
        
        [JsonProperty(PropertyName = "txn")]
        public Transaction Tx { get; set; }

        [JsonProperty(PropertyName = "sig")]
        public Signature Sig { get; set; }

        [JsonProperty(PropertyName = "msig")]
        public MultisigSignature MSig { get; set; }

        [JsonProperty(PropertyName = "lsig")]
        public LogicsigSignature LSig { get; set; }

        [JsonProperty(PropertyName = "sgnr")]
        public Address AuthAddr { get; set; }
       
     
    }
}
