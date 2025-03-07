using AVM.ClientGenerator.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Core
{
    public class AssetFreezeTransactionReference : TransactionReference
    {
        [Storage(StorageType.Protocol)]
        public byte[] FreezeAssetAccount;
        [Storage(StorageType.Protocol)]
        public ulong FreezeAsset;
        [Storage(StorageType.Protocol)]
        public bool FreezeAssetFrozen;
 

    }
}
