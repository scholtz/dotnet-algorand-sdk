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
    ""desc"": ""Contract line one\rContract line two\u2028Contract line three"",
    ""methods"": [ {
      ""name"": ""swap"",
      ""desc"": ""Method line one\nMethod line two\u0085Method line three"",
      ""args"": [ { ""name"": ""assetA"", ""type"": ""uint64"", ""desc"": ""Arg line one\nUSDC in ALGOUSDC\r\nArg line three"" } ],
      ""returns"": { ""type"": ""uint64"", ""desc"": ""Return line one\nReturn line two"" }
    } ]
  }
}";

        private static AppDescription Load() =>
            JsonConvert.DeserializeObject<AppDescription>(Arc32, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });

        // Text that would be live code if a description's line terminator escaped the comment.
        private const string Payload = "public static int InjectedByDescription = 1;";

        private static void AssertOnlyInComments(string source)
        {
            Assert.That(source, Does.Contain("InjectedByDescription"), "payload should survive inside a comment");
            foreach (var line in source.Split('\n'))
            {
                if (!line.Contains("InjectedByDescription")) continue;
                Assert.That(line.TrimStart(), Does.StartWith("//"), "description text escaped its comment: " + line);
            }
        }

        [TestCase(0x000D)]
        [TestCase(0x000A)]
        [TestCase(0x0085)]
        [TestCase(0x2028)]
        [TestCase(0x2029)]
        public void Arc32DescriptionsCannotInjectCode(int codePoint)
        {
            var json = Arc32.Replace("Contract line one", "Contract " + JsonConvert.ToString(char.ConvertFromUtf32(codePoint)).Trim('"') + Payload)
                            .Replace("Method line one", "Method " + JsonConvert.ToString(char.ConvertFromUtf32(codePoint)).Trim('"') + Payload)
                            .Replace("Arg line one", "Arg " + JsonConvert.ToString(char.ConvertFromUtf32(codePoint)).Trim('"') + Payload);
            var app = JsonConvert.DeserializeObject<AppDescription>(json, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
            AssertOnlyInComments(app.ToSmartContractReference("Multiline", ""));
            AssertOnlyInComments(app.ToProxy("Multiline"));
        }

        [TestCase(0x000D)]
        [TestCase(0x0085)]
        [TestCase(0x2028)]
        [TestCase(0x2029)]
        public async System.Threading.Tasks.Task Arc56DescriptionsCannotInjectCode(int codePoint)
        {
            var spec = Newtonsoft.Json.Linq.JObject.Parse(System.IO.File.ReadAllText("Arc56/GasStation.arc56.json"));
            spec["description"] = "Banner " + char.ConvertFromUtf32(codePoint) + Payload;
            foreach (var method in spec["methods"])
            {
                method["desc"] = "Method " + char.ConvertFromUtf32(codePoint) + Payload;
                foreach (var arg in method["args"])
                {
                    arg["desc"] = "Arg " + char.ConvertFromUtf32(codePoint) + Payload;
                }
            }

            var generator = new Algorand.AVM.ClientGenerator.ABI.ARC56.ClientGeneratorARC56();
            generator.LoadFromByteArray(System.Text.Encoding.UTF8.GetBytes(spec.ToString()));
            AssertOnlyInComments(await generator.ToProxy("InjectArc56"));
        }

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

        [Test]
        public async System.Threading.Tasks.Task Arc56ProxyWithMultilineDescriptionsCompiles()
        {
            var spec = Newtonsoft.Json.Linq.JObject.Parse(System.IO.File.ReadAllText("Arc56/GasStation.arc56.json"));
            spec["description"] = "Banner one\rBanner two";
            foreach (var method in spec["methods"])
            {
                method["desc"] = "Method line one\nMethod line two\r\nMethod line three";
                foreach (var arg in method["args"])
                {
                    arg["desc"] = "Arg line one\nUSDC in ALGOUSDC\rArg line three";
                }
            }

            var generator = new Algorand.AVM.ClientGenerator.ABI.ARC56.ClientGeneratorARC56();
            generator.LoadFromByteArray(System.Text.Encoding.UTF8.GetBytes(spec.ToString()));
            var source = await generator.ToProxy("MultilineArc56");

            GeneratedClientCompiler.CompileGeneratedClient(source, "MultilineArc56_" + System.Guid.NewGuid().ToString("N"));
        }
    }
}
