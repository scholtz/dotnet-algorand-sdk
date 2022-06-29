
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class ErrorResponse{
    [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Data {get;set;}


    [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public string Message {get;set;}

    
}


}
