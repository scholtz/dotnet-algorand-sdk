using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class VariableArray<T> : WireType where T : WireType, new()
    {
        public override string GetDescription()
        {
            return Value.FirstOrDefault().GetDescription() + "[]";
        }
        public List<T> Value { get; set; } = new List<T>();
        public override bool IsDynamic => Value.Exists(v => v.IsDynamic);


        public override uint Decode(byte[] data)
        {
            //read the bigendian ushort length and instantiate the tuple
            if (data.Length < 2) throw new ArgumentException("Invalid data length");
            var lengthBytes = data.Take(2).ToArray();
            if (BitConverter.IsLittleEndian) lengthBytes = lengthBytes.Reverse().ToArray();
            ushort length = BitConverter.ToUInt16(lengthBytes, 0);
            Tuple tuple = new Tuple();
            tuple.Value = new List<WireType>(length);
            for (int i = 0; i < length; i++)
            {
                tuple.Value.Add(new T());
            }
            data = data.Skip(2).ToArray();
            //decode the tuple
            uint offset = tuple.Decode(data);
            Value = tuple.Value.Cast<T>().ToList();
            return offset + 2;
        }

        public override byte[] Encode()
        {
            byte[] bytes;
            if (Value == null)
            {
                bytes = new byte[0];
            }
            else
            {
                var lengthBytes = BitConverter.GetBytes((ushort)(Value.Count));
                if (BitConverter.IsLittleEndian) lengthBytes = lengthBytes.Reverse().ToArray();
                Tuple tuple = new Tuple();
                tuple.Value.AddRange(Value);
                var tupleBytes = tuple.Encode();
                bytes = lengthBytes.Concat(tupleBytes).ToArray();

            }
            return bytes;
        }

        public override bool From(object instance)
        {
            if (instance is List<T> listV)
            {
                Value = listV;
                return true;
            }
            if (instance is string stringV)
            {
                var bytes = Encoding.UTF8.GetBytes(stringV);
                Value.AddRange(bytes.Select(b => new Byte(b) as T));
                return true;
            }
            if (instance is byte[] bytesV)
            {
                Value.AddRange(bytesV.Select(b => new Byte(b) as T));
                return true;
            }
            if (instance is string[] stringA)
            {
                Value.AddRange(stringA.Select(s => { var t = new T(); t.From(s); return t; }));
                return true;
            }
            throw new NotImplementedException();
        }
        public override object ToValue()
        {
            if (Value.FirstOrDefault() is Byte b)
            {
                var bArr = Value.Select(b => (byte)b.ToValue());
                return Encoding.UTF8.GetString(bArr.ToArray());
            }
            return Value;
        }
        public byte[] ToByteArray()
        {
            if (Value.FirstOrDefault() is Byte b)
            {
                return Value.Select(b => (byte)b.ToValue()).ToArray();
            }
            return null;
        }
        public string[] ToStringArray()
        {
            if (Value.FirstOrDefault() is String b)
            {
                return Value.Select(b => b.ToValue().ToString()).ToArray();
            }
            return null;
        }

    }
}
