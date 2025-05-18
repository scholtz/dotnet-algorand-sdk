using Algorand.Algod.Model.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationTests
{
    [TestClass]
    public class MessagePackTest
    {
        public static byte[] HexToBytes(string hex)
        {
            if (hex.Length % 2 != 0)
                throw new ArgumentException("Hex string must have an even length");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);

            return bytes;
        }
        [TestMethod]
        public void TestCpp()
        {
            var txn = Algorand.Utils.Encoder.DecodeFromMsgPack<SignedTransaction>(HexToBytes("82a3736967c440f27ed757ae2f004a5b91cb2476b890e4a833237b8259c340bb70f4c070237b8c49c509916728a551acdb7fdbd18d7777ff4ef2ea6f8d52cfc3a7d8d233977801a374786e89a461726376c42064f765cb8652579cf8582e5f1a1a3a7ca57b8ba00bbfa1079d029a234a8290aaa3666565cd03e8a26676ce030c4ed4a367656eac746573746e65742d76312e30a26768c4204863b518a4b3c84ec810f22d4f1081cb0f71f059a7ac20dec62f7f70e5093a22a26c76ce030c52bca3736e64c42064f765cb8652579cf8582e5f1a1a3a7ca57b8ba00bbfa1079d029a234a8290aaa474797065a56178666572a478616964ce2bbb83cc"));
            var txnJson = Algorand.Utils.Encoder.EncodeToJson(txn);
            Assert.IsNotNull(txnJson);

            //var txn2 = new SignedTransaction()
            //{
            //    Sig = new Algorand.Signature(new byte[] {
            //        152,74,227,165,107,72,91,105,194,234,5,138,152,216,244,46,220,158,205,236,207,255,225,171,27,186,225,11,52,106,70,166,150,86,124,98,235,165,20,108,108,198,3,50,90,134,203,28,196,243,242,86,66,235,44,0,145,32,113,250,144,192,26,2
            //    }),
            //    Tx = new AssetTransferTransaction()
            //    {
            //        AssetAmount = 0,
            //        XferAsset = 733709260,
            //        GenesisHash = new Algorand.Digest(new byte[] { 72, 99, 181, 24, 164, 179, 200, 78, 200, 16, 242, 45, 79, 16, 129, 203, 15, 113, 240, 89, 167, 172, 32, 222, 198, 47, 127, 112, 229, 9, 58, 34 }),
            //        LastValid = 51139296,
            //        GenesisId = "testnet-v1.0",
            //        FirstValid = 51138296,
            //        Fee = 1000,
            //        AssetReceiver = new Algorand.Address(new byte[] { 100, 247, 101, 203, 134, 82, 87, 156, 248, 88, 46, 95, 26, 26, 58, 124, 165, 123, 139, 160, 11, 191, 161, 7, 157, 2, 154, 35, 74, 130, 144, 170 }),
            //    }
            //};


            var txn2 = Algorand.Utils.Encoder.DecodeFromMsgPack<SignedTransaction>(HexToBytes("82A3736967C440413363C746C67C135A5C327C0D487766633C008B2C2E711C50B17B7BA3E95ED1FC2255AFF40359B8DCC07C8C97D4394D005179196EE1F550552286FE96A0350CA374786E88A46170617289A2616EA84D79204173736574A26175B368747470733A2F2F6578616D706C652E636F6DA163C42064F765CB8652579CF8582E5F1A1A3A7CA57B8BA00BBFA1079D029A234A8290AAA26463CC02A166C42064F765CB8652579CF8582E5F1A1A3A7CA57B8BA00BBFA1079D029A234A8290AAA16DC42064F765CB8652579CF8582E5F1A1A3A7CA57B8BA00BBFA1079D029A234A8290AAA172C42064F765CB8652579CF8582E5F1A1A3A7CA57B8BA00BBFA1079D029A234A8290AAA174CE000F4240A2756EA4554E4954A3666565CD03E8A26676CE030E7986A367656EAC746573746E65742D76312E30A26768C4204863B518A4B3C84EC810F22D4F1081CB0F71F059A7AC20DEC62F7F70E5093A22A26C76CE030E7D6EA3736E64C42064F765CB8652579CF8582E5F1A1A3A7CA57B8BA00BBFA1079D029A234A8290AAA474797065A461636667"));
            var txnJson2 = Algorand.Utils.Encoder.EncodeToJson(txn2);
            Assert.IsNotNull(txnJson2);

            Assert.AreEqual(txnJson, txnJson2);
        }
    }
}
