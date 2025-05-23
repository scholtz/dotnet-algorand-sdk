﻿using AVM.ClientGenerator.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Core
{
    public class AssetTransferTransactionReference : TransactionReference
    {
        [Storage(StorageType.Protocol)]
        public ulong XferAsset;

        [Storage(StorageType.Protocol)]
        public ulong AssetAmount;

        [Storage(StorageType.Protocol)]
        public byte[] AssetSender;

        [Storage(StorageType.Protocol)]
        public byte[] AssetReceiver;

        [Storage(StorageType.Protocol)]
        public byte[] AssetCloseTo;
        
    }
}
