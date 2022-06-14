using Algorand.Algod.Model;
using Algorand.Algod.Test;
using System.Net.Http;
using System.Net;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

using algorand_tests;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;
using Algorand.Algod.Model.Transactions;
using System.Collections.Generic;

namespace specflow.StepDefinitions
{
    [Binding]
    public sealed class algodResponseUnitTests
    {
        public string error;
        
        [Given(@"mock http responses in ""([^""]*)"" loaded from ""([^""]*)""$")]
        public void GivenMockHttpResponsesInJsonFilesLoadedFromDirectory(string jsonfile, string directory)
        {
            byte[] mockResponseBytes;

            HttpResponseMessage resp;

            if (jsonfile.EndsWith("base64"))
            {
                mockResponseBytes = System.Convert.FromBase64String( File.ReadAllText(Path.Combine( "Features","Unit",directory,jsonfile)) )   ;
                resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content =  new ByteArrayContent(mockResponseBytes)
                };
                resp.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/msgpack");

            }
            else
            {
                mockResponseBytes = File.ReadAllBytes(Path.Combine(directory,jsonfile));
                resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(mockResponseBytes)
                };
                resp.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            
            
            TestHttpMessageHandler.NextResponse = resp;
        }

        Algorand.Algod.Model.Transactions.Transaction? pendingTransactionInfo;
        [When(@"we make any Pending Transaction Information call")]
        public async Task WeMakeAnyPendingTransactionInformationCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                pendingTransactionInfo = await httpUtilities.algodDefaultApiInstance.PendingTransactionInformationAsync("", null) as Algorand.Algod.Model.Transactions.Transaction;
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        [Then(@"the parsed Pending Transaction Information response should have sender ""([^""]*)""")]
        public void ExpectPendingTransactionInformationResponseSenderToBe(string sender)
        {
            pendingTransactionInfo?.Sender.Should().Be(sender);
        }

        PendingTransactions? pendingTransactions;
        [When(@"we make any Pending Transactions Information call")]
        public async Task WeMakeAnyPendingTransactionsInformationCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                pendingTransactions = await httpUtilities.algodDefaultApiInstance.GetPendingTransactionsAsync(null, null);
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }

        }

        PostTransactionsResponse? postTransactionsResponse;
        [When(@"we make any Send Raw Transaction call")]
        public async Task WeMakeAnySendRawTransactionCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                postTransactionsResponse = await httpUtilities.algodDefaultApiInstance.TransactionsAsync(new List<SignedTransaction>());
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        PendingTransactions? pendingTransactionsByAddress;
        [When(@"we make any Pending Transactions By Address call")]
        public async Task WeMakeAnyPendingTransactionsByAddressCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                pendingTransactionsByAddress = await httpUtilities.algodDefaultApiInstance.GetPendingTransactionsByAddressAsync("test", null, null);
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        NodeStatusResponse? status;
        [When(@"we make any Node Status call")]
        public async Task WeMakeAnyNodeStatusCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                status = await httpUtilities.algodDefaultApiInstance.GetStatusAsync();
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        SupplyResponse? supply;
        [When(@"we make any Ledger Supply call")]
        public async Task WeMakeAnyLedgerSupplyCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                supply = await httpUtilities.algodDefaultApiInstance.GetSupplyAsync();
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        NodeStatusResponse? statusAfterBlock;
        [When(@"we make any Status After Block call")]
        public async Task WeMakeAnyStatusAfterBlockCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                statusAfterBlock = await httpUtilities.algodDefaultApiInstance.WaitForBlockAsync(0);
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        Account? accountInformation;
        [When(@"we make any Account Information call")]
        public async Task WeMakeAnyAccountInformationCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                accountInformation = await httpUtilities.algodDefaultApiInstance.AccountInformationAsync("test", null, null);
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        CertifiedBlock? block;
        [When(@"we make any Get Block call")]
        public async Task WeMakeAnyGetBlockCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                block = await httpUtilities.algodDefaultApiInstance.GetBlockAsync(0, null);
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        TransactionParametersResponse? transactionParameters;
        [When(@"we make any Suggested Transaction Parameters call")]
        public async Task WeMakeAnySuggestedTransactionParametersCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                transactionParameters = await httpUtilities.algodDefaultApiInstance.TransactionParamsAsync();
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        DryrunResponse? dryrunResponse;
        [When(@"we make any Dryrun call")]
        public async Task WeMakeAnyDryrunCall()
        {
            httpUtilities.setUp();
            try
            {
                error = "";
                dryrunResponse = await httpUtilities.algodDefaultApiInstance.TealDryrunAsync(new DryrunRequest());
            }
            catch (ApiException<ErrorResponse> ex)
            {
                error = ex.Result.Message;
            }
        }

        [Then(@"expect error string to contain ""([^""]*)""$")]
        public void ExpectErrorStringToBe(string err)
        {
            error.Trim().Should().Be(err.Trim());
        }

      

    }
}
