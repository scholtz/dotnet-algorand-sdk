using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorand.V2.Algod.Model
{
    internal class CommittedAssetTransferTransaction : CommittedTransaction<AssetTransferTransaction>
    {
        /// <summary>The number of the asset's unit that were transferred to the close-to address..</summary>
        [JsonProperty("asset-closing-amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(0)]
        private ulong? assetClosingAmount { set { AssetClosingAmount = value; } }
        [JsonIgnore]
        public ulong? AssetClosingAmount { get; private set; }


    }
}
