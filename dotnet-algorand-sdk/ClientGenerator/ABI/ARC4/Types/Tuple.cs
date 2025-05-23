﻿using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class Tuple : WireType
    {
        public override string GetDescription()
        {
            if (Value.Select(w => w.GetDescription()).Distinct().Count() == 1)
            {
                if (IsDynamic)
                {
                    return $"{Value.First().GetDescription()}[]";
                }
                return $"{Value.First().GetDescription()}[{Value.Count}]";
            }
            return $"({string.Join(",", Value.Select(w => w.GetDescription()))})";
        }
        public List<WireType> Value { get; set; } = new List<WireType>();

        public override bool IsDynamic => Value.Exists(x => x.IsDynamic);

        public override uint Decode(byte[] data)
        {
            uint offset = 0;
            int boolCount = 0;
            foreach (var item in Value)
            {
                if (item is Bool)
                {
                    if (boolCount == 0) offset++;
                    byte mask = (byte)(0x80 >> boolCount);
                    boolCount++;
                    (item as Bool).Value = (data[0] & mask) != 0;
                    if (boolCount == 8)
                    {
                        boolCount = 0;
                        data = data.Skip(1).ToArray();

                    }
                }
                else
                {
                    uint len = item.Decode(data);
                    data = data.Skip((int)len).ToArray();
                    offset += len;
                }


            }
            return offset;
        }

        public override byte[] Encode()
        {
            List<byte[]> heads = new List<byte[]>();
            List<byte[]> tails = new List<byte[]>();


            int boolCount = 0;
            byte[] boolHead = new byte[1] { 0 };
            foreach (var item in Value)
            {
                byte[] encoded = item.Encode();
                if (item is Bool)
                {
                    if (boolCount % 8 == 0)
                    {
                        boolHead = encoded;
                        heads.Add(boolHead);
                        boolCount = 0;
                    }
                    else
                    {

                        boolHead[0] = (byte)(boolHead[0] | (encoded[0] >> boolCount));
                    }
                    boolCount++;
                    tails.Add(new byte[] { });

                }
                else
                {
                    boolCount = 0;
                    boolHead = new byte[1] { 0 };

                    if (item.IsDynamic)
                    {
                        heads.Add(new byte[2]); //reserve space for the offset
                        tails.Add(encoded);
                    }
                    else
                    {
                        heads.Add(encoded);
                        tails.Add(new byte[] { });
                    }
                }
            }

            ushort offset = (ushort)heads.Sum(x => x.Length);
            int tail = 0;
            int head = 0;
            //second pass to calculate the offsets
            foreach (var item in Value)
            {
                if (item.IsDynamic)
                {
                    var bytes = BitConverter.GetBytes(offset);
                    if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                    Buffer.BlockCopy(bytes, 0, heads[head], 0, 2);
                    head++;
                }
                offset += (ushort)tails[tail].Length;
                tail++;


            }

            //concatenate the heads and tails
            byte[] result = heads.SelectMany(x => x).Concat(tails.SelectMany(x => x)).ToArray();
            return result;
        }

        public override bool From(object instance)
        {
            Value.Clear();
            if (instance is List<object> listV)
            {
                foreach (var item in listV)
                {
                    var wiretype = WireType.FromABIDescription(TypeHelpers.CSTypeToAbiType(instance.GetType()));
                    wiretype.From(item);
                    Value.Add(wiretype);
                }
            }
            if (instance is byte[] bytes)
            {
                foreach (var item in bytes)
                {
                    var wiretype = WireType.FromABIDescription(TypeHelpers.CSTypeToAbiType(item.GetType()));
                    if (wiretype == null)
                    {
                        throw new Exception($"Unable to determine wiretype of {item.GetType()}");
                    }
                    wiretype.From(item);
                    Value.Add(wiretype);
                }
            }
            return true;
        }

        public override object ToValue()
        {
            var list = new List<object>();
            foreach (var item in Value)
            {
                list.Add(item.ToValue());
            }
            return list;
        }
    }
}
