using Algorand.Algod.Model;
using Algorand.Algod.Test;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

using algorand_tests;

namespace specflow.StepDefinitions
{
    [Binding]
    public sealed class v2AlgodBindings
    {
      
        [When(@"we make a Pending Transaction Information against txid ""([^""]*)"" with format ""([^""]*)""$")]
        public void WeMakeAPendingTransactionInformationAgainstTxIdWithFormat(string txId, string format)
        {
            Format fmt = (Format)Enum.Parse(typeof(Format), format.FirstCharToUpper());

            httpUtilities.algodDefaultApiInstance.PendingTransactionInformationAsync(txId, fmt);
        }
        //When we make a Pending Transaction Information with max <max> and format "<format>"
        [When(@"we make a Pending Transaction Information with max (\d+) and format ""([^""]*)""$")]
        public void WeMakeAPendingTransactionInformationAgainstTxIdWithMaxAndFormat(ulong max, string format)
        {
            Format fmt = (Format)Enum.Parse(typeof(Format), format.FirstCharToUpper());

            httpUtilities.algodDefaultApiInstance.GetPendingTransactionsAsync(fmt,max);
        }

        [Then(@"expect the path used to be ""([^""]*)""$")]
        public void ExpectThePathUsedToBe(string expectedPath)
        {
            expectedPath.Should().Be(HttpClientTestInformation.LastRequest.RequestUri?.PathAndQuery);

        }
    }
}