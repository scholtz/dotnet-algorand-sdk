
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class ReturnedTransaction{
    [Newtonsoft.Json.JsonProperty("application-index", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ApplicationIndex {get;set;}

    [Newtonsoft.Json.JsonProperty("asset-closing-amount", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? AssetClosingAmount {get;set;}

    [Newtonsoft.Json.JsonProperty("asset-index", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? AssetIndex {get;set;}

    [Newtonsoft.Json.JsonProperty("close-rewards", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CloseRewards {get;set;}

    [Newtonsoft.Json.JsonProperty("closing-amount", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ClosingAmount {get;set;}

    [Newtonsoft.Json.JsonProperty("confirmed-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ConfirmedRound {get;set;}

    [Newtonsoft.Json.JsonProperty("global-state-delta", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<EvalDeltaKeyValue> GlobalStateDelta {get;set;} = new System.Collections.ObjectModel.Collection<EvalDeltaKeyValue>();

    [Newtonsoft.Json.JsonProperty("inner-txns", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<IReturnableTransaction> InnerTxns {get;set;} = new System.Collections.ObjectModel.Collection<IReturnableTransaction>();

    [Newtonsoft.Json.JsonProperty("local-state-delta", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AccountStateDelta> LocalStateDelta {get;set;} = new System.Collections.ObjectModel.Collection<AccountStateDelta>();

    [Newtonsoft.Json.JsonProperty("logs", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<byte[]> Logs {get;set;} = new System.Collections.ObjectModel.Collection<byte[]>();


    [Newtonsoft.Json.JsonProperty("pool-error", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string PoolError {get;set;}

    [Newtonsoft.Json.JsonProperty("receiver-rewards", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ReceiverRewards {get;set;}

    [Newtonsoft.Json.JsonProperty("sender-rewards", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? SenderRewards {get;set;}


    [Newtonsoft.Json.JsonProperty("txn", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public SignedTransaction Txn {get;set;}

    
}


}
