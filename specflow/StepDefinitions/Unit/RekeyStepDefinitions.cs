using System;
using TechTalk.SpecFlow;

namespace algorand_tests.StepDefinitions
{
    [Binding]
    public class RekeyStepDefinitions
    {
        [When(@"I add a rekeyTo field with address ""([^""]*)""")]
        public void WhenIAddARekeyToFieldWithAddress(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I set the from address to ""([^""]*)""")]
        public void WhenISetTheFromAddressTo(string p0)
        {
            throw new PendingStepException();
        }
    }
}
