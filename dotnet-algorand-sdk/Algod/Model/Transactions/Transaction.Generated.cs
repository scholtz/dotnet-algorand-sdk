
namespace Algorand.Algod.Model.Transactions
{

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class Transaction{

    [Newtonsoft.Json.JsonProperty("fee", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Fee")]
    public ulong Fee {get;set;}
#else
    public ulong? Fee {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("fv", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"FirstValid")]
    public ulong FirstValid {get;set;}
#else
    public ulong? FirstValid {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("gen", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"GenesisId")]
    public string GenesisId {get;set;}
#else
    public string GenesisId {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("gh", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"GenesisHash")]
    public Algorand.Digest GenesisHash {get;set;}
#else
    public Algorand.Digest GenesisHash {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("grp", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Group")]
    public Algorand.Digest Group {get;set;}
#else
    public Algorand.Digest Group {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("lv", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"LastValid")]
    public ulong LastValid {get;set;}
#else
    public ulong? LastValid {get;set;}
#endif



    
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Lease")]
        [Newtonsoft.Json.JsonIgnore]
        private byte[] _lease {get;set;}
#endif
    [Newtonsoft.Json.JsonProperty("lx", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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




     
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Note")]
    [Newtonsoft.Json.JsonIgnore]
    private byte[] _note {get;set;}
#endif
        [Newtonsoft.Json.JsonProperty("note", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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





        [Newtonsoft.Json.JsonProperty("rekey", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"RekeyTo")]
    public Algorand.Address RekeyTo {get;set;}
#else
    public Algorand.Address RekeyTo {get;set;}
#endif



    [Newtonsoft.Json.JsonProperty("snd", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Sender")]
    public Algorand.Address Sender {get;set;}
#else
    public Algorand.Address Sender {get;set;}
#endif


    
}


}
