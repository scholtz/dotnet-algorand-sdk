
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionSignatureMultisigSubsignature{
    [Newtonsoft.Json.JsonProperty("public-key", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] PublicKey {get;set;}

    [Newtonsoft.Json.JsonProperty("signature", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Signature {get;set;}

    
}


}
