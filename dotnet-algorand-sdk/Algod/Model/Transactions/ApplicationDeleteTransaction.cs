


using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model
{

    public  class ApplicationDeleteTransaction : ApplicationCallTransaction
    {

        [JsonProperty(PropertyName = "apid")]
        [DefaultValue(0)]
        public ulong? ApplicationId { get; set; } = 0;


        [JsonProperty(PropertyName = "apan")]
        public OnCompletion OnCompletion => OnCompletion.Delete;








    }
}
