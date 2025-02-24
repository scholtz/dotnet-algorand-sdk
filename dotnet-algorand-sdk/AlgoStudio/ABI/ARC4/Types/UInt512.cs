using System.Numerics;

namespace AlgoStudio.ABI.ARC4.Types
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
        /// Create uint512 instance from bigint value
        /// </summary>
        /// <param name="value"></param>
        public UInt512(BigInteger value) : base(512)
        {
            base.Value = value;
        }
        /// <summary>
        /// Create UInt512 instance from byte array
        /// </summary>
        /// <param name="value"></param>
        public UInt512(byte[] value) : base(512)
        {
            base.Decode(value);
        }
    }
}
