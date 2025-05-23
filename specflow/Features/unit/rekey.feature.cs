﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace algorand_tests.Features.Unit
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RekeyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = new string[] {
                "unit.rekey",
                "unit"};
        
#line 1 "rekey.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/unit", "Rekey", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Rekey")))
            {
                global::algorand_tests.Features.Unit.RekeyFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void CreateAndSignARekeyingTransaction(string fee, string fv, string lv, string gh, string to, string close, string amt, string gen, string note, string mn, string golden, string rekeyTo, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("fee", fee);
            argumentsOfScenario.Add("fv", fv);
            argumentsOfScenario.Add("lv", lv);
            argumentsOfScenario.Add("gh", gh);
            argumentsOfScenario.Add("to", to);
            argumentsOfScenario.Add("close", close);
            argumentsOfScenario.Add("amt", amt);
            argumentsOfScenario.Add("gen", gen);
            argumentsOfScenario.Add("note", note);
            argumentsOfScenario.Add("mn", mn);
            argumentsOfScenario.Add("golden", golden);
            argumentsOfScenario.Add("rekeyTo", rekeyTo);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create and sign a rekeying transaction", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
    testRunner.Given(string.Format("payment transaction parameters {0} {1} {2} \"{3}\" \"{4}\" \"{5}\" {6} \"{7}\" \"{8}\"", fee, fv, lv, gh, to, close, amt, gen, note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 6
    testRunner.And(string.Format("mnemonic for private key \"{0}\"", mn), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 7
    testRunner.When("I create the flat fee payment transaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
    testRunner.And(string.Format("I add a rekeyTo field with address \"{0}\"", rekeyTo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
    testRunner.And("I sign the transaction with the private key", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
    testRunner.Then(string.Format("the signed transaction should equal the golden \"{0}\"", golden), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create and sign a rekeying transaction: 1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rekey")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("unit.rekey")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:fee", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:fv", "6513047")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:lv", "6514047")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gh", "wGHE2Pwdvd7S12BL5FaOP20EGYesN73ktiC1qzkkit8=")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:to", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:close", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:amt", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gen", "mainnet-v1.0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:note", "ChlGdKMXTs4=")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:mn", "cute elevator romance type flight broccoli hub engage hundred brick add cage crou" +
            "ch turtle cake service heart cube like hidden dizzy lonely include abandon oven")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:golden", @"gqNzaWfEQNiXcIWUgBqo7owprXZ8DQzga5ws8ZOWaClqTNqixtIiHjqahZg0qiHcFdcqxFXzbH/Org1yLWihtR5fWrmEgAijdHhujKNhbXTNA+ilY2xvc2XEIHmkpHGR5QK7UJQyNsAuSjiZuuSHr8f0OxHo0H2ZU7R5o2ZlZc0D6KJmds4AY2GXo2dlbqxtYWlubmV0LXYxLjCiZ2jEIMBhxNj8Hb3e0tdgS+RWjj9tBBmHrDe95LYgtas5JIrfomx2zgBjZX+kbm90ZcQIChlGdKMXTs6jcmN2xCB5pKRxkeUCu1CUMjbALko4mbrkh6/H9DsR6NB9mVO0eaVyZWtlecQgAAh70b1fGJ9jrtxQg8p+Dk6dRMxB4KgrStW0KRxADXajc25kxCAACHvRvV8Yn2Ou3FCDyn4OTp1EzEHgqCtK1bQpHEANdqR0eXBlo3BheQ==")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:rekeyTo", "AAEHXUN5L4MJ6Y5O3RIIHST6BZHJ2RGMIHQKQK2K2W2CSHCABV3MFUFBGA")]
        public void CreateAndSignARekeyingTransaction_1000()
        {
#line 4
  this.CreateAndSignARekeyingTransaction("1000", "6513047", "6514047", "wGHE2Pwdvd7S12BL5FaOP20EGYesN73ktiC1qzkkit8=", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA", "1000", "mainnet-v1.0", "ChlGdKMXTs4=", "cute elevator romance type flight broccoli hub engage hundred brick add cage crou" +
                    "ch turtle cake service heart cube like hidden dizzy lonely include abandon oven", @"gqNzaWfEQNiXcIWUgBqo7owprXZ8DQzga5ws8ZOWaClqTNqixtIiHjqahZg0qiHcFdcqxFXzbH/Org1yLWihtR5fWrmEgAijdHhujKNhbXTNA+ilY2xvc2XEIHmkpHGR5QK7UJQyNsAuSjiZuuSHr8f0OxHo0H2ZU7R5o2ZlZc0D6KJmds4AY2GXo2dlbqxtYWlubmV0LXYxLjCiZ2jEIMBhxNj8Hb3e0tdgS+RWjj9tBBmHrDe95LYgtas5JIrfomx2zgBjZX+kbm90ZcQIChlGdKMXTs6jcmN2xCB5pKRxkeUCu1CUMjbALko4mbrkh6/H9DsR6NB9mVO0eaVyZWtlecQgAAh70b1fGJ9jrtxQg8p+Dk6dRMxB4KgrStW0KRxADXajc25kxCAACHvRvV8Yn2Ou3FCDyn4OTp1EzEHgqCtK1bQpHEANdqR0eXBlo3BheQ==", "AAEHXUN5L4MJ6Y5O3RIIHST6BZHJ2RGMIHQKQK2K2W2CSHCABV3MFUFBGA", ((string[])(null)));
#line hidden
        }
        
        public virtual void CreateAndSignTransactionUsingARekey_EdAccount(string fee, string fv, string lv, string gh, string to, string close, string amt, string gen, string note, string mn, string golden, string fromAddress, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("fee", fee);
            argumentsOfScenario.Add("fv", fv);
            argumentsOfScenario.Add("lv", lv);
            argumentsOfScenario.Add("gh", gh);
            argumentsOfScenario.Add("to", to);
            argumentsOfScenario.Add("close", close);
            argumentsOfScenario.Add("amt", amt);
            argumentsOfScenario.Add("gen", gen);
            argumentsOfScenario.Add("note", note);
            argumentsOfScenario.Add("mn", mn);
            argumentsOfScenario.Add("golden", golden);
            argumentsOfScenario.Add("fromAddress", fromAddress);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create and sign transaction using a rekey-ed account", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 17
    testRunner.Given(string.Format("payment transaction parameters {0} {1} {2} \"{3}\" \"{4}\" \"{5}\" {6} \"{7}\" \"{8}\"", fee, fv, lv, gh, to, close, amt, gen, note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 18
    testRunner.And(string.Format("mnemonic for private key \"{0}\"", mn), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
    testRunner.When("I create the flat fee payment transaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 20
    testRunner.And(string.Format("I set the from address to \"{0}\"", fromAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
    testRunner.And("I sign the transaction with the private key", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
    testRunner.Then(string.Format("the signed transaction should equal the golden \"{0}\"", golden), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create and sign transaction using a rekey-ed account: 1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Rekey")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("unit.rekey")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("unit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:fee", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:fv", "6523851")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:lv", "6524851")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gh", "wGHE2Pwdvd7S12BL5FaOP20EGYesN73ktiC1qzkkit8=")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:to", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:close", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:amt", "1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gen", "mainnet-v1.0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:note", "Pr/BIa6bbgo=")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:mn", "cute elevator romance type flight broccoli hub engage hundred brick add cage crou" +
            "ch turtle cake service heart cube like hidden dizzy lonely include abandon oven")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:golden", @"g6RzZ25yxCAACHvRvV8Yn2Ou3FCDyn4OTp1EzEHgqCtK1bQpHEANdqNzaWfEQHOKZiZw33wKbcEYVC2q2p1rNQygF5iv98zCJDIvblbhaP+4C+b31/5yYi9hlCA9ZAr6csol+3y3/Yn7qMX+8QKjdHhui6NhbXTNA+ilY2xvc2XEIHmkpHGR5QK7UJQyNsAuSjiZuuSHr8f0OxHo0H2ZU7R5o2ZlZc0D6KJmds4AY4vLo2dlbqxtYWlubmV0LXYxLjCiZ2jEIMBhxNj8Hb3e0tdgS+RWjj9tBBmHrDe95LYgtas5JIrfomx2zgBjj7Okbm90ZcQIPr/BIa6bbgqjcmN2xCB5pKRxkeUCu1CUMjbALko4mbrkh6/H9DsR6NB9mVO0eaNzbmTEICzNBpDQeH70lV5lkLAuexyXDUji1uQ/x22ZvmHPLTxipHR5cGWjcGF5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:fromAddress", "FTGQNEGQPB7PJFK6MWILALT3DSLQ2SHC23SD7R3NTG7GDTZNHRRDXVGL3Y")]
        public void CreateAndSignTransactionUsingARekey_EdAccount_1000()
        {
#line 16
  this.CreateAndSignTransactionUsingARekey_EdAccount("1000", "6523851", "6524851", "wGHE2Pwdvd7S12BL5FaOP20EGYesN73ktiC1qzkkit8=", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA", "PGSKI4MR4UBLWUEUGI3MALSKHCM3VZEHV7D7IOYR5DIH3GKTWR46CGLACA", "1000", "mainnet-v1.0", "Pr/BIa6bbgo=", "cute elevator romance type flight broccoli hub engage hundred brick add cage crou" +
                    "ch turtle cake service heart cube like hidden dizzy lonely include abandon oven", @"g6RzZ25yxCAACHvRvV8Yn2Ou3FCDyn4OTp1EzEHgqCtK1bQpHEANdqNzaWfEQHOKZiZw33wKbcEYVC2q2p1rNQygF5iv98zCJDIvblbhaP+4C+b31/5yYi9hlCA9ZAr6csol+3y3/Yn7qMX+8QKjdHhui6NhbXTNA+ilY2xvc2XEIHmkpHGR5QK7UJQyNsAuSjiZuuSHr8f0OxHo0H2ZU7R5o2ZlZc0D6KJmds4AY4vLo2dlbqxtYWlubmV0LXYxLjCiZ2jEIMBhxNj8Hb3e0tdgS+RWjj9tBBmHrDe95LYgtas5JIrfomx2zgBjj7Okbm90ZcQIPr/BIa6bbgqjcmN2xCB5pKRxkeUCu1CUMjbALko4mbrkh6/H9DsR6NB9mVO0eaNzbmTEICzNBpDQeH70lV5lkLAuexyXDUji1uQ/x22ZvmHPLTxipHR5cGWjcGF5", "FTGQNEGQPB7PJFK6MWILALT3DSLQ2SHC23SD7R3NTG7GDTZNHRRDXVGL3Y", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion
