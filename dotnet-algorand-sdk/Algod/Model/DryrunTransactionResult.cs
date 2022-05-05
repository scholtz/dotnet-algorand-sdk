

namespace Algorand.Algod.Model
{
    using System = global::System;

    /// <summary>DryrunTxnResult contains any LogicSig or ApplicationCall program debug information and state updates from a dryrun.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class DryrunTxnResult
    {
        /// <summary>Disassembled program line by line.</summary>
        [Newtonsoft.Json.JsonProperty("disassembly", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<string> Disassembly { get; set; } = new System.Collections.ObjectModel.Collection<string>();

        [Newtonsoft.Json.JsonProperty("logic-sig-trace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DryrunState> LogicSigTrace { get; set; }

        [Newtonsoft.Json.JsonProperty("logic-sig-messages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> LogicSigMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("app-call-trace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DryrunState> AppCallTrace { get; set; }

        [Newtonsoft.Json.JsonProperty("app-call-messages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> AppCallMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("global-delta", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StateDelta GlobalDelta { get; set; }

        [Newtonsoft.Json.JsonProperty("local-deltas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AccountStateDelta> LocalDeltas { get; set; }

        [Newtonsoft.Json.JsonProperty("logs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<byte[]> Logs { get; set; }

        /// <summary>Execution cost of app call transaction</summary>
        [Newtonsoft.Json.JsonProperty("cost", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Cost { get; set; }


    }

}
