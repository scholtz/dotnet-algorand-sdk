using AVM.ClientGenerator.ABI.ARC32;
using Newtonsoft.Json;
using NUnit.Framework;

namespace test
{
    /// <summary>
    /// ARC32 descriptions routinely contain line breaks. They are emitted into XML doc comments, so every
    /// continuation line must stay a comment, otherwise the generated client does not compile.
    /// </summary>
    [TestFixture]
    public class MultilineDocCommentTests
    {
        private const string Arc32 = @"{
  ""hints"": { ""swap(uint64)uint64"": { ""call_config"": { ""no_op"": ""CALL"" } } },
  ""bare_call_config"": { ""no_op"": ""NEVER"", ""opt_in"": ""NEVER"", ""close_out"": ""NEVER"", ""update_application"": ""NEVER"", ""delete_application"": ""NEVER"" },
  ""schema"": { ""local"": { ""declared"": {}, ""reserved"": {} }, ""global"": { ""declared"": {}, ""reserved"": {} } },
  ""state"": { ""global"": { ""num_byte_slices"": 0, ""num_uints"": 0 }, ""local"": { ""num_byte_slices"": 0, ""num_uints"": 0 } },
  ""source"": { ""approval"": ""Cg=="", ""clear"": ""Cg=="", ""approvalAVM"": ""#pragma version 10\nint 1"", ""clearAVM"": ""#pragma version 10\nint 1"" },
  ""contract"": {
    ""name"": ""Multiline"",
    ""desc"": ""Contract line one\nContract line two"",
    ""methods"": [ {
      ""name"": ""swap"",
      ""desc"": ""Method line one\nMethod line two"",
      ""args"": [ { ""name"": ""assetA"", ""type"": ""uint64"", ""desc"": ""Arg line one\nUSDC in ALGOUSDC\r\nArg line three"" } ],
      ""returns"": { ""type"": ""uint64"", ""desc"": ""Return line one\nReturn line two"" }
    } ]
  }
}";

        private static AppDescription Load() =>
            JsonConvert.DeserializeObject<AppDescription>(Arc32, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });

        [Test]
        public void SmartContractReferenceWithMultilineDescriptionsCompiles()
        {
            var source = Load().ToSmartContractReference("Multiline", "");
            GeneratedClientCompiler.CompileGeneratedClient(source, "MultilineRef_" + System.Guid.NewGuid().ToString("N"));
        }

        [Test]
        public void ProxyWithMultilineDescriptionsCompiles()
        {
            var source = Load().ToProxy("Multiline");
            GeneratedClientCompiler.CompileGeneratedClient(source, "MultilineProxy_" + System.Guid.NewGuid().ToString("N"));
        }
    }
}
