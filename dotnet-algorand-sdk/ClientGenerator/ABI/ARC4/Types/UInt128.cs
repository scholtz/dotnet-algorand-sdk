using System.Numerics;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class UInt128 : UInt
    {
        /// <summary>
        /// Create uint128 instance with empty constructor
        /// </summary>
        /// <param name="value"></param>
        public UInt128() : base(128)
        {
        }
        /// <summary>
        /// Create uint128 instance with value
        /// </summary>
        /// <param name="value"></param>
        public UInt128(object value) : base(256)
        {
            base.From(value);
        }
    }
}
