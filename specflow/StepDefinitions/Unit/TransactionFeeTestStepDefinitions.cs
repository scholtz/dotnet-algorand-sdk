using Algorand;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace algorand_tests.StepDefinitions
{
    [Binding]
    public class TransactionFeeTestStepDefinitions
    {
        ScenarioContext _scenarioContext;

        public TransactionFeeTestStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I build an application transaction with operation ""([^""]*)"", application-id (.*), sender ""([^""]*)"", approval-program ""([^""]*)"", clear-program ""([^""]*)"", global-bytes (.*), global-ints (.*), local-bytes (.*), local-ints (.*), app-args ""([^""]*)"", foreign-apps ""([^""]*)"", foreign-assets ""([^""]*)"", app-accounts ""([^""]*)"", fee (.*), first-valid (.*), last-valid (.*), genesis-hash ""([^""]*)"", extra-pages (.*)")]
        public void WhenIBuildAnApplicationTransactionWithOperationApplication_IdSenderApproval_ProgramClear_ProgramGlobal_BytesGlobal_IntsLocal_BytesLocal_IntsApp_ArgsForeign_AppsForeign_AssetsApp_AccountsFeeFirst_ValidLast_ValidGenesis_HashExtra_Pages(
            string operation, 
            int appId, 
            string sender, 
            string approvProgFile, 
            string clearProgFile, 
            int globalBytes, 
            int globalInt, 
            int localBytes, 
            int localInts, 
            string appArgs, 
            string foreignApps, 
            string foreignAssets, 
            string appAccounts, 
            int fee, 
            int firstValid, 
            int lastValid, 
            string genesisHash, 
            int extraPages)
        {






            byte[] approvalProgram = null;
            if (!String.IsNullOrWhiteSpace(approvProgFile))
            {
                approvalProgram = File.ReadAllBytes(Path.Combine("Features", "resources", approvProgFile));
            }

            byte[] clearStateProgram = null;
            if (!String.IsNullOrWhiteSpace(clearProgFile))
            {
                clearStateProgram = File.ReadAllBytes(Path.Combine("Features", "resources", clearProgFile));
            }

            ApplicationCallTransaction appCall=null;
            switch( operation){
                case "create":
                    appCall = new ApplicationCreateTransaction()
                    {
                        Sender = new Address(sender),
                        ApprovalProgram = new Algorand.TEALProgram(approvalProgram),
                        ClearStateProgram = new Algorand.TEALProgram(clearStateProgram),
                        GlobalStateSchema = new StateSchema() { NumByteSlice = (ulong)globalBytes, NumUint = (ulong)globalInt },
                        LocalStateSchema = new StateSchema() { NumByteSlice = (ulong)localBytes, NumUint = (ulong)localInts },
                        ApplicationArgs = new List<byte[]>() { Encoding.UTF8.GetBytes(appArgs.Replace("str:","") )},
                        ForeignApps = toUlongList(foreignApps),
                        ForeignAssets = toUlongList(foreignAssets),
                        Accounts = toAddressList(appAccounts),
                        Fee = (ulong)fee,
                        FirstValid = (ulong)firstValid,
                        LastValid = (ulong)lastValid,
                        GenesisHash = new Digest(genesisHash),
                        ExtraProgramPages = (ulong)extraPages

                    };
                    break;
                case "update":
                    appCall = new ApplicationUpdateTransaction()
                    {
                        ApplicationId=(ulong)appId,
                        Sender = new Address(sender),
                        ApprovalProgram = new Algorand.TEALProgram(approvalProgram),
                        ClearStateProgram = new Algorand.TEALProgram(clearStateProgram),
                        GlobalStateSchema = new StateSchema() { NumByteSlice = (ulong)globalBytes, NumUint = (ulong)globalInt },
                        LocalStateSchema = new StateSchema() { NumByteSlice = (ulong)localBytes, NumUint = (ulong)localInts },
                        ApplicationArgs = new List<byte[]>() { Encoding.UTF8.GetBytes(appArgs.Replace("str:", "") )},
                        ForeignApps = toUlongList(foreignApps),
                        ForeignAssets = toUlongList(foreignAssets),
                        Accounts = toAddressList(appAccounts),
                        Fee = (ulong)fee,
                        FirstValid = (ulong)firstValid,
                        LastValid = (ulong)lastValid,
                        GenesisHash = new Digest(genesisHash),
                        ExtraProgramPages = (ulong)extraPages

                    };
                    break;
                case "call":
                    appCall = new ApplicationNoopTransaction()
                    {
                        ApplicationId = (ulong)appId,
                        Sender = new Address(sender),
                      
                        ApplicationArgs = new List<byte[]>() { Encoding.UTF8.GetBytes(appArgs.Replace("str:", "")) },
                        ForeignApps = toUlongList(foreignApps),
                        ForeignAssets = toUlongList(foreignAssets),
                        Accounts = toAddressList(appAccounts),
                        Fee = (ulong)fee,
                        FirstValid = (ulong)firstValid,
                        LastValid = (ulong)lastValid,
                        GenesisHash = new Digest(genesisHash),
       

                    };
                    break;
                case "optin":
                    appCall = new ApplicationOptInTransaction()
                    {
                        ApplicationId = (ulong)appId,
                        Sender = new Address(sender),
                        ApplicationArgs = new List<byte[]>() { Encoding.UTF8.GetBytes(appArgs.Replace("str:", "")) },
                        ForeignApps = toUlongList(foreignApps),
                        ForeignAssets = toUlongList(foreignAssets),
                        Accounts = toAddressList(appAccounts),
                        Fee = (ulong)fee,
                        FirstValid = (ulong)firstValid,
                        LastValid = (ulong)lastValid,
                        GenesisHash = new Digest(genesisHash)
                    };
                    break;
                case "clear":
                    appCall = new ApplicationClearStateTransaction()
                    {
                        ApplicationId = (ulong)appId,
                        Sender = new Address(sender),
                        ApplicationArgs = new List<byte[]>() { Encoding.UTF8.GetBytes(appArgs.Replace("str:", "")) },
                        ForeignApps = toUlongList(foreignApps),
                        ForeignAssets = toUlongList(foreignAssets),
                        Accounts = toAddressList(appAccounts),
                        Fee = (ulong)fee,
                        FirstValid = (ulong)firstValid,
                        LastValid = (ulong)lastValid,
                        GenesisHash = new Digest(genesisHash)
            

                    };
                    break;
                case "closeout":
                    appCall = new ApplicationCloseOutTransaction()
                    {
                        ApplicationId = (ulong)appId,
                        Sender = new Address(sender),
                        ApplicationArgs = new List<byte[]>() { Encoding.UTF8.GetBytes(appArgs.Replace("str:", "")) },
                        ForeignApps = toUlongList(foreignApps),
                        ForeignAssets = toUlongList(foreignAssets),
                        Accounts = toAddressList(appAccounts),
                        Fee = (ulong)fee,
                        FirstValid = (ulong)firstValid,
                        LastValid = (ulong)lastValid,
                        GenesisHash = new Digest(genesisHash),
                        

                    };
                    break;
                case "delete":
                    appCall = new ApplicationDeleteTransaction()
                    {
                        ApplicationId = (ulong)appId,
                        Sender = new Address(sender),
                        ApplicationArgs = new List<byte[]>() { Encoding.UTF8.GetBytes(appArgs.Replace("str:", "")) },
                        ForeignApps = toUlongList(foreignApps),
                        ForeignAssets = toUlongList(foreignAssets),
                        Accounts = toAddressList(appAccounts),
                        Fee = (ulong)fee,
                        FirstValid = (ulong)firstValid,
                        LastValid = (ulong)lastValid,
                        GenesisHash = new Digest(genesisHash),
           

                    };
                    break;
            }
            appCall.Should().NotBe(null);

            _scenarioContext["transaction"] = appCall;


        }

        private List<Address> toAddressList(string appAccounts)
        {
            if (String.IsNullOrWhiteSpace(appAccounts)) return new List<Address>();

            return appAccounts.Split(',').Select(s => new Address(s)).ToList();
        }

        private List<ulong> toUlongList(string foreignApps)
        {
            if (String.IsNullOrWhiteSpace(foreignApps)) return new List<ulong>();

            return foreignApps.Split(',').Select(s => ulong.Parse(s)).ToList();
        }

        [When(@"sign the transaction")]
        public void WhenSignTheTransaction()
        {
            Transaction transaction = (Transaction)_scenarioContext["transaction"];
            Account account = (Account)_scenarioContext["account"];
            SignedTransaction signedTransaction = transaction.Sign(account);

            _scenarioContext["signedTransaction"] = signedTransaction;


        }

        [Then(@"fee field is in txn")]
        public void ThenFeeFieldIsInTxn()
        {
            SignedTransaction tx = (SignedTransaction) _scenarioContext["signedTransaction"];
            var json= Algorand.Utils.Encoder.EncodeToJson(tx);
            json.Should().Contain("fee");

        }

        [Then(@"fee field not in txn")]
        public void ThenFeeFieldNotInTxn()
        {
            SignedTransaction tx = (SignedTransaction)_scenarioContext["signedTransaction"];
            var json = Algorand.Utils.Encoder.EncodeToJson(tx);
            json.Should().NotContain("fee");

        }

        [Given(@"payment transaction parameters  (.*) (.*) (.*) ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" (.*) ""([^""]*)"" ""([^""]*)""")]
        public void GivenPaymentTransactionParameters(ulong fee, ulong fv, ulong lv, string gh, string to, string close, ulong amt, string gen, string note)
        {
            throw new PendingStepException();
        }

        [Given(@"mnemonic for private key ""([^""]*)""")]
        public void GivenMnemonicForPrivateKey(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"multisig addresses ""([^""]*)""")]
        public void GivenMultisigAddresses(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I create the multisig payment transaction")]
        public void WhenICreateTheMultisigPaymentTransaction()
        {
            throw new PendingStepException();
        }

        [When(@"I sign the multisig transaction with the private key")]
        public void WhenISignTheMultisigTransactionWithThePrivateKey()
        {
            throw new PendingStepException();
        }

        [When(@"I create the multisig payment transaction with zero fee")]
        public void WhenICreateTheMultisigPaymentTransactionWithZeroFee()
        {
            throw new PendingStepException();
        }
    }
}
