using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Algorand.AVM.ClientGenerator.ABI.ARC56;
using Algorand.AVM.ClientGenerator.Extensions;
using AVM.ClientGenerator.ABI.ARC32;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
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
            "name\n",
            "name\r\n",
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

        [TestCase("CON")]
        [TestCase("nul")]
        [TestCase("LPT1")]
        public void Arc56RejectsWindowsDeviceNamesAsContractName(string name)
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
        public void ErrorMessageDoesNotEchoControlCharacters()
        {
            var ex = Assert.Throws<SpecValidationException>(() => SpecValidator.RequireIdentifier("a\r\n\u001b[31mb\u2028", "x"));
            Assert.That(ex.Message.All(c => c >= 0x20 && c < 0x7f), Is.True, "message must be printable ASCII only: " + ex.Message);
        }

        // Spec fields the validator does not cover must still never reach the output as live code: they are either
        // rejected or only emitted after ToPascalCase (alphanumeric only) / an ABI type parse. Each mutation puts a
        // statement containing an underscore into one such field; PascalCasing removes underscores, so the verbatim
        // payload showing up in the output outside a comment means it was emitted unescaped.
        private const string Payload = "Injected_Call();";

        private static readonly string HostileText = "x\"); " + Payload + " //";

        private static IEnumerable<TestCaseData> UncoveredFieldMutations()
        {
            yield return new TestCaseData("struct key", (System.Action<JObject>)(s => Rename(s["structs"], "UserStruct", HostileText + "{} class Y")));
            yield return new TestCaseData("struct field name", (System.Action<JObject>)(s => s["structs"]["UserStruct"][0]["name"] = HostileText));
            yield return new TestCaseData("struct field type", (System.Action<JObject>)(s => s["structs"]["UserStruct"][0]["type"] = HostileText));
            yield return new TestCaseData("method arg type", (System.Action<JObject>)(s => s["methods"].First(m => m["args"].Any())["args"][0]["type"] = HostileText));
            yield return new TestCaseData("method arg struct", (System.Action<JObject>)(s => s["methods"].First(m => m["args"].Any())["args"][0]["struct"] = HostileText));
            yield return new TestCaseData("method return type", (System.Action<JObject>)(s => s["methods"][0]["returns"]["type"] = HostileText));
            yield return new TestCaseData("method return struct", (System.Action<JObject>)(s => s["methods"][0]["returns"]["struct"] = HostileText));
            yield return new TestCaseData("event arg name", (System.Action<JObject>)(s => s["events"] = Events(HostileText, "uint64", null)));
            yield return new TestCaseData("event arg type", (System.Action<JObject>)(s => s["events"] = Events("v", HostileText, null)));
            yield return new TestCaseData("event arg struct", (System.Action<JObject>)(s => s["events"] = Events("v", "uint64", HostileText)));
            yield return new TestCaseData("global state key name", (System.Action<JObject>)(s => Rename(s["state"]["keys"]["global"], "version", HostileText)));
            yield return new TestCaseData("box key name", (System.Action<JObject>)(s => Rename(s["state"]["keys"]["box"], "configuration", HostileText)));
            yield return new TestCaseData("state key type", (System.Action<JObject>)(s => s["state"]["keys"]["global"]["version"]["keyType"] = HostileText));
            yield return new TestCaseData("state value type", (System.Action<JObject>)(s => s["state"]["keys"]["global"]["version"]["valueType"] = HostileText));
            yield return new TestCaseData("state key literal", (System.Action<JObject>)(s => s["state"]["keys"]["global"]["version"]["key"] = HostileText));
        }

        private static JArray Events(string argName, string argType, string argStruct)
        {
            var arg = new JObject { ["name"] = argName, ["type"] = argType };
            if (argStruct != null) arg["struct"] = argStruct;
            return new JArray(new JObject { ["name"] = "Evt", ["args"] = new JArray(arg) });
        }

        private static void Rename(JToken parent, string oldName, string newName)
        {
            var obj = (JObject)parent;
            var value = obj[oldName];
            obj.Remove(oldName);
            obj[newName] = value;
        }

        [TestCase("struct field type")]
        [TestCase("method arg type")]
        [TestCase("method return type")]
        [TestCase("event arg type")]
        public void Arc56RejectsHostileAbiTypes(string field)
        {
            var spec = GasStation();
            var mutate = (System.Action<JObject>)UncoveredFieldMutations().First(c => (string)c.Arguments[0] == field).Arguments[1];
            mutate(spec);
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCase("uint64")]
        [TestCase("byte[4]")]
        [TestCase("(uint64,string)[]")]
        [TestCase("ufixed64x2")]
        [TestCase("uint64[3][]")]
        [TestCase("UserStruct")]
        public void AbiTypeValidatorAcceptsRealTypes(string type)
        {
            Assert.DoesNotThrow(() => SpecValidator.RequireAbiType(type, "type"));
        }

        [TestCase("uint64\"); X(); //")]
        [TestCase("a\\b")]
        [TestCase("a;b")]
        [TestCase("a{b}")]
        [TestCase("a\nb")]
        public void AbiTypeValidatorRejectsLiteralBreakingCharacters(string type)
        {
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireAbiType(type, "type"));
        }

        [Test]
        public void Arc32RejectsHostileAbiType()
        {
            var json = Arc32("Multiline", "swap", "assetA").Replace("\"type\": \"uint64\" }", "\"type\": \"uint64\\\"); X(); //\" }");
            Assert.That(json, Does.Contain("X();"), "fixture replacement must apply");
            Assert.ThrowsAsync<SpecValidationException>(() => AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json)));
        }

        [TestCaseSource(nameof(UncoveredFieldMutations))]
        public async Task Arc56UncoveredFieldsNeverBecomeLiveCode(string field, System.Action<JObject> mutate)
        {
            var spec = GasStation();
            mutate(spec);
            string source;
            try
            {
                source = await Load(spec).ToProxy("Probe");
            }
            catch (System.Exception)
            {
                return; // rejected outright: fine
            }
            // Parse the output: the payload may sit inside a comment or a string literal, but must never be an identifier
            // (which is what it would be if it had escaped into code).
            var tree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(source);
            var leaked = tree.GetRoot().DescendantTokens()
                .Where(t => t.Kind() == Microsoft.CodeAnalysis.CSharp.SyntaxKind.IdentifierToken && t.Text == "Injected_Call")
                .ToList();
            Assert.That(leaked, Is.Empty, $"{field}: payload emitted as code");
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
