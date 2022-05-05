namespace Algorand.Algod.Model
{
    using System = global::System;

    /// <summary>Configures whether the response object is JSON or MessagePack encoded.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public enum Format
    {
        [System.Runtime.Serialization.EnumMember(Value = @"json")]
        Json = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"msgpack")]
        Msgpack = 1,
    }
}
