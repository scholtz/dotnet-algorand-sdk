using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorand.Algod.Model
{
    public class CommittedApplicationCreateTransaction :  CommittedApplicationCallTransaction 
    {

        public CommittedApplicationCreateTransaction() : base(new ApplicationCreateTransaction()) { }

        /// <summary>The round where this transaction was confirmed, if present.</summary>
        [JsonProperty("application-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(0)]
        private ulong? applicationIndex { set { ApplicationIndex = value; } }
        [JsonIgnore]
        public ulong? ApplicationIndex { get; private set; }


        

    }
}
