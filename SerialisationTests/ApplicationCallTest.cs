using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace SerialisationTests
{
    [TestClass]
    public class ApplicationCallTest
    {
        [TestMethod]
        public void ClearState()
        {
            ApplicationClearStateTransaction txn = new ApplicationClearStateTransaction()
            {
                ApplicationId = 123,

            };

           
            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(ApplicationClearStateTransaction));
        }

        [TestMethod]
        public void OptIn()
        {
            ApplicationOptInTransaction txn = new ApplicationOptInTransaction()
            {
                ApplicationId = 123,

            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(ApplicationOptInTransaction));
        }

        [TestMethod]
        public void Update()
        {
            ApplicationUpdateTransaction txn = new ApplicationUpdateTransaction()
            {
                ApplicationId = 123,
                ApprovalProgram = new Algorand.TEALProgram("BEAB"),
                ClearStateProgram = new Algorand.TEALProgram("BEAB"),
                GlobalStateSchema = new StateSchema(),
                LocalStateSchema = new StateSchema()
            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(ApplicationUpdateTransaction));
        }

        [TestMethod]
        public void CloseOut()
        {
            ApplicationCloseOutTransaction txn = new ApplicationCloseOutTransaction()
            {
                ApplicationId = 123,

            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(ApplicationCloseOutTransaction));
        }

        [TestMethod]
        public void Create()
        {
            ApplicationCreateTransaction txn = new ApplicationCreateTransaction()
            {
 
                ApprovalProgram = new Algorand.TEALProgram("BEAB"),
                ClearStateProgram = new Algorand.TEALProgram("BEAB"),
                GlobalStateSchema = new StateSchema(),
                LocalStateSchema = new StateSchema()

            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(ApplicationCreateTransaction));
        }

        [TestMethod]
        public void Delete()
        {
            ApplicationDeleteTransaction txn = new ApplicationDeleteTransaction()
            {
                ApplicationId = 123,

            };


            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(ApplicationDeleteTransaction));
        }

        [TestMethod]
        public void Noop()
        {
            ApplicationNoopTransaction txn = new ApplicationNoopTransaction()
            {
                ApplicationId = 123,

            };

            var txnJson = Encoder.EncodeToJson(txn);

            var transaction = JsonConvert.DeserializeObject<Transaction>(txnJson);
            Assert.IsInstanceOfType(transaction, typeof(ApplicationNoopTransaction));
        }

    }
}
