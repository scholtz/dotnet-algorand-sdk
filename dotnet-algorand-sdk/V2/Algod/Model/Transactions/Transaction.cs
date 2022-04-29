
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
  

    public abstract class Transaction
    {
        private const ulong MIN_TX_FEE_UALGOS = 1000;


        [JsonProperty(PropertyName = "snd")]
        public Address Sender = new Address();
       
        
        [JsonProperty(PropertyName = "fee")]
        [DefaultValue(0)]
        public ulong? Fee = 0;
  

        [JsonProperty(PropertyName = "fv")]
        [DefaultValue(0)]
        public ulong? FirstValid = 0;


        [JsonProperty(PropertyName = "lv")]
        [DefaultValue(0)]
        public ulong? LastValid = 0;


        [JsonIgnore]
        private byte[] _note;
        [JsonProperty(PropertyName = "note")]
        public byte[] Note
        {
            get
            {
                return _note;
            }
            set
            {
                if (value != null && value.Length > 0)
                    _note = value;
            }
        }

        [JsonProperty(PropertyName = "gen")]
        [DefaultValue("")]
        public string GenesisID = "";



        [JsonProperty(PropertyName = "gh")]
        public Digest GenesisHash = new Digest();



        [JsonProperty(PropertyName = "grp")]
        public Digest Group = new Digest();



        [JsonIgnore]
        private byte[] _lease;
        [JsonProperty(PropertyName = "lx")]
        public byte[] Lease
        {
            get
            {
                return _lease;
            }
            set
            {
                if (value != null && value.Length > 0)
                    _lease = value;
            }
        }


        [JsonProperty("rekey")]
        public Address RekeyTo = new Address();


        /// <summary>
        /// Sets the transaction fee according to suggestedFeePerByte * estimateTxSize.
        /// </summary>
        /// <param name="tx">transaction to populate fee field</param>
        /// <param name="suggestedFeePerByte">suggestedFee given by network</param>
        public static void SetFeeByFeePerByte(Transaction tx, ulong? suggestedFeePerByte)
        {
            ulong? newFee = suggestedFeePerByte * (ulong)EstimatedEncodedSize(tx);
            if (newFee < MIN_TX_FEE_UALGOS)
            {
                newFee = MIN_TX_FEE_UALGOS;
            }
            tx.fee = newFee;
        }



    }
}
