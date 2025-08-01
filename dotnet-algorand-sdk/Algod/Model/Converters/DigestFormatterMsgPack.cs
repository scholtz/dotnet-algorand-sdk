using MessagePack;
using MessagePack.Formatters;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Converters
{
    public class DigestFormatterMsgPack : IMessagePackFormatter<Digest>
    {
        public void Serialize(ref MessagePackWriter writer, Digest value, MessagePackSerializerOptions options)
        {
            writer.Write(value.Bytes);
        }

        public Digest Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var bytes = reader.ReadBytes();
            if (bytes is null) return null;
            return new Digest(bytes.Value.ToArray());
        }
    }

}
