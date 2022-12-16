
namespace Algorand.Algod.Model
{

using System = global::System;


public partial class BoxesResponse{

    [Newtonsoft.Json.JsonProperty("boxes", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<BoxDescriptor> Boxes {get;set;} = new System.Collections.ObjectModel.Collection<BoxDescriptor>();

    
}


}
