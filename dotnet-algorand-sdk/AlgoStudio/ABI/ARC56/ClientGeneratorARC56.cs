using AlgoStudio.ABI;
using AlgoStudio.ABI.ARC32;
using AlgoStudio.ABI.ARC4;
using AlgoStudio.ABI.ARC56;
using AlgoStudio.Clients;
using AlgoStudio.Compiler;
using Newtonsoft.Json;
using RestSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Algorand.AlgoStudio.ABI.ARC56
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


        public string ToProxy(string namespaceName)
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
            code.AddOpeningLine("using AlgoStudio;");
            code.AddOpeningLine("using AlgoStudio.Core;");
            code.AddOpeningLine("using System.Collections.Generic;");
            code.AddOpeningLine("using System.Linq;");
            code.AddOpeningLine("using System.Text;");
            code.AddOpeningLine("using System.Threading.Tasks;");
            code.AddOpeningLine("using AlgoStudio.ABI.ARC56;");
            code.AddOpeningLine("using Algorand.AlgoStudio.ABI.ARC56;");



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
            proxyBody.AddClosingLine($"protected string _ARC56DATA = \"{Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Contract)))}\";");
            proxyBody.AddClosingLine("}");

            var ctor = proxyBody.AddChild();
            ctor.AddOpeningLine("public override AppDescriptionArc56 App { get; set; } = null;");
            ctor.AddOpeningLine("");
            ctor.AddOpeningLine($"public {className}(DefaultApi defaultApi, ulong appId) : base(defaultApi, appId) ");
            ctor.AddOpeningLine("{");
            ctor.AddClosingLine("}");

            var ctorInner = ctor.AddChild();
            ctorInner.AddOpeningLine("App = Newtonsoft.Json.JsonConvert.DeserializeObject<AlgoStudio.ABI.ARC56.AppDescriptionArc56>(Encoding.UTF8.GetString(Convert.FromBase64String(_ARC56DATA)));");

            defineStructs(proxyBody);
            defineMethods(proxyBody, structs);



            return code.ToString();
        }
        private void defineStructs(Code proxyBody)
        {
            foreach (var item in Contract.Structs)
            {
                var structObj = proxyBody.AddChild();
                structObj.AddOpeningLine($"public class {item.Key.ToPascalCase(CultureInfo.InvariantCulture)} : AVMObjectType");
                structObj.AddOpeningLine("{");
                structObj.AddClosingLine("}");

                foreach (var structItem in item.Value)
                {
                    var structItemObj = structObj.AddChild();
                    var p = TypeHelpers.ABITypeToCSType(structItem.Type, structItem.Type, new List<string>(), false);
                    structItemObj.AddOpeningLine($"public {p.Item2} {structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)} {{get; set;}}");
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
                        structF1.AddOpeningLine($"AlgoStudio.ABI.ARC4.Types.WireType v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)} = AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription(\"{structItem.Type}\");");
                        structF1.AddOpeningLine($"v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}.From({structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)});");
                        structF1.AddOpeningLine($"stringRef[ret.Count] = v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}.Encode();");
                        structF1.AddOpeningLine($"ret.AddRange(new byte[2]);");
                    }
                    else
                    {

                        structF1.AddOpeningLine($"AlgoStudio.ABI.ARC4.Types.WireType v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)} = AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription(\"{structItem.Type}\");");
                        structF1.AddOpeningLine($"v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}.From({structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)});");
                        structF1.AddOpeningLine($"ret.AddRange(v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}.Encode());");
                    }

                }
                structF1.AddOpeningLine("foreach (var item in stringRef)\r\n                {\r\n                    var b1 = ret.Count;\r\n                    ret[item.Key] = Convert.ToByte(b1 / 256);\r\n                    ret[item.Key + 1] = Convert.ToByte(b1 % 256);\r\n                    ret.AddRange(item.Value);\r\n                }");
                structF1.AddOpeningLine("return ret.ToArray();");


                // Parse()
                var structF2 = structObj.AddChild();
                structF2.AddOpeningLine($"public static {item.Key.ToPascalCase(CultureInfo.InvariantCulture)} Parse(byte[] bytes)");
                structF2.AddOpeningLine("{");
                structF2.AddClosingLine("}");

                var structF2In = structF2.AddChild();

                structF2.AddOpeningLine($"var queue = new Queue<byte>(bytes);");
                structF2.AddOpeningLine($"var ret = new {item.Key.ToPascalCase(CultureInfo.InvariantCulture)}();");
                structF2.AddOpeningLine($"uint count = 0;");

                foreach (var structItem in item.Value)
                {
                    structF2.AddOpeningLine($"AlgoStudio.ABI.ARC4.Types.WireType v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)} = AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription(\"{structItem.Type}\");");
                    structF2.AddOpeningLine($"count = v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}.Decode(queue.ToArray());");
                    structF2.AddOpeningLine($"queue.Take(Convert.ToInt32(count));");
                    structF2.AddOpeningLine($"var value{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)} = v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}.ToValue();");
                    var p = TypeHelpers.ABITypeToCSType(structItem.Type, structItem.Type, new List<string>(), false);
                    structF2.AddOpeningLine($"if (value{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)} is {p.Item2} v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}Value){{ret.{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)} = v{structItem.Name.ToPascalCase(CultureInfo.InvariantCulture)}Value;}}");
                }
                structF2.AddOpeningLine("return ret;");

            }
        }
        private void defineMethods(Code proxyBody, List<string> structs)
        {
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

                abiMethod.AddOpeningLine($"public async {methodReturnType} {methodName.ToPascalCase(CultureInfo.InvariantCulture)} ({parameters}Account _tx_sender, ulong? _tx_fee,string _tx_note = \"\", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AlgoStudio.Core.OnCompleteType _tx_callType = AlgoStudio.Core.OnCompleteType.NoOp )".Replace(",,", ",").Replace(", ,", ","));
                abiMethod.AddOpeningLine("{");
                abiMethod.AddClosingLine("}");

                abiMethodForTransactions.AddOpeningLine($"public async Task<List<Transaction>> {methodName.ToPascalCase(CultureInfo.InvariantCulture)}_Transactions ({parameters}Account _tx_sender, ulong? _tx_fee, string _tx_note = \"\", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AlgoStudio.Core.OnCompleteType _tx_callType = AlgoStudio.Core.OnCompleteType.NoOp )".Replace(",,", ",").Replace(", ,", ","));
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
                abiMethodBody.AddOpeningLine($"var result = await base.CallApp({argsList}, _tx_fee: _tx_fee,  _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions , _tx_apps: _tx_apps, _tx_assets:_tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);");

                if (t.type != "void")
                {
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
