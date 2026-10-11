using Algorand.Algod.Model;
using NUnit.Framework;
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
            var lsig = block.Block.Transactions.First().LSig;
            Assert.That(lsig, Is.Not.Null);
            Assert.That(lsig.Logic.Length, Is.EqualTo(1805));
            Assert.That(lsig.Args.Single().Length, Is.EqualTo(1226));
        }
    }
}
