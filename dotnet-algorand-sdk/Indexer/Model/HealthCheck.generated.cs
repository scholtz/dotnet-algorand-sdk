
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class HealthCheck{
    [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Data {get;set;}


    [Newtonsoft.Json.JsonProperty("db-available", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool DbAvailable {get;set;}

    [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<string> Errors {get;set;} = new System.Collections.ObjectModel.Collection<string>();


    [Newtonsoft.Json.JsonProperty("is-migrating", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public bool IsMigrating {get;set;}


    [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Message {get;set;}


    [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Round {get;set;}


    [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Version {get;set;}

    
}


}
