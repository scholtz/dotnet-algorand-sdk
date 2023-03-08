
namespace Algorand.Algod.Model
{
    using Algorand.Algod.Model.Transactions;
#if UNITY
    using UnityEngine;
#endif

using System = global::System;
#if UNITY
using UnityEngine;
#endif

#if UNITY
[System.Serializable]
#endif
public partial class BoxesResponse{

    [Newtonsoft.Json.JsonProperty("boxes", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"")]
    [field:InspectorName(@"Boxes")]
    public System.Collections.Generic.List<BoxDescriptor> Boxes {get;set;} = new System.Collections.Generic.List<BoxDescriptor>();
#else
    public System.Collections.Generic.ICollection<BoxDescriptor> Boxes {get;set;} = new System.Collections.ObjectModel.Collection<BoxDescriptor>();
#endif
    
}


}
