using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    public partial class StateSchema
    {
        public bool ShouldSerializeNumByteSlice()
        {
            return (NumByteSlice??0) != 0 ;
        }

        public bool ShouldSerializeNumUint()
        {
            return (NumUint ?? 0) != 0;
        }
    }
}
