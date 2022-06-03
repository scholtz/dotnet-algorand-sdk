using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace SerialisationTests
{
    [TestClass]
    public class AssetMovementsTest
    {
        [TestMethod]
        public void Accept()
        {
            AssetAcceptTransaction txn = new AssetAcceptTransaction()
            {
                AssetReceiver = new Algorand.Address(),
                XferAsset=2
            };

           
            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetAcceptTransaction));
        }


        [TestMethod]
        public void Clawback()
        {
            AssetClawbackTransaction txn = new AssetClawbackTransaction()
            {
                AssetReceiver = new Algorand.Address(),
                AssetAmount = 5,
                AssetSender = new Algorand.Address(),
                XferAsset = 2
            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetClawbackTransaction));
        }

        [TestMethod]
        public void Txfer()
        {
            AssetTransferTransaction txn = new AssetTransferTransaction()
            {
                AssetReceiver = new Algorand.Address(),
                AssetAmount = 5,
                XferAsset = 2

            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(AssetTransferTransaction));
        }


    }
}
