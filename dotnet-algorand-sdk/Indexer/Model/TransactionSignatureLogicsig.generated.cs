
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionSignatureLogicsig{
    [Newtonsoft.Json.JsonProperty("args", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<byte[]> Args {get;set;} = new System.Collections.ObjectModel.Collection<byte[]>();


    [Newtonsoft.Json.JsonProperty("logic", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Logic {get;set;}

    [Newtonsoft.Json.JsonProperty("multisig-signature", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionSignatureMultisig MultisigSignature {get;set;}

    [Newtonsoft.Json.JsonProperty("signature", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Signature {get;set;}

    
}


}
