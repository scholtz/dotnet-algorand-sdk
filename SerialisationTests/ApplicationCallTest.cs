using Algorand.Algod.Model;
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
        }
    }
}
