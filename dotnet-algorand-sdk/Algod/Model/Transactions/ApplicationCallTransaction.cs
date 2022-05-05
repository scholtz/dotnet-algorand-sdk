


using JsonSubTypes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.Algod.Model {

    [JsonConverter(typeof(JsonSubtypes), "OnCompletion")]
    [JsonSubtypes.KnownSubType(typeof(ApplicationClearStateTransaction), OnCompletion.Clear)]

    public abstract class ApplicationCallTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private string type => "appl";



        [JsonProperty(PropertyName = "apat")]
        public List<Address> Accounts = new List<Address>();

        [JsonProperty(PropertyName = "apaa")]
        public List<byte[]> ApplicationArgs = new List<byte[]>();
        
        [JsonProperty(PropertyName = "apfa")]
        public List<ulong> ForeignApps = new List<ulong>();

        [JsonProperty(PropertyName = "apas")]
        public List<ulong> ForeignAssets = new List<ulong>();

        public bool ShouldSerializeAccounts() { return Accounts?.Count > 0; }
        public bool ShouldSerializeApplicationArgs() { return ApplicationArgs?.Count > 0; }
        public bool ShouldSerializeForeignApps() { return ForeignApps?.Count > 0; }
        public bool ShouldSerializeForeignAssets() { return ForeignAssets?.Count > 0; }



    }
}
