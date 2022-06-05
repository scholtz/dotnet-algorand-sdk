
using Algorand.Utils;
using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{



  

    public abstract partial class Transaction : IReturnableTransaction
    {
    

        [JsonProperty(PropertyName = "snd")]
        public Address Sender { get; set; }


        [JsonProperty(PropertyName = "fee")]
        [DefaultValue(0)]
        public ulong? Fee { get; set; } = 0;
  

        [JsonProperty(PropertyName = "fv")]
        [DefaultValue(0)]
        public ulong? FirstValid { get; set; } = 0;


        [JsonProperty(PropertyName = "lv")]
        [DefaultValue(0)]
        public ulong? LastValid { get; set; } = 0;


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
        public string GenesisID { get; set; } = "";


      
        [JsonProperty(PropertyName = "gh")]
        public Digest GenesisHash { get; set; }



        [JsonProperty(PropertyName = "grp")]
        public Digest Group { get; set; }



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
        public Address RekeyTo { get; set; }

  




    }
}
