using MessagePack;
using MessagePack;
using MessagePack.Formatters;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Converters.MsgPack
{
    public class ParticipationPublicKeyFormatterMsgPack : IMessagePackFormatter<ParticipationPublicKey>
    {
        public void Serialize(ref MessagePackWriter writer, ParticipationPublicKey value, MessagePackSerializerOptions options)
        {
            writer.Write(value.Bytes);
        }

        public ParticipationPublicKey Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var bytes = reader.ReadBytes();
            if (bytes is null) return null;
            return new ParticipationPublicKey(bytes.Value.ToArray());
        }
    }

}
