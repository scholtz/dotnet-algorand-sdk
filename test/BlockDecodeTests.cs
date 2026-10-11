using Algorand.Algod.Model;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace test
{
    [TestFixture]
    public class BlockDecodeTests
    {
        // Regression: MainNet block 64000338 holds a payment signed by a LogicSig with a
        // 1226-byte argument and a 1805-byte program. Decoding used to throw
        // MessageTypeException ("Cannot convert 'raw' header from PositiveFixNum").
        [Test]
        public void DecodesMainNetBlock64000338WithLargeLogicSig()
        {
            var bytes = File.ReadAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "mainnet-block-64000338.msgpack"));

            var block = Algorand.Utils.Encoder.DecodeFromMsgPack<CertifiedBlock>(bytes);

            Assert.That(block.Block.Round, Is.EqualTo(64000338UL));
            var lsig = block.Block.Transactions.Select(t => t.LSig).First(l => l != null);
            Assert.That(lsig.Logic.Length, Is.EqualTo(1805));
            var arg = lsig.Args.Single();
            Assert.That(arg.Length, Is.EqualTo(1226));
            // content, not just length: both must appear verbatim in the wire bytes
            Assert.That(IndexOf(bytes, arg), Is.GreaterThanOrEqualTo(0), "arg bytes differ from the wire data");
            Assert.That(Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(arg)), Is.EqualTo("25EE682213E2A31A51CEBE59CF7A4EF4E0F109D3C0130BCEEDD693D030CC001C"));
            Assert.That(IndexOf(bytes, lsig.Logic), Is.GreaterThanOrEqualTo(0), "program bytes differ from the wire data");
            Assert.That(lsig.Sig, Is.Null);
            Assert.That(lsig.Msig, Is.Null);
        }

        // The Encoder falls back silently to a second decoder when the MessagePack-CSharp path throws,
        // so also pin the fast path (NoDefaultsFormatter.Deserializer) directly.
        [Test]
        public void FastPathDecodesLargeLogicSigArgs()
        {
            var bytes = File.ReadAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "mainnet-block-64000338.msgpack"));
            var options = MessagePack.MessagePackSerializerOptions.Standard.WithResolver(
                MessagePack.Resolvers.CompositeResolver.Create(
                    new MessagePack.Formatters.IMessagePackFormatter[] { Algorand.Algod.Model.Converters.MsgPack.NullableStringFormatterMsgPack.Instance },
                    new MessagePack.IFormatterResolver[] { MessagePack.Resolvers.ContractlessStandardResolver.Instance }));

            var block = MessagePack.MessagePackSerializer.Deserialize<CertifiedBlock>(bytes, options);

            Assert.That(block.Block.Transactions.Select(t => t.LSig).First(l => l != null).Args.Single().Length, Is.EqualTo(1226));
        }

        private static int IndexOf(byte[] haystack, byte[] needle)
        {
            return haystack.AsSpan().IndexOf(needle.AsSpan());
        }
    }
}
