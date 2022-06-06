
namespace Algorand.Algod.Model
{

using System = global::System;

public partial class Account{

    [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Address Address {get;set;}
    

    [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Amount {get;set;}
    

    [Newtonsoft.Json.JsonProperty("amount-without-pending-rewards", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong AmountWithoutPendingRewards {get;set;}
    
    [Newtonsoft.Json.JsonProperty("apps-local-state", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ApplicationLocalState> AppsLocalState {get;set;} = new System.Collections.ObjectModel.Collection<ApplicationLocalState>();

    [Newtonsoft.Json.JsonProperty("apps-total-extra-pages", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? AppsTotalExtraPages {get;set;}
    
    [Newtonsoft.Json.JsonProperty("apps-total-schema", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ApplicationStateSchema AppsTotalSchema {get;set;}
    
    [Newtonsoft.Json.JsonProperty("assets", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AssetHolding> Assets {get;set;} = new System.Collections.ObjectModel.Collection<AssetHolding>();

    [Newtonsoft.Json.JsonProperty("auth-addr", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Address AuthAddr {get;set;}
    
    [Newtonsoft.Json.JsonProperty("created-apps", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Application> CreatedApps {get;set;} = new System.Collections.ObjectModel.Collection<Application>();

    [Newtonsoft.Json.JsonProperty("created-assets", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<Asset> CreatedAssets {get;set;} = new System.Collections.ObjectModel.Collection<Asset>();


    [Newtonsoft.Json.JsonProperty("min-balance", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong MinBalance {get;set;}
    
    [Newtonsoft.Json.JsonProperty("participation", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AccountParticipation Participation {get;set;}
    

    [Newtonsoft.Json.JsonProperty("pending-rewards", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong PendingRewards {get;set;}
    
    [Newtonsoft.Json.JsonProperty("reward-base", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? RewardBase {get;set;}
    

    [Newtonsoft.Json.JsonProperty("rewards", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Rewards {get;set;}
    

    [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Round {get;set;}
    
   
    [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Status {get;set;}
    

    [Newtonsoft.Json.JsonProperty("total-apps-opted-in", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TotalAppsOptedIn {get;set;}
    

    [Newtonsoft.Json.JsonProperty("total-assets-opted-in", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TotalAssetsOptedIn {get;set;}
    

    [Newtonsoft.Json.JsonProperty("total-created-apps", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TotalCreatedApps {get;set;}
    

    [Newtonsoft.Json.JsonProperty("total-created-assets", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong TotalCreatedAssets {get;set;}
    
    
}


}
