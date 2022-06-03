using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
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
                AssetParams = new AssetParams() { Creator=new Algorand.Address(), Decimals=1,Total=1}

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
                AssetParams = new AssetParams() { Creator = new Algorand.Address(), Decimals = 1, Total = 1 }
            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetUpdateTransaction));
        }

        [TestMethod]
        public void Destroy()
        {
            AssetDestroyTransaction txn = new AssetDestroyTransaction()
            {
  
                AssetIndex = 2
            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetDestroyTransaction));
        }


    }
}
