using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace sdk_examples.contract
{
    class StatefulContract
    {
        public static async Task Main(params string[] args)
        {
            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            if (ALGOD_API_ADDR.IndexOf("//") == -1)
            {
                ALGOD_API_ADDR = "http://" + ALGOD_API_ADDR;
            }
       
            string adminMnemonic = "lift gold aim couch filter amount novel scrap annual grow amazing pioneer disagree sense phrase menu unknown dolphin style blouse guide tell also about case";
            Account admin = new Account(adminMnemonic);
            string creatorMnemonic = "oval brown real consider grow someone impulse palace elegant code elegant victory observe nerve thunder trash mutual viable patient ask below imitate gallery able text";
            string userMnemonic = "clog tide item robust bounce fiction axis violin night steel frame pear ice proud consider uphold gaze polar page call infant segment page abstract diamond";



            // create two accounts to create and uses the stateful contract
            var creator = new Account(creatorMnemonic);
            var user = new Account(userMnemonic);
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            DefaultApi client = new DefaultApi(httpClient);

            
            // declare application state storage (immutable)
            ulong localInts = 1;
            ulong localBytes = 1;
            ulong globalInts = 1;
            ulong globalBytes = 0;

            // user declared approval program (initial)
            string approvalProgramSourceInitial = File.ReadAllText("contract/stateful_approval_init.teal");

            // user declared approval program (refactored)
            string approvalProgramSourceRefactored = File.ReadAllText("contract/stateful_approval_refact.teal");
         
            // declare clear state program source
            string clearProgramSource = File.ReadAllText("contract/stateful_clear.teal");

            CompileResponse approvalProgram;
            CompileResponse clearProgram;
            CompileResponse approvalProgramRefactored;

            using (var datams = new MemoryStream(Encoding.UTF8.GetBytes(approvalProgramSourceInitial)))
            {
                approvalProgram = await client.TealCompileAsync(datams);
            }
            using (var datams = new MemoryStream(Encoding.UTF8.GetBytes(clearProgramSource)))
            {
                clearProgram = await client.TealCompileAsync(datams);
            }
            using (var datams = new MemoryStream(Encoding.UTF8.GetBytes(approvalProgramSourceRefactored)))
            {
                approvalProgramRefactored = await client.TealCompileAsync(datams);
            }



            try
            {
                // create new application
                var appid = await CreateApp(client, creator, new TEALProgram(approvalProgram.Result),
                    new TEALProgram(clearProgram.Result), globalInts, globalBytes, localInts, localBytes);

                // opt-in to application
                await OptIn(client, user, appid);
                // call application without arguments
                await CallApp(client, user, appid, null);
                // read local state of application from user account
                await ReadLocalState(client, user, appid);

                // read global state of application
                await ReadGlobalState(client, creator, appid);

                // update application
                await UpdateApp(client, creator, appid,
                    new TEALProgram(approvalProgramRefactored.Result),
                    new TEALProgram(clearProgram.Result));
                // call application with arguments
                var date = DateTime.Now;
                Console.WriteLine(date.ToString("yyyy-MM-dd 'at' HH:mm:ss"));
                List<byte[]> appArgs = new List<byte[]>
                {
                    Encoding.UTF8.GetBytes(date.ToString("yyyy-MM-dd 'at' HH:mm:ss"))
                };
                await CallApp(client, user, appid, appArgs);

                // read local state of application from user account
                await ReadLocalState(client, user, appid);

                // close-out from application
                await CloseOutApp(client, user, (ulong)appid);

                // opt-in again to application
                await OptIn(client, user, appid);

                // call application with arguments
                await CallApp(client, user, appid, appArgs);

                // read local state of application from user account
                await ReadLocalState(client, user, appid);

                // delete application
                await DeleteApp(client, creator, appid);

                // clear application from user account
                await ClearApp(client, user, appid);

                Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                // This is generally expected, but should give us an informative error message.
                Console.WriteLine("Exception when calling algod#sendTransaction: " + e.Message);
            }
        }
        public static async Task CloseOutApp(DefaultApi client, Account sender, ulong appId)
        {
            try
            {
                var transParams = await client.TransactionParamsAsync();
                var tx = new ApplicationCloseOutTransaction()
                {
                    Sender = sender.Address,
                    ApplicationId = appId,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                };


                var signedTx = tx.Sign(sender);
                Console.WriteLine("Signed transaction with txid: " + signedTx.Tx.TxID());

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid);
                Console.WriteLine("Confirmed Round is: " + resp.ConfirmedRound);
                Console.WriteLine("Application ID is: " + appId);
            }
            catch (Algorand.Algod.Model.ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
            }
        }

        private static async Task UpdateApp(DefaultApi client, Account creator, ulong? appid, TEALProgram approvalProgram, TEALProgram clearProgram)
        {
            try
            {
                var transParams = await client.TransactionParamsAsync();
                var tx = new ApplicationUpdateTransaction()
                {
                    Sender = creator.Address,
                    ApplicationId = appid,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                    ApprovalProgram = approvalProgram,
                    ClearStateProgram = clearProgram
                };

                var signedTx = tx.Sign(creator);
                Console.WriteLine("Signed transaction with txid: " + signedTx.Tx.TxID());

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid);
                Console.WriteLine("Confirmed Round is: " + resp.ConfirmedRound);
                Console.WriteLine("Application ID is: " + appid);
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
            }
        }

        static async Task<ulong?> CreateApp(DefaultApi client, Account creator, TEALProgram approvalProgram,
            TEALProgram clearProgram, ulong globalInts, ulong globalBytes, ulong localInts, ulong localBytes)
        {
            try
            {
                var transParams = await client.TransactionParamsAsync();

                var tx = new ApplicationCreateTransaction()
                {
                    Sender = creator.Address,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                    ApprovalProgram = approvalProgram,
                    ClearStateProgram = clearProgram,
                    GlobalStateSchema = new StateSchema() { NumUint = globalInts, NumByteSlice = globalBytes },
                    LocalStateSchema = new StateSchema() { NumUint = localInts, NumByteSlice = localBytes }
                };

                var signedTx = tx.Sign(creator);
                Console.WriteLine("Signed transaction with txid: " + signedTx.Tx.TxID());

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationCreateTransaction;
                Console.WriteLine("Application ID is: " + resp.ApplicationIndex.ToString());
                return resp.ApplicationIndex;
            }
            catch (Algorand.Algod.Model.ApiException<ErrorResponse> e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Result.Message);
                return null;
            }
        }

        static async Task OptIn(DefaultApi client, Account sender, ulong? applicationId)
        {
            try
            {
                var transParams = await client.TransactionParamsAsync();
                var tx = new ApplicationOptInTransaction()
                {
                    Sender = sender.Address,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                    ApplicationId = applicationId
                };


                var signedTx = tx.Sign(sender);
                Console.WriteLine("Signed transaction with txid: " + signedTx.Tx.TxID());

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationOptInTransaction;
                Console.WriteLine(string.Format("Address {0} optin to Application({1})",   sender.Address.ToString(), resp.ApplicationId));
            }
            catch (Algorand.Algod.Model.ApiException<ErrorResponse> e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Result.Message);
            }
        }

        static async Task DeleteApp(DefaultApi client, Account sender, ulong? applicationId)
        {
            try
            {
                var transParams = await client.TransactionParamsAsync();
                var tx = new ApplicationDeleteTransaction()
                {
                    Sender = sender.Address,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                    ApplicationId = applicationId
                };


                var signedTx = tx.Sign(sender);
                Console.WriteLine("Signed transaction with txid: " + signedTx.Tx.TxID());

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationDeleteTransaction;
                Console.WriteLine("Success deleted the application " + resp.ApplicationId);
            }
            catch (Algorand.Algod.Model.ApiException<ErrorResponse> e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Result.Message);
            }
        }

        static async Task ClearApp(DefaultApi client, Account sender, ulong? applicationId)
        {
            try
            {
                var transParams = await client.TransactionParamsAsync();
                var tx = new ApplicationClearStateTransaction()
                {
                    Sender = sender.Address,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                    ApplicationId = applicationId.Value,
                };
                
                var signedTx = tx.Sign(sender);
                Console.WriteLine("Signed transaction with txid: " + signedTx.Tx.TxID());

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationClearStateTransaction;
                Console.WriteLine("Success cleared the application " + resp.ApplicationId);
            }
            catch (Algorand.Algod.Model.ApiException<ErrorResponse> e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Result.Message);
            }
        }

        static async Task CallApp(DefaultApi client, Account sender, ulong? applicationId, List<byte[]> args)
        {
            try
            {
                var transParams = await client.TransactionParamsAsync();

                var tx = new ApplicationNoopTransaction()
                {
                    Sender = sender.Address,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                    ApplicationId = applicationId.Value,
                    ApplicationArgs = args
                };

                var signedTx = tx.Sign(sender);
                Console.WriteLine("Signed transaction with txid: " + signedTx.Tx.TxID());

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationNoopTransaction;
                Console.WriteLine("Confirmed at round: " + resp.ConfirmedRound);
                Console.WriteLine(string.Format("Call Application({0}) success.",      resp.ApplicationId));
                
                if (resp.GlobalStateDelta != null)
                {
                    var outStr = "    Global state: ";
                    foreach (var v in resp.GlobalStateDelta)
                    {
                        outStr += v.ToString();
                    }
                    Console.WriteLine(outStr);
                }
                if (resp.LocalStateDelta != null)
                {
                    var outStr = "    Local state: ";
                    foreach (var v in resp.LocalStateDelta)
                    {
                        outStr += v.ToString();
                    }
                    Console.WriteLine(outStr);
                }
            }
            catch (Algorand.Algod.Model.ApiException<ErrorResponse> e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Result.Message);
            }
        }

        static public async Task ReadLocalState(DefaultApi client, Account account, ulong? appId)
        {
            var acctResponse = await client.AccountInformationAsync(account.Address.ToString(),null, null);
            var applicationLocalState = acctResponse.AppsLocalState;
            foreach (var state in applicationLocalState)
            {
                if (state.Id == appId)
                {
                    var outStr = "User's application local state: ";
                    foreach (var v in state.KeyValue)
                    {
                        outStr += v.ToString();
                    }
                    Console.WriteLine(outStr);
                }
            }
        }

        static public async Task ReadGlobalState(DefaultApi client, Account account, ulong? appId)
        {
            var acctResponse = await client.AccountInformationAsync(account.Address.ToString(), null,null);
            var createdApplications = acctResponse.CreatedApps;
            foreach (var app in createdApplications)
            {
                if (app.Id == appId)
                {
                    var outStr = "Application global state: ";
                    foreach (var v in app.Params.GlobalState)
                    {
                        outStr += v.ToString();
                    }
                    Console.WriteLine(outStr);
                }
            }
        }
    }
}
