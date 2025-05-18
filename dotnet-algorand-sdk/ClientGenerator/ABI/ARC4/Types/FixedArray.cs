using System;
using System.Linq;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class FixedArray<T> : Tuple where T : WireType, new()
    {
        public uint Length { get; private set; }

        public FixedArray(uint length)
        {
            Length = length;
            Value = new System.Collections.Generic.List<WireType>((int)length);
            for (int i = 0; i < length; i++)
            {
                Value.Add(new T());
            }
        }
        public override bool From(object instance)
        {
            return base.From(instance);
        }
        public byte[] ToByteArray()
        {
            if (Value.FirstOrDefault() is Byte b)
            {
                return Value.Select(b => (byte)b.ToValue()).ToArray();
            }
            return null;
        }
    }
}
