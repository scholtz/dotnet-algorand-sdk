using MessagePack;
using MessagePack.Formatters;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Converters.MsgPack
{
    public class VRFPublicKeyFormatterMsgPack : IMessagePackFormatter<VRFPublicKey>
    {
        public void Serialize(ref MessagePackWriter writer, VRFPublicKey value, MessagePackSerializerOptions options)
        {
            writer.Write(value.Bytes);
        }

        public VRFPublicKey Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var bytes = reader.ReadBytes();
            if (bytes is null) return null;
            return new VRFPublicKey(bytes.Value.ToArray());
        }
    }

}
