using System.Numerics;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class UInt512 : UInt
    {
        /// <summary>
        /// Create uint512 instance with empty constructor
        /// </summary>
        /// <param name="value"></param>
        public UInt512() : base(512)
        {
        }
        /// <summary>
        /// Create uint512 instance with value
        /// </summary>
        /// <param name="value"></param>
        public UInt512(object value) : base(256)
        {
            base.From(value);
        }
    }
}
