using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorand.Algod.Model
{
    public class KeyRegisterOnlineTransaction : KeyRegistrationTransaction
    {

        /// <summary>
        /// VotePK is the participation public key used in key registration transactions
        /// </summary>
        [JsonProperty(PropertyName = "votekey")]
        public ParticipationPublicKey VotePK { get; set; }

        /// <summary>
        /// selectionPK is the VRF public key used in key registration transactions
        /// </summary>
        [JsonProperty(PropertyName = "selkey")]
        public VRFPublicKey SelectionPK { get; set; }
        /// <summary>
        /// voteFirst is the first round this keyreg tx is valid for
        /// </summary>
        [JsonProperty(PropertyName = "votefst")]
        [DefaultValue(0)]
        public ulong? VoteFirst { get; set; } = 0;

        /// <summary>
        /// voteLast is the last round this keyreg tx is valid for
        /// </summary>
        [JsonProperty(PropertyName = "votelst")]
        [DefaultValue(0)]
        public ulong? VoteLast { get; set; } = 0;
        /// <summary>
        /// voteKeyDilution
        /// </summary>
        [JsonProperty(PropertyName = "votekd")]
        [DefaultValue(0)]
        public ulong? VoteKeyDilution { get; set; } = 0;
        /// <summary>
        /// nonParticipation
        /// </summary>
        [JsonProperty(PropertyName = "nonpart")]
        [DefaultValue(false)]
        public bool? NonParticipation { get; set; } = false;
    }
}
