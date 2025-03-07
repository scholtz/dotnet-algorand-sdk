using System.Numerics;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class UInt256 : UInt
    {
        /// <summary>
        /// Create uint256 instance with empty constructor
        /// </summary>
        /// <param name="value"></param>
        public UInt256() : base(256)
        {
        }
        /// <summary>
        /// Create uint256 instance with value
        /// </summary>
        /// <param name="value"></param>
        public UInt256(object value) : base(256)
        {
            base.From(value);
        }
    }
}
