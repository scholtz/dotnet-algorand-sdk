
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public abstract class AssetMovementsTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type",Required =Required.Always)]
        private string type => "axfer";


        [JsonProperty(PropertyName = "xaid", Required = Required.Always)]
        [DefaultValue(0)]
        public ulong? XferAsset = 0;

      



     


    
    }
}
