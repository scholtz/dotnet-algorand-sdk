using System;
using TechTalk.SpecFlow;

namespace algorand_tests.StepDefinitions
{
    [Binding]
    public class OfflineStepDefinitions
    {
        [When(@"I generate a key")]
        public void WhenIGenerateAKey()
        {
            throw new PendingStepException();
        }

        [When(@"I decode the address")]
        public void WhenIDecodeTheAddress()
        {
            throw new PendingStepException();
        }

        [When(@"I encode the address")]
        public void WhenIEncodeTheAddress()
        {
            throw new PendingStepException();
        }

        [Then(@"the address should still be the same")]
        public void ThenTheAddressShouldStillBeTheSame()
        {
            throw new PendingStepException();
        }

        [When(@"I convert the private key back to a mnemonic")]
        public void WhenIConvertThePrivateKeyBackToAMnemonic()
        {
            throw new PendingStepException();
        }

        [Then(@"the mnemonic should still be the same as ""([^""]*)""")]
        public void ThenTheMnemonicShouldStillBeTheSameAs(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"mnemonic for master derivation key ""([^""]*)""")]
        public void GivenMnemonicForMasterDerivationKey(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I convert the master derivation key back to a mnemonic")]
        public void WhenIConvertTheMasterDerivationKeyBackToAMnemonic()
        {
            throw new PendingStepException();
        }

        [When(@"I create the flat fee payment transaction")]
        public void WhenICreateTheFlatFeePaymentTransaction()
        {
            throw new PendingStepException();
        }

        [When(@"I sign the transaction with the private key")]
        public void WhenISignTheTransactionWithThePrivateKey()
        {
            throw new PendingStepException();
        }

        [Then(@"the signed transaction should equal the golden ""([^""]*)""")]
        public void ThenTheSignedTransactionShouldEqualTheGolden(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the multisig address should equal the golden ""([^""]*)""")]
        public void ThenTheMultisigAddressShouldEqualTheGolden(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the multisig transaction should equal the golden ""([^""]*)""")]
        public void ThenTheMultisigTransactionShouldEqualTheGolden(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"encoded multisig transaction ""([^""]*)""")]
        public void GivenEncodedMultisigTransaction(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I append a signature to the multisig transaction")]
        public void WhenIAppendASignatureToTheMultisigTransaction()
        {
            throw new PendingStepException();
        }

        [Given(@"encoded multisig transactions ""([^""]*)""")]
        public void GivenEncodedMultisigTransactions(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I merge the multisig transactions")]
        public void WhenIMergeTheMultisigTransactions()
        {
            throw new PendingStepException();
        }

        [When(@"I convert (.*) microalgos to algos and back")]
        public void WhenIConvertMicroalgosToAlgosAndBack(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"it should still be the same amount of microalgos (.*)")]
        public void ThenItShouldStillBeTheSameAmountOfMicroalgos(int p0)
        {
            throw new PendingStepException();
        }
    }
}
