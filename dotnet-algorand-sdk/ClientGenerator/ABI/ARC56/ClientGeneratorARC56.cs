using AVM.ClientGenerator.ABI;
using AVM.ClientGenerator.ABI.ARC32;
using AVM.ClientGenerator.ABI.ARC4;
using AVM.ClientGenerator.ABI.ARC56;
using AVM.ClientGenerator.Clients;
using AVM.ClientGenerator.Compiler;
using Newtonsoft.Json;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Algorand.AVM.ClientGenerator.Extensions;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.Formatting;
using System.Linq.Expressions;

namespace Algorand.AVM.ClientGenerator.ABI.ARC56
{
    public class ClientGeneratorARC56
    {
        private AppDescriptionArc56 Contract { get; set; } = null;
        /// <summary>
        /// Load app description from file
        /// 
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool LoadFromByteArray(byte[] data)
        {
            Contract = JsonConvert.DeserializeObject<AppDescriptionArc56>(Encoding.UTF8.GetString(data), new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            return true;
        }
        public string GetOutputFileName()
        {
            return Contract.Name + ".cs";
        }


        public async Task<string> ToProxy(string namespaceName)
        {
            if (Contract == null) throw new Exception("Load the contract first");

            List<string> structs = new List<string>();


            string className = $"{Contract.Name}Proxy";

            Code code = new Code(indent: 0);
            code.AddOpeningLine("using System;");
            code.AddOpeningLine("using Algorand;");
            code.AddOpeningLine("using Algorand.Algod;");
            code.AddOpeningLine("using Algorand.Algod.Model;");
            code.AddOpeningLine("using Algorand.Algod.Model.Transactions;");
            code.AddOpeningLine("using AVM.ClientGenerator;");
            code.AddOpeningLine("using AVM.ClientGenerator.Core;");
            code.AddOpeningLine("using System.Collections.Generic;");
            code.AddOpeningLine("using System.Linq;");
            code.AddOpeningLine("using System.Text;");
            code.AddOpeningLine("using System.Threading.Tasks;");
            code.AddOpeningLine("using AVM.ClientGenerator.ABI.ARC56;");
            code.AddOpeningLine("using Algorand.AVM.ClientGenerator.ABI.ARC56;");



            code.AddOpeningLine("");
            code.AddOpeningLine($"namespace {namespaceName}");
            code.AddOpeningLine("{");
            code.AddOpeningLine("");
            code.AddClosingLine("}");
            var proxyBody = code.AddChild();
            proxyBody.AddOpeningLine("");


            //Add any leading structured trivia

            if (!string.IsNullOrEmpty(Contract.Description))
            {
                proxyBody.AddOpeningLine("//");
                proxyBody.AddOpeningLine($"// {Contract.Description?.Replace("\n", "\n//")}");
                proxyBody.AddOpeningLine("//");
            }


            proxyBody.AddOpeningLine($"public class {className} : ProxyBase");
            proxyBody.AddOpeningLine("{");
            proxyBody.AddClosingLine($"protected override ulong? ExtraProgramPages {{get; set; }} = {Convert.FromBase64String(Contract.ByteCode.Approval).Length / 2048};");
            proxyBody.AddClosingLine($"protected string _ARC56DATA = \"{Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Contract)))}\";");
            proxyBody.AddClosingLine("}");

            var ctor = proxyBody.AddChild();
            ctor.AddOpeningLine("public override AppDescriptionArc56 App { get; set; } = null;");
            ctor.AddOpeningLine("");
            ctor.AddOpeningLine($"public {className}(DefaultApi defaultApi, ulong appId) : base(defaultApi, appId) ");
            ctor.AddOpeningLine("{");
            ctor.AddClosingLine("}");

            var ctorInner = ctor.AddChild();
            ctorInner.AddOpeningLine("App = Newtonsoft.Json.JsonConvert.DeserializeObject<AVM.ClientGenerator.ABI.ARC56.AppDescriptionArc56>(Encoding.UTF8.GetString(Convert.FromBase64String(_ARC56DATA)));");

            defineStructs(proxyBody);
            defineMethods(proxyBody, structs);



            return await FormatCode(code.ToString());
        }
        static async Task<string> FormatCode(string sourceCode)
        {
            var workspace = new AdhocWorkspace();
            var options = workspace.Options
                .WithChangedOption(CSharpFormattingOptions.NewLinesForBracesInMethods, true)
                .WithChangedOption(CSharpFormattingOptions.IndentBraces, false);

            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var root = await syntaxTree.GetRootAsync();
            var formattedRoot = Formatter.Format(root, workspace, options);
            return formattedRoot.ToFullString();
        }
        private void defineStructs(Code proxyBody)
        {
            foreach (var item in Contract.Structs)
            {
                var structObj = proxyBody.AddChild();
                structObj.AddOpeningLine($"public class {item.Key.ToPascalCase()} : AVMObjectType");
                structObj.AddOpeningLine("{");
                structObj.AddClosingLine("}");

                foreach (var structItem in item.Value)
                {
                    var structItemObj = structObj.AddChild();
                    var p = TypeHelpers.ABITypeToCSType(structItem.Type, structItem.Type, new List<string>(), false);
                    structItemObj.AddOpeningLine($"public {p.Item2} {structItem.Name.ToPascalCase()} {{get; set;}}");
                }
                // ToByteArray()
                var structF1 = structObj.AddChild();
                structF1.AddOpeningLine("public byte[] ToByteArray()");
                structF1.AddOpeningLine("{");
                structF1.AddClosingLine("}");

                var structF1In = structF1.AddChild();

                structF1.AddOpeningLine("var ret = new List<byte>();");
                structF1.AddOpeningLine("var stringRef = new Dictionary<int, byte[]>();");

                foreach (var structItem in item.Value)
                {
                    if (structItem.Type == "string")
                    {
                        structF1.AddOpeningLine($"AVM.ClientGenerator.ABI.ARC4.Types.WireType v{structItem.Name.ToPascalCase()} = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription(\"{structItem.Type}\");");
                        structF1.AddOpeningLine($"v{structItem.Name.ToPascalCase()}.From({structItem.Name.ToPascalCase()});");
                        structF1.AddOpeningLine($"stringRef[ret.Count] = v{structItem.Name.ToPascalCase()}.Encode();");
                        structF1.AddOpeningLine($"ret.AddRange(new byte[2]);");
                    }
                    else
                    {

                        structF1.AddOpeningLine($"AVM.ClientGenerator.ABI.ARC4.Types.WireType v{structItem.Name.ToPascalCase()} = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription(\"{structItem.Type}\");");
                        structF1.AddOpeningLine($"v{structItem.Name.ToPascalCase()}.From({structItem.Name.ToPascalCase()});");
                        structF1.AddOpeningLine($"ret.AddRange(v{structItem.Name.ToPascalCase()}.Encode());");
                    }

                }
                structF1.AddOpeningLine("foreach (var item in stringRef)\r\n                {\r\n                    var b1 = ret.Count;\r\n                    ret[item.Key] = Convert.ToByte(b1 / 256);\r\n                    ret[item.Key + 1] = Convert.ToByte(b1 % 256);\r\n                    ret.AddRange(item.Value);\r\n                }");
                structF1.AddOpeningLine("return ret.ToArray();");


                // Parse()
                var structF2 = structObj.AddChild();
                structF2.AddOpeningLine($"public static {item.Key.ToPascalCase()} Parse(byte[] bytes)");
                structF2.AddOpeningLine("{");
                structF2.AddClosingLine("}");

                var structF2In = structF2.AddChild();

                structF2.AddOpeningLine($"var queue = new Queue<byte>(bytes);");
                structF2.AddOpeningLine($"var prefixOffset = 0;");
                structF2.AddOpeningLine($"var retPrefix = new byte[4] {{ bytes[0], bytes[1], bytes[2], bytes[3] }};\r\n                if (retPrefix.SequenceEqual(Constants.RetPrefix))\r\n                {{\r\n                    prefixOffset=4;\r\n                    for (int i = 0; i < 4 && queue.Count > 0; i++){{queue.Dequeue();}}\r\n                }}");
                structF2.AddOpeningLine($"var ret = new {item.Key.ToPascalCase()}();");
                structF2.AddOpeningLine($"uint count = 0;");

                foreach (var structItem in item.Value)
                {
                    if (structItem.Type == "string")
                    {
                        structF2.AddOpeningLine($"var index{structItem.Name.ToPascalCase()} = queue.Dequeue() * 256 + queue.Dequeue();");
                        structF2.AddOpeningLine($"AVM.ClientGenerator.ABI.ARC4.Types.WireType v{structItem.Name.ToPascalCase()} = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription(\"{structItem.Type}\");");
                        structF2.AddOpeningLine($"v{structItem.Name.ToPascalCase()}.Decode(bytes.Skip(index{structItem.Name.ToPascalCase()} + prefixOffset).ToArray());");

                        structF2.AddOpeningLine($"var value{structItem.Name.ToPascalCase()} = v{structItem.Name.ToPascalCase()}.ToValue();");
                        structF2.AddOpeningLine($"if (value{structItem.Name.ToPascalCase()} is string v{structItem.Name.ToPascalCase()}Value) {{ ret.{structItem.Name.ToPascalCase()} = v{structItem.Name.ToPascalCase()}Value; }}");
                    }
                    else
                    {
                        structF2.AddOpeningLine($"AVM.ClientGenerator.ABI.ARC4.Types.WireType v{structItem.Name.ToPascalCase()} = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription(\"{structItem.Type}\");");
                        structF2.AddOpeningLine($"count = v{structItem.Name.ToPascalCase()}.Decode(queue.ToArray());");
                        structF2.AddOpeningLine($"for (int i = 0; i < Convert.ToInt32(count); i++){{queue.Dequeue();}}");
                        structF2.AddOpeningLine($"var value{structItem.Name.ToPascalCase()} = v{structItem.Name.ToPascalCase()}.ToValue();");
                        var p = TypeHelpers.ABITypeToCSType(structItem.Type, structItem.Type, new List<string>(), false);
                        structF2.AddOpeningLine($"if (value{structItem.Name.ToPascalCase()} is {p.Item2} v{structItem.Name.ToPascalCase()}Value){{ret.{structItem.Name.ToPascalCase()} = v{structItem.Name.ToPascalCase()}Value;}}");
                    }
                }
                structF2.AddOpeningLine("return ret;");

            }
        }
        private void defineMethods(Code proxyBody, List<string> structs)
        {
            if (!this.Contract.Methods.Any(m => m.Name == "CreateApplication"))
            {
                // make custom deploy method
                this.Contract.Methods.Add(new Method()
                {
                    Name = "CreateApplication",
                    Actions = new MethodActions() { Create = new List<string>() { }, },
                    Args = new List<MethodArgument>() { },
                    Description = "Constructor Bare Action",
                    ReadOnly = false,
                    Events = new List<Event>() { },
                    Recommendations = new Recommendations() { },
                    Returns = new MethodReturn() { Type = "void" }
                });
            }

            foreach (var method in this.Contract.Methods)
            {
                var returnType = method.Returns;
                var methodName = method.Name;
                List<MethodArgument> transactionParameters = new List<MethodArgument>();
                List<MethodArgument> appRefParameters = new List<MethodArgument>();
                List<MethodArgument> acctRefParameters = new List<MethodArgument>();
                List<MethodArgument> assetRefParameters = new List<MethodArgument>();
                List<MethodArgument> argParameters = new List<MethodArgument>();

                foreach (var parm in method.Args)
                {
                    var parmType = parm.Type;
                    if (parm.IsTransaction())
                    {
                        transactionParameters.Add(parm);
                        continue;
                    }

                    if (parm.IsApplicationRef())
                    {
                        appRefParameters.Add(parm);
                        continue;
                    }

                    if (parm.IsAccountRef())
                    {
                        acctRefParameters.Add(parm);
                        continue;
                    }

                    if (parm.IsAssetRef())
                    {
                        assetRefParameters.Add(parm);
                        continue;
                    }

                    argParameters.Add(parm);
                }

                var transactionParameterDefinitions = transactionParameters.Select(p => defineTransactionParameter(p));
                var appRefParameterDefinitions = appRefParameters.Select(p => defineAppRefParameter(p));
                var accountRefParameterDefinitions = acctRefParameters.Select(p => defineAcctRefParameter(p));
                var assetRefParameterDefinitions = assetRefParameters.Select(p => defineAssetRefParameter(p));
                var argParameterDefinitions = argParameters.Select(p => defineArgParameter(p, methodName, structs));
                var allParameters = transactionParameterDefinitions.Concat(appRefParameterDefinitions).Concat(accountRefParameterDefinitions).Concat(assetRefParameterDefinitions).Concat(argParameterDefinitions);

                string parameters = string.Join(",", allParameters);

                string argsList = "new List<object> {" + string.Join(",", new List<string> { "abiHandle" }.Concat(method.Args.Select(p => p.Name))) + "}";
                if(method.Description == "Constructor Bare Action")
                {
                    argsList = "new List<object> {}";
                }


                var t = TypeHelpers.GetCSType(Contract.Name + "return", returnType.Type, returnType.Struct, structs, false);
                string methodReturnType;
                if (t.type != "void")
                {
                    methodReturnType = $"Task<{t.type}>";
                }
                else
                {
                    methodReturnType = "Task";
                }

                var abiMethod = proxyBody.AddChild();
                var abiMethodForTransactions = proxyBody.AddChild();

                abiMethod.AddOpeningLine(
$@"///<summary>
        ///{method.Description?.Replace("\n", "\n///") ?? ""}
        ///</summary>");

                foreach (var parm in method.Args)
                {
                    abiMethod.AddOpeningLine($@"/// <param name=""{parm.Name}"">{parm.Description?.Replace("\n", "\n///")} {parm.Struct?.Replace("\n", "\n///")}</param>");
                }

                if (!string.IsNullOrEmpty(parameters))
                {
                    parameters += ", ";
                }
                var defaultOp = "AVM.ClientGenerator.Core.OnCompleteType.NoOp";
                if (method.Name == "CreateApplication")
                {
                    defaultOp = "AVM.ClientGenerator.Core.OnCompleteType.CreateApplication";
                }
                abiMethod.AddOpeningLine($"public async {methodReturnType} {methodName.ToPascalCase()} ({parameters}Account _tx_sender, ulong? _tx_fee,string _tx_note = \"\", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = {defaultOp} )".Replace(",,", ",").Replace(", ,", ","));
                abiMethod.AddOpeningLine("{");
                abiMethod.AddClosingLine("}");

                abiMethodForTransactions.AddOpeningLine($"public async Task<List<Transaction>> {methodName.ToPascalCase()}_Transactions ({parameters}Account _tx_sender, ulong? _tx_fee, string _tx_note = \"\", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = {defaultOp} )".Replace(",,", ",").Replace(", ,", ","));
                abiMethodForTransactions.AddOpeningLine("{");
                abiMethodForTransactions.AddClosingLine("}");

                var abiMethodBody = abiMethod.AddChild();

                abiMethodBody.AddOpeningLine($"_tx_boxes ??= new List<BoxRef>();");
                abiMethodBody.AddOpeningLine($"_tx_transactions ??= new List<Transaction>();");
                abiMethodBody.AddOpeningLine($"_tx_assets ??= new List<ulong>();");
                abiMethodBody.AddOpeningLine($"_tx_apps ??= new List<ulong>();");
                abiMethodBody.AddOpeningLine($"_tx_accounts ??= new List<Address>();");

                if (transactionParameters.Count > 0)
                {
                    abiMethodBody.AddOpeningLine("_tx_transactions.AddRange(new List<Transaction> {" + string.Join(",", transactionParameters.Select(p => p.Name)) + "});");
                }

                if (appRefParameters.Count > 0)
                {
                    abiMethodBody.AddOpeningLine("_tx_apps.AddRange(new List<ulong> {" + string.Join(",", appRefParameters.Select(p => p.Name)) + "});");
                }

                if (assetRefParameters.Count > 0)
                {
                    abiMethodBody.AddOpeningLine("_tx_assets.AddRange(new List<ulong> {" + string.Join(",", assetRefParameters.Select(p => p.Name)) + "});");
                }

                if (acctRefParameters.Count > 0)
                {
                    abiMethodBody.AddOpeningLine("_tx_accounts.AddRange(new List<Address> {" + string.Join(",", acctRefParameters.Select(p => p.Name)) + "});");
                }


                abiMethodBody.AddOpeningLine($"byte[] abiHandle = {{{String.Join(",", method.ToARC4MethodSelector())}}};");

                var simOrCall = "CallApp";
                if (method.ReadOnly == true)
                {
                    simOrCall = "SimApp";
                }

                abiMethodBody.AddOpeningLine($"var result = await base.{simOrCall}({argsList}, _tx_fee: _tx_fee,  _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions , _tx_apps: _tx_apps, _tx_assets:_tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);");

                if (t.type != "void")
                {
                    if (t.type == returnType.Struct)
                    {
                        abiMethodBody.AddOpeningLine($"return {returnType.Struct}.Parse(result.Last());");
                    }
                    else
                    if (ProxyGenerator.returnTypeConversions.TryGetValue(t.type, out string retline))
                    {
                        abiMethodBody.AddOpeningLine(retline);
                    }
                    else
                    {
                        abiMethodBody.AddOpeningLine("throw new Exception(\"Conversion not implemented\"); // <unknown return conversion>");
                    }
                }

                var abiMethodBodyForTransactions = abiMethodForTransactions.AddChild();
                abiMethodBodyForTransactions.AddOpeningLine($"byte[] abiHandle = {{{String.Join(",", method.ToARC4MethodSelector())}}};");
                abiMethodBodyForTransactions.AddOpeningLine($"return await base.MakeTransactionList({argsList}, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions , _tx_apps: _tx_apps, _tx_assets:_tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);");
            }
        }
        private string defineArgParameter(MethodArgument p, string methodName, List<string> structs)
        {
            var type = TypeHelpers.GetCSType(MethodDescription.FormatStructName(methodName + "_arg_" + p.Name), p.Type, p.Struct, structs, false).type;
            return $"{type} {p.Name}";
        }

        private string defineAssetRefParameter(MethodArgument p)
        {
            return $"ulong {p.Name}";
        }

        private string defineAcctRefParameter(MethodArgument p)
        {
            return $"Address {p.Name}";
        }

        private string defineTransactionParameter(MethodArgument p)
        {
            string parmType = p.Type.ToString();
            if (!string.IsNullOrWhiteSpace(p.Struct)) parmType = p.Struct;
            string outputParmType = TypeHelpers.determineTransactionType(parmType);
            return $"{outputParmType} {p.Name}";
        }


        private string defineAppRefParameter(MethodArgument p)
        {
            return $"ulong {p.Name}";
        }
    }
}
