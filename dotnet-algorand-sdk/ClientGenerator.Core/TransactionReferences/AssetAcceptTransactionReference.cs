﻿using AVM.ClientGenerator.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Core
{
    internal class AssetAcceptTransactionReference : TransactionReference
    {
        [Storage(StorageType.Protocol)]
        public ulong XferAsset;

        [Storage(StorageType.Protocol)]
        public byte[] AssetSender;

        [Storage(StorageType.Protocol)]
        public byte[] AssetReceiver;


    }
}
