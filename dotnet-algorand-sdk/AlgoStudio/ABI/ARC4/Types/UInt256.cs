using System.Numerics;

namespace AlgoStudio.ABI.ARC4.Types
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
        /// Create uint256 instance from bigint value
        /// </summary>
        /// <param name="value"></param>
        public UInt256(BigInteger value) : base(256)
        {
            base.Value = value;
        }
        /// <summary>
        /// Create UInt256 instance from byte array
        /// </summary>
        /// <param name="value"></param>
        public UInt256(byte[] value) : base(256)
        {
            base.Decode(value);
        }
    }
}
