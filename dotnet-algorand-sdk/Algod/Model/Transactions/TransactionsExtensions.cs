using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algorand.Algod.Model.Transactions
{
    public static class TransactionsExtensions
    {
        public static Transaction FillInParams(this Transaction tx, TransactionParametersResponse transParams)
        {
            tx.Fee = Math.Max(transParams.Fee, 1000);
            tx.FirstValid = transParams.LastRound;
            tx.LastValid = transParams.LastRound + 1000;
            tx.GenesisHash = new Digest(transParams.GenesisHash);
            tx.GenesisId = transParams.GenesisId;
            return tx;
        }
        public static async Task<Transaction> FillInParams(this Transaction tx, DefaultApi apiInstance)
        {
            var transParams = await apiInstance.TransactionParamsAsync();

            tx.Fee = Math.Max(transParams.Fee, 1000);
            tx.FirstValid = transParams.LastRound;
            tx.LastValid = transParams.LastRound + 1000;
            tx.GenesisHash = new Digest(transParams.GenesisHash);
            tx.GenesisId = transParams.GenesisId;
            return tx;
        }
    }
}
