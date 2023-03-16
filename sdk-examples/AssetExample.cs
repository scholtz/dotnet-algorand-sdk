using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace sdk_examples
{
    class AssetExample
    {
        public static async Task Main(params string[] args)
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            // These will be our three accounts for the demonstration.
            //
            //   If using Sandbox, please use the following commands to replace the below mnemonics:
            //   ./sandbox goal account list
            //   ./sandbox goal account export -a <address>
            //   Repeat the second command foreach account.
            Account acct1 = new Account("shaft web sell outdoor brick above promote call disease gift fun course grief hurdle key bamboo choice camp law lucky bitter skill term able ignore");
            Account acct2 = new Account("pipe want hockey shoulder gallery inner woman salute wrestle fashion define bonus broom start disease portion salt gesture measure prosper just draw engage ability dizzy");
            Account acct3 = new Account("above magic coast refuse poet world deputy shield index fork race crawl olympic glare improve aware valid drill orchard invest topic vault spend abandon high");

            // Create a connection to our sandbox node
            
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi algodApiInstance = new DefaultApi(httpClient);

            // PART 1: CREATE ASSET

            var ap = new AssetParams()
            {
                Name = "Asset Name",
                UnitName = "AST",
                Total = 10000,

                Manager = acct1.Address
            };

            var assetCreateTx = new AssetCreateTransaction()
            {
                AssetParams = ap
            };

            var tx = await MakeTransaction(assetCreateTx, acct1, algodApiInstance) as AssetCreateTransaction;

            var assetId = (ulong)tx.AssetIndex;
            Console.WriteLine($"Asset id is {assetId}\n");
            var ast = await algodApiInstance.GetAssetByIDAsync(assetId);

            // PART 2: UPDATE ASSET PARAMETERS

            // Now that we have a reference to our asset, we can update its parameters
            // Let's change the asset manager for example
            Console.WriteLine($"Current manager: {ast.Params.Manager}\n");
            ast.Params.Manager = acct2.Address;

            var assetUpdateTx = new AssetUpdateTransaction()
            {
                AssetParams = ast.Params
            };

            await MakeTransaction(assetUpdateTx, acct1, algodApiInstance); 

            ast = await algodApiInstance.GetAssetByIDAsync(assetId);
            Console.WriteLine($"Current manager: {ast.Params.Manager}\n");

            // PART 3: OPT INTO RECEIVING THE ASSET

            var assetOptInTx = new AssetAcceptTransaction()
            {
                XferAsset = assetId,
                AssetReceiver = acct3.Address
            };

            await MakeTransaction(assetOptInTx, acct3, algodApiInstance);

            // PART 4: TRANSFER ASSET

            var assetTransferTx = new AssetTransferTransaction()
            {
                XferAsset = assetId,
                AssetReceiver = acct3.Address,
                AssetAmount = 100
            };

            await MakeTransaction(assetTransferTx, acct1, algodApiInstance);

            // PART 5: FREEZE ASSET

            var assetFreezeTx = new AssetFreezeTransaction()
            {
                AssetFreezeID = assetId,
                FreezeState = true,
                FreezeTarget = acct3.Address,
            };

            await MakeTransaction(assetFreezeTx, acct2, algodApiInstance);

            // PART 6: ASSET CLAWBACK

            var artx = new AssetClawbackTransaction()
            {
                XferAsset = assetId,
                AssetSender = acct3.Address,
                AssetReceiver = acct1.Address,
                AssetAmount = 10
            };

            await MakeTransaction(artx, acct2, algodApiInstance);

            // PART 7: DESTROY ASSET

            var assetDestroyTx = new AssetDestroyTransaction()
            {
                AssetIndex = assetId,
            };

            await MakeTransaction(assetDestroyTx, acct2, algodApiInstance);
        }

        static async Task<Transaction> MakeTransaction(Transaction tx, Account sender, DefaultApi apiInstance)
        {
            Console.WriteLine("Making transaction: " + tx.GetType().Name);

            try
            {
                // Get the prameters for constructing a new transaction.
                // Required before every transaction in order to get the latest parameters from the blockchain.
                var transParams = await apiInstance.TransactionParamsAsync();

                tx.SetFee(transParams.Fee);
                tx.FirstValid = transParams.LastRound;
                tx.LastValid = transParams.LastRound + 1000;
                tx.GenesisHash = new Digest(transParams.GenesisHash);
                tx.GenesisID = transParams.GenesisId;
            }
            catch (HttpRequestException e)
            {
                Console.Error.WriteLine("Could not get transaction parameters response: " + e.Message);
                Environment.Exit(1);
            }

            tx.Sender = sender.Address;

            var signedTx = tx.Sign(sender);

            try
            {
                var response = await Utils.SubmitTransaction(apiInstance, signedTx);
                var result = await Utils.WaitTransactionToComplete(apiInstance, response.Txid);
                Console.WriteLine($"Transaction ID: {response.Txid}\nConfirmed round: {result.ConfirmedRound}\n");

                if (result is AssetCreateTransaction)
                { 
                    return result as AssetCreateTransaction;
                }

                return result;
            }
            catch (ApiException<ErrorResponse> e)
            {
                Console.Error.WriteLine(e.Result.Message);
                Environment.Exit(1);
            }

            return null;
        }
    }
}