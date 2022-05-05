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
        public ParticipationPublicKey VotePK;

        /// <summary>
        /// selectionPK is the VRF public key used in key registration transactions
        /// </summary>
        [JsonProperty(PropertyName = "selkey")]
        public VRFPublicKey SelectionPK;
        /// <summary>
        /// voteFirst is the first round this keyreg tx is valid for
        /// </summary>
        [JsonProperty(PropertyName = "votefst")]
        [DefaultValue(0)]
        public ulong? VoteFirst = 0;

        /// <summary>
        /// voteLast is the last round this keyreg tx is valid for
        /// </summary>
        [JsonProperty(PropertyName = "votelst")]
        [DefaultValue(0)]
        public ulong? VoteLast = 0;
        /// <summary>
        /// voteKeyDilution
        /// </summary>
        [JsonProperty(PropertyName = "votekd")]
        [DefaultValue(0)]
        public ulong? VoteKeyDilution = 0;
        /// <summary>
        /// nonParticipation
        /// </summary>
        [JsonProperty(PropertyName = "nonpart")]
        [DefaultValue(false)]
        public bool? NonParticipation = false;
    }
}
