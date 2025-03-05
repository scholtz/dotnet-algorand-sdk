using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.AlgoStudio.ABI.ARC56
{
    public interface AVMObjectType
    {
        public abstract byte[] ToByteArray();
    }
}
