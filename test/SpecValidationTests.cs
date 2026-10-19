using Algorand.AVM.ClientGenerator.ABI.ARC56;
using Algorand.AVM.ClientGenerator.Extensions;
using AVM.ClientGenerator.ABI.ARC32;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    /// <summary>
    /// ARC32/ARC56 specs are untrusted input. Every spec-supplied name the generator writes verbatim into generated
    /// C# (identifiers, event signature literal) or into the output file name must be a plain identifier.
    /// </summary>
    [TestFixture]
    public class SpecValidationTests
    {
        private const string Marker = "PWNED_MARKER";

        private static readonly string[] HostileNames =
        {
            "x){ var " + Marker + "=1; } void Y(int z",
            "E\\\"; public static int " + Marker + " = 1; //",
            "X{} class " + Marker + "{ static " + Marker + "(){} } class Y",
            "../../../escaped",
            @"..\..\escaped",
            "a b",
            "a-b",
            "1abc",
            "a\u2028b",
            "a\nb",
            "\u00e9t\u00e9",
        };

        private static JObject GasStation() => JObject.Parse(File.ReadAllText("Arc56/GasStation.arc56.json"));

        private static ClientGeneratorARC56 Load(JObject spec)
        {
            var generator = new ClientGeneratorARC56();
            generator.LoadFromByteArray(Encoding.UTF8.GetBytes(spec.ToString()));
            return generator;
        }

        [Test]
        public void ShippedArc56FixturesStillLoad()
        {
            foreach (var file in new[] { "Arc56/GasStation.arc56.json" })
            {
                Assert.DoesNotThrow(() => Load(JObject.Parse(File.ReadAllText(file))), file);
            }
        }

        [TestCaseSource(nameof(HostileNames))]
        public void Arc56RejectsHostileContractName(string name)
        {
            var spec = GasStation();
            spec["name"] = name;
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCaseSource(nameof(HostileNames))]
        public void Arc56RejectsHostileMethodName(string name)
        {
            var spec = GasStation();
            spec["methods"][0]["name"] = name;
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCaseSource(nameof(HostileNames))]
        public void Arc56RejectsHostileArgumentName(string name)
        {
            var spec = GasStation();
            var method = spec["methods"].First(m => m["args"] != null && m["args"].Any());
            method["args"][0]["name"] = name;
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCaseSource(nameof(HostileNames))]
        public void Arc56RejectsHostileEventName(string name)
        {
            var spec = GasStation();
            spec["events"] = new JArray(new JObject { ["name"] = name, ["args"] = new JArray() });
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCaseSource(nameof(HostileNames))]
        public void Arc56RejectsHostileMethodEventName(string name)
        {
            var spec = GasStation();
            spec["methods"][0]["events"] = new JArray(new JObject { ["name"] = name, ["args"] = new JArray() });
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [Test]
        public async Task Arc56EventSignatureLiteralEscapesBackslash()
        {
            // the name validation is the primary defence; the literal escaping must hold even if a name slips through
            var spec = GasStation();
            spec["events"] = new JArray(new JObject { ["name"] = "Evt", ["args"] = new JArray() });
            var source = await Load(spec).ToProxy("Probe");
            Assert.That(source, Does.Contain("Signature = \"Evt()\";"));
        }

        [Test]
        public void Arc56OutputFileNameIsADirectlessName()
        {
            var spec = GasStation();
            var name = Load(spec).GetOutputFileName();
            Assert.That(Path.GetFileName(name), Is.EqualTo(name));
        }

        private static string Arc32(string contractName, string methodName, string argName) => @"{
  ""hints"": { ""swap(uint64)uint64"": { ""call_config"": { ""no_op"": ""CALL"" } } },
  ""bare_call_config"": { ""no_op"": ""NEVER"", ""opt_in"": ""NEVER"", ""close_out"": ""NEVER"", ""update_application"": ""NEVER"", ""delete_application"": ""NEVER"" },
  ""schema"": { ""local"": { ""declared"": {}, ""reserved"": {} }, ""global"": { ""declared"": {}, ""reserved"": {} } },
  ""state"": { ""global"": { ""num_byte_slices"": 0, ""num_uints"": 0 }, ""local"": { ""num_byte_slices"": 0, ""num_uints"": 0 } },
  ""source"": { ""approval"": ""Cg=="", ""clear"": ""Cg=="", ""approval-avm"": ""#pragma version 10\nint 1"", ""clear-avm"": ""#pragma version 10\nint 1"" },
  ""contract"": {
    ""name"": " + Newtonsoft.Json.JsonConvert.ToString(contractName) + @",
    ""methods"": [ {
      ""name"": " + Newtonsoft.Json.JsonConvert.ToString(methodName) + @",
      ""args"": [ { ""name"": " + Newtonsoft.Json.JsonConvert.ToString(argName) + @", ""type"": ""uint64"" } ],
      ""returns"": { ""type"": ""uint64"" }
    } ]
  }
}";

        private static Task<AppDescription> LoadArc32(string c, string m, string a) =>
            AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(Arc32(c, m, a)));

        [Test]
        public async Task Arc32AcceptsPlainIdentifiers()
        {
            var app = await LoadArc32("Multiline", "swap", "assetA");
            Assert.That(app, Is.Not.Null);
        }

        [TestCaseSource(nameof(HostileNames))]
        public void Arc32RejectsHostileNames(string name)
        {
            Assert.ThrowsAsync<SpecValidationException>(() => LoadArc32(name, "swap", "assetA"), "contract name");
            Assert.ThrowsAsync<SpecValidationException>(() => LoadArc32("Multiline", name, "assetA"), "method name");
            Assert.ThrowsAsync<SpecValidationException>(() => LoadArc32("Multiline", "swap", name), "argument name");
        }

        [Test]
        public void ArcValidatorAcceptsAndRejects()
        {
            Assert.DoesNotThrow(() => SpecValidator.RequireIdentifier("_a1", "x"));
            Assert.DoesNotThrow(() => SpecValidator.RequireIdentifier(null, "x", allowEmpty: true));
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireIdentifier(null, "x"));
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireIdentifier("", "x"));
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireIdentifier(new string('a', 201), "x"));
        }
    }
}
