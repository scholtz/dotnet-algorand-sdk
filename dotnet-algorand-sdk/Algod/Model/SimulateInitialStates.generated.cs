
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
public partial class SimulateInitialStates{

    [Newtonsoft.Json.JsonProperty("app-initial-states", Required = Newtonsoft.Json.Required.Default,  NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
#if UNITY
    [field:SerializeField]
    [Tooltip(@"The initial states of accessed application before simulation. The order of this array is arbitrary.")]
    [field:InspectorName(@"AppInitialStates")]
    public System.Collections.Generic.List<ApplicationInitialStates> AppInitialStates {get;set;} = new System.Collections.Generic.List<ApplicationInitialStates>();
#else
    public System.Collections.Generic.ICollection<ApplicationInitialStates> AppInitialStates {get;set;} = new System.Collections.ObjectModel.Collection<ApplicationInitialStates>();
#endif
    
}


}
