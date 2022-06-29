
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class ApplicationResponse{
    [Newtonsoft.Json.JsonProperty("application", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Application Application {get;set;}


    [Newtonsoft.Json.JsonProperty("current-round", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong CurrentRound {get;set;}

    
}


}
