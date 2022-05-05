using Algorand.Algod.Model;
using Algorand.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace SerialisationTests
{
    [TestClass]
    public class AssetConfigTest
    {
        [TestMethod]
        public void Create()
        {
            AssetCreateTransaction txn = new AssetCreateTransaction()
            {
                AssetParams = new AssetParams() 

            };

           
            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetCreateTransaction));
        }


        [TestMethod]
        public void Update()
        {
            AssetUpdateTransaction txn = new AssetUpdateTransaction()
            {
                AssetIndex = 2,
                AssetParams = new AssetParams()
            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetClawbackTransaction));
        }

        [TestMethod]
        public void Destroy()
        {
            AssetDestroyTransaction txn = new AssetDestroyTransaction()
            {
                AssetParams=null,
                AssetIndex = 2
            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetDestroyTransaction));
        }


    }
}
