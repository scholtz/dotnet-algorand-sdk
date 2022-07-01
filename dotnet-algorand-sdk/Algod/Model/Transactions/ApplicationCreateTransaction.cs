


using Algorand.Utils;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{

    public partial class ApplicationCreateTransaction : ApplicationNoopTransaction
    {

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
