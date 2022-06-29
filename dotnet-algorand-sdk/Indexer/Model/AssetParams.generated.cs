
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class AssetParams{
    [Newtonsoft.Json.JsonProperty("clawback", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Clawback {get;set;}


    [Newtonsoft.Json.JsonProperty("creator", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Creator {get;set;}


    [Newtonsoft.Json.JsonProperty("decimals", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Decimals {get;set;}

    [Newtonsoft.Json.JsonProperty("default-frozen", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool? DefaultFrozen {get;set;}

    [Newtonsoft.Json.JsonProperty("freeze", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Freeze {get;set;}

    [Newtonsoft.Json.JsonProperty("manager", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Manager {get;set;}

    [Newtonsoft.Json.JsonProperty("metadata-hash", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] MetadataHash {get;set;}

    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name {get;set;}

    [Newtonsoft.Json.JsonProperty("name-b64", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] NameB64 {get;set;}

    [Newtonsoft.Json.JsonProperty("reserve", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Reserve {get;set;}


    [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Total {get;set;}

    [Newtonsoft.Json.JsonProperty("unit-name", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string UnitName {get;set;}

    [Newtonsoft.Json.JsonProperty("unit-name-b64", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] UnitNameB64 {get;set;}

    [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Url {get;set;}

    [Newtonsoft.Json.JsonProperty("url-b64", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] UrlB64 {get;set;}

    
}


}
