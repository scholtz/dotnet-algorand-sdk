using System;
using TechTalk.SpecFlow;

namespace specflow.StepDefinitions
{
    [Binding]
    public sealed class v2AlgodBindings
    {
        [Given("mock server recording request paths")]
        public void MockServerRecordingRequestPaths()
        {

            System.Diagnostics.Debug.WriteLine("Hi 1");
            
        }

        [When(@"we make a Pending Transaction Information against txid ""([^""]*)"" with format ""([^""]*)""$")]
        public void WeMakeAPendingTransactionInformationAgainstTxId(string txId, string format)
        {

            System.Diagnostics.Debug.WriteLine("Hi 2");

        }

     

        [Then(@"expect the path used to be ""([^""]*)""$")]
        public void ExpectThePathUsedToBe(string expectedPath)
        {
            //TODO: implement assert (verification) logic
            System.Diagnostics.Debug.WriteLine("Hi 3");

        }
    }
}