﻿


using JsonSubTypes;
using Newtonsoft.Json;

using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions { 


    public partial class ApplicationClearStateTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong ApplicationId { get; set; } = 0;



        
    

    }
}