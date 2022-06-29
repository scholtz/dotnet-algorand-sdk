
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class StateSchema{

    [Newtonsoft.Json.JsonProperty("num-byte-slice", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong NumByteSlice {get;set;}


    [Newtonsoft.Json.JsonProperty("num-uint", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ulong NumUint {get;set;}

    
}


}
