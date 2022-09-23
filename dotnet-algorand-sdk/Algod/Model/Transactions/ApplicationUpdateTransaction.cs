


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

    public partial class ApplicationUpdateTransaction : ApplicationCallTransaction
    {
        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Update;

        public bool ShouldSerializeGlobalStateSchema()
        {
            return GlobalStateSchema.NumByteSlice != 0 || GlobalStateSchema.NumUint != 0;
        }

        public bool ShouldSerializeLocalStateSchema()
        {
            return LocalStateSchema.NumByteSlice != 0 || LocalStateSchema.NumUint != 0;
        }


    }
}
