
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionSignatureMultisig{
    [Newtonsoft.Json.JsonProperty("subsignature", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<TransactionSignatureMultisigSubsignature> Subsignature {get;set;} = new System.Collections.ObjectModel.Collection<TransactionSignatureMultisigSubsignature>();

    [Newtonsoft.Json.JsonProperty("threshold", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? Threshold {get;set;}

    [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? Version {get;set;}

    
}


}
