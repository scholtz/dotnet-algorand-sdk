using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorand.Algod.Model
{
    public class CommittedAssetCreateTransaction : CommittedTransaction
    {

        public CommittedAssetCreateTransaction() : base(new AssetCreateTransaction()) { }

        /// <summary>The number of the asset's unit that were transferred to the close-to address..</summary>
        [JsonProperty("asset-index", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(0)]
        private ulong? assetIndex { set { AssetIndex = value; } }
        [JsonIgnore]
        public ulong? AssetIndex { get; private set; }


    }
}
