using MessagePack;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    [MessagePackObject]
    public partial class StateSchema
    {
        public bool ShouldSerializeNumByteSlice()
        {
            return NumByteSlice != 0 ;
        }

        public bool ShouldSerializeNumUint()
        {
            return NumUint  != 0;
        }
    }
}
