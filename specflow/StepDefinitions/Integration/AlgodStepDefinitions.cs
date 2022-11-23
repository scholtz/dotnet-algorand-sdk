using specflow.StepDefinitions;
using System;
using System.Threading.Tasks;
using System.Linq;
using TechTalk.SpecFlow;
using FluentAssertions;
using Algorand.Algod.Model.Transactions;
using Algorand.Algod.Model;
using System.Runtime.InteropServices;
using Algorand;
using System.Collections.Generic;
using System.Text;
using Algorand.Utils;

namespace algorand_tests.StepDefinitions
{
    [Binding]
    public class AlgodStepDefinitions
    {

        ScenarioContext _scenarioContext;
        string walletName = "unencrypted-default-wallet";
        string walletPswd = "";
        public AlgodStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an algod client")]
        public void GivenAnAlgodClient()
        {
            httpUtilities.setUp();
            httpUtilities.setUpKmd();
            getDefaultWallet();
        }

        [Then(@"the node should be healthy")]
        public async Task ThenTheNodeShouldBeHealthy()
        {
            bool error = false;
            try
            {

                await httpUtilities.algodCommonApiInstance.HealthCheckAsync();
            }
            catch (Exception ex)
            {
                error = true;
            }

            error.Should().BeFalse();

        }

        [When(@"I get the status")]
        public async Task WhenIGetTheStatus()
        {
            
            var status=await httpUtilities.algodDefaultApiInstance.GetStatusAsync();

            _scenarioContext["status"] = status;
            
        }


        private async Task selfPayTransaction()
        {
            var suggestedParms= await httpUtilities.algodDefaultApiInstance.TransactionParamsAsync();

            List<string> addresses = (List<string>)_scenarioContext["accounts"];

            PaymentTransaction transaction = new PaymentTransaction()
            {
                Fee = 1000,
                FirstValid = suggestedParms.LastRound,
                LastValid = suggestedParms.LastRound+1000,
                GenesisHash = new Digest(suggestedParms.GenesisHash),
                Receiver = new Address(addresses[0]),
                Amount = 1,
                GenesisID = suggestedParms.GenesisId,
                Sender= new Address(addresses[0])

            };

            _scenarioContext["transaction"] = transaction;
            string handle = getWalletHandleToken();
            var resp= httpUtilities.kmdApi.ExportKey(new Algorand.Kmd.Model.ExportKeyRequest(addresses[0], handle, walletPswd));

            Account account = new Account(Convert.FromBase64String(resp.PrivateKey));

            SignedTransaction st=transaction.Sign(account);

            await httpUtilities.algodDefaultApiInstance.TransactionsAsync(new List<SignedTransaction> { st });

        }

        [When(@"I get status after this block")]
        public async Task WhenIGetStatusAfterThisBlock()
        {
            bool error = false;
            try
            {
                NodeStatusResponse? status = (NodeStatusResponse?)_scenarioContext["status"];

                status.Should().NotBeNull();

                await selfPayTransaction();

                await httpUtilities.algodDefaultApiInstance.WaitForBlockAsync(status!.LastRound);
            }
            catch (Exception ex)
            {
                error = true;
            }
            error.Should().BeFalse();
        }

        [Then(@"I can get the block info")]
        public async Task ThenICanGetTheBlockInfo()
        {
            bool error = false;
            try
            {
                NodeStatusResponse? status = (NodeStatusResponse?)_scenarioContext["status"];

                status.Should().NotBeNull();

                await httpUtilities.algodDefaultApiInstance.GetBlockAsync(status!.LastRound,null);
            }
            catch (Exception ex)
            {
                error = true;
            }
            error.Should().BeFalse();
        }

        [Then(@"I get the ledger supply")]
        public async Task ThenIGetTheLedgerSupply()
        {
            bool error = false;
            try
            {
                await httpUtilities.algodDefaultApiInstance.GetSupplyAsync();
            }catch(Exception ex)
            {
                error = true;
            }
            error.Should().BeFalse();

        }

        [Given(@"a kmd client")]
        public void GivenAKmdClient()
        {
            httpUtilities.setUpKmd();
            getDefaultWallet();
        }

        [Given(@"wallet information")]
        public async Task  GivenWalletInformation()
        {
            getDefaultWallet();

        }




        private void getDefaultWallet()
        {
            
            string handle = getWalletHandleToken();

            var accs = httpUtilities.kmdApi.ListKeysInWallet(new Algorand.Kmd.Model.ListKeysRequest() { WalletHandleToken = handle });
            accs.Should().NotBeNull();
            accs.Addresses.Should().NotBeNull();
            accs.Addresses.Count.Should().BeGreaterThan(0);

            _scenarioContext["accounts"] = accs.Addresses;
        }

        private string  getWalletHandleToken()
        {
            var wallets = httpUtilities.kmdApi.ListWallets();
            wallets.Should().NotBeNull();

            var wallet = wallets.Wallets.Where(w => w.Name == walletName).FirstOrDefault();
            wallet.Should().NotBeNull();

            _scenarioContext["wallet"] = wallet;

            var handle = httpUtilities.kmdApi.InitWalletHandleToken(new Algorand.Kmd.Model.InitWalletHandleTokenRequest() { WalletId = wallet.Id, WalletPassword = walletPswd });
            handle.Should().NotBeNull();

 
            return handle.WalletHandleToken;
        }

        [Then(@"I get transactions by address and round")]
        public async Task ThenIGetTransactionsByAddressAndRound()
        {
            //not valid for v2 api
            return ;
        }

        [Then(@"I get transactions by address only")]
        public async Task ThenIGetTransactionsByAddressOnly()
        {

            List<string> addresses = (List<string>)_scenarioContext["accounts"];
            var res = await httpUtilities.algodDefaultApiInstance.GetPendingTransactionsByAddressAsync(addresses[0], null, 0);
        }

        [Then(@"I get transactions by address and date")]
        public void ThenIGetTransactionsByAddressAndDate()
        {
            //not implemented for v2 api
            return;
        }

        [Given(@"default transaction with parameters (.*) ""([^""]*)""")]
        public async Task GivenDefaultTransactionWithParameters(int p0, string none)
        {
            var suggestedParms = await httpUtilities.algodDefaultApiInstance.TransactionParamsAsync();


            List<string> addresses = (List<string>)_scenarioContext["accounts"];
            PaymentTransaction transaction = new PaymentTransaction()
            {

                Fee = 1000,
                FirstValid = suggestedParms.LastRound,
                LastValid = suggestedParms.LastRound + 1000,
                GenesisHash = new Digest(suggestedParms.GenesisHash),
                Receiver = new Address(addresses[0]),
                Amount = (ulong)p0,
                GenesisID = suggestedParms.GenesisId,
                Sender = new Address(addresses[0]),
                Note = Encoding.UTF8.GetBytes(none)

            };
            
            _scenarioContext["transaction"] = transaction;
           

        }

        [When(@"I get the private key")]
        public void WhenIGetThePrivateKey()
        {
            List<string> addresses = (List<string>)_scenarioContext["accounts"];
            string handle = getWalletHandleToken();
            var resp = httpUtilities.kmdApi.ExportKey(new Algorand.Kmd.Model.ExportKeyRequest(addresses[0], handle, walletPswd));
            Account account = new Account(Convert.FromBase64String(resp.PrivateKey));
            _scenarioContext["privateAccount"] = account;
            
        }

        [When(@"I sign the transaction with the private key")]
        public async Task WhenISignTheTransactionWithThePrivateKey()
        {
            var transaction = (Transaction) _scenarioContext["transaction"];
            var account = (Account)_scenarioContext["privateAccount"];
            SignedTransaction st = transaction.Sign(account);
            _scenarioContext["signedTransaction"] = st;
            
        }


        [When(@"I send the transaction")]
        public async Task WhenISendTheTransaction()
        {
            _scenarioContext["error"] = false;
            SignedTransaction st=(SignedTransaction) _scenarioContext["signedTransaction"] ;
            
            var id = (await Utils.SubmitTransaction(httpUtilities.algodDefaultApiInstance, st)).Txid;
            _scenarioContext["submittedTxnid"] = id;
          
        }

        [Then(@"I can get the transaction by ID")]
        public async Task ThenICanGetTheTransactionByID()
        {
            string txid = (string)_scenarioContext["submittedTxnid"];

            var resp = await Utils.WaitTransactionToComplete(httpUtilities.algodDefaultApiInstance, txid) as Transaction;
        }

        [Then(@"I get pending transactions")]
        public async Task ThenIGetPendingTransactions()
        {
            await httpUtilities.algodDefaultApiInstance.GetPendingTransactionsAsync(null,null);
        }

        [When(@"I get recent transactions, limited by (.*) transactions")]
        public void WhenIGetRecentTransactionsLimitedByTransactions(int p0)
        {
            //Legacy function from V1
            return;
        }

        [When(@"I get the suggested params")]
        public void WhenIGetTheSuggestedParams()
        {
            throw new PendingStepException();
        }

        [When(@"I get the suggested fee")]
        public void WhenIGetTheSuggestedFee()
        {
            //deprecated test
            return;
        }

        [Then(@"the fee in the suggested params should equal the suggested fee")]
        public void ThenTheFeeInTheSuggestedParamsShouldEqualTheSuggestedFee()
        {
            //deprecated test
            return;
            
        }

        [When(@"I get versions with algod")]
        public void WhenIGetVersionsWithAlgod()
        {
            //deprecated test
            return;
        }

        [Then(@"v(.*) should be in the versions")]
        public void ThenVShouldBeInTheVersions(int p0)
        {
            //deprecated test
            return;
        }

        [Then(@"I get account information")]
        public async Task ThenIGetAccountInformation()
        {
            List<string> addresses = (List<string>)_scenarioContext["accounts"];
            
            await httpUtilities.algodDefaultApiInstance.AccountInformationAsync(addresses[0], null, null);
        }
    }
}
