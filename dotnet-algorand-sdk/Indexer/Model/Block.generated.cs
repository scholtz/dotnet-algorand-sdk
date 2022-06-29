
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class Block{

    [Newtonsoft.Json.JsonProperty("genesis-hash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] GenesisHash {get;set;}


    [Newtonsoft.Json.JsonProperty("genesis-id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string GenesisId {get;set;}


    [Newtonsoft.Json.JsonProperty("previous-block-hash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] PreviousBlockHash {get;set;}

    [Newtonsoft.Json.JsonProperty("rewards", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public BlockRewards Rewards {get;set;}


    [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Round {get;set;}


    [Newtonsoft.Json.JsonProperty("seed", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] Seed {get;set;}


    [Newtonsoft.Json.JsonProperty("timestamp", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Timestamp {get;set;}

    [Newtonsoft.Json.JsonProperty("transactions", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Transaction> Transactions {get;set;} = new System.Collections.ObjectModel.Collection<Transaction>();


    [Newtonsoft.Json.JsonProperty("transactions-root", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public byte[] TransactionsRoot {get;set;}

    [Newtonsoft.Json.JsonProperty("txn-counter", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? TxnCounter {get;set;}

    [Newtonsoft.Json.JsonProperty("upgrade-state", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public BlockUpgradeState UpgradeState {get;set;}

    [Newtonsoft.Json.JsonProperty("upgrade-vote", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public BlockUpgradeVote UpgradeVote {get;set;}

    
}


}
