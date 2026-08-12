using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorand.Algod
{
    /// <summary>
    /// Convenience extensions on the algod client. These are the standard way of submitting
    /// transactions and awaiting their confirmation:
    ///
    ///   var submit = await algod.SubmitTransaction(signedTx);           // single transaction
    ///   var submit = await algod.SubmitTransactions(signedTxGroup);     // atomic group
    ///   var result = await algod.WaitTransactionToComplete(submit.Txid);
    /// </summary>
    public static class DefaultApiExtensions
    {
        /// <summary>
        /// Encodes and submits a signed transaction to the network.
        /// </summary>
        /// <param name="client">The algod api instance</param>
        /// <param name="signedTx">The signed transaction to broadcast</param>
        /// <returns>The transaction submission response carrying the transaction id</returns>
        public static async Task<PostTransactionsResponse> SubmitTransaction(this DefaultApi client, SignedTransaction signedTx)
        {
            return await client.TransactionsAsync(new List<SignedTransaction> { signedTx });
        }

        /// <summary>
        /// Encodes and submits a set of signed transactions (e.g. an atomic transfer group) to the network.
        /// </summary>
        /// <param name="client">The algod api instance</param>
        /// <param name="signedTxs">The signed transactions to broadcast</param>
        /// <returns>The transaction submission response carrying the first transaction id</returns>
        public static async Task<PostTransactionsResponse> SubmitTransactions(this DefaultApi client, IEnumerable<SignedTransaction> signedTxs)
        {
            return await client.TransactionsAsync(signedTxs as List<SignedTransaction> ?? signedTxs.ToList());
        }

        /// <summary>
        /// Waits until a submitted transaction is confirmed into a block (or fails with a pool error).
        /// </summary>
        /// <param name="client">The algod api instance</param>
        /// <param name="txID">transaction ID</param>
        /// <param name="timeout">how many rounds to check pending transactions for</param>
        /// <returns>The confirmed transaction</returns>
        public static async Task<Transaction> WaitTransactionToComplete(this DefaultApi client, string txID, ulong timeout = 3)
        {
            if (client == null || string.IsNullOrEmpty(txID) || timeout < 0)
            {
                throw new ArgumentException("Bad arguments for waitForConfirmation.");
            }
            NodeStatusResponse nodeStatusResponse = await client.GetStatusAsync();
            var startRound = nodeStatusResponse.LastRound + 1;
            var currentRound = startRound;
            while (currentRound < (startRound + timeout))
            {
                var pendingInfo = await client.PendingTransactionInformationAsync(txID, null) as Transaction;

                if (pendingInfo != null)
                {
                    if (pendingInfo.ConfirmedRound > 0)
                    {
                        // Got the completed Transaction
                        return pendingInfo;
                    }
                    if (pendingInfo.PoolError != null && pendingInfo.PoolError.Length > 0)
                    {
                        // If there was a pool error, then the transaction has been rejected!
                        throw new Exception("The transaction has been rejected with a pool error: " + pendingInfo.PoolError);
                    }
                }
                await client.WaitForBlockAsync(currentRound);
                currentRound++;
            }
            throw new Exception("Transaction not confirmed after " + timeout + " rounds!");
        }
    }
}
