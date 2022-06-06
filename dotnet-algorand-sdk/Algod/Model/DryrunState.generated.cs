
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class DryrunState{
    [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Error {get;set;}


    [Newtonsoft.Json.JsonProperty("line", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Line {get;set;}


    [Newtonsoft.Json.JsonProperty("pc", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong Pc {get;set;}

    [Newtonsoft.Json.JsonProperty("scratch", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<TealValue> Scratch {get;set;} = new System.Collections.ObjectModel.Collection<TealValue>();


    [Newtonsoft.Json.JsonProperty("stack", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<TealValue> Stack {get;set;} = new System.Collections.ObjectModel.Collection<TealValue>();

    
}


}
