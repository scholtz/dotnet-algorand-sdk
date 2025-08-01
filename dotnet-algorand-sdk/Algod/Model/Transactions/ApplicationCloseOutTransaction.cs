


using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    [MessagePack.MessagePackObject]
    public partial class ApplicationCloseOutTransaction : ApplicationCallTransaction
    {
        [JsonProperty(PropertyName = "apan")]
        [MessagePack.Key("apan")]
        public OnCompletion OnCompletion => OnCompletion.Closeout;
    }
}
