using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;


namespace Algorand.Algod.Model.Transactions
{
  
    public abstract partial class AssetChangeTransaction : AssetConfigurationTransaction
    { 
        [JsonProperty(PropertyName = "caid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong AssetIndex { get; set; } = 0;

    }
}
