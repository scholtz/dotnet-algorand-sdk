
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionSignature{
    [Newtonsoft.Json.JsonProperty("logicsig", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionSignatureLogicsig Logicsig {get;set;}

    [Newtonsoft.Json.JsonProperty("multisig", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionSignatureMultisig Multisig {get;set;}

    [Newtonsoft.Json.JsonProperty("sig", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Sig {get;set;}

    
}


}
