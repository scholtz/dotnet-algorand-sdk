


namespace Algorand.V2.Algod.Model
{
    using System = global::System;
    /// <summary>Account information at a given round.
    /// <br/>
    /// <br/>Definition:
    /// <br/>data/basics/userBalance.go : AccountData
    /// <br/></summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class Account
    {
        /// <summary>the account public key</summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Address { get; set; }

        /// <summary>\[algo\] total number of MicroAlgos in the account</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        public ulong Amount { get; set; }

        /// <summary>specifies the amount of MicroAlgos in the account, without the pending rewards.</summary>
        [Newtonsoft.Json.JsonProperty("amount-without-pending-rewards", Required = Newtonsoft.Json.Required.Always)]
        public ulong AmountWithoutPendingRewards { get; set; }

        /// <summary>\[appl\] applications local data stored in this account.
        /// <br/>
        /// <br/>Note the raw object uses `map[int] -&gt; AppLocalState` for this type.</summary>
        [Newtonsoft.Json.JsonProperty("apps-local-state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ApplicationLocalState> AppsLocalState { get; set; }

        /// <summary>\[tsch\] stores the sum of all of the local schemas and global schemas in this account.
        /// <br/>
        /// <br/>Note: the raw account uses `StateSchema` for this type.</summary>
        [Newtonsoft.Json.JsonProperty("apps-total-schema", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ApplicationStateSchema AppsTotalSchema { get; set; }

        /// <summary>\[teap\] the sum of all extra application program pages for this account.</summary>
        [Newtonsoft.Json.JsonProperty("apps-total-extra-pages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AppsTotalExtraPages { get; set; }

        /// <summary>\[asset\] assets held by this account.
        /// <br/>
        /// <br/>Note the raw object uses `map[int] -&gt; AssetHolding` for this type.</summary>
        [Newtonsoft.Json.JsonProperty("assets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AssetHolding> Assets { get; set; }

        /// <summary>\[appp\] parameters of applications created by this account including app global data.
        /// <br/>
        /// <br/>Note: the raw account uses `map[int] -&gt; AppParams` for this type.</summary>
        [Newtonsoft.Json.JsonProperty("created-apps", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Application> CreatedApps { get; set; }

        /// <summary>\[apar\] parameters of assets created by this account.
        /// <br/>
        /// <br/>Note: the raw account uses `map[int] -&gt; Asset` for this type.</summary>
        [Newtonsoft.Json.JsonProperty("created-assets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Asset> CreatedAssets { get; set; }

        [Newtonsoft.Json.JsonProperty("participation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AccountParticipation Participation { get; set; }

        /// <summary>amount of MicroAlgos of pending rewards in this account.</summary>
        [Newtonsoft.Json.JsonProperty("pending-rewards", Required = Newtonsoft.Json.Required.Always)]
        public ulong PendingRewards { get; set; }

        /// <summary>\[ebase\] used as part of the rewards computation. Only applicable to accounts which are participating.</summary>
        [Newtonsoft.Json.JsonProperty("reward-base", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ulong? RewardBase { get; set; }

        /// <summary>\[ern\] total rewards of MicroAlgos the account has received, including pending rewards.</summary>
        [Newtonsoft.Json.JsonProperty("rewards", Required = Newtonsoft.Json.Required.Always)]
        public ulong Rewards { get; set; }

        /// <summary>The round for which this information is relevant.</summary>
        [Newtonsoft.Json.JsonProperty("round", Required = Newtonsoft.Json.Required.Always)]
        public ulong Round { get; set; }

        /// <summary>\[onl\] delegation status of the account's MicroAlgos
        /// <br/>* Offline - indicates that the associated account is delegated.
        /// <br/>*  Online  - indicates that the associated account used as part of the delegation pool.
        /// <br/>*   NotParticipating - indicates that the associated account is neither a delegator nor a delegate.</summary>
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Status { get; set; }

        /// <summary>Indicates what type of signature is used by this account, must be one of:
        /// <br/>* sig
        /// <br/>* msig
        /// <br/>* lsig</summary>
        [Newtonsoft.Json.JsonProperty("sig-type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public AccountSigType? SigType { get; set; }

        /// <summary>\[spend\] the address against which signing should be checked. If empty, the address of the current account is used. This field can be updated in any transaction by setting the RekeyTo field.</summary>
        [Newtonsoft.Json.JsonProperty("auth-addr", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AuthAddr { get; set; }


    }
}
