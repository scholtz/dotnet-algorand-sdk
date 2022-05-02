namespace Algorand.V2.Algod.Model
{
    using System = global::System;
    /// <summary>AccountParticipation describes the parameters used by this account in consensus protocol.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AccountParticipation
    {
        /// <summary>\[sel\] Selection public key (if any) currently registered for this round.</summary>
        [Newtonsoft.Json.JsonProperty("selection-participation-key", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] SelectionParticipationKey { get; set; }

        /// <summary>\[voteFst\] First round for which this participation is valid.</summary>
        [Newtonsoft.Json.JsonProperty("vote-first-valid", Required = Newtonsoft.Json.Required.Always)]
        public ulong VoteFirstValid { get; set; }

        /// <summary>\[voteKD\] Number of subkeys in each batch of participation keys.</summary>
        [Newtonsoft.Json.JsonProperty("vote-key-dilution", Required = Newtonsoft.Json.Required.Always)]
        public ulong VoteKeyDilution { get; set; }

        /// <summary>\[voteLst\] Last round for which this participation is valid.</summary>
        [Newtonsoft.Json.JsonProperty("vote-last-valid", Required = Newtonsoft.Json.Required.Always)]
        public ulong VoteLastValid { get; set; }

        /// <summary>\[vote\] root participation public key (if any) currently registered for this round.</summary>
        [Newtonsoft.Json.JsonProperty("vote-participation-key", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public byte[] VoteParticipationKey { get; set; }


    }
}
