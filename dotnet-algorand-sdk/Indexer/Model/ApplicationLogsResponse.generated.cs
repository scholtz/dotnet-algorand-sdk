
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class ApplicationLogsResponse{

    [Newtonsoft.Json.JsonProperty("application-id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong ApplicationId {get;set;}


    [Newtonsoft.Json.JsonProperty("current-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CurrentRound {get;set;}

    [Newtonsoft.Json.JsonProperty("log-data", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<ApplicationLogData> LogData {get;set;} = new System.Collections.ObjectModel.Collection<ApplicationLogData>();

    [Newtonsoft.Json.JsonProperty("next-token", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string NextToken {get;set;}

    
}


}
