using System;
using TechTalk.SpecFlow;

namespace algorand_tests.StepDefinitions
{
    [Binding]
    public class SendingTransactionsStepDefinitions
    {
        [Then(@"the transaction should go through")]
        public void ThenTheTransactionShouldGoThrough()
        {
            throw new PendingStepException();
        }

        [Given(@"default multisig transaction with parameters (.*) ""([^""]*)""")]
        public void GivenDefaultMultisigTransactionWithParameters(int p0, string p1)
        {
            throw new PendingStepException();
        }

        [When(@"I send the multisig transaction")]
        public void WhenISendTheMultisigTransaction()
        {
            throw new PendingStepException();
        }

        [Then(@"the transaction should not go through")]
        public void ThenTheTransactionShouldNotGoThrough()
        {
            throw new PendingStepException();
        }

        [Given(@"default V(.*) key registration transaction ""([^""]*)""")]
        public void GivenDefaultVKeyRegistrationTransaction(int p0, string online)
        {
            throw new PendingStepException();
        }
    }
}
