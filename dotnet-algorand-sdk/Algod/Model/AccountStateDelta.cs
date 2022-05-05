namespace Algorand.Algod.Model
{
    using System = global::System;



    /// <summary>Application state delta.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AccountStateDelta
    {
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("delta", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public StateDelta Delta { get; set; } = new StateDelta();


    }
}
