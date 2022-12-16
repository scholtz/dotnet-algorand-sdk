
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
    using System = global::System;


public partial class DryrunRequest{

    [Newtonsoft.Json.JsonProperty("accounts", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<Account> Accounts {get;set;} = new System.Collections.ObjectModel.Collection<Account>();


    [Newtonsoft.Json.JsonProperty("apps", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<Application> Apps {get;set;} = new System.Collections.ObjectModel.Collection<Application>();


    [Newtonsoft.Json.JsonProperty("latest-timestamp", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong LatestTimestamp {get;set;}


    [Newtonsoft.Json.JsonProperty("protocol-version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string ProtocolVersion {get;set;}


    [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Round {get;set;}


    [Newtonsoft.Json.JsonProperty("sources", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<DryrunSource> Sources {get;set;} = new System.Collections.ObjectModel.Collection<DryrunSource>();


    [Newtonsoft.Json.JsonProperty("txns", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<SignedTransaction> Txns {get;set;} = new System.Collections.ObjectModel.Collection<SignedTransaction>();

    
}


}
