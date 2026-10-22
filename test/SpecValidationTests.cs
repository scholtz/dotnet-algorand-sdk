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
            foreach (var file in Directory.GetFiles("Arc56", "*.arc56.json"))
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
        [TestCase("ref:Foo")]
        public void AbiTypeValidatorAcceptsRealTypes(string type)
        {
            Assert.DoesNotThrow(() => SpecValidator.RequireAbiType(type, "type"));
        }

        [Test]
        public void AbiTypeValidatorRejectsPathologicalTupleNesting()
        {
            var deep = new string('(', 4000) + "uint64" + new string(')', 4000);
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireAbiType(deep, "type"));
            var atLimit = new string('(', SpecValidator.MaxAbiTupleDepth) + "uint64" + new string(')', SpecValidator.MaxAbiTupleDepth);
            Assert.DoesNotThrow(() => SpecValidator.RequireAbiType(atLimit, "type"));
        }

        [Test]
        public void AbiTypeValidatorRejectsPathologicalArraySuffixes()
        {
            var deep = "uint64" + string.Concat(Enumerable.Repeat("[2]", 3000));
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireAbiType(deep, "type"));
        }

        [Test]
        public void AbiTypeValidatorAcceptsWideTuplesOfArrays()
        {
            var wide = "(" + string.Join(",", Enumerable.Repeat("byte[32]", 100)) + ")";
            Assert.DoesNotThrow(() => SpecValidator.RequireAbiType(wide, "type"));
        }

        [Test]
        public void Arc56AcceptsModerateStructChainAndDiamond()
        {
            var structs = new JObject();
            for (int i = 0; i < 10; i++)
                structs["S" + i] = new JArray(
                    new JObject { ["name"] = "a", ["type"] = i == 9 ? "uint64" : "S" + (i + 1) },
                    new JObject { ["name"] = "b", ["type"] = i == 9 ? "uint64" : "S" + (i + 1) + "[]" });
            var spec = GasStation();
            spec["structs"] = structs;
            Assert.DoesNotThrow(() => Load(spec));
        }

        [Test]
        public void Arc56RejectsNonIdentifierStructKey()
        {
            var spec = GasStation();
            spec["structs"] = new JObject { ["1A"] = new JArray(new JObject { ["name"] = "x", ["type"] = "1A" }) };
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [Test]
        public void Arc56RejectsDeepAcyclicStructChain()
        {
            var structs = new JObject();
            for (int i = 0; i < 200; i++)
                structs["S" + i] = new JArray(new JObject { ["name"] = "n", ["type"] = i == 199 ? "uint64" : "S" + (i + 1) });
            var spec = GasStation();
            spec["structs"] = structs;
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [Test]
        public void Arc56RejectsDiamondStructGraphWithExponentialExpansion()
        {
            var structs = new JObject();
            for (int i = 0; i < 30; i++)
                structs["S" + i] = new JArray(
                    new JObject { ["name"] = "a", ["type"] = i == 29 ? "uint64" : "S" + (i + 1) },
                    new JObject { ["name"] = "b", ["type"] = i == 29 ? "uint64" : "S" + (i + 1) });
            var spec = GasStation();
            spec["structs"] = structs;
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCase("A", "A")]
        [TestCase("A[]", "A")]
        [TestCase("(uint64,A)[2]", "A")]
        public void Arc56RejectsSelfReferentialStruct(string fieldType, string structName)
        {
            var spec = GasStation();
            spec["structs"] = new JObject { [structName] = new JArray(new JObject { ["name"] = "x", ["type"] = fieldType }) };
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [Test]
        public void Arc56RejectsMutuallyRecursiveStructs()
        {
            var spec = GasStation();
            spec["structs"] = new JObject
            {
                ["A"] = new JArray(new JObject { ["name"] = "b", ["type"] = "B" }),
                ["B"] = new JArray(new JObject { ["name"] = "a", ["type"] = "A" }),
            };
            Assert.Throws<SpecValidationException>(() => Load(spec));
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

        private const string HostileLiteral = "x\"; Injected_Call(); //";

        [TestCase("approval")]
        [TestCase("clear")]
        [TestCase("approval-avm")]
        [TestCase("clear-avm")]
        public void Arc32RejectsHostileSourceStrings(string field)
        {
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["source"][field] = HostileLiteral;
            Assert.ThrowsAsync<SpecValidationException>(() => AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString())));
        }

        [TestCase("name")]
        [TestCase("type")]
        [TestCase("typeDetail")]
        public void Arc32RejectsHostileStateVariables(string field)
        {
            var element = new JObject { ["key"] = "a2V5", ["type"] = "uint64" };
            string name = "counter";
            if (field == "name") name = HostileLiteral; else element[field] = HostileLiteral;
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["state"]["global"]["declared"] = new JObject { [name] = element };
            Assert.ThrowsAsync<SpecValidationException>(() => AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString())));
        }

        [Test]
        public async Task Arc32AcceptsPlainStateVariables()
        {
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["state"]["global"]["declared"] = new JObject { ["counter"] = new JObject { ["key"] = "Y291bnRlcg==", ["type"] = "uint64" } };
            var app = await AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString()));
            Assert.That(app, Is.Not.Null);
        }

        [Test]
        public void Arc32DescriptionBuiltByHandIsValidatedBeforeGeneration()
        {
            var app = new AppDescription();
            app.Contract.Name = HostileLiteral;
            Assert.Throws<SpecValidationException>(() => app.ToProxy("Probe"));
            Assert.Throws<SpecValidationException>(() => app.ToSmartContractReference("Probe", ""));
        }

        [Test]
        public void ValidationMessageHandlesNullNames()
        {
            // the error message is built eagerly from names that may be missing
            Assert.DoesNotThrow(() => SpecValidator.Show(null));
            var spec = GasStation();
            spec["structs"]["UserStruct"][0]["name"] = null;
            spec["structs"]["UserStruct"][0]["type"] = "bad;type";
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCase("uint64[System.Environment.ExitCode]")]
        [TestCase("uint64[1+1]")]
        [TestCase("byte[x]")]
        [TestCase("a.b")]
        [TestCase("List<int>")]
        public void AbiTypeValidatorRejectsExpressionsInsideBrackets(string type)
        {
            // the text between [ and ] is copied into the generated client as an array-length expression
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireAbiType(type, "type"));
        }

        [Test]
        public void Arc56HostileArrayLengthIsRejected()
        {
            var spec = GasStation();
            spec["methods"].First(m => m["args"].Any())["args"][0]["type"] = "uint64[System.Environment.ExitCode]";
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [Test]
        public void Arc56RejectedSpecIsNotKeptOnTheGenerator()
        {
            var generator = new ClientGeneratorARC56();
            Assert.DoesNotThrow(() => generator.LoadFromByteArray(Encoding.UTF8.GetBytes(GasStation().ToString())));
            var bad = GasStation();
            bad["name"] = "x y";
            Assert.Throws<SpecValidationException>(() => generator.LoadFromByteArray(Encoding.UTF8.GetBytes(bad.ToString())));
            Assert.ThrowsAsync<System.Exception>(() => generator.ToProxy("Probe"), "a rejected spec must not be generated from");
        }

        [Test]
        public void Arc32RejectsHostileSelector()
        {
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["contract"]["methods"][0]["selector"] = System.Convert.ToBase64String(Encoding.UTF8.GetBytes("x\"); Injected_Call(); //"));
            Assert.ThrowsAsync<SpecValidationException>(() => AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString())));
        }

        [TestCase("List<ulong>")]
        [TestCase("ulong?")]
        [TestCase("Algorand.Address")]
        [TestCase("System.Collections.Generic.Dictionary<string, int>")]
        [TestCase("byte[]")]
        [TestCase("(int a, string b)")]
        public void CSharpTypeValidatorAcceptsTypesTheSdkWrites(string type)
        {
            // TypeDetail is C# type text produced by the SDK's own spec generator and is emitted verbatim as a type
            Assert.DoesNotThrow(() => SpecValidator.RequireCSharpType(type, "type"));
        }

        [TestCase("int x) { Injected_Call(); } void M(int y")]
        [TestCase("List<int>) Injected_Call(")]
        [TestCase("int[Injected_Call()]")]
        [TestCase("int /* c */")]
        [TestCase("a; b")]
        [TestCase("a\"b")]
        [TestCase("int x = 1")]
        [TestCase("Foo Bar")]
        public void CSharpTypeValidatorRejectsAnythingButOneTypeName(string type)
        {
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireCSharpType(type, "type"));
        }

        [Test]
        public async Task Arc32AcceptsCSharpTypeDetail()
        {
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["contract"]["methods"][0]["args"][0]["typeDetail"] = "List<ulong>";
            json["contract"]["methods"][0]["returns"]["typeDetail"] = "ulong?";
            var app = await AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString()));
            Assert.That(app, Is.Not.Null);
        }

        [Test]
        public void Arc32RejectsHostileTypeDetail()
        {
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["contract"]["methods"][0]["args"][0]["typeDetail"] = HostileLiteral;
            Assert.ThrowsAsync<SpecValidationException>(() => AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString())));
        }

        [TestCase("X { } class Evil { static Evil() { } } namespace Y")]
        [TestCase("A..B")]
        [TestCase("A.1B")]
        [TestCase("A;B")]
        [TestCase("A B")]
        public void GenerateRejectsHostileNamespace(string ns)
        {
            var generator = Load(GasStation());
            Assert.ThrowsAsync<SpecValidationException>(() => generator.ToProxy(ns));
        }

        [TestCase("Probe")]
        [TestCase("My.Company.Clients")]
        [TestCase("AVMGasStation.GeneratedClients")]
        public async Task GenerateAcceptsDottedNamespace(string ns)
        {
            var source = await Load(GasStation()).ToProxy(ns);
            Assert.That(source, Does.Contain("namespace " + ns));
        }

        [TestCase("AB-_")]
        [TestCase("a b")]
        public void Arc32SourceMustBeStandardBase64(string value)
        {
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["source"]["approval-avm"] = value;
            Assert.ThrowsAsync<SpecValidationException>(() => AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString())));
        }

        [TestCase("approval")]
        [TestCase("clear")]
        public void Arc56RejectsNonBase64ByteCode(string program)
        {
            var spec = GasStation();
            spec["byteCode"][program] = "!!! not base64 !!!";
            Assert.Throws<SpecValidationException>(() => Load(spec));
        }

        [TestCase("abc")]
        [TestCase("A===")]
        [TestCase("=A=")]
        public void Base64ValidatorRequiresADecodableString(string value)
        {
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireBase64(value, "program"));
        }

        [TestCase("Cg==")]
        [TestCase("Y291bnRlcg==")]
        [TestCase("")]
        public void Base64ValidatorAcceptsRealPrograms(string value)
        {
            Assert.DoesNotThrow(() => SpecValidator.RequireBase64(value, "program"));
        }

        [Test]
        public void CSharpTypeValidatorAcceptsMultiLineTupleTypes()
        {
            // TypeDetail is Type.ToString() of the contract author's source, which may span lines
            Assert.DoesNotThrow(() => SpecValidator.RequireCSharpType("(ulong a,\r\n    string b)", "type"));
        }

        [Test]
        public async Task Arc32StateKeyTextNeverReachesTheReferenceClassUnsanitised()
        {
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["state"]["global"]["declared"] = new JObject { ["counter"] = new JObject { ["key"] = "a b/*c*/;d()", ["type"] = "uint64" } };
            var app = await AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString()));
            var reference = app.ToSmartContractReference("Probe", "");
            Assert.That(reference, Does.Not.Contain("/*c*/"));
            Assert.That(CSharpSyntaxTree.ParseText(reference).GetRoot().DescendantTokens().Any(t => t.Kind() == SyntaxKind.IdentifierToken && t.Text == "a_b__c___d__"), Is.True);
        }

        [Test]
        public void Arc56NullSpecIsRejected()
        {
            var generator = new ClientGeneratorARC56();
            Assert.Throws<SpecValidationException>(() => generator.LoadFromByteArray(Encoding.UTF8.GetBytes("null")));
        }

        [Test]
        public void GenerateRejectsEmptyNamespace()
        {
            var generator = Load(GasStation());
            Assert.ThrowsAsync<SpecValidationException>(() => generator.ToProxy(""));
        }

        [Test]
        public void CSharpTypeValidatorRejectsPathologicalNestingWithSpecValidationException()
        {
            var deep = new string('(', 1500) + "int" + new string(')', 1500);
            Assert.Throws<SpecValidationException>(() => SpecValidator.RequireCSharpType(deep, "type"));
        }

        [Test]
        public async Task Arc32StateKeyIsNeverEmittedAsCodeInTheReferenceClass()
        {
            // a legitimate base64 key may contain '/', '+' and '=' (here "//8=" for bytes FF FF); it is written as a field name
            var json = JObject.Parse(Arc32("Multiline", "swap", "assetA"));
            json["state"]["global"]["declared"] = new JObject { ["counter"] = new JObject { ["key"] = "//8=", ["type"] = "uint64" } };
            var app = await AppDescription.LoadFromByteArray(Encoding.UTF8.GetBytes(json.ToString()));
            Assert.That(app, Is.Not.Null);
            var reference = app.ToSmartContractReference("Probe", "");
            var tree = CSharpSyntaxTree.ParseText(reference);
            Assert.That(tree.GetRoot().DescendantTokens().Any(t => t.Kind() == SyntaxKind.IdentifierToken && t.Text == "__8_"), Is.True, "the key must become the field name __8_");
            Assert.That(reference, Does.Not.Contain("//8="));
        }

        [TestCase("global::System.Collections.Generic.List<ulong>")]
        [TestCase("@event")]
        public void CSharpTypeValidatorAcceptsQualifiedAndVerbatimNames(string type)
        {
            Assert.DoesNotThrow(() => SpecValidator.RequireCSharpType(type, "type"));
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
  ""source"": { ""approval"": ""Cg=="", ""clear"": ""Cg=="", ""approval-avm"": ""Cg=="", ""clear-avm"": ""Cg=="" },
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
