
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class KvDelta{
    [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Key {get;set;}

    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public byte[] Value {get;set;}

    
}


}
