using Algorand.Algod.Model.Transactions;
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
            string ADDR = "KV2XGKMXGYJ6PWYQA5374BYIQBL3ONRMSIARPCFCJEAMAHQEVYPB7PL3KU";

            AssetFreezeTransaction txn = new AssetFreezeTransaction() { AssetFreezeID = 123, FreezeState = false, FreezeTarget = new Algorand.Address(ADDR) };
            

            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);

            Assert.IsInstanceOfType(transaction, typeof(AssetFreezeTransaction));
        }

      
    }
}
