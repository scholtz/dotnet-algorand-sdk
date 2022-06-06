
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class DryrunTxnResult{
    [Newtonsoft.Json.JsonProperty("app-call-messages", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<string> AppCallMessages {get;set;} = new System.Collections.ObjectModel.Collection<string>();

    [Newtonsoft.Json.JsonProperty("app-call-trace", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<DryrunState> AppCallTrace {get;set;} = new System.Collections.ObjectModel.Collection<DryrunState>();

    [Newtonsoft.Json.JsonProperty("cost", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ulong? Cost {get;set;}


    [Newtonsoft.Json.JsonProperty("disassembly", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<string> Disassembly {get;set;} = new System.Collections.ObjectModel.Collection<string>();

    [Newtonsoft.Json.JsonProperty("global-delta", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<EvalDeltaKeyValue> GlobalDelta {get;set;} = new System.Collections.ObjectModel.Collection<EvalDeltaKeyValue>();

    [Newtonsoft.Json.JsonProperty("local-deltas", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AccountStateDelta> LocalDeltas {get;set;} = new System.Collections.ObjectModel.Collection<AccountStateDelta>();

    [Newtonsoft.Json.JsonProperty("logic-sig-disassembly", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<string> LogicSigDisassembly {get;set;} = new System.Collections.ObjectModel.Collection<string>();

    [Newtonsoft.Json.JsonProperty("logic-sig-messages", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<string> LogicSigMessages {get;set;} = new System.Collections.ObjectModel.Collection<string>();

    [Newtonsoft.Json.JsonProperty("logic-sig-trace", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<DryrunState> LogicSigTrace {get;set;} = new System.Collections.ObjectModel.Collection<DryrunState>();

    [Newtonsoft.Json.JsonProperty("logs", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<byte[]> Logs {get;set;} = new System.Collections.ObjectModel.Collection<byte[]>();

    
}


}
