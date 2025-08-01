using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorand.Algod.Model.Transactions
{
    [MessagePackObject]
    public partial class KeyRegisterOnlineTransaction : KeyRegistrationTransaction
    {
        public bool ShouldSerializeVoteKeyDilution()
        {
            return VoteKeyDilution != 0;
        }

        public bool ShouldSerializeVoteFirst()
        {
            return VoteFirst != 0;
        }

        public bool ShouldSerializeVoteLast()
        {
            return VoteLast != 0;
        }

        [JsonProperty(PropertyName = "sprfkey")]
        [MessagePack.Key("sprfkey")]
        public byte[] StateProofPK { get; set; } 

    }
}
