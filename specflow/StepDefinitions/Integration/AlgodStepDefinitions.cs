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
        public void ThenIGetTheLedgerSupply()
        {
            throw new PendingStepException();
        }

        [Given(@"a kmd client")]
        public void GivenAKmdClient()
        {
            throw new PendingStepException();
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
        public void ThenIGetTransactionsByAddressAndRound()
        {
            throw new PendingStepException();
        }

        [Then(@"I get transactions by address only")]
        public void ThenIGetTransactionsByAddressOnly()
        {
            throw new PendingStepException();
        }

        [Then(@"I get transactions by address and date")]
        public void ThenIGetTransactionsByAddressAndDate()
        {
            throw new PendingStepException();
        }

        [Given(@"default transaction with parameters (.*) ""([^""]*)""")]
        public void GivenDefaultTransactionWithParameters(int p0, string none)
        {
            throw new PendingStepException();
        }

        [When(@"I get the private key")]
        public void WhenIGetThePrivateKey()
        {
            throw new PendingStepException();
        }

        [When(@"I send the transaction")]
        public void WhenISendTheTransaction()
        {
            throw new PendingStepException();
        }

        [Then(@"I can get the transaction by ID")]
        public void ThenICanGetTheTransactionByID()
        {
            throw new PendingStepException();
        }

        [Then(@"I get pending transactions")]
        public void ThenIGetPendingTransactions()
        {
            throw new PendingStepException();
        }

        [When(@"I get recent transactions, limited by (.*) transactions")]
        public void WhenIGetRecentTransactionsLimitedByTransactions(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"I get the suggested params")]
        public void WhenIGetTheSuggestedParams()
        {
            throw new PendingStepException();
        }

        [When(@"I get the suggested fee")]
        public void WhenIGetTheSuggestedFee()
        {
            throw new PendingStepException();
        }

        [Then(@"the fee in the suggested params should equal the suggested fee")]
        public void ThenTheFeeInTheSuggestedParamsShouldEqualTheSuggestedFee()
        {
            throw new PendingStepException();
        }

        [When(@"I get versions with algod")]
        public void WhenIGetVersionsWithAlgod()
        {
            throw new PendingStepException();
        }

        [Then(@"v(.*) should be in the versions")]
        public void ThenVShouldBeInTheVersions(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"I get account information")]
        public void ThenIGetAccountInformation()
        {
            throw new PendingStepException();
        }
    }
}
