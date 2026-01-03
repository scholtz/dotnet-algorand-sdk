using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{
    public partial class SignedTransaction
    {
        /// <summary>
        /// Decode signed transaction from base64 string
        /// </summary>
        /// <param name="b64">Base64 encoded string</param>
        /// <returns></returns>
        public static SignedTransaction FromBase64String(string b64)
        {
            byte[] txBytes = Convert.FromBase64String(b64);
            return Utils.Encoder.DecodeFromMsgPack<SignedTransaction>(txBytes);
        }
    }
}
