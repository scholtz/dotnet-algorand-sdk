using JsonSubTypes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Algorand.Algod.Model.Transactions
{
    [JsonConverter(typeof(JsonSubtypes), "apan")]
    [JsonSubtypes.KnownSubType(typeof(ApplicationClearStateTransaction), OnCompletion.Clear)]
    [JsonSubtypes.KnownSubType(typeof(ApplicationOptInTransaction), OnCompletion.Optin)]
    [JsonSubtypes.KnownSubType(typeof(ApplicationUpdateTransaction), OnCompletion.Update)]
    [JsonSubtypes.KnownSubType(typeof(ApplicationCloseOutTransaction), OnCompletion.Closeout)]
    [JsonSubtypes.KnownSubType(typeof(ApplicationDeleteTransaction), OnCompletion.Delete)]
    [JsonSubtypes.FallBackSubType(typeof(ApplicationNoopTransaction))]
    public abstract partial class ApplicationCallTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        public string type => "appl";

        public bool ShouldSerializeAccounts() { return Accounts?.Count > 0; }
        public bool ShouldSerializeApplicationArgs() { return ApplicationArgs?.Count > 0; }
        public bool ShouldSerializeForeignApps() { return ForeignApps?.Count > 0; }
        public bool ShouldSerializeForeignAssets() { return ForeignAssets?.Count > 0; }

        [JsonIgnore]
        public ICollection<IReturnableTransaction> InnerTxns { get; internal set; }

        [JsonIgnore]
        public ICollection<byte[]> Logs { get; internal set; }

        [JsonIgnore]
        public StateDelta GlobalStateDelta { get; internal set; }
        [JsonIgnore]
        public ICollection<AccountStateDelta> LocalStateDelta { get; internal set; }

    }


}
