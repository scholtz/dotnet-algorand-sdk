
namespace Algorand.Indexer.Model
{

using System = global::System;


public partial class TransactionAssetConfig{
    [Newtonsoft.Json.JsonProperty("asset-id", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? AssetId {get;set;}

    [Newtonsoft.Json.JsonProperty("params", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public AssetParams Params {get;set;}

    
}


}
