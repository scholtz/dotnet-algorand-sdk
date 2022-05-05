using Algorand.Algod.Model;
using Algorand.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace SerialisationTests
{
    [TestClass]
    public class AssetFreezeTxnTest
    {
        [TestMethod]
        public void AssetFreezeTxn()
        {
            AssetFreezeTransaction txn = new AssetFreezeTransaction() { AssetFreezeID = 123, FreezeState = false, FreezeTarget = new Algorand.Address() };
            

            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);

            Assert.IsInstanceOfType(transaction, typeof(AssetFreezeTransaction));
        }

      
    }
}
