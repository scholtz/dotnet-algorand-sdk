using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.V2.Algod.Model
{
    internal abstract class CommittedApplicationCallTransaction : CommittedTransaction
    {

        protected CommittedApplicationCallTransaction(ApplicationCallTransaction tx) : base(tx) { }

        /// <summary>\[ld\] Local state key/value changes for the application being executed by this transaction.</summary>
        [JsonIgnore]
        public ICollection<AccountStateDelta> LocalStateDelta { get; private set; }

        [JsonProperty("local-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ICollection<AccountStateDelta> localStateDelta { set { LocalStateDelta = value; } }

        [JsonIgnore]
        public StateDelta GlobalStateDelta { get; private set; }
        /// <summary>\[gd\] Global state key/value changes for the application being executed by this transaction.</summary>
        [JsonProperty("global-state-delta", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private StateDelta globalStateDelta { set { GlobalStateDelta = value; } }

        /// <summary>\[lg\] Logs for the application being executed by this transaction.</summary>
        public ICollection<byte[]> Logs { get; private set; }
        [JsonProperty("logs", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ICollection<byte[]> logs { set { Logs = value; } }

        public ICollection<CommittedApplicationCallTransaction> InnerTxns { get; private set; }
        /// <summary>Inner transactions produced by application execution.</summary>
        [JsonProperty("inner-txns", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        private ICollection<CommittedApplicationCallTransaction> innerTxns { set { InnerTxns = value; } }
    }
}
