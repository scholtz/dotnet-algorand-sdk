using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorand.V2.Algod.Model
{
    public abstract class KeyRegistrationTransaction : Transaction
    {
        [JsonProperty(PropertyName = "type")]
        private readonly string type = "keyreg";


    }
}
