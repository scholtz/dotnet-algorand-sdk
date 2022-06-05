

using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    public partial class AssetFreezeTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        public string type => "afrz";

       
    }
}
