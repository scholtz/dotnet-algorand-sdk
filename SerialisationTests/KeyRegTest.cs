using Algorand.Algod.Model;
using Algorand.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace SerialisationTests
{
    [TestClass]
    public class KeyRegTest
    {
        [TestMethod]
        public void KeyRegOnline()
        {
            KeyRegisterOnlineTransaction txn = new KeyRegisterOnlineTransaction()
            {
                VoteFirst = 2,
                VoteKeyDilution = 3
            };

            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);

            Assert.IsInstanceOfType(transaction, typeof(KeyRegisterOnlineTransaction));
        }

        [TestMethod]
        public void KeyRegOffline()
        {
            KeyRegisterOfflineTransaction txn = new KeyRegisterOfflineTransaction();

            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);

            Assert.IsInstanceOfType(transaction, typeof(KeyRegisterOfflineTransaction));
        }
    }
}
