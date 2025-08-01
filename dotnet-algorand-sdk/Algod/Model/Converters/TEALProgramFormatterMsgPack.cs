using MessagePack;
using MessagePack.Formatters;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Converters
{
    public class TEALProgramFormatterMsgPack : IMessagePackFormatter<TEALProgram>
    {
        public void Serialize(ref MessagePackWriter writer, TEALProgram value, MessagePackSerializerOptions options)
        {
            writer.Write(value.Bytes);
        }

        public TEALProgram Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var bytes = reader.ReadBytes();
            if (bytes is null) return null;
            return new TEALProgram(bytes.Value.ToArray());
        }
    }

}
