
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class Transaction{
    [Newtonsoft.Json.JsonProperty("application-transaction", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionApplication ApplicationTransaction {get;set;}

    [Newtonsoft.Json.JsonProperty("asset-config-transaction", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionAssetConfig AssetConfigTransaction {get;set;}

    [Newtonsoft.Json.JsonProperty("asset-freeze-transaction", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionAssetFreeze AssetFreezeTransaction {get;set;}

    [Newtonsoft.Json.JsonProperty("asset-transfer-transaction", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionAssetTransfer AssetTransferTransaction {get;set;}

    [Newtonsoft.Json.JsonProperty("auth-addr", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Address AuthAddr {get;set;}

    [Newtonsoft.Json.JsonProperty("close-rewards", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CloseRewards {get;set;}

    [Newtonsoft.Json.JsonProperty("closing-amount", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ClosingAmount {get;set;}

    [Newtonsoft.Json.JsonProperty("confirmed-round", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ConfirmedRound {get;set;}

    [Newtonsoft.Json.JsonProperty("created-application-index", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CreatedApplicationIndex {get;set;}

    [Newtonsoft.Json.JsonProperty("created-asset-index", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? CreatedAssetIndex {get;set;}


    [Newtonsoft.Json.JsonProperty("fee", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Fee {get;set;}


    [Newtonsoft.Json.JsonProperty("first-valid", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong FirstValid {get;set;}

    [Newtonsoft.Json.JsonProperty("genesis-hash", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] GenesisHash {get;set;}

    [Newtonsoft.Json.JsonProperty("genesis-id", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string GenesisId {get;set;}

    [Newtonsoft.Json.JsonProperty("global-state-delta", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<EvalDeltaKeyValue> GlobalStateDelta {get;set;} = new System.Collections.ObjectModel.Collection<EvalDeltaKeyValue>();

    [Newtonsoft.Json.JsonProperty("group", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Group {get;set;}

    [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Id {get;set;}

    [Newtonsoft.Json.JsonProperty("inner-txns", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Transaction> InnerTxns {get;set;} = new System.Collections.ObjectModel.Collection<Transaction>();

    [Newtonsoft.Json.JsonProperty("intra-round-offset", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? IntraRoundOffset {get;set;}

    [Newtonsoft.Json.JsonProperty("keyreg-transaction", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionKeyreg KeyregTransaction {get;set;}


    [Newtonsoft.Json.JsonProperty("last-valid", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong LastValid {get;set;}

    [Newtonsoft.Json.JsonProperty("lease", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Lease {get;set;}

    [Newtonsoft.Json.JsonProperty("local-state-delta", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AccountStateDelta> LocalStateDelta {get;set;} = new System.Collections.ObjectModel.Collection<AccountStateDelta>();

    [Newtonsoft.Json.JsonProperty("logs", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<byte[]> Logs {get;set;} = new System.Collections.ObjectModel.Collection<byte[]>();

    [Newtonsoft.Json.JsonProperty("note", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Note {get;set;}

    [Newtonsoft.Json.JsonProperty("payment-transaction", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionPayment PaymentTransaction {get;set;}

    [Newtonsoft.Json.JsonProperty("receiver-rewards", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? ReceiverRewards {get;set;}

    [Newtonsoft.Json.JsonProperty("rekey-to", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Address RekeyTo {get;set;}

    [Newtonsoft.Json.JsonProperty("round-time", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? RoundTime {get;set;}


    [Newtonsoft.Json.JsonProperty("sender", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Sender {get;set;}

    [Newtonsoft.Json.JsonProperty("sender-rewards", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? SenderRewards {get;set;}

    [Newtonsoft.Json.JsonProperty("signature", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TransactionSignature Signature {get;set;}

    [Newtonsoft.Json.JsonProperty("tx-type", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string TxType {get;set;}

    
}


}
