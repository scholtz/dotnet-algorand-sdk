using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class Byte : UInt
    {
        public Byte() : base(8)
        {
        }
        public Byte(byte data) : base(8)
        {
            base.From(data);
        }
    }
}
