

using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.V2.Algod.Model
{
    public class ApplicationCallTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "appl";

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? applicationId = 0;

        [JsonProperty(PropertyName = "apan")]
        public V2.Indexer.Model.OnCompletion onCompletion = V2.Indexer.Model.OnCompletion.Noop;


        [JsonProperty(PropertyName = "apat")]
        public List<Address> accounts = new List<Address>();

        [JsonProperty(PropertyName = "apap")]
        public TEALProgram approvalProgram = null;

        [JsonProperty(PropertyName = "apaa")]
        public List<byte[]> applicationArgs = new List<byte[]>();

        [JsonProperty(PropertyName = "apsu")]
        public TEALProgram clearStateProgram = null;




        [JsonProperty(PropertyName = "apfa")]
        public List<ulong> foreignApps = new List<ulong>();

        [JsonProperty(PropertyName = "apas")]
        public List<ulong> foreignAssets = new List<ulong>();

        [JsonProperty(PropertyName = "apgs")]
        public V2.Indexer.Model.StateSchema globalStateSchema = new V2.Indexer.Model.StateSchema();


        [JsonProperty(PropertyName = "apls")]
        public V2.Indexer.Model.StateSchema localStateSchema = new V2.Indexer.Model.StateSchema();


        [JsonProperty(PropertyName = "apep")]
        [DefaultValue(0)]
        public ulong? extraProgramPages = 0;


    }
}
