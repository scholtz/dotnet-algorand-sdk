using specflow.StepDefinitions;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Algorand.Algod.Model.Transactions;
using Algorand.Algod.Model;
using System.Runtime.InteropServices;
using Algorand;
using System.Collections.Generic;
using System.Text;
using Algorand.Utils;
using System.Linq;
using System.Threading.Tasks;

namespace algorand_tests.StepDefinitions
{
    [Binding]
    public class SendingTransactionsStepDefinitions
    {
        ScenarioContext _scenarioContext;

        public SendingTransactionsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"the transaction should go through")]
        public void ThenTheTransactionShouldGoThrough()
        {
            bool error = (bool)_scenarioContext["error"];
            error.Should().BeFalse();
        }

        [Given(@"default multisig transaction with parameters (.*) ""([^""]*)""")]
        public async Task GivenDefaultMultisigTransactionWithParameters(int p0, string p1)
        {
            List<string> addresses = (List<string>)_scenarioContext["accounts"];
            var multiSigAddress = new MultisigAddress(1, 1, addresses.Select(a => new Algorand.Address(a).Bytes ).ToList() ).ToAddress();
            var suggestedParms = await httpUtilities.algodDefaultApiInstance.TransactionParamsAsync();

            PaymentTransaction transaction = new PaymentTransaction()
            {
                Fee = 1000,
                FirstValid = suggestedParms.LastRound,
                LastValid = suggestedParms.LastRound + 1000,
                GenesisHash = new Digest(suggestedParms.GenesisHash),
                Receiver = new Address(addresses[0]),
                Amount = 1,
                GenesisID = suggestedParms.GenesisId,
                Sender = multiSigAddress
            };

            _scenarioContext["multisig"]=transaction;

        }

        [When(@"I sign the multisig transaction with the private key")]
        public void WhenISignTheMultisigTransactionWithThePrivateKey()
        {
            var transaction = (Transaction)_scenarioContext["multisig"];
            var account = (Account)_scenarioContext["privateAccount"];
            SignedTransaction st = transaction.Sign(account);
            _scenarioContext["signedTransaction"] = st;
        }

        [When(@"I send the multisig transaction")]
        public async Task WhenISendTheMultisigTransaction()
        {
            bool error = false;
            SignedTransaction st = (SignedTransaction)_scenarioContext["signedTransaction"];
            try
            {
                var id = (await Utils.SubmitTransaction(httpUtilities.algodDefaultApiInstance, st)).Txid;
                _scenarioContext["submittedTxnid"] = id;
            }
            catch (Exception ex)
            {
                error = true;    
            }
            _scenarioContext["error"] = error;  
        }

        [Then(@"the transaction should not go through")]
        public void ThenTheTransactionShouldNotGoThrough()
        {
            bool error = (bool)_scenarioContext["error"];
            error.Should().BeTrue();
        }

        [Given(@"default V(.*) key registration transaction ""([^""]*)""")]
        public async Task GivenDefaultVKeyRegistrationTransaction(int p0, string online)
        {
            var suggestedParms = await httpUtilities.algodDefaultApiInstance.TransactionParamsAsync();

           
            KeyRegistrationTransaction txn=null;
            List<string> addresses = (List<string>)_scenarioContext["accounts"];
            switch (online)
            {
                case "online":
                    txn = new KeyRegisterOnlineTransaction()
                    {
                        FirstValid = suggestedParms.LastRound,
                        LastValid = suggestedParms.LastRound + 1000,
                        GenesisHash = new Digest(suggestedParms.GenesisHash),
                        GenesisID = suggestedParms.GenesisId,
                        
                        Fee =1000,
                        Sender = new Address(addresses[0]),
                        NonParticipation=false,
                        VotePK = new ParticipationPublicKey(Convert.FromBase64String("9mr13Ri8rFepxN3ghIUrZNui6LqqM5hEzB45Rri5lkU=")),
                        SelectionPK = new VRFPublicKey(Convert.FromBase64String("dx717L3uOIIb/jr9OIyls1l5Ei00NFgRa380w7TnPr4=")),
                        VoteFirst=0,
                        VoteLast=30001,
                        VoteKeyDilution=10000,
                        StateProofPK=Convert.FromBase64String("mYR0GVEObMTSNdsKM6RwYywHYPqVDqg3E4JFzxZOreH9NU8B+tKzUanyY8AQ144hETgSMX7fXWwjBdHz6AWk9w==")
                        
                    };
                    break;
                case "nonparticipation":
                     txn = new KeyRegisterOnlineTransaction()
                    {
                         Fee = 1000,
                         Sender = new Address(addresses[0]),
                         FirstValid = suggestedParms.LastRound,
                         LastValid = suggestedParms.LastRound + 1000,
                         GenesisHash = new Digest(suggestedParms.GenesisHash),
                         GenesisID = suggestedParms.GenesisId,
                         NonParticipation = true,
                        
                    };
                    break;
                case "offline":
                     txn = new KeyRegisterOfflineTransaction()
                    {
                         Fee = 1000,
                         Sender = new Address(addresses[0]),
                         FirstValid = suggestedParms.LastRound,
                         LastValid = suggestedParms.LastRound + 1000,
                         GenesisHash = new Digest(suggestedParms.GenesisHash),
                         GenesisID = suggestedParms.GenesisId,
                     };
                    break;
            }

            txn.Should().NotBeNull();
            _scenarioContext["transaction"] = txn;


        }
    }
}
