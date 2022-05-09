
using Algorand.Algod.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Algorand.Utils
{
    /// <summary>
    /// Convenience methods for algorand sdk.
    /// </summary>
    public class Utils
    {
      
      
        /// <summary>
        /// utility function to wait on a transaction to be confirmed using algod v2 API
        /// </summary>
        /// <param name="instance">The algod api instance using algod v2 API</param>
        /// <param name="txID">transaction ID</param>
        /// <param name="timeout">how many rounds do you wish to check pending transactions for</param>
        /// <returns>The pending transaction response</returns>
        public static async Task<Algod.Model.CommittedTransaction> WaitTransactionToComplete(Algod.DefaultApi instance, string txID, ulong timeout = 3) 
        {

            if (instance == null || txID == null || txID.Length == 0 || timeout < 0)
            {
                throw new ArgumentException("Bad arguments for waitForConfirmation.");
            }
            NodeStatusResponse nodeStatusResponse = await instance.StatusAsync();            
            var startRound = nodeStatusResponse.LastRound + 1;
            var currentRound = startRound;
            while (currentRound < (startRound + timeout))
            {
                var pendingInfo = await instance.PendingGetAsync(txID,null);

                if (pendingInfo != null)
                {
                    if (pendingInfo.ConfirmedRound != null && pendingInfo.ConfirmedRound > 0)
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
                await instance.WaitForBlockAfterAsync(currentRound);
                currentRound++;
            }
            throw new Exception("Transaction not confirmed after " + timeout + " rounds!");
        }
      


        /// <summary>
        /// encode and submit signed transaction using algod v2 api
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="signedTx"></param>
        /// <returns></returns>
        public static async Task<PostTransactionsResponse> SubmitTransaction(Algod.DefaultApi instance, SignedTransaction signedTx) //throws Exception
        {
                    
                return await instance.TransactionsAsync(new List<SignedTransaction> { signedTx });
         
        }
        public static ulong AlgosToMicroalgos(double algos)
        {
            return Convert.ToUInt64(Math.Floor(algos * 1000000));
        }
        public static double MicroalgosToAlgos(ulong microAlgos)
        {
            return microAlgos / 1000000.0;
        }
        
       
        /// <summary>
        /// Generate a 32 bytes string for asset metadata hash
        /// </summary>
        /// <returns>a 32 bytes string</returns>
        public static string GetRandomAssetMetaHash()
        {
            Random rd = new Random();
            byte[] bts = new byte[32];
            rd.NextBytes(bts);
            //var base64 = Convert.ToBase64String(bts);
            return Convert.ToBase64String(bts);
        }
       
    
       
      

      
 

      

     
       
    

      
        private static void ValidateAsset(AssetParams asset)
        {
            if (asset.Creator is null ) throw new ArgumentException("The sender must be specified.");
         
            
            if (asset.Name is null || asset.Name == "") throw new ArgumentException("The asset name must be specified.");
            
            if (asset.UnitName is null || asset.UnitName == "") throw new ArgumentException("The unit name must be specified.");
            else if (asset.UnitName.Length > 8) throw new ArgumentException(string.Format("The length of unit name is {0} > 8.", asset.UnitName.Length));
            
            if (asset.Total is null || asset.Total < 1) throw new ArgumentException("The total number of the asset must be specified and bigger than zero.");
            
            if (asset.Manager is null) asset.Manager = asset.Creator;
            
            if (asset.Reserve is null) asset.Reserve = asset.Manager;
            
            if (asset.Freeze is null) asset.Freeze = asset.Manager;
             
            if (asset.Clawback is null) asset.Clawback = asset.Manager;
            
            if (asset.MetadataHash is null || asset.MetadataHash.Length == 0)
                asset.MetadataHash = Encoding.UTF8.GetBytes(GetRandomAssetMetaHash());//auto generate metahash by sdk
            else if (asset.MetadataHash.Length != 32)
                throw new ArgumentException("The metadata hash should be 32 bytes.");

            if (asset.DefaultFrozen is null) asset.DefaultFrozen = false;
        }
      
       
        
     
      
        
    
      
     
        public async static Task<Algod.Model.DryrunResponse> GetDryrunResponse(Algod.DefaultApi client, SignedTransaction stxn, byte[] source = null)
        {
            List<DryrunSource> sources = new List<DryrunSource>();
            List<SignedTransaction> stxns = new List<SignedTransaction>();
            //compiled 
            if (source is null)
            {
                stxns.Add(stxn);
            }
            // source
            else
            {
                sources.Add(new Algod.Model.DryrunSource(){
                    FieldName= "lsig",
                    Source= Encoding.UTF8.GetString(source), TxnIndex= 0 });
                stxns.Add(stxn);
            }
            if (sources.Count < 1) sources = null;
            return await client.DryrunAsync(new DryrunRequest() { Txns = stxns, Sources = sources });
        }

        internal static byte[] CombineBytes(byte[] b1, byte[] b2)
        {
            byte[] ret = new byte[b1.Length + b2.Length];
            Buffer.BlockCopy(b1, 0, ret, 0, b1.Length);
            Buffer.BlockCopy(b2, 0, ret, b1.Length, b2.Length);
            return ret;
        }
    }
}
