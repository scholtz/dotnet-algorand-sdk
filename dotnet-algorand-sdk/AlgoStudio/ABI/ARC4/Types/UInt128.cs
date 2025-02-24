using System.Numerics;

namespace AlgoStudio.ABI.ARC4.Types
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
        /// Create uint128 instance from bigint value
        /// </summary>
        /// <param name="value"></param>
        public UInt128(BigInteger value) : base(128)
        {
            base.Value = value;
        }
        /// <summary>
        /// Create UInt128 instance from byte array
        /// </summary>
        /// <param name="value"></param>
        public UInt128(byte[] value) : base(128)
        {
            base.Decode(value);
        }
    }
}
