using Algorand.AVM.ClientGenerator.Extensions;
using AVM.ClientGenerator.Clients;
using AVM.ClientGenerator.Compiler;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.ABI.ARC32
{
    public class StorageSection
    {
        [Newtonsoft.Json.JsonProperty("num_byte_slices")]
        public ulong? NumByteSlices { get; set; } = 0;
        [Newtonsoft.Json.JsonProperty("num_uints")]
        public ulong? NumUints { get; set; } = 0;
        public Dictionary<string, StorageElement> Declared { get; set; } = new Dictionary<string, StorageElement>();

        internal void ToProxy(Code proxyBody, List<string> structs, bool local)
        {
            foreach (var kv in Declared)
            {
                Code code = proxyBody.AddChild();
                if (!string.IsNullOrWhiteSpace(kv.Value.Descr))
                {
                    code.AddOpeningLine(
                    $@"{"\t"}///<summary>
                        {"\t"}///{kv.Value.Descr.ToDocCommentText()}
                        {"\t"}///</summary>");


                }
                var returnType = TypeHelpers.GetCSType(kv.Key + "Type", kv.Value.Type, kv.Value.TypeDetail, structs, false);
                var fieldName = kv.Key;
                var fieldKey = kv.Value.Key;

                Core.VariableType machineValueType = Core.VariableType.Unsupported;
                if (TealTypeUtils.PredefinedByteSliceStoreTypes.Contains(returnType.type)) machineValueType = Core.VariableType.ByteSlice;
                if (TealTypeUtils.PredefinedIntegerStoredTypes.Contains(returnType.type)) machineValueType = Core.VariableType.UInt64;
                string typeCall;
                string retline = $"return ({returnType.type})result;"; ;
                switch (machineValueType)
                {
                    case Core.VariableType.ByteSlice:
                        typeCall = local ? "GetLocalByteSlice(caller,key)" : "GetGlobalByteSlice(key)";
                        if (ProxyGenerator.storageConversions.TryGetValue(returnType.type, out retline))
                        {

                        }
                        else
                        {
                            retline = "return; // <unknown return conversion>";
                        }

                        break;
                    case Core.VariableType.UInt64: typeCall = local ? "GetLocalUInt(caller,key)" : "GetGlobalUInt(key)"; break;
                    default:
                        throw new Exception("Unsupported field type.");
                }

                if (local)
                {
                    code.AddOpeningLine($"public async Task<{returnType.type}> {fieldName}(Account caller)");
                }
                else
                {
                    code.AddOpeningLine($"public async Task<{returnType.type}> {fieldName}()");
                }
                code.AddOpeningLine("{");
                var body = code.AddChild();
                body.AddOpeningLine($"var key=\"{fieldName}\";");
                body.AddOpeningLine($"var result= await base.{typeCall};");
                body.AddOpeningLine(retline);
                code.AddClosingLine("}");
            }
        }




        /// <summary>
        /// The storage key (base64 text in a real spec, so it may hold '+', '/', '=') is written as a C# field name:
        /// anything that is not a letter, digit or '_' becomes '_', so key text can never end the declaration or
        /// start a comment.
        /// </summary>
        private static string ToFieldName(string key)
        {
            if (string.IsNullOrEmpty(key)) return "_";
            var name = System.Text.RegularExpressions.Regex.Replace(key, @"[^\p{L}\p{N}_]", "_");
            return char.IsDigit(name[0]) ? "_" + name : name;
        }

        internal void ToSmartContractReference(StringBuilder stateBuilder, string storageAttribute, List<string> structs)
        {
            foreach (var kv in Declared)
            {
                stateBuilder.AppendLine($"\t\t{storageAttribute}");

                var t = TypeHelpers.GetCSType(kv.Key + "Type", kv.Value.Type, kv.Value.TypeDetail, structs, false);

                if (!string.IsNullOrWhiteSpace(t.bitwidthAttrib)) stateBuilder.AppendLine($"\t\t{t.bitwidthAttrib}");
                stateBuilder.AppendLine($"\t\tpublic {t.bitwidthAttrib}{t.type} {ToFieldName(kv.Value.Key)};");

                stateBuilder.AppendLine();
            }
        }


    }
}
