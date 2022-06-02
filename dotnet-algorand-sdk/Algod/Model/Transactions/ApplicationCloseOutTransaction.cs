


using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.Algod.Model { 

    public  class ApplicationCloseOutTransaction : ApplicationCallTransaction
    {


        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? ApplicationId { get; set; } = 0;
       
        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Closeout; 





    

    }
}
