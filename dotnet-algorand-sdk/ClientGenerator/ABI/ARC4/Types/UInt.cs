using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class UInt : WireType
    {
        public uint BitWidth { get; private set; }
        private BigInteger _value;
        public BigInteger Value { get { return _value; } set { if (value < 0 || value >= BigInteger.Pow(2, (int)BitWidth)) throw new ArgumentException("Invalid value bitwidth."); else _value = value; } }

        public override bool IsDynamic => false;

        public UInt(uint bitwidth)
        {
            //check if bitwidth is modulo 8 and between 8 and 512. also make sure the value fits in the bitwidth:
            if (bitwidth % 8 != 0 || bitwidth < 8 || bitwidth > 512)
            {
                throw new ArgumentException("Invalid bitwidth.");
            }

            BitWidth = bitwidth;
        }
        private UInt()
        {
        }
        /// <summary>
        /// Create UInt instance with value
        /// </summary>
        /// <param name="value"></param>
        public UInt(object value)
        {
            From(value);
        }

        public override byte[] Encode()
        {
            //convert Value to big endian byte array, padding with zeros if necessary to match bitwidth:
            byte[] bytes = Value.ToByteArray();
            Array.Reverse(bytes); //BigInteger is always little endian, so we need to reverse it to get big endian.
            if (bytes.Length * 8 < BitWidth)
            {
                byte[] padded = new byte[BitWidth / 8];
                Array.Copy(bytes, 0, padded, padded.Length - bytes.Length, bytes.Length);
                bytes = padded;
            }
            else if (bytes.Length * 8 > BitWidth)
            {
                throw new InvalidOperationException("Value does not fit in bitwidth");
            }

            return bytes;

        }

        public override uint Decode(byte[] data)
        {
            //get the bytes from data for the bitwidth size, reverse them to little endian and convert to BigInteger:
            if (data.Length * 8 < BitWidth)
            {
                throw new ArgumentException("Invalid data length");
            }
            int byteLength = (int)BitWidth / 8;
            byte[] bytes = data.Take(byteLength).ToArray();
            Array.Reverse(bytes);
            Value = new BigInteger(bytes);
            return (uint)byteLength;
        }

        public override bool From(object instance)
        {
            if (instance is BigInteger sInstance)
            {
                Value = sInstance;
                return true;
            }
            if (instance is ulong ulongV)
            {
                Value = new BigInteger(ulongV);
                return true;
            }
            if (instance is uint uintV)
            {
                Value = new BigInteger(uintV);
                return true;
            }
            if (instance is long longV)
            {
                Value = new BigInteger(longV);
                return true;
            }
            if (instance is int intV)
            {
                Value = new BigInteger(intV);
                return true;
            }
            if (instance is decimal decimalV)
            {
                Value = new BigInteger(decimalV);
                return true;
            }
            if (instance is double doubleV)
            {
                Value = new BigInteger(doubleV);
                return true;
            }
            if (instance is float floatV)
            {
                Value = new BigInteger(floatV);
                return true;
            }
            if (instance is byte byteV)
            {
                Value = new BigInteger(byteV);
                return true;
            }
            throw new NotImplementedException();
        }

        public override object ToValue()
        {
            if (BitWidth == 8)
            {
                return Value.ToByteArray()[0]; 
            }
            if (BitWidth == 64)
            {
                return (ulong) Value;
            }
            return Value;
        }
    }
}
