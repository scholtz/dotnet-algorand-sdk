using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{


    public partial class AssetUpdateTransaction : AssetChangeTransaction
    {
        [JsonProperty(PropertyName = "apar")]
        public AssetParams AssetParams { get; set; }



    }
}
