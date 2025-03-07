using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class String : VariableArray<Byte>
    {
        public String() : base("byte")
        {
        }
    }
}
