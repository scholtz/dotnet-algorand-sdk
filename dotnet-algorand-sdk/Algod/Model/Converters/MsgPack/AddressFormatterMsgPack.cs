using MessagePack;
using MessagePack;
using MessagePack.Formatters;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Converters.MsgPack
{
    public class AddressFormatterMsgPack : IMessagePackFormatter<Address>
    {
        public void Serialize(ref MessagePackWriter writer, Address value, MessagePackSerializerOptions options)
        {
            writer.Write(value.Bytes);
        }

        public Address Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var bytes = reader.ReadBytes();
            if (bytes is null) return null;
            return new Address(bytes.Value.ToArray());
        }
    }

}
