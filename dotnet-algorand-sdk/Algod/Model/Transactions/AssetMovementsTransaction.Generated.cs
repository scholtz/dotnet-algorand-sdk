
using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

   
    public abstract partial class AssetMovementsTransaction : Transaction
    {
        [JsonProperty(PropertyName = "xaid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? XferAsset { get; set; } = 0;
    }
}
