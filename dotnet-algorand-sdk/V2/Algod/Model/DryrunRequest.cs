namespace Algorand.V2.Algod.Model
{
    using System = global::System;


    /// <summary>Request data type for dryrun endpoint. Given the Transactions and simulated ledger state upload, run TEAL scripts and return debugging information.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class DryrunRequest
    {
        [Newtonsoft.Json.JsonProperty("txns", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<SignedTransaction> Txns { get; set; } = new System.Collections.ObjectModel.Collection<SignedTransaction>();

        [Newtonsoft.Json.JsonProperty("accounts", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<Account> Accounts { get; set; } = new System.Collections.ObjectModel.Collection<Account>();

        [Newtonsoft.Json.JsonProperty("apps", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<Application> Apps { get; set; } = new System.Collections.ObjectModel.Collection<Application>();

        /// <summary>ProtocolVersion specifies a specific version string to operate under, otherwise whatever the current protocol of the network this algod is running in.</summary>
        [Newtonsoft.Json.JsonProperty("protocol-version", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string ProtocolVersion { get; set; }

        /// <summary>Round is available to some TEAL scripts. Defaults to the current round on the network this algod is attached to.</summary>
        [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
        public ulong Round { get; set; }

        /// <summary>LatestTimestamp is available to some TEAL scripts. Defaults to the latest confirmed timestamp this algod is attached to.</summary>
        [Newtonsoft.Json.JsonProperty("latest-timestamp", Required = Newtonsoft.Json.Required.Always)]
        public ulong LatestTimestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("sources", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<DryrunSource> Sources { get; set; } = new System.Collections.ObjectModel.Collection<DryrunSource>();


    }
}
