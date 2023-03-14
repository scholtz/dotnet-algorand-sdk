using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace sdk_examples.contract
{
    class DryrunStatefulExample
    {
        public static async Task Main(params string[] args)
        {
            string ALGOD_API_ADDR = "http://localhost:4001/";
            string ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            var client = new DefaultApi(httpClient);

            ulong localInts = 1;
            ulong localBytes = 0;
            ulong globalInts = 1;
            ulong globalBytes = 0;


            byte[] data = Encoding.ASCII.GetBytes(TEALExamples.HelloWorld()); // TODO: Turn into a method and parametrize
            CompileResponse approval_program_compiled;
            using (var datams = new MemoryStream(data))
            {
                approval_program_compiled = await client.TealCompileAsync(datams);
            }

            data = Encoding.ASCII.GetBytes(TEALExamples.HelloWorldClear()); // TODO: Turn into a method and parametrize
            CompileResponse clear_program_compiled;
            using (var datams = new MemoryStream(data))
            {
                clear_program_compiled = await client.TealCompileAsync(datams);
            }

            data = Encoding.ASCII.GetBytes(TEALExamples.HelloWorldUpdated());// TODO: Turn into a method and parametrize
            CompileResponse approval_program_refactored_compiled;
            using (var datams = new MemoryStream(data))
            {
                approval_program_refactored_compiled = await client.TealCompileAsync(datams);
            }

            var creator = new Account("shaft web sell outdoor brick above promote call disease gift fun course grief hurdle key bamboo choice camp law lucky bitter skill term able ignore");
            var user = new Account("pipe want hockey shoulder gallery inner woman salute wrestle fashion define bonus broom start disease portion salt gesture measure prosper just draw engage ability dizzy");

            try
            {
                var appid = await CreateApp(client, creator, new TEALProgram(approval_program_compiled.Result),
                    new TEALProgram(clear_program_compiled.Result), globalInts, globalBytes, localInts, localBytes);

                // opt-in to application
                await OptIn(client, user, appid);
                await OptIn(client, creator, appid);

                //call app from user account updates global storage

                await CallApp(client, creator, user, appid, null,
                    new TEALProgram(approval_program_compiled.Result), "V2/contract/hello_world.teal");

                // read global state of application
                await ReadGlobalState(client, creator, appid);

                // update application
                await UpdateApp(client, creator, appid.Value,
                    new TEALProgram(approval_program_refactored_compiled.Result),
                    new TEALProgram(clear_program_compiled.Result));

                //call application with updated app which updates local storage counter
                await CallApp(client, creator, user, appid, null,
                    new TEALProgram(approval_program_refactored_compiled.Result), "contract/hello_world_updated.teal");

                //read local state of application from user account
                await ReadLocalState(client, user, appid);

                //close-out from application - removes application from balance record
                await CloseOutApp(client, user, (ulong?)appid);

                //opt-in again to application
                await OptIn(client, user, appid);

                //call application with arguments
                await CallApp(client, creator, user, appid, null,
                    new TEALProgram(approval_program_refactored_compiled.Result), "contract/hello_world_updated.teal");

                // delete application
                // clears global storage only
                // user must clear local
                await DeleteApp(client, creator, appid);

                // clear application from user account
                // clears local storage
                await ClearApp(client, user, appid);
            }
            catch (Algorand.ApiException e)
            {
                throw new Exception("Could not get params", e);
            }

            Console.WriteLine("You have successefully arrived the end of this test, please press and key to exist.");
        }

        public async static Task CloseOutApp(DefaultApi client, Account sender, ulong? appId)
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
                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid);
                Console.WriteLine("Close out Application ID is: " + appId);
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
            }
        }

        private async static Task UpdateApp(DefaultApi client, Account creator, ulong appid, TEALProgram approvalProgram, TEALProgram clearProgram)
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
                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid);
                Console.WriteLine("Updated the application ID is: " + appid);
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
            }
        }

        async static Task<ulong?> CreateApp(DefaultApi client, Account creator, TEALProgram approvalProgram,
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
                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationCreateTransaction;

                Console.WriteLine("Application ID is: " + resp.ApplicationIndex);
                return resp.ApplicationIndex;
            }
            catch (Algorand.ApiException<ErrorResponse> e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Response);
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
                var id = await Utils.SubmitTransaction(client, signedTx);

                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationOptInTransaction;
                Console.WriteLine("Optin to Application ID: " + resp.ApplicationId);
            }
            catch (Algorand.ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
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
            catch (Algorand.ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
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
            catch (ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
            }
        }

        async static Task CallApp(DefaultApi client, Account creator, Account user, ulong? applicationId, List<byte[]> args,
            TEALProgram program, string tealFileName)
        {
            Console.WriteLine("Creator Account:" + creator.Address.ToString());
            Console.WriteLine("User Account:" + user.Address.ToString());
            try
            {
                var transParams = await client.TransactionParamsAsync();
                var tx = new ApplicationNoopTransaction()
                {
                    Sender = user.Address,
                    Fee = transParams.Fee >= 1000 ? transParams.Fee : 1000,
                    FirstValid = transParams.LastRound,
                    LastValid = transParams.LastRound + 1000,
                    GenesisID = transParams.GenesisId,
                    GenesisHash = new Digest(transParams.GenesisHash),
                    ApplicationId = applicationId.Value,
                    ApplicationArgs = args

                };
                var signedTx = tx.Sign(user);


                var cr = await client.AccountInformationAsync(creator.Address.ToString(), null, null);
                var usr = await client.AccountInformationAsync(user.Address.ToString(), null, null);
                var mydrr = DryrunDrr(signedTx, program, cr, usr);
                var drrFile = "mydrr.dr";
                WriteDrr(drrFile, mydrr);
                Console.WriteLine("drr file created ... debugger starting - goto chrome://inspect");

                // START debugging session
                // either use from terminal in this folder
                // `tealdbg debug program.teal --dryrun-req mydrr.dr`
                //
                // or use this line to invoke debugger
                // and switch to chrome://inspect to inspect and debug
                // (program execution will continue aafter debuigging session completes)

                Execute(string.Format("tealdbg debug {0} --dryrun-req {1}", tealFileName, drrFile));

                // break here on the next line with debugger
                // run this command in this folder
                // tealdbg debug hello_world.teal --dryrun-req mydrr.dr
                // or
                // tealdbg debug hello_world_updated.teal --dryrun-req mydrr.dr

                var id = await Utils.SubmitTransaction(client, signedTx);
                Console.WriteLine("Successfully sent tx with id: " + id.Txid);
                var resp = await Utils.WaitTransactionToComplete(client, id.Txid) as ApplicationCallTransaction;
                Console.WriteLine("Confirmed at round: " + resp.ConfirmedRound);
                //System.out.println("Called app-id: " + pTrx.txn.tx.applicationId);
                if (resp.GlobalStateDelta != null)
                {
                    Console.WriteLine("    Global state: " + resp.GlobalStateDelta.ToString());
                }
                if (resp.LocalStateDelta != null)
                {
                    Console.WriteLine("    Local state: " + resp.LocalStateDelta.ToString());
                }
            }
            catch (Algorand.ApiException e)
            {
                Console.WriteLine("Exception when calling create application: " + e.Message);
            }
        }

        private static void Execute(string line)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                System.Diagnostics.Process.Start("/System/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal", line);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var strCmdText = "/C " + line;
                System.Diagnostics.Process.Start("cmd.exe", strCmdText);
            }
        }

        private static void WriteDrr(string filePath, DryrunRequest content)
        {
            var data = Algorand.Utils.Encoder.EncodeToMsgPackOrdered(content);
            File.WriteAllBytes("./V2/contract/" + filePath, data);
        }

        static DryrunRequest DryrunDrr(SignedTransaction signTx, TEALProgram program, Algorand.Algod.Model.Account cr, Algorand.Algod.Model.Account usr)
        {
            var sources = new List<DryrunSource>();

            if (program != null)
            {
                sources.Add(new DryrunSource() { FieldName = "approv", Source = Convert.ToBase64String(program.Bytes), TxnIndex = 0 });
            }
            var drr = new DryrunRequest()
            {
                Txns = new List<SignedTransaction>() { signTx },
                Accounts = new List<Account>() { cr, usr },
                Sources = sources
            };
            return drr;
        }

        async static public Task ReadLocalState(DefaultApi client, Account account, ulong? appId)
        {
            var acctResponse = await client.AccountInformationAsync(account.Address.ToString(), null, null);
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

        async static public Task ReadGlobalState(DefaultApi client, Account account, ulong? appId)
        {
            var acctResponse = await client.AccountInformationAsync(account.Address.ToString(), null, null);
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
