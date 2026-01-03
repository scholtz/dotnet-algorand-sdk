using Algorand.Algod.Model.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{
    public abstract partial class Transaction : IReturnableTransaction
    {
        /// <summary>
        /// Decode unsigned transaction from base64 string
        /// </summary>
        /// <param name="b64">Base64 encoded string</param>
        /// <returns></returns>
        public static Transaction FromBase64String(string b64)
        {
            byte[] txBytes = Convert.FromBase64String(b64);
            return Algorand.Utils.Encoder.DecodeFromMsgPack<Transaction>(txBytes);
        }
    }
}
