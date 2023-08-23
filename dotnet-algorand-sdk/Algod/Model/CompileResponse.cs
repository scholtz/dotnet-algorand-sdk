
namespace Algorand.Algod.Model
{
    using Newtonsoft.Json.Linq;
    using System = global::System;


public partial class CompileResponse{

        [Newtonsoft.Json.JsonProperty("sourcemap", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"JSON of the source map")]
    [field:InspectorName(@"Sourcemap")]
    public byte[] Sourcemap {get;set;}
#else
        public JObject Sourcemap { get; set; }
#endif



    }


}
