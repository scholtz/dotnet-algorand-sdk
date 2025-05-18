using System;
using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using AVM.ClientGenerator;
using AVM.ClientGenerator.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVM.ClientGenerator.ABI.ARC56;
using Algorand.AVM.ClientGenerator.ABI.ARC56;

namespace ARC200
{


    //
    // Smart Contract Token Base Interface
    //
    public class Arc200Proxy : ProxyBase
    {
        public override AppDescriptionArc56 App { get; set; } = null;

        public Arc200Proxy(DefaultApi defaultApi, ulong appId) : base(defaultApi, appId)
        {
            App = Newtonsoft.Json.JsonConvert.DeserializeObject<AVM.ClientGenerator.ABI.ARC56.AppDescriptionArc56>(Encoding.UTF8.GetString(Convert.FromBase64String(_ARC56DATA)));

        }

        public class Structs
        {
            public class ApprovalStruct : AVMObjectType
            {
                public AVM.ClientGenerator.ABI.ARC4.Types.UInt256 ApprovalAmount { get; set; }

                public byte[] Owner { get; set; }

                public byte[] Spender { get; set; }

                public byte[] ToByteArray()
                {
                    var ret = new List<byte>();
                    var stringRef = new Dictionary<int, byte[]>();
                    AVM.ClientGenerator.ABI.ARC4.Types.WireType vApprovalAmount = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
                    vApprovalAmount.From(ApprovalAmount);
                    ret.AddRange(vApprovalAmount.Encode());
                    AVM.ClientGenerator.ABI.ARC4.Types.WireType vOwner = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
                    vOwner.From(Owner);
                    ret.AddRange(vOwner.Encode());
                    AVM.ClientGenerator.ABI.ARC4.Types.WireType vSpender = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
                    vSpender.From(Spender);
                    ret.AddRange(vSpender.Encode());
                    foreach (var item in stringRef)
                    {
                        var b1 = ret.Count;
                        ret[item.Key] = Convert.ToByte(b1 / 256);
                        ret[item.Key + 1] = Convert.ToByte(b1 % 256);
                        ret.AddRange(item.Value);
                    }
                    return ret.ToArray();

                }

                public static ApprovalStruct Parse(byte[] bytes)
                {
                    var queue = new Queue<byte>(bytes);
                    var prefixOffset = 0;
                    var retPrefix = new byte[4] { bytes[0], bytes[1], bytes[2], bytes[3] };
                    if (retPrefix.SequenceEqual(Constants.RetPrefix))
                    {
                        prefixOffset = 4;
                        for (int i = 0; i < 4 && queue.Count > 0; i++) { queue.Dequeue(); }
                    }
                    var ret = new ApprovalStruct();
                    uint count = 0;
                    AVM.ClientGenerator.ABI.ARC4.Types.WireType vApprovalAmount = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
                    count = vApprovalAmount.Decode(queue.ToArray());
                    for (int i = 0; i < Convert.ToInt32(count); i++) { queue.Dequeue(); }
                    var valueApprovalAmount = vApprovalAmount.ToValue();
                    if (valueApprovalAmount is AVM.ClientGenerator.ABI.ARC4.Types.UInt256 vApprovalAmountValue) { ret.ApprovalAmount = vApprovalAmountValue; }
                    AVM.ClientGenerator.ABI.ARC4.Types.WireType vOwner = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
                    count = vOwner.Decode(queue.ToArray());
                    for (int i = 0; i < Convert.ToInt32(count); i++) { queue.Dequeue(); }
                    var valueOwner = vOwner.ToValue();
                    if (valueOwner is byte[] vOwnerValue) { ret.Owner = vOwnerValue; }
                    AVM.ClientGenerator.ABI.ARC4.Types.WireType vSpender = AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
                    count = vSpender.Decode(queue.ToArray());
                    for (int i = 0; i < Convert.ToInt32(count); i++) { queue.Dequeue(); }
                    var valueSpender = vSpender.ToValue();
                    if (valueSpender is byte[] vSpenderValue) { ret.Spender = vSpenderValue; }
                    return ret;

                }

            }

        }

        ///<summary>
        ///
        ///</summary>
        /// <param name="name"> </param>
        /// <param name="symbol"> </param>
        /// <param name="decimals"> </param>
        /// <param name="totalSupply"> </param>
        public async Task<bool> Bootstrap(byte[] name, byte[] symbol, byte decimals, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 totalSupply, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 151, 83, 130, 226 };
            var nameAbi = new AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>(); nameAbi.From(name);
            var symbolAbi = new AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>(); symbolAbi.From(symbol);
            var decimalsAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Byte(); decimalsAbi.From(decimals);

            var result = await base.CallApp(new List<object> { abiHandle, nameAbi, symbolAbi, decimalsAbi, totalSupply }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.Bool();
            returnValueObj.Decode(lastLogReturnData);
            return BitConverter.ToBoolean(ReverseIfLittleEndian(lastLogReturnData), 0);

        }

        public async Task<List<Transaction>> Bootstrap_Transactions(byte[] name, byte[] symbol, byte decimals, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 totalSupply, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 151, 83, 130, 226 };
            var nameAbi = new AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>(); nameAbi.From(name);
            var symbolAbi = new AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>(); symbolAbi.From(symbol);
            var decimalsAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Byte(); decimalsAbi.From(decimals);

            return await base.MakeTransactionList(new List<object> { abiHandle, nameAbi, symbolAbi, decimalsAbi, totalSupply }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Returns the name of the token
        ///</summary>
        public async Task<byte[]> Arc200Name(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 101, 125, 19, 236 };

            var result = await base.SimApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.FixedArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>(32);
            returnValueObj.Decode(lastLogReturnData);
            return returnValueObj.ToByteArray();


        }

        public async Task<List<Transaction>> Arc200Name_Transactions(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 101, 125, 19, 236 };

            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Returns the symbol of the token
        ///</summary>
        public async Task<byte[]> Arc200Symbol(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 182, 174, 26, 37 };

            var result = await base.SimApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.FixedArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>(8);
            returnValueObj.Decode(lastLogReturnData);
            return returnValueObj.ToByteArray();


        }

        public async Task<List<Transaction>> Arc200Symbol_Transactions(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 182, 174, 26, 37 };

            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Returns the decimals of the token
        ///</summary>
        public async Task<byte> Arc200Decimals(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 132, 236, 19, 213 };

            var result = await base.SimApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.Byte();
            returnValueObj.Decode(lastLogReturnData);
            return ReverseIfLittleEndian(lastLogReturnData)[0];

        }

        public async Task<List<Transaction>> Arc200Decimals_Transactions(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 132, 236, 19, 213 };

            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Returns the total supply of the token
        ///</summary>
        public async Task<AVM.ClientGenerator.ABI.ARC4.Types.UInt256> Arc200TotalSupply(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 236, 153, 96, 65 };

            var result = await base.SimApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.UInt256();
            returnValueObj.Decode(lastLogReturnData);
            return returnValueObj;

        }

        public async Task<List<Transaction>> Arc200TotalSupply_Transactions(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 236, 153, 96, 65 };

            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Returns the current balance of the owner of the token
        ///</summary>
        /// <param name="owner">The address of the owner of the token </param>
        public async Task<AVM.ClientGenerator.ABI.ARC4.Types.UInt256> Arc200BalanceOf(Address owner, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { owner });
            byte[] abiHandle = { 130, 229, 115, 196 };
            var ownerAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); ownerAbi.From(owner);

            var result = await base.SimApp(new List<object> { abiHandle, ownerAbi }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.UInt256();
            returnValueObj.Decode(lastLogReturnData);
            return returnValueObj;

        }

        public async Task<List<Transaction>> Arc200BalanceOf_Transactions(Address owner, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 130, 229, 115, 196 };
            var ownerAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); ownerAbi.From(owner);

            return await base.MakeTransactionList(new List<object> { abiHandle, ownerAbi }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Transfers tokens
        ///</summary>
        /// <param name="to">The destination of the transfer </param>
        /// <param name="value">Amount of tokens to transfer </param>
        public async Task<bool> Arc200Transfer(Address to, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 value, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { to });
            byte[] abiHandle = { 218, 112, 37, 185 };
            var toAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); toAbi.From(to);

            var result = await base.CallApp(new List<object> { abiHandle, toAbi, value }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.Bool();
            returnValueObj.Decode(lastLogReturnData);
            return BitConverter.ToBoolean(ReverseIfLittleEndian(lastLogReturnData), 0);

        }

        public async Task<List<Transaction>> Arc200Transfer_Transactions(Address to, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 value, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 218, 112, 37, 185 };
            var toAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); toAbi.From(to);

            return await base.MakeTransactionList(new List<object> { abiHandle, toAbi, value }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Transfers tokens from source to destination as approved spender
        ///</summary>
        /// <param name="from">The source of the transfer </param>
        /// <param name="to">The destination of the transfer </param>
        /// <param name="value">Amount of tokens to transfer </param>
        public async Task<bool> Arc200TransferFrom(Address from, Address to, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 value, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { from, to });
            byte[] abiHandle = { 74, 150, 143, 143 };
            var fromAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); fromAbi.From(from);
            var toAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); toAbi.From(to);

            var result = await base.CallApp(new List<object> { abiHandle, fromAbi, toAbi, value }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.Bool();
            returnValueObj.Decode(lastLogReturnData);
            return BitConverter.ToBoolean(ReverseIfLittleEndian(lastLogReturnData), 0);

        }

        public async Task<List<Transaction>> Arc200TransferFrom_Transactions(Address from, Address to, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 value, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 74, 150, 143, 143 };
            var fromAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); fromAbi.From(from);
            var toAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); toAbi.From(to);

            return await base.MakeTransactionList(new List<object> { abiHandle, fromAbi, toAbi, value }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Approve spender for a token
        ///</summary>
        /// <param name="spender">Who is allowed to take tokens on owner's behalf </param>
        /// <param name="value">Amount of tokens to be taken by spender </param>
        public async Task<bool> Arc200Approve(Address spender, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 value, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { spender });
            byte[] abiHandle = { 181, 66, 33, 37 };
            var spenderAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); spenderAbi.From(spender);

            var result = await base.CallApp(new List<object> { abiHandle, spenderAbi, value }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.Bool();
            returnValueObj.Decode(lastLogReturnData);
            return BitConverter.ToBoolean(ReverseIfLittleEndian(lastLogReturnData), 0);

        }

        public async Task<List<Transaction>> Arc200Approve_Transactions(Address spender, AVM.ClientGenerator.ABI.ARC4.Types.UInt256 value, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 181, 66, 33, 37 };
            var spenderAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); spenderAbi.From(spender);

            return await base.MakeTransactionList(new List<object> { abiHandle, spenderAbi, value }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Returns the current allowance of the spender of the tokens of the owner
        ///</summary>
        /// <param name="owner">Owner's account </param>
        /// <param name="spender">Who is allowed to take tokens on owner's behalf </param>
        public async Task<AVM.ClientGenerator.ABI.ARC4.Types.UInt256> Arc200Allowance(Address owner, Address spender, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { owner, spender });
            byte[] abiHandle = { 187, 179, 25, 243 };
            var ownerAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); ownerAbi.From(owner);
            var spenderAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); spenderAbi.From(spender);

            var result = await base.SimApp(new List<object> { abiHandle, ownerAbi, spenderAbi }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            var lastLogBytes = result.Last();
            if (lastLogBytes.Length < 4 || lastLogBytes[0] != 21 || lastLogBytes[1] != 31 || lastLogBytes[2] != 124 || lastLogBytes[3] != 117) throw new Exception("Invalid ABI handle");
            var lastLogReturnData = lastLogBytes.Skip(4).ToArray();
            var returnValueObj = new AVM.ClientGenerator.ABI.ARC4.Types.UInt256();
            returnValueObj.Decode(lastLogReturnData);
            return returnValueObj;

        }

        public async Task<List<Transaction>> Arc200Allowance_Transactions(Address owner, Address spender, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 187, 179, 25, 243 };
            var ownerAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); ownerAbi.From(owner);
            var spenderAbi = new AVM.ClientGenerator.ABI.ARC4.Types.Address(); spenderAbi.From(spender);

            return await base.MakeTransactionList(new List<object> { abiHandle, ownerAbi, spenderAbi }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Constructor Bare Action
        ///</summary>
        public async Task CreateApplication(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.CreateApplication)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 0, 193, 250, 21 };

            var result = await base.CallApp(new List<object> { }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> CreateApplication_Transactions(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.CreateApplication)
        {
            byte[] abiHandle = { 0, 193, 250, 21 };

            return await base.MakeTransactionList(new List<object> { }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        protected override ulong? ExtraProgramPages { get; set; } = 0;
        protected string _ARC56DATA = "eyJhcmNzIjpbMjIsMjhdLCJuYW1lIjoiQXJjMjAwIiwiZGVzYyI6IlNtYXJ0IENvbnRyYWN0IFRva2VuIEJhc2UgSW50ZXJmYWNlIiwibmV0d29ya3MiOnt9LCJzdHJ1Y3RzIjp7IkFwcHJvdmFsU3RydWN0IjpbeyJuYW1lIjoiYXBwcm92YWxBbW91bnQiLCJ0eXBlIjoidWludDI1NiJ9LHsibmFtZSI6Im93bmVyIiwidHlwZSI6ImFkZHJlc3MifSx7Im5hbWUiOiJzcGVuZGVyIiwidHlwZSI6ImFkZHJlc3MifV19LCJNZXRob2RzIjpbeyJuYW1lIjoiYm9vdHN0cmFwIiwiZGVzYyI6bnVsbCwiYXJncyI6W3sidHlwZSI6ImJ5dGVbXSIsInN0cnVjdCI6bnVsbCwibmFtZSI6Im5hbWUiLCJkZXNjIjpudWxsLCJkZWZhdWx0VmFsdWUiOm51bGx9LHsidHlwZSI6ImJ5dGVbXSIsInN0cnVjdCI6bnVsbCwibmFtZSI6InN5bWJvbCIsImRlc2MiOm51bGwsImRlZmF1bHRWYWx1ZSI6bnVsbH0seyJ0eXBlIjoidWludDgiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJkZWNpbWFscyIsImRlc2MiOm51bGwsImRlZmF1bHRWYWx1ZSI6bnVsbH0seyJ0eXBlIjoidWludDI1NiIsInN0cnVjdCI6bnVsbCwibmFtZSI6InRvdGFsU3VwcGx5IiwiZGVzYyI6bnVsbCwiZGVmYXVsdFZhbHVlIjpudWxsfV0sInJldHVybnMiOnsidHlwZSI6ImJvb2wiLCJzdHJ1Y3QiOm51bGwsImRlc2MiOm51bGx9LCJhY3Rpb25zIjp7ImNyZWF0ZSI6W10sImNhbGwiOlsiTm9PcCJdfSwicmVhZG9ubHkiOmZhbHNlLCJldmVudHMiOlt7Im5hbWUiOiJhcmMyMDBfVHJhbnNmZXIiLCJkZXNjIjpudWxsLCJhcmdzIjpbeyJ0eXBlIjoiYWRkcmVzcyIsInN0cnVjdCI6bnVsbCwibmFtZSI6ImZyb20iLCJkZXNjIjpudWxsfSx7InR5cGUiOiJhZGRyZXNzIiwic3RydWN0IjpudWxsLCJuYW1lIjoidG8iLCJkZXNjIjpudWxsfSx7InR5cGUiOiJ1aW50MjU2Iiwic3RydWN0IjpudWxsLCJuYW1lIjoidmFsdWUiLCJkZXNjIjpudWxsfV19XSwicmVjb21tZW5kYXRpb25zIjp7ImlubmVyVHJhbnNhY3Rpb25Db3VudCI6bnVsbCwiYm94ZXMiOm51bGwsImFjY291bnRzIjpudWxsLCJhcHBzIjpudWxsLCJhc3NldHMiOm51bGx9fSx7Im5hbWUiOiJhcmMyMDBfbmFtZSIsImRlc2MiOiJSZXR1cm5zIHRoZSBuYW1lIG9mIHRoZSB0b2tlbiIsImFyZ3MiOltdLCJyZXR1cm5zIjp7InR5cGUiOiJieXRlWzMyXSIsInN0cnVjdCI6bnVsbCwiZGVzYyI6IlRoZSBuYW1lIG9mIHRoZSB0b2tlbiJ9LCJhY3Rpb25zIjp7ImNyZWF0ZSI6W10sImNhbGwiOlsiTm9PcCJdfSwicmVhZG9ubHkiOnRydWUsImV2ZW50cyI6W10sInJlY29tbWVuZGF0aW9ucyI6eyJpbm5lclRyYW5zYWN0aW9uQ291bnQiOm51bGwsImJveGVzIjpudWxsLCJhY2NvdW50cyI6bnVsbCwiYXBwcyI6bnVsbCwiYXNzZXRzIjpudWxsfX0seyJuYW1lIjoiYXJjMjAwX3N5bWJvbCIsImRlc2MiOiJSZXR1cm5zIHRoZSBzeW1ib2wgb2YgdGhlIHRva2VuIiwiYXJncyI6W10sInJldHVybnMiOnsidHlwZSI6ImJ5dGVbOF0iLCJzdHJ1Y3QiOm51bGwsImRlc2MiOiJUaGUgc3ltYm9sIG9mIHRoZSB0b2tlbiJ9LCJhY3Rpb25zIjp7ImNyZWF0ZSI6W10sImNhbGwiOlsiTm9PcCJdfSwicmVhZG9ubHkiOnRydWUsImV2ZW50cyI6W10sInJlY29tbWVuZGF0aW9ucyI6eyJpbm5lclRyYW5zYWN0aW9uQ291bnQiOm51bGwsImJveGVzIjpudWxsLCJhY2NvdW50cyI6bnVsbCwiYXBwcyI6bnVsbCwiYXNzZXRzIjpudWxsfX0seyJuYW1lIjoiYXJjMjAwX2RlY2ltYWxzIiwiZGVzYyI6IlJldHVybnMgdGhlIGRlY2ltYWxzIG9mIHRoZSB0b2tlbiIsImFyZ3MiOltdLCJyZXR1cm5zIjp7InR5cGUiOiJ1aW50OCIsInN0cnVjdCI6bnVsbCwiZGVzYyI6IlRoZSBkZWNpbWFscyBvZiB0aGUgdG9rZW4ifSwiYWN0aW9ucyI6eyJjcmVhdGUiOltdLCJjYWxsIjpbIk5vT3AiXX0sInJlYWRvbmx5Ijp0cnVlLCJldmVudHMiOltdLCJyZWNvbW1lbmRhdGlvbnMiOnsiaW5uZXJUcmFuc2FjdGlvbkNvdW50IjpudWxsLCJib3hlcyI6bnVsbCwiYWNjb3VudHMiOm51bGwsImFwcHMiOm51bGwsImFzc2V0cyI6bnVsbH19LHsibmFtZSI6ImFyYzIwMF90b3RhbFN1cHBseSIsImRlc2MiOiJSZXR1cm5zIHRoZSB0b3RhbCBzdXBwbHkgb2YgdGhlIHRva2VuIiwiYXJncyI6W10sInJldHVybnMiOnsidHlwZSI6InVpbnQyNTYiLCJzdHJ1Y3QiOm51bGwsImRlc2MiOiJUaGUgdG90YWwgc3VwcGx5IG9mIHRoZSB0b2tlbiJ9LCJhY3Rpb25zIjp7ImNyZWF0ZSI6W10sImNhbGwiOlsiTm9PcCJdfSwicmVhZG9ubHkiOnRydWUsImV2ZW50cyI6W10sInJlY29tbWVuZGF0aW9ucyI6eyJpbm5lclRyYW5zYWN0aW9uQ291bnQiOm51bGwsImJveGVzIjpudWxsLCJhY2NvdW50cyI6bnVsbCwiYXBwcyI6bnVsbCwiYXNzZXRzIjpudWxsfX0seyJuYW1lIjoiYXJjMjAwX2JhbGFuY2VPZiIsImRlc2MiOiJSZXR1cm5zIHRoZSBjdXJyZW50IGJhbGFuY2Ugb2YgdGhlIG93bmVyIG9mIHRoZSB0b2tlbiIsImFyZ3MiOlt7InR5cGUiOiJhZGRyZXNzIiwic3RydWN0IjpudWxsLCJuYW1lIjoib3duZXIiLCJkZXNjIjoiVGhlIGFkZHJlc3Mgb2YgdGhlIG93bmVyIG9mIHRoZSB0b2tlbiIsImRlZmF1bHRWYWx1ZSI6bnVsbH1dLCJyZXR1cm5zIjp7InR5cGUiOiJ1aW50MjU2Iiwic3RydWN0IjpudWxsLCJkZXNjIjoiVGhlIGN1cnJlbnQgYmFsYW5jZSBvZiB0aGUgaG9sZGVyIG9mIHRoZSB0b2tlbiJ9LCJhY3Rpb25zIjp7ImNyZWF0ZSI6W10sImNhbGwiOlsiTm9PcCJdfSwicmVhZG9ubHkiOnRydWUsImV2ZW50cyI6W10sInJlY29tbWVuZGF0aW9ucyI6eyJpbm5lclRyYW5zYWN0aW9uQ291bnQiOm51bGwsImJveGVzIjpudWxsLCJhY2NvdW50cyI6bnVsbCwiYXBwcyI6bnVsbCwiYXNzZXRzIjpudWxsfX0seyJuYW1lIjoiYXJjMjAwX3RyYW5zZmVyIiwiZGVzYyI6IlRyYW5zZmVycyB0b2tlbnMiLCJhcmdzIjpbeyJ0eXBlIjoiYWRkcmVzcyIsInN0cnVjdCI6bnVsbCwibmFtZSI6InRvIiwiZGVzYyI6IlRoZSBkZXN0aW5hdGlvbiBvZiB0aGUgdHJhbnNmZXIiLCJkZWZhdWx0VmFsdWUiOm51bGx9LHsidHlwZSI6InVpbnQyNTYiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJ2YWx1ZSIsImRlc2MiOiJBbW91bnQgb2YgdG9rZW5zIHRvIHRyYW5zZmVyIiwiZGVmYXVsdFZhbHVlIjpudWxsfV0sInJldHVybnMiOnsidHlwZSI6ImJvb2wiLCJzdHJ1Y3QiOm51bGwsImRlc2MiOiJTdWNjZXNzIn0sImFjdGlvbnMiOnsiY3JlYXRlIjpbXSwiY2FsbCI6WyJOb09wIl19LCJyZWFkb25seSI6ZmFsc2UsImV2ZW50cyI6W3sibmFtZSI6ImFyYzIwMF9UcmFuc2ZlciIsImRlc2MiOm51bGwsImFyZ3MiOlt7InR5cGUiOiJhZGRyZXNzIiwic3RydWN0IjpudWxsLCJuYW1lIjoiZnJvbSIsImRlc2MiOm51bGx9LHsidHlwZSI6ImFkZHJlc3MiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJ0byIsImRlc2MiOm51bGx9LHsidHlwZSI6InVpbnQyNTYiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJ2YWx1ZSIsImRlc2MiOm51bGx9XX1dLCJyZWNvbW1lbmRhdGlvbnMiOnsiaW5uZXJUcmFuc2FjdGlvbkNvdW50IjpudWxsLCJib3hlcyI6bnVsbCwiYWNjb3VudHMiOm51bGwsImFwcHMiOm51bGwsImFzc2V0cyI6bnVsbH19LHsibmFtZSI6ImFyYzIwMF90cmFuc2ZlckZyb20iLCJkZXNjIjoiVHJhbnNmZXJzIHRva2VucyBmcm9tIHNvdXJjZSB0byBkZXN0aW5hdGlvbiBhcyBhcHByb3ZlZCBzcGVuZGVyIiwiYXJncyI6W3sidHlwZSI6ImFkZHJlc3MiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJmcm9tIiwiZGVzYyI6IlRoZSBzb3VyY2Ugb2YgdGhlIHRyYW5zZmVyIiwiZGVmYXVsdFZhbHVlIjpudWxsfSx7InR5cGUiOiJhZGRyZXNzIiwic3RydWN0IjpudWxsLCJuYW1lIjoidG8iLCJkZXNjIjoiVGhlIGRlc3RpbmF0aW9uIG9mIHRoZSB0cmFuc2ZlciIsImRlZmF1bHRWYWx1ZSI6bnVsbH0seyJ0eXBlIjoidWludDI1NiIsInN0cnVjdCI6bnVsbCwibmFtZSI6InZhbHVlIiwiZGVzYyI6IkFtb3VudCBvZiB0b2tlbnMgdG8gdHJhbnNmZXIiLCJkZWZhdWx0VmFsdWUiOm51bGx9XSwicmV0dXJucyI6eyJ0eXBlIjoiYm9vbCIsInN0cnVjdCI6bnVsbCwiZGVzYyI6IlN1Y2Nlc3MifSwiYWN0aW9ucyI6eyJjcmVhdGUiOltdLCJjYWxsIjpbIk5vT3AiXX0sInJlYWRvbmx5IjpmYWxzZSwiZXZlbnRzIjpbeyJuYW1lIjoiYXJjMjAwX0FwcHJvdmFsIiwiZGVzYyI6bnVsbCwiYXJncyI6W3sidHlwZSI6ImFkZHJlc3MiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJvd25lciIsImRlc2MiOm51bGx9LHsidHlwZSI6ImFkZHJlc3MiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJzcGVuZGVyIiwiZGVzYyI6bnVsbH0seyJ0eXBlIjoidWludDI1NiIsInN0cnVjdCI6bnVsbCwibmFtZSI6InZhbHVlIiwiZGVzYyI6bnVsbH1dfSx7Im5hbWUiOiJhcmMyMDBfVHJhbnNmZXIiLCJkZXNjIjpudWxsLCJhcmdzIjpbeyJ0eXBlIjoiYWRkcmVzcyIsInN0cnVjdCI6bnVsbCwibmFtZSI6ImZyb20iLCJkZXNjIjpudWxsfSx7InR5cGUiOiJhZGRyZXNzIiwic3RydWN0IjpudWxsLCJuYW1lIjoidG8iLCJkZXNjIjpudWxsfSx7InR5cGUiOiJ1aW50MjU2Iiwic3RydWN0IjpudWxsLCJuYW1lIjoidmFsdWUiLCJkZXNjIjpudWxsfV19XSwicmVjb21tZW5kYXRpb25zIjp7ImlubmVyVHJhbnNhY3Rpb25Db3VudCI6bnVsbCwiYm94ZXMiOm51bGwsImFjY291bnRzIjpudWxsLCJhcHBzIjpudWxsLCJhc3NldHMiOm51bGx9fSx7Im5hbWUiOiJhcmMyMDBfYXBwcm92ZSIsImRlc2MiOiJBcHByb3ZlIHNwZW5kZXIgZm9yIGEgdG9rZW4iLCJhcmdzIjpbeyJ0eXBlIjoiYWRkcmVzcyIsInN0cnVjdCI6bnVsbCwibmFtZSI6InNwZW5kZXIiLCJkZXNjIjoiV2hvIGlzIGFsbG93ZWQgdG8gdGFrZSB0b2tlbnMgb24gb3duZXIncyBiZWhhbGYiLCJkZWZhdWx0VmFsdWUiOm51bGx9LHsidHlwZSI6InVpbnQyNTYiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJ2YWx1ZSIsImRlc2MiOiJBbW91bnQgb2YgdG9rZW5zIHRvIGJlIHRha2VuIGJ5IHNwZW5kZXIiLCJkZWZhdWx0VmFsdWUiOm51bGx9XSwicmV0dXJucyI6eyJ0eXBlIjoiYm9vbCIsInN0cnVjdCI6bnVsbCwiZGVzYyI6IlN1Y2Nlc3MifSwiYWN0aW9ucyI6eyJjcmVhdGUiOltdLCJjYWxsIjpbIk5vT3AiXX0sInJlYWRvbmx5IjpmYWxzZSwiZXZlbnRzIjpbeyJuYW1lIjoiYXJjMjAwX0FwcHJvdmFsIiwiZGVzYyI6bnVsbCwiYXJncyI6W3sidHlwZSI6ImFkZHJlc3MiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJvd25lciIsImRlc2MiOm51bGx9LHsidHlwZSI6ImFkZHJlc3MiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJzcGVuZGVyIiwiZGVzYyI6bnVsbH0seyJ0eXBlIjoidWludDI1NiIsInN0cnVjdCI6bnVsbCwibmFtZSI6InZhbHVlIiwiZGVzYyI6bnVsbH1dfV0sInJlY29tbWVuZGF0aW9ucyI6eyJpbm5lclRyYW5zYWN0aW9uQ291bnQiOm51bGwsImJveGVzIjpudWxsLCJhY2NvdW50cyI6bnVsbCwiYXBwcyI6bnVsbCwiYXNzZXRzIjpudWxsfX0seyJuYW1lIjoiYXJjMjAwX2FsbG93YW5jZSIsImRlc2MiOiJSZXR1cm5zIHRoZSBjdXJyZW50IGFsbG93YW5jZSBvZiB0aGUgc3BlbmRlciBvZiB0aGUgdG9rZW5zIG9mIHRoZSBvd25lciIsImFyZ3MiOlt7InR5cGUiOiJhZGRyZXNzIiwic3RydWN0IjpudWxsLCJuYW1lIjoib3duZXIiLCJkZXNjIjoiT3duZXIncyBhY2NvdW50IiwiZGVmYXVsdFZhbHVlIjpudWxsfSx7InR5cGUiOiJhZGRyZXNzIiwic3RydWN0IjpudWxsLCJuYW1lIjoic3BlbmRlciIsImRlc2MiOiJXaG8gaXMgYWxsb3dlZCB0byB0YWtlIHRva2VucyBvbiBvd25lcidzIGJlaGFsZiIsImRlZmF1bHRWYWx1ZSI6bnVsbH1dLCJyZXR1cm5zIjp7InR5cGUiOiJ1aW50MjU2Iiwic3RydWN0IjpudWxsLCJkZXNjIjoiVGhlIHJlbWFpbmluZyBhbGxvd2FuY2UifSwiYWN0aW9ucyI6eyJjcmVhdGUiOltdLCJjYWxsIjpbIk5vT3AiXX0sInJlYWRvbmx5Ijp0cnVlLCJldmVudHMiOltdLCJyZWNvbW1lbmRhdGlvbnMiOnsiaW5uZXJUcmFuc2FjdGlvbkNvdW50IjpudWxsLCJib3hlcyI6bnVsbCwiYWNjb3VudHMiOm51bGwsImFwcHMiOm51bGwsImFzc2V0cyI6bnVsbH19XSwic3RhdGUiOnsic2NoZW1hIjp7Imdsb2JhbCI6eyJpbnRzIjowLCJieXRlcyI6NH0sImxvY2FsIjp7ImludHMiOjAsImJ5dGVzIjowfX0sImtleXMiOnsiZ2xvYmFsIjp7ImRlc2MiOm51bGwsImtleVR5cGUiOiIiLCJ2YWx1ZVR5cGUiOiIiLCJrZXkiOiIifSwibG9jYWwiOnsiZGVzYyI6bnVsbCwia2V5VHlwZSI6IiIsInZhbHVlVHlwZSI6IiIsImtleSI6IiJ9LCJib3giOnsiZGVzYyI6bnVsbCwia2V5VHlwZSI6IiIsInZhbHVlVHlwZSI6IiIsImtleSI6IiJ9fSwibWFwcyI6eyJnbG9iYWwiOnsiZGVzYyI6bnVsbCwia2V5VHlwZSI6IiIsInZhbHVlVHlwZSI6IiIsInByZWZpeCI6bnVsbH0sImxvY2FsIjp7ImRlc2MiOm51bGwsImtleVR5cGUiOiIiLCJ2YWx1ZVR5cGUiOiIiLCJwcmVmaXgiOm51bGx9LCJib3giOnsiZGVzYyI6bnVsbCwia2V5VHlwZSI6IiIsInZhbHVlVHlwZSI6IiIsInByZWZpeCI6bnVsbH19fSwiYmFyZUFjdGlvbnMiOnsiY3JlYXRlIjpbIk5vT3AiXSwiY2FsbCI6W119LCJzb3VyY2VJbmZvIjp7ImFwcHJvdmFsIjp7InNvdXJjZUluZm8iOlt7InBjIjpbNTkzLDcyM10sImVycm9yTWVzc2FnZSI6IkJveCBtdXN0IGhhdmUgdmFsdWUiLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOls3MjRdLCJlcnJvck1lc3NhZ2UiOiJJbmRleCBhY2Nlc3MgaXMgb3V0IG9mIGJvdW5kcyIsInRlYWwiOm51bGwsInNvdXJjZSI6bnVsbH0seyJwYyI6WzYxNF0sImVycm9yTWVzc2FnZSI6Ikluc3VmZmljaWVudCBiYWxhbmNlIGF0IHRoZSBzZW5kZXIgYWNjb3VudCIsInRlYWwiOm51bGwsInNvdXJjZSI6bnVsbH0seyJwYyI6WzM3MV0sImVycm9yTWVzc2FnZSI6Ik5hbWUgb2YgdGhlIGFzc2V0IG11c3QgYmUgbG9uZ2VyIG9yIGVxdWFsIHRvIDEgY2hhcmFjdGVyIiwidGVhbCI6bnVsbCwic291cmNlIjpudWxsfSx7InBjIjpbMzc0XSwiZXJyb3JNZXNzYWdlIjoiTmFtZSBvZiB0aGUgYXNzZXQgbXVzdCBiZSBzaG9ydGVyIG9yIGVxdWFsIHRvIDMyIGNoYXJhY3RlcnMiLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOlsxNDUsMTY3LDE4OSwyMTQsMjM2LDI1NSwyNzEsMjg3LDMwMywzMTldLCJlcnJvck1lc3NhZ2UiOiJPbkNvbXBsZXRpb24gaXMgbm90IE5vT3AiLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOlszNjNdLCJlcnJvck1lc3NhZ2UiOiJPbmx5IGRlcGxveWVyIG9mIHRoaXMgc21hcnQgY29udHJhY3QgY2FuIGNhbGwgYm9vdHN0cmFwIG1ldGhvZCIsInRlYWwiOm51bGwsInNvdXJjZSI6bnVsbH0seyJwYyI6WzM4Ml0sImVycm9yTWVzc2FnZSI6IlN5bWJvbCBvZiB0aGUgYXNzZXQgbXVzdCBiZSBsb25nZXIgb3IgZXF1YWwgdG8gMSBjaGFyYWN0ZXIiLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOlszODVdLCJlcnJvck1lc3NhZ2UiOiJTeW1ib2wgb2YgdGhlIGFzc2V0IG11c3QgYmUgc2hvcnRlciBvciBlcXVhbCB0byA4IGNoYXJhY3RlcnMiLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOlszOTJdLCJlcnJvck1lc3NhZ2UiOiJUaGlzIG1ldGhvZCBjYW4gYmUgY2FsbGVkIG9ubHkgb25jZSIsInRlYWwiOm51bGwsInNvdXJjZSI6bnVsbH0seyJwYyI6WzM1Ml0sImVycm9yTWVzc2FnZSI6ImNhbiBvbmx5IGNhbGwgd2hlbiBjcmVhdGluZyIsInRlYWwiOm51bGwsInNvdXJjZSI6bnVsbH0seyJwYyI6WzE0OCwxNzAsMTkyLDIxNywyMzksMjU4LDI3NCwyOTAsMzA2LDMyMl0sImVycm9yTWVzc2FnZSI6ImNhbiBvbmx5IGNhbGwgd2hlbiBub3QgY3JlYXRpbmciLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOls0NDMsNDU4LDQ3Myw0NzhdLCJlcnJvck1lc3NhZ2UiOiJjaGVjayBHbG9iYWxTdGF0ZSBleGlzdHMiLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOls1MThdLCJlcnJvck1lc3NhZ2UiOiJpbnN1ZmZpY2llbnQgYXBwcm92YWwiLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9LHsicGMiOls0NTEsNDY2LDY5Ml0sImVycm9yTWVzc2FnZSI6ImludmFsaWQgc2l6ZSIsInRlYWwiOm51bGwsInNvdXJjZSI6bnVsbH0seyJwYyI6WzUyNiw2MzIsNjU0XSwiZXJyb3JNZXNzYWdlIjoib3ZlcmZsb3ciLCJ0ZWFsIjpudWxsLCJzb3VyY2UiOm51bGx9XSwicGNPZmZzZXRNZXRob2QiOiJub25lIn0sImNsZWFyIjp7InNvdXJjZUluZm8iOltdLCJwY09mZnNldE1ldGhvZCI6Im5vbmUifX0sInNvdXJjZSI6eyJhcHByb3ZhbCI6IkkzQnlZV2R0WVNCMlpYSnphVzl1SURFd0NpTndjbUZuYldFZ2RIbHdaWFJ5WVdOcklHWmhiSE5sQ2dvdkx5QkFZV3huYjNKaGJtUm1iM1Z1WkdGMGFXOXVMMkZzWjI5eVlXNWtMWFI1Y0dWelkzSnBjSFF2WVhKak5DOXBibVJsZUM1a0xuUnpPanBEYjI1MGNtRmpkQzVoY0hCeWIzWmhiRkJ5YjJkeVlXMG9LU0F0UGlCMWFXNTBOalE2Q20xaGFXNDZDaUFnSUNCcGJuUmpZbXh2WTJzZ01TQXpNaUF3SURnS0lDQWdJR0o1ZEdWallteHZZMnNnTUhneE5URm1OMk0zTlNBaVlpSWdJblFpSURCNE9EQWdNSGczT1Rnell6TTFZeUF3ZURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem8wTkFvZ0lDQWdMeThnWlhod2IzSjBJR05zWVhOeklFRnlZekl3TUNCbGVIUmxibVJ6SUVOdmJuUnlZV04wSUhzS0lDQWdJSFI0YmlCT2RXMUJjSEJCY21kekNpQWdJQ0JpZWlCdFlXbHVYMkpoY21WZmNtOTFkR2x1WjBBeE5Rb2dJQ0FnY0hWemFHSjVkR1Z6Y3lBd2VEazNOVE00TW1VeUlEQjROalUzWkRFelpXTWdNSGhpTm1GbE1XRXlOU0F3ZURnMFpXTXhNMlExSURCNFpXTTVPVFl3TkRFZ01IZzRNbVUxTnpOak5DQXdlR1JoTnpBeU5XSTVJREI0TkdFNU5qaG1PR1lnTUhoaU5UUXlNakV5TlNBd2VHSmlZak14T1dZeklDOHZJRzFsZEdodlpDQWlZbTl2ZEhOMGNtRndLR0o1ZEdWYlhTeGllWFJsVzEwc2RXbHVkRGdzZFdsdWRESTFOaWxpYjI5c0lpd2diV1YwYUc5a0lDSmhjbU15TURCZmJtRnRaU2dwWW5sMFpWc3pNbDBpTENCdFpYUm9iMlFnSW1GeVl6SXdNRjl6ZVcxaWIyd29LV0o1ZEdWYk9GMGlMQ0J0WlhSb2IyUWdJbUZ5WXpJd01GOWtaV05wYldGc2N5Z3BkV2x1ZERnaUxDQnRaWFJvYjJRZ0ltRnlZekl3TUY5MGIzUmhiRk4xY0hCc2VTZ3BkV2x1ZERJMU5pSXNJRzFsZEdodlpDQWlZWEpqTWpBd1gySmhiR0Z1WTJWUFppaGhaR1J5WlhOektYVnBiblF5TlRZaUxDQnRaWFJvYjJRZ0ltRnlZekl3TUY5MGNtRnVjMlpsY2loaFpHUnlaWE56TEhWcGJuUXlOVFlwWW05dmJDSXNJRzFsZEdodlpDQWlZWEpqTWpBd1gzUnlZVzV6Wm1WeVJuSnZiU2hoWkdSeVpYTnpMR0ZrWkhKbGMzTXNkV2x1ZERJMU5pbGliMjlzSWl3Z2JXVjBhRzlrSUNKaGNtTXlNREJmWVhCd2NtOTJaU2hoWkdSeVpYTnpMSFZwYm5ReU5UWXBZbTl2YkNJc0lHMWxkR2h2WkNBaVlYSmpNakF3WDJGc2JHOTNZVzVqWlNoaFpHUnlaWE56TEdGa1pISmxjM01wZFdsdWRESTFOaUlLSUNBZ0lIUjRibUVnUVhCd2JHbGpZWFJwYjI1QmNtZHpJREFLSUNBZ0lHMWhkR05vSUcxaGFXNWZZbTl2ZEhOMGNtRndYM0p2ZFhSbFFETWdiV0ZwYmw5aGNtTXlNREJmYm1GdFpWOXliM1YwWlVBMElHMWhhVzVmWVhKak1qQXdYM041YldKdmJGOXliM1YwWlVBMUlHMWhhVzVmWVhKak1qQXdYMlJsWTJsdFlXeHpYM0p2ZFhSbFFEWWdiV0ZwYmw5aGNtTXlNREJmZEc5MFlXeFRkWEJ3YkhsZmNtOTFkR1ZBTnlCdFlXbHVYMkZ5WXpJd01GOWlZV3hoYm1ObFQyWmZjbTkxZEdWQU9DQnRZV2x1WDJGeVl6SXdNRjkwY21GdWMyWmxjbDl5YjNWMFpVQTVJRzFoYVc1ZllYSmpNakF3WDNSeVlXNXpabVZ5Um5KdmJWOXliM1YwWlVBeE1DQnRZV2x1WDJGeVl6SXdNRjloY0hCeWIzWmxYM0p2ZFhSbFFERXhJRzFoYVc1ZllYSmpNakF3WDJGc2JHOTNZVzVqWlY5eWIzVjBaVUF4TWdvS2JXRnBibDloWm5SbGNsOXBabDlsYkhObFFERTVPZ29nSUNBZ0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qUTBDaUFnSUNBdkx5QmxlSEJ2Y25RZ1kyeGhjM01nUVhKak1qQXdJR1Y0ZEdWdVpITWdRMjl1ZEhKaFkzUWdld29nSUNBZ2FXNTBZMTh5SUM4dklEQUtJQ0FnSUhKbGRIVnliZ29LYldGcGJsOWhjbU15TURCZllXeHNiM2RoYm1ObFgzSnZkWFJsUURFeU9nb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pFNE5nb2dJQ0FnTHk4Z1FHRnlZelF1WVdKcGJXVjBhRzlrS0hzZ2NtVmhaRzl1YkhrNklIUnlkV1VnZlNrS0lDQWdJSFI0YmlCUGJrTnZiWEJzWlhScGIyNEtJQ0FnSUNFS0lDQWdJR0Z6YzJWeWRDQXZMeUJQYmtOdmJYQnNaWFJwYjI0Z2FYTWdibTkwSUU1dlQzQUtJQ0FnSUhSNGJpQkJjSEJzYVdOaGRHbHZia2xFQ2lBZ0lDQmhjM05sY25RZ0x5OGdZMkZ1SUc5dWJIa2dZMkZzYkNCM2FHVnVJRzV2ZENCamNtVmhkR2x1WndvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPalEwQ2lBZ0lDQXZMeUJsZUhCdmNuUWdZMnhoYzNNZ1FYSmpNakF3SUdWNGRHVnVaSE1nUTI5dWRISmhZM1FnZXdvZ0lDQWdkSGh1WVNCQmNIQnNhV05oZEdsdmJrRnlaM01nTVFvZ0lDQWdkSGh1WVNCQmNIQnNhV05oZEdsdmJrRnlaM01nTWdvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakU0TmdvZ0lDQWdMeThnUUdGeVl6UXVZV0pwYldWMGFHOWtLSHNnY21WaFpHOXViSGs2SUhSeWRXVWdmU2tLSUNBZ0lHTmhiR3h6ZFdJZ1lYSmpNakF3WDJGc2JHOTNZVzVqWlFvZ0lDQWdZbmwwWldOZk1DQXZMeUF3ZURFMU1XWTNZemMxQ2lBZ0lDQnpkMkZ3Q2lBZ0lDQmpiMjVqWVhRS0lDQWdJR3h2WndvZ0lDQWdhVzUwWTE4d0lDOHZJREVLSUNBZ0lISmxkSFZ5YmdvS2JXRnBibDloY21NeU1EQmZZWEJ3Y205MlpWOXliM1YwWlVBeE1Ub0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE56UUtJQ0FnSUM4dklFQmhjbU0wTG1GaWFXMWxkR2h2WkNncENpQWdJQ0IwZUc0Z1QyNURiMjF3YkdWMGFXOXVDaUFnSUNBaENpQWdJQ0JoYzNObGNuUWdMeThnVDI1RGIyMXdiR1YwYVc5dUlHbHpJRzV2ZENCT2IwOXdDaUFnSUNCMGVHNGdRWEJ3YkdsallYUnBiMjVKUkFvZ0lDQWdZWE56WlhKMElDOHZJR05oYmlCdmJteDVJR05oYkd3Z2QyaGxiaUJ1YjNRZ1kzSmxZWFJwYm1jS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem8wTkFvZ0lDQWdMeThnWlhod2IzSjBJR05zWVhOeklFRnlZekl3TUNCbGVIUmxibVJ6SUVOdmJuUnlZV04wSUhzS0lDQWdJSFI0Ym1FZ1FYQndiR2xqWVhScGIyNUJjbWR6SURFS0lDQWdJSFI0Ym1FZ1FYQndiR2xqWVhScGIyNUJjbWR6SURJS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem94TnpRS0lDQWdJQzh2SUVCaGNtTTBMbUZpYVcxbGRHaHZaQ2dwQ2lBZ0lDQmpZV3hzYzNWaUlHRnlZekl3TUY5aGNIQnliM1psQ2lBZ0lDQmllWFJsWTE4d0lDOHZJREI0TVRVeFpqZGpOelVLSUNBZ0lITjNZWEFLSUNBZ0lHTnZibU5oZEFvZ0lDQWdiRzluQ2lBZ0lDQnBiblJqWHpBZ0x5OGdNUW9nSUNBZ2NtVjBkWEp1Q2dwdFlXbHVYMkZ5WXpJd01GOTBjbUZ1YzJabGNrWnliMjFmY205MWRHVkFNVEE2Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZNVFUzQ2lBZ0lDQXZMeUJBWVhKak5DNWhZbWx0WlhSb2IyUW9LUW9nSUNBZ2RIaHVJRTl1UTI5dGNHeGxkR2x2YmdvZ0lDQWdJUW9nSUNBZ1lYTnpaWEowSUM4dklFOXVRMjl0Y0d4bGRHbHZiaUJwY3lCdWIzUWdUbTlQY0FvZ0lDQWdkSGh1SUVGd2NHeHBZMkYwYVc5dVNVUUtJQ0FnSUdGemMyVnlkQ0F2THlCallXNGdiMjVzZVNCallXeHNJSGRvWlc0Z2JtOTBJR055WldGMGFXNW5DaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk5EUUtJQ0FnSUM4dklHVjRjRzl5ZENCamJHRnpjeUJCY21NeU1EQWdaWGgwWlc1a2N5QkRiMjUwY21GamRDQjdDaUFnSUNCMGVHNWhJRUZ3Y0d4cFkyRjBhVzl1UVhKbmN5QXhDaUFnSUNCMGVHNWhJRUZ3Y0d4cFkyRjBhVzl1UVhKbmN5QXlDaUFnSUNCMGVHNWhJRUZ3Y0d4cFkyRjBhVzl1UVhKbmN5QXpDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk1UVTNDaUFnSUNBdkx5QkFZWEpqTkM1aFltbHRaWFJvYjJRb0tRb2dJQ0FnWTJGc2JITjFZaUJoY21NeU1EQmZkSEpoYm5ObVpYSkdjbTl0Q2lBZ0lDQmllWFJsWTE4d0lDOHZJREI0TVRVeFpqZGpOelVLSUNBZ0lITjNZWEFLSUNBZ0lHTnZibU5oZEFvZ0lDQWdiRzluQ2lBZ0lDQnBiblJqWHpBZ0x5OGdNUW9nSUNBZ2NtVjBkWEp1Q2dwdFlXbHVYMkZ5WXpJd01GOTBjbUZ1YzJabGNsOXliM1YwWlVBNU9nb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pFME5Bb2dJQ0FnTHk4Z1FHRnlZelF1WVdKcGJXVjBhRzlrS0NrS0lDQWdJSFI0YmlCUGJrTnZiWEJzWlhScGIyNEtJQ0FnSUNFS0lDQWdJR0Z6YzJWeWRDQXZMeUJQYmtOdmJYQnNaWFJwYjI0Z2FYTWdibTkwSUU1dlQzQUtJQ0FnSUhSNGJpQkJjSEJzYVdOaGRHbHZia2xFQ2lBZ0lDQmhjM05sY25RZ0x5OGdZMkZ1SUc5dWJIa2dZMkZzYkNCM2FHVnVJRzV2ZENCamNtVmhkR2x1WndvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPalEwQ2lBZ0lDQXZMeUJsZUhCdmNuUWdZMnhoYzNNZ1FYSmpNakF3SUdWNGRHVnVaSE1nUTI5dWRISmhZM1FnZXdvZ0lDQWdkSGh1WVNCQmNIQnNhV05oZEdsdmJrRnlaM01nTVFvZ0lDQWdkSGh1WVNCQmNIQnNhV05oZEdsdmJrRnlaM01nTWdvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakUwTkFvZ0lDQWdMeThnUUdGeVl6UXVZV0pwYldWMGFHOWtLQ2tLSUNBZ0lHTmhiR3h6ZFdJZ1lYSmpNakF3WDNSeVlXNXpabVZ5Q2lBZ0lDQmllWFJsWTE4d0lDOHZJREI0TVRVeFpqZGpOelVLSUNBZ0lITjNZWEFLSUNBZ0lHTnZibU5oZEFvZ0lDQWdiRzluQ2lBZ0lDQnBiblJqWHpBZ0x5OGdNUW9nSUNBZ2NtVjBkWEp1Q2dwdFlXbHVYMkZ5WXpJd01GOWlZV3hoYm1ObFQyWmZjbTkxZEdWQU9Eb0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE16SUtJQ0FnSUM4dklFQmhjbU0wTG1GaWFXMWxkR2h2WkNoN0lISmxZV1J2Ym14NU9pQjBjblZsSUgwcENpQWdJQ0IwZUc0Z1QyNURiMjF3YkdWMGFXOXVDaUFnSUNBaENpQWdJQ0JoYzNObGNuUWdMeThnVDI1RGIyMXdiR1YwYVc5dUlHbHpJRzV2ZENCT2IwOXdDaUFnSUNCMGVHNGdRWEJ3YkdsallYUnBiMjVKUkFvZ0lDQWdZWE56WlhKMElDOHZJR05oYmlCdmJteDVJR05oYkd3Z2QyaGxiaUJ1YjNRZ1kzSmxZWFJwYm1jS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem8wTkFvZ0lDQWdMeThnWlhod2IzSjBJR05zWVhOeklFRnlZekl3TUNCbGVIUmxibVJ6SUVOdmJuUnlZV04wSUhzS0lDQWdJSFI0Ym1FZ1FYQndiR2xqWVhScGIyNUJjbWR6SURFS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem94TXpJS0lDQWdJQzh2SUVCaGNtTTBMbUZpYVcxbGRHaHZaQ2g3SUhKbFlXUnZibXg1T2lCMGNuVmxJSDBwQ2lBZ0lDQmpZV3hzYzNWaUlHRnlZekl3TUY5aVlXeGhibU5sVDJZS0lDQWdJR0o1ZEdWalh6QWdMeThnTUhneE5URm1OMk0zTlFvZ0lDQWdjM2RoY0FvZ0lDQWdZMjl1WTJGMENpQWdJQ0JzYjJjS0lDQWdJR2x1ZEdOZk1DQXZMeUF4Q2lBZ0lDQnlaWFIxY200S0NtMWhhVzVmWVhKak1qQXdYM1J2ZEdGc1UzVndjR3g1WDNKdmRYUmxRRGM2Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZNVEl4Q2lBZ0lDQXZMeUJBWVhKak5DNWhZbWx0WlhSb2IyUW9leUJ5WldGa2IyNXNlVG9nZEhKMVpTQjlLUW9nSUNBZ2RIaHVJRTl1UTI5dGNHeGxkR2x2YmdvZ0lDQWdJUW9nSUNBZ1lYTnpaWEowSUM4dklFOXVRMjl0Y0d4bGRHbHZiaUJwY3lCdWIzUWdUbTlQY0FvZ0lDQWdkSGh1SUVGd2NHeHBZMkYwYVc5dVNVUUtJQ0FnSUdGemMyVnlkQ0F2THlCallXNGdiMjVzZVNCallXeHNJSGRvWlc0Z2JtOTBJR055WldGMGFXNW5DaUFnSUNCallXeHNjM1ZpSUdGeVl6SXdNRjkwYjNSaGJGTjFjSEJzZVFvZ0lDQWdZbmwwWldOZk1DQXZMeUF3ZURFMU1XWTNZemMxQ2lBZ0lDQnpkMkZ3Q2lBZ0lDQmpiMjVqWVhRS0lDQWdJR3h2WndvZ0lDQWdhVzUwWTE4d0lDOHZJREVLSUNBZ0lISmxkSFZ5YmdvS2JXRnBibDloY21NeU1EQmZaR1ZqYVcxaGJITmZjbTkxZEdWQU5qb0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE1URUtJQ0FnSUM4dklFQmhjbU0wTG1GaWFXMWxkR2h2WkNoN0lISmxZV1J2Ym14NU9pQjBjblZsSUgwcENpQWdJQ0IwZUc0Z1QyNURiMjF3YkdWMGFXOXVDaUFnSUNBaENpQWdJQ0JoYzNObGNuUWdMeThnVDI1RGIyMXdiR1YwYVc5dUlHbHpJRzV2ZENCT2IwOXdDaUFnSUNCMGVHNGdRWEJ3YkdsallYUnBiMjVKUkFvZ0lDQWdZWE56WlhKMElDOHZJR05oYmlCdmJteDVJR05oYkd3Z2QyaGxiaUJ1YjNRZ1kzSmxZWFJwYm1jS0lDQWdJR05oYkd4emRXSWdZWEpqTWpBd1gyUmxZMmx0WVd4ekNpQWdJQ0JpZVhSbFkxOHdJQzh2SURCNE1UVXhaamRqTnpVS0lDQWdJSE4zWVhBS0lDQWdJR052Ym1OaGRBb2dJQ0FnYkc5bkNpQWdJQ0JwYm5Salh6QWdMeThnTVFvZ0lDQWdjbVYwZFhKdUNncHRZV2x1WDJGeVl6SXdNRjl6ZVcxaWIyeGZjbTkxZEdWQU5Ub0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE1ERUtJQ0FnSUM4dklFQmhjbU0wTG1GaWFXMWxkR2h2WkNoN0lISmxZV1J2Ym14NU9pQjBjblZsSUgwcENpQWdJQ0IwZUc0Z1QyNURiMjF3YkdWMGFXOXVDaUFnSUNBaENpQWdJQ0JoYzNObGNuUWdMeThnVDI1RGIyMXdiR1YwYVc5dUlHbHpJRzV2ZENCT2IwOXdDaUFnSUNCMGVHNGdRWEJ3YkdsallYUnBiMjVKUkFvZ0lDQWdZWE56WlhKMElDOHZJR05oYmlCdmJteDVJR05oYkd3Z2QyaGxiaUJ1YjNRZ1kzSmxZWFJwYm1jS0lDQWdJR05oYkd4emRXSWdZWEpqTWpBd1gzTjViV0p2YkFvZ0lDQWdZbmwwWldOZk1DQXZMeUF3ZURFMU1XWTNZemMxQ2lBZ0lDQnpkMkZ3Q2lBZ0lDQmpiMjVqWVhRS0lDQWdJR3h2WndvZ0lDQWdhVzUwWTE4d0lDOHZJREVLSUNBZ0lISmxkSFZ5YmdvS2JXRnBibDloY21NeU1EQmZibUZ0WlY5eWIzVjBaVUEwT2dvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPamt4Q2lBZ0lDQXZMeUJBWVhKak5DNWhZbWx0WlhSb2IyUW9leUJ5WldGa2IyNXNlVG9nZEhKMVpTQjlLUW9nSUNBZ2RIaHVJRTl1UTI5dGNHeGxkR2x2YmdvZ0lDQWdJUW9nSUNBZ1lYTnpaWEowSUM4dklFOXVRMjl0Y0d4bGRHbHZiaUJwY3lCdWIzUWdUbTlQY0FvZ0lDQWdkSGh1SUVGd2NHeHBZMkYwYVc5dVNVUUtJQ0FnSUdGemMyVnlkQ0F2THlCallXNGdiMjVzZVNCallXeHNJSGRvWlc0Z2JtOTBJR055WldGMGFXNW5DaUFnSUNCallXeHNjM1ZpSUdGeVl6SXdNRjl1WVcxbENpQWdJQ0JpZVhSbFkxOHdJQzh2SURCNE1UVXhaamRqTnpVS0lDQWdJSE4zWVhBS0lDQWdJR052Ym1OaGRBb2dJQ0FnYkc5bkNpQWdJQ0JwYm5Salh6QWdMeThnTVFvZ0lDQWdjbVYwZFhKdUNncHRZV2x1WDJKdmIzUnpkSEpoY0Y5eWIzVjBaVUF6T2dvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPalkxQ2lBZ0lDQXZMeUJBWVhKak5DNWhZbWx0WlhSb2IyUW9LUW9nSUNBZ2RIaHVJRTl1UTI5dGNHeGxkR2x2YmdvZ0lDQWdJUW9nSUNBZ1lYTnpaWEowSUM4dklFOXVRMjl0Y0d4bGRHbHZiaUJwY3lCdWIzUWdUbTlQY0FvZ0lDQWdkSGh1SUVGd2NHeHBZMkYwYVc5dVNVUUtJQ0FnSUdGemMyVnlkQ0F2THlCallXNGdiMjVzZVNCallXeHNJSGRvWlc0Z2JtOTBJR055WldGMGFXNW5DaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk5EUUtJQ0FnSUM4dklHVjRjRzl5ZENCamJHRnpjeUJCY21NeU1EQWdaWGgwWlc1a2N5QkRiMjUwY21GamRDQjdDaUFnSUNCMGVHNWhJRUZ3Y0d4cFkyRjBhVzl1UVhKbmN5QXhDaUFnSUNCMGVHNWhJRUZ3Y0d4cFkyRjBhVzl1UVhKbmN5QXlDaUFnSUNCMGVHNWhJRUZ3Y0d4cFkyRjBhVzl1UVhKbmN5QXpDaUFnSUNCMGVHNWhJRUZ3Y0d4cFkyRjBhVzl1UVhKbmN5QTBDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk5qVUtJQ0FnSUM4dklFQmhjbU0wTG1GaWFXMWxkR2h2WkNncENpQWdJQ0JqWVd4c2MzVmlJR0p2YjNSemRISmhjQW9nSUNBZ1lubDBaV05mTUNBdkx5QXdlREUxTVdZM1l6YzFDaUFnSUNCemQyRndDaUFnSUNCamIyNWpZWFFLSUNBZ0lHeHZad29nSUNBZ2FXNTBZMTh3SUM4dklERUtJQ0FnSUhKbGRIVnliZ29LYldGcGJsOWlZWEpsWDNKdmRYUnBibWRBTVRVNkNpQWdJQ0F2THlCamIyNTBjbUZqZEhNdllYSmpNakF3TG1Gc1oyOHVkSE02TkRRS0lDQWdJQzh2SUdWNGNHOXlkQ0JqYkdGemN5QkJjbU15TURBZ1pYaDBaVzVrY3lCRGIyNTBjbUZqZENCN0NpQWdJQ0IwZUc0Z1QyNURiMjF3YkdWMGFXOXVDaUFnSUNCaWJub2diV0ZwYmw5aFpuUmxjbDlwWmw5bGJITmxRREU1Q2lBZ0lDQjBlRzRnUVhCd2JHbGpZWFJwYjI1SlJBb2dJQ0FnSVFvZ0lDQWdZWE56WlhKMElDOHZJR05oYmlCdmJteDVJR05oYkd3Z2QyaGxiaUJqY21WaGRHbHVad29nSUNBZ2FXNTBZMTh3SUM4dklERUtJQ0FnSUhKbGRIVnliZ29LQ2k4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pvNlFYSmpNakF3TG1KdmIzUnpkSEpoY0NodVlXMWxPaUJpZVhSbGN5d2djM2x0WW05c09pQmllWFJsY3l3Z1pHVmphVzFoYkhNNklHSjVkR1Z6TENCMGIzUmhiRk4xY0hCc2VUb2dZbmwwWlhNcElDMCtJR0o1ZEdWek9ncGliMjkwYzNSeVlYQTZDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk5qVXROallLSUNBZ0lDOHZJRUJoY21NMExtRmlhVzFsZEdodlpDZ3BDaUFnSUNBdkx5QndkV0pzYVdNZ1ltOXZkSE4wY21Gd0tHNWhiV1U2SUVSNWJtRnRhV05DZVhSbGN5d2djM2x0WW05c09pQkVlVzVoYldsalFubDBaWE1zSUdSbFkybHRZV3h6T2lCVmFXNTBUamdzSUhSdmRHRnNVM1Z3Y0d4NU9pQlZhVzUwVGpJMU5pazZJRUp2YjJ3Z2V3b2dJQ0FnY0hKdmRHOGdOQ0F4Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZOamNLSUNBZ0lDOHZJR0Z6YzJWeWRDaFVlRzR1YzJWdVpHVnlJRDA5UFNCSGJHOWlZV3d1WTNKbFlYUnZja0ZrWkhKbGMzTXNJQ2RQYm14NUlHUmxjR3h2ZVdWeUlHOW1JSFJvYVhNZ2MyMWhjblFnWTI5dWRISmhZM1FnWTJGdUlHTmhiR3dnWW05dmRITjBjbUZ3SUcxbGRHaHZaQ2NwT3dvZ0lDQWdkSGh1SUZObGJtUmxjZ29nSUNBZ1oyeHZZbUZzSUVOeVpXRjBiM0pCWkdSeVpYTnpDaUFnSUNBOVBRb2dJQ0FnWVhOelpYSjBJQzh2SUU5dWJIa2daR1Z3Ykc5NVpYSWdiMllnZEdocGN5QnpiV0Z5ZENCamIyNTBjbUZqZENCallXNGdZMkZzYkNCaWIyOTBjM1J5WVhBZ2JXVjBhRzlrQ2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZOamdLSUNBZ0lDOHZJR0Z6YzJWeWRDaHVZVzFsTG01aGRHbDJaUzVzWlc1bmRHZ2dQaUF3TENBblRtRnRaU0J2WmlCMGFHVWdZWE56WlhRZ2JYVnpkQ0JpWlNCc2IyNW5aWElnYjNJZ1pYRjFZV3dnZEc4Z01TQmphR0Z5WVdOMFpYSW5LVHNLSUNBZ0lHWnlZVzFsWDJScFp5QXROQW9nSUNBZ1pYaDBjbUZqZENBeUlEQUtJQ0FnSUd4bGJnb2dJQ0FnWkhWd0NpQWdJQ0JoYzNObGNuUWdMeThnVG1GdFpTQnZaaUIwYUdVZ1lYTnpaWFFnYlhWemRDQmlaU0JzYjI1blpYSWdiM0lnWlhGMVlXd2dkRzhnTVNCamFHRnlZV04wWlhJS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem8yT1FvZ0lDQWdMeThnWVhOelpYSjBLRzVoYldVdWJtRjBhWFpsTG14bGJtZDBhQ0E4UFNBek1pd2dKMDVoYldVZ2IyWWdkR2hsSUdGemMyVjBJRzExYzNRZ1ltVWdjMmh2Y25SbGNpQnZjaUJsY1hWaGJDQjBieUF6TWlCamFHRnlZV04wWlhKekp5azdDaUFnSUNCcGJuUmpYekVnTHk4Z016SUtJQ0FnSUR3OUNpQWdJQ0JoYzNObGNuUWdMeThnVG1GdFpTQnZaaUIwYUdVZ1lYTnpaWFFnYlhWemRDQmlaU0J6YUc5eWRHVnlJRzl5SUdWeGRXRnNJSFJ2SURNeUlHTm9ZWEpoWTNSbGNuTUtJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pvM01Bb2dJQ0FnTHk4Z1lYTnpaWEowS0hONWJXSnZiQzV1WVhScGRtVXViR1Z1WjNSb0lENGdNQ3dnSjFONWJXSnZiQ0J2WmlCMGFHVWdZWE56WlhRZ2JYVnpkQ0JpWlNCc2IyNW5aWElnYjNJZ1pYRjFZV3dnZEc4Z01TQmphR0Z5WVdOMFpYSW5LVHNLSUNBZ0lHWnlZVzFsWDJScFp5QXRNd29nSUNBZ1pYaDBjbUZqZENBeUlEQUtJQ0FnSUd4bGJnb2dJQ0FnWkhWd0NpQWdJQ0JoYzNObGNuUWdMeThnVTNsdFltOXNJRzltSUhSb1pTQmhjM05sZENCdGRYTjBJR0psSUd4dmJtZGxjaUJ2Y2lCbGNYVmhiQ0IwYnlBeElHTm9ZWEpoWTNSbGNnb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pjeENpQWdJQ0F2THlCaGMzTmxjblFvYzNsdFltOXNMbTVoZEdsMlpTNXNaVzVuZEdnZ1BEMGdPQ3dnSjFONWJXSnZiQ0J2WmlCMGFHVWdZWE56WlhRZ2JYVnpkQ0JpWlNCemFHOXlkR1Z5SUc5eUlHVnhkV0ZzSUhSdklEZ2dZMmhoY21GamRHVnljeWNwT3dvZ0lDQWdhVzUwWTE4eklDOHZJRGdLSUNBZ0lEdzlDaUFnSUNCaGMzTmxjblFnTHk4Z1UzbHRZbTlzSUc5bUlIUm9aU0JoYzNObGRDQnRkWE4wSUdKbElITm9iM0owWlhJZ2IzSWdaWEYxWVd3Z2RHOGdPQ0JqYUdGeVlXTjBaWEp6Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZOakFLSUNBZ0lDOHZJSEIxWW14cFl5QjBiM1JoYkZOMWNIQnNlU0E5SUVkc2IySmhiRk4wWVhSbFBGVnBiblJPTWpVMlBpaDdJR3RsZVRvZ0ozUW5JSDBwT3dvZ0lDQWdhVzUwWTE4eUlDOHZJREFLSUNBZ0lHSjVkR1ZqWHpJZ0x5OGdJblFpQ2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZOeklLSUNBZ0lDOHZJR0Z6YzJWeWRDZ2hkR2hwY3k1MGIzUmhiRk4xY0hCc2VTNW9ZWE5XWVd4MVpTd2dKMVJvYVhNZ2JXVjBhRzlrSUdOaGJpQmlaU0JqWVd4c1pXUWdiMjVzZVNCdmJtTmxKeWs3Q2lBZ0lDQmhjSEJmWjJ4dlltRnNYMmRsZEY5bGVBb2dJQ0FnWW5WeWVTQXhDaUFnSUNBaENpQWdJQ0JoYzNObGNuUWdMeThnVkdocGN5QnRaWFJvYjJRZ1kyRnVJR0psSUdOaGJHeGxaQ0J2Ym14NUlHOXVZMlVLSUNBZ0lDOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6bzBPQW9nSUNBZ0x5OGdjSFZpYkdsaklHNWhiV1VnUFNCSGJHOWlZV3hUZEdGMFpUeEVlVzVoYldsalFubDBaWE0rS0hzZ2EyVjVPaUFuYmljZ2ZTazdDaUFnSUNCd2RYTm9ZbmwwWlhNZ0ltNGlDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk56UUtJQ0FnSUM4dklIUm9hWE11Ym1GdFpTNTJZV3gxWlNBOUlHNWhiV1U3Q2lBZ0lDQm1jbUZ0WlY5a2FXY2dMVFFLSUNBZ0lHRndjRjluYkc5aVlXeGZjSFYwQ2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZOVElLSUNBZ0lDOHZJSEIxWW14cFl5QnplVzFpYjJ3Z1BTQkhiRzlpWVd4VGRHRjBaVHhFZVc1aGJXbGpRbmwwWlhNK0tIc2dhMlY1T2lBbmN5Y2dmU2s3Q2lBZ0lDQndkWE5vWW5sMFpYTWdJbk1pQ2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZOelVLSUNBZ0lDOHZJSFJvYVhNdWMzbHRZbTlzTG5aaGJIVmxJRDBnYzNsdFltOXNPd29nSUNBZ1puSmhiV1ZmWkdsbklDMHpDaUFnSUNCaGNIQmZaMnh2WW1Gc1gzQjFkQW9nSUNBZ0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qWXdDaUFnSUNBdkx5QndkV0pzYVdNZ2RHOTBZV3hUZFhCd2JIa2dQU0JIYkc5aVlXeFRkR0YwWlR4VmFXNTBUakkxTmo0b2V5QnJaWGs2SUNkMEp5QjlLVHNLSUNBZ0lHSjVkR1ZqWHpJZ0x5OGdJblFpQ2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZOellLSUNBZ0lDOHZJSFJvYVhNdWRHOTBZV3hUZFhCd2JIa3VkbUZzZFdVZ1BTQjBiM1JoYkZOMWNIQnNlVHNLSUNBZ0lHWnlZVzFsWDJScFp5QXRNUW9nSUNBZ1lYQndYMmRzYjJKaGJGOXdkWFFLSUNBZ0lDOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6bzFOZ29nSUNBZ0x5OGdjSFZpYkdsaklHUmxZMmx0WVd4eklEMGdSMnh2WW1Gc1UzUmhkR1U4VldsdWRFNDRQaWg3SUd0bGVUb2dKMlFuSUgwcE93b2dJQ0FnY0hWemFHSjVkR1Z6SUNKa0lnb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pjM0NpQWdJQ0F2THlCMGFHbHpMbVJsWTJsdFlXeHpMblpoYkhWbElEMGdaR1ZqYVcxaGJITTdDaUFnSUNCbWNtRnRaVjlrYVdjZ0xUSUtJQ0FnSUdGd2NGOW5iRzlpWVd4ZmNIVjBDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk56Z0tJQ0FnSUM4dklHTnZibk4wSUhObGJtUmxjaUE5SUc1bGR5QkJaR1J5WlhOektGUjRiaTV6Wlc1a1pYSXBPd29nSUNBZ2RIaHVJRk5sYm1SbGNnb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pZeUNpQWdJQ0F2THlCd2RXSnNhV01nWW1Gc1lXNWpaWE1nUFNCQ2IzaE5ZWEE4UVdSa2NtVnpjeXdnVldsdWRFNHlOVFkrS0hzZ2EyVjVVSEpsWm1sNE9pQW5ZaWNnZlNrN0NpQWdJQ0JpZVhSbFkxOHhJQzh2SUNKaUlnb2dJQ0FnWkdsbklERUtJQ0FnSUdOdmJtTmhkQW9nSUNBZ0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qZ3dDaUFnSUNBdkx5QjBhR2x6TG1KaGJHRnVZMlZ6S0hObGJtUmxjaWt1ZG1Gc2RXVWdQU0IwYjNSaGJGTjFjSEJzZVRzS0lDQWdJR1p5WVcxbFgyUnBaeUF0TVFvZ0lDQWdZbTk0WDNCMWRBb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pneUNpQWdJQ0F2THlCbGJXbDBLRzVsZHlCaGNtTXlNREJmVkhKaGJuTm1aWElvZXlCbWNtOXRPaUJ1WlhjZ1FXUmtjbVZ6Y3loSGJHOWlZV3d1ZW1WeWIwRmtaSEpsYzNNcExDQjBiem9nYzJWdVpHVnlMQ0IyWVd4MVpUb2dkRzkwWVd4VGRYQndiSGtnZlNrcE93b2dJQ0FnWjJ4dlltRnNJRnBsY205QlpHUnlaWE56Q2lBZ0lDQnpkMkZ3Q2lBZ0lDQmpiMjVqWVhRS0lDQWdJR1p5WVcxbFgyUnBaeUF0TVFvZ0lDQWdZMjl1WTJGMENpQWdJQ0JpZVhSbFl5QTBJQzh2SUcxbGRHaHZaQ0FpWVhKak1qQXdYMVJ5WVc1elptVnlLR0ZrWkhKbGMzTXNZV1JrY21WemN5eDFhVzUwTWpVMktTSUtJQ0FnSUhOM1lYQUtJQ0FnSUdOdmJtTmhkQW9nSUNBZ2JHOW5DaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk9ETUtJQ0FnSUM4dklISmxkSFZ5YmlCdVpYY2dRbTl2YkNoMGNuVmxLVHNLSUNBZ0lHSjVkR1ZqWHpNZ0x5OGdNSGc0TUFvZ0lDQWdjbVYwYzNWaUNnb0tMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPanBCY21NeU1EQXVZWEpqTWpBd1gyNWhiV1VvS1NBdFBpQmllWFJsY3pvS1lYSmpNakF3WDI1aGJXVTZDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk5EZ0tJQ0FnSUM4dklIQjFZbXhwWXlCdVlXMWxJRDBnUjJ4dlltRnNVM1JoZEdVOFJIbHVZVzFwWTBKNWRHVnpQaWg3SUd0bGVUb2dKMjRuSUgwcE93b2dJQ0FnYVc1MFkxOHlJQzh2SURBS0lDQWdJSEIxYzJoaWVYUmxjeUFpYmlJS0lDQWdJR0Z3Y0Y5bmJHOWlZV3hmWjJWMFgyVjRDaUFnSUNCaGMzTmxjblFnTHk4Z1kyaGxZMnNnUjJ4dlltRnNVM1JoZEdVZ1pYaHBjM1J6Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZPVE1LSUNBZ0lDOHZJSEpsZEhWeWJpQnVaWGNnVTNSaGRHbGpRbmwwWlhNOE16SStLSFJvYVhNdWJtRnRaUzUyWVd4MVpTNXVZWFJwZG1VcE93b2dJQ0FnWlhoMGNtRmpkQ0F5SURBS0lDQWdJR1IxY0FvZ0lDQWdiR1Z1Q2lBZ0lDQnBiblJqWHpFZ0x5OGdNeklLSUNBZ0lEMDlDaUFnSUNCaGMzTmxjblFnTHk4Z2FXNTJZV3hwWkNCemFYcGxDaUFnSUNCeVpYUnpkV0lLQ2dvdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk9rRnlZekl3TUM1aGNtTXlNREJmYzNsdFltOXNLQ2tnTFQ0Z1lubDBaWE02Q21GeVl6SXdNRjl6ZVcxaWIydzZDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk5USUtJQ0FnSUM4dklIQjFZbXhwWXlCemVXMWliMndnUFNCSGJHOWlZV3hUZEdGMFpUeEVlVzVoYldsalFubDBaWE0rS0hzZ2EyVjVPaUFuY3ljZ2ZTazdDaUFnSUNCcGJuUmpYeklnTHk4Z01Bb2dJQ0FnY0hWemFHSjVkR1Z6SUNKeklnb2dJQ0FnWVhCd1gyZHNiMkpoYkY5blpYUmZaWGdLSUNBZ0lHRnpjMlZ5ZENBdkx5QmphR1ZqYXlCSGJHOWlZV3hUZEdGMFpTQmxlR2x6ZEhNS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem94TURNS0lDQWdJQzh2SUhKbGRIVnliaUJ1WlhjZ1UzUmhkR2xqUW5sMFpYTThPRDRvZEdocGN5NXplVzFpYjJ3dWRtRnNkV1V1Ym1GMGFYWmxLVHNLSUNBZ0lHVjRkSEpoWTNRZ01pQXdDaUFnSUNCa2RYQUtJQ0FnSUd4bGJnb2dJQ0FnYVc1MFkxOHpJQzh2SURnS0lDQWdJRDA5Q2lBZ0lDQmhjM05sY25RZ0x5OGdhVzUyWVd4cFpDQnphWHBsQ2lBZ0lDQnlaWFJ6ZFdJS0Nnb3ZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZPa0Z5WXpJd01DNWhjbU15TURCZlpHVmphVzFoYkhNb0tTQXRQaUJpZVhSbGN6b0tZWEpqTWpBd1gyUmxZMmx0WVd4ek9nb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pVMkNpQWdJQ0F2THlCd2RXSnNhV01nWkdWamFXMWhiSE1nUFNCSGJHOWlZV3hUZEdGMFpUeFZhVzUwVGpnK0tIc2dhMlY1T2lBblpDY2dmU2s3Q2lBZ0lDQnBiblJqWHpJZ0x5OGdNQW9nSUNBZ2NIVnphR0o1ZEdWeklDSmtJZ29nSUNBZ1lYQndYMmRzYjJKaGJGOW5aWFJmWlhnS0lDQWdJR0Z6YzJWeWRDQXZMeUJqYUdWamF5QkhiRzlpWVd4VGRHRjBaU0JsZUdsemRITUtJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE1UTUtJQ0FnSUM4dklISmxkSFZ5YmlCMGFHbHpMbVJsWTJsdFlXeHpMblpoYkhWbE93b2dJQ0FnY21WMGMzVmlDZ29LTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pwQmNtTXlNREF1WVhKak1qQXdYM1J2ZEdGc1UzVndjR3g1S0NrZ0xUNGdZbmwwWlhNNkNtRnlZekl3TUY5MGIzUmhiRk4xY0hCc2VUb0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pvMk1Bb2dJQ0FnTHk4Z2NIVmliR2xqSUhSdmRHRnNVM1Z3Y0d4NUlEMGdSMnh2WW1Gc1UzUmhkR1U4VldsdWRFNHlOVFkrS0hzZ2EyVjVPaUFuZENjZ2ZTazdDaUFnSUNCcGJuUmpYeklnTHk4Z01Bb2dJQ0FnWW5sMFpXTmZNaUF2THlBaWRDSUtJQ0FnSUdGd2NGOW5iRzlpWVd4ZloyVjBYMlY0Q2lBZ0lDQmhjM05sY25RZ0x5OGdZMmhsWTJzZ1IyeHZZbUZzVTNSaGRHVWdaWGhwYzNSekNpQWdJQ0F2THlCamIyNTBjbUZqZEhNdllYSmpNakF3TG1Gc1oyOHVkSE02TVRJekNpQWdJQ0F2THlCeVpYUjFjbTRnZEdocGN5NTBiM1JoYkZOMWNIQnNlUzUyWVd4MVpUc0tJQ0FnSUhKbGRITjFZZ29LQ2k4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pvNlFYSmpNakF3TG1GeVl6SXdNRjlpWVd4aGJtTmxUMllvYjNkdVpYSTZJR0o1ZEdWektTQXRQaUJpZVhSbGN6b0tZWEpqTWpBd1gySmhiR0Z1WTJWUFpqb0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE16SXRNVE16Q2lBZ0lDQXZMeUJBWVhKak5DNWhZbWx0WlhSb2IyUW9leUJ5WldGa2IyNXNlVG9nZEhKMVpTQjlLUW9nSUNBZ0x5OGdjSFZpYkdsaklHRnlZekl3TUY5aVlXeGhibU5sVDJZb2IzZHVaWEk2SUVGa1pISmxjM01wT2lCaGNtTTBMbFZwYm5ST01qVTJJSHNLSUNBZ0lIQnliM1J2SURFZ01Rb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pFek5Bb2dJQ0FnTHk4Z2NtVjBkWEp1SUhSb2FYTXVYMkpoYkdGdVkyVlBaaWh2ZDI1bGNpazdDaUFnSUNCbWNtRnRaVjlrYVdjZ0xURUtJQ0FnSUdOaGJHeHpkV0lnWDJKaGJHRnVZMlZQWmdvZ0lDQWdjbVYwYzNWaUNnb0tMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPanBCY21NeU1EQXVZWEpqTWpBd1gzUnlZVzV6Wm1WeUtIUnZPaUJpZVhSbGN5d2dkbUZzZFdVNklHSjVkR1Z6S1NBdFBpQmllWFJsY3pvS1lYSmpNakF3WDNSeVlXNXpabVZ5T2dvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakUwTkMweE5EVUtJQ0FnSUM4dklFQmhjbU0wTG1GaWFXMWxkR2h2WkNncENpQWdJQ0F2THlCd2RXSnNhV01nWVhKak1qQXdYM1J5WVc1elptVnlLSFJ2T2lCQlpHUnlaWE56TENCMllXeDFaVG9nWVhKak5DNVZhVzUwVGpJMU5pazZJR0Z5WXpRdVFtOXZiQ0I3Q2lBZ0lDQndjbTkwYnlBeUlERUtJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE5EWUtJQ0FnSUM4dklISmxkSFZ5YmlCMGFHbHpMbDkwY21GdWMyWmxjaWh1WlhjZ1FXUmtjbVZ6Y3loVWVHNHVjMlZ1WkdWeUtTd2dkRzhzSUhaaGJIVmxLVHNLSUNBZ0lIUjRiaUJUWlc1a1pYSUtJQ0FnSUdaeVlXMWxYMlJwWnlBdE1nb2dJQ0FnWm5KaGJXVmZaR2xuSUMweENpQWdJQ0JqWVd4c2MzVmlJRjkwY21GdWMyWmxjZ29nSUNBZ2NtVjBjM1ZpQ2dvS0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qcEJjbU15TURBdVlYSmpNakF3WDNSeVlXNXpabVZ5Um5KdmJTaG1jbTl0T2lCaWVYUmxjeXdnZEc4NklHSjVkR1Z6TENCMllXeDFaVG9nWW5sMFpYTXBJQzArSUdKNWRHVnpPZ3BoY21NeU1EQmZkSEpoYm5ObVpYSkdjbTl0T2dvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakUxTnkweE5UZ0tJQ0FnSUM4dklFQmhjbU0wTG1GaWFXMWxkR2h2WkNncENpQWdJQ0F2THlCd2RXSnNhV01nWVhKak1qQXdYM1J5WVc1elptVnlSbkp2YlNobWNtOXRPaUJCWkdSeVpYTnpMQ0IwYnpvZ1FXUmtjbVZ6Y3l3Z2RtRnNkV1U2SUdGeVl6UXVWV2x1ZEU0eU5UWXBPaUJoY21NMExrSnZiMndnZXdvZ0lDQWdjSEp2ZEc4Z015QXhDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk1UVTVDaUFnSUNBdkx5QmpiMjV6ZENCemNHVnVaR1Z5SUQwZ2JtVjNJRUZrWkhKbGMzTW9WSGh1TG5ObGJtUmxjaWs3Q2lBZ0lDQjBlRzRnVTJWdVpHVnlDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk1UWXdDaUFnSUNBdkx5QmpiMjV6ZENCemNHVnVaR1Z5WDJGc2JHOTNZVzVqWlNBOUlIUm9hWE11WDJGc2JHOTNZVzVqWlNobWNtOXRMQ0J6Y0dWdVpHVnlLVHNLSUNBZ0lHWnlZVzFsWDJScFp5QXRNd29nSUNBZ1pHbG5JREVLSUNBZ0lHTmhiR3h6ZFdJZ1gyRnNiRzkzWVc1alpRb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pFMk1Rb2dJQ0FnTHk4Z1lYTnpaWEowS0hOd1pXNWtaWEpmWVd4c2IzZGhibU5sTG01aGRHbDJaU0ErUFNCMllXeDFaUzV1WVhScGRtVXNJQ2RwYm5OMVptWnBZMmxsYm5RZ1lYQndjbTkyWVd3bktUc0tJQ0FnSUdSMWNBb2dJQ0FnWm5KaGJXVmZaR2xuSUMweENpQWdJQ0JpUGowS0lDQWdJR0Z6YzJWeWRDQXZMeUJwYm5OMVptWnBZMmxsYm5RZ1lYQndjbTkyWVd3S0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem94TmpJS0lDQWdJQzh2SUdOdmJuTjBJRzVsZDE5emNHVnVaR1Z5WDJGc2JHOTNZVzVqWlNBOUlHNWxkeUJWYVc1MFRqSTFOaWh6Y0dWdVpHVnlYMkZzYkc5M1lXNWpaUzV1WVhScGRtVWdMU0IyWVd4MVpTNXVZWFJwZG1VcE93b2dJQ0FnWm5KaGJXVmZaR2xuSUMweENpQWdJQ0JpTFFvZ0lDQWdaSFZ3Q2lBZ0lDQnNaVzRLSUNBZ0lHbHVkR05mTVNBdkx5QXpNZ29nSUNBZ1BEMEtJQ0FnSUdGemMyVnlkQ0F2THlCdmRtVnlabXh2ZHdvZ0lDQWdhVzUwWTE4eElDOHZJRE15Q2lBZ0lDQmllbVZ5YndvZ0lDQWdZbndLSUNBZ0lDOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6b3hOak1LSUNBZ0lDOHZJSFJvYVhNdVgyRndjSEp2ZG1Vb1puSnZiU3dnYzNCbGJtUmxjaXdnYm1WM1gzTndaVzVrWlhKZllXeHNiM2RoYm1ObEtUc0tJQ0FnSUdaeVlXMWxYMlJwWnlBdE13b2dJQ0FnWTI5MlpYSWdNZ29nSUNBZ1kyRnNiSE4xWWlCZllYQndjbTkyWlFvZ0lDQWdjRzl3Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZNVFkwQ2lBZ0lDQXZMeUJ5WlhSMWNtNGdkR2hwY3k1ZmRISmhibk5tWlhJb1puSnZiU3dnZEc4c0lIWmhiSFZsS1RzS0lDQWdJR1p5WVcxbFgyUnBaeUF0TXdvZ0lDQWdabkpoYldWZlpHbG5JQzB5Q2lBZ0lDQm1jbUZ0WlY5a2FXY2dMVEVLSUNBZ0lHTmhiR3h6ZFdJZ1gzUnlZVzV6Wm1WeUNpQWdJQ0J5WlhSemRXSUtDZ292THlCamIyNTBjbUZqZEhNdllYSmpNakF3TG1Gc1oyOHVkSE02T2tGeVl6SXdNQzVoY21NeU1EQmZZWEJ3Y205MlpTaHpjR1Z1WkdWeU9pQmllWFJsY3l3Z2RtRnNkV1U2SUdKNWRHVnpLU0F0UGlCaWVYUmxjem9LWVhKak1qQXdYMkZ3Y0hKdmRtVTZDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk1UYzBMVEUzTlFvZ0lDQWdMeThnUUdGeVl6UXVZV0pwYldWMGFHOWtLQ2tLSUNBZ0lDOHZJSEIxWW14cFl5QmhjbU15TURCZllYQndjbTkyWlNoemNHVnVaR1Z5T2lCQlpHUnlaWE56TENCMllXeDFaVG9nWVhKak5DNVZhVzUwVGpJMU5pazZJRUp2YjJ3Z2V3b2dJQ0FnY0hKdmRHOGdNaUF4Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZNVGMyQ2lBZ0lDQXZMeUJqYjI1emRDQnZkMjVsY2lBOUlHNWxkeUJCWkdSeVpYTnpLRlI0Ymk1elpXNWtaWElwT3dvZ0lDQWdkSGh1SUZObGJtUmxjZ29nSUNBZ0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qRTNOd29nSUNBZ0x5OGdjbVYwZFhKdUlIUm9hWE11WDJGd2NISnZkbVVvYjNkdVpYSXNJSE53Wlc1a1pYSXNJSFpoYkhWbEtUc0tJQ0FnSUdaeVlXMWxYMlJwWnlBdE1nb2dJQ0FnWm5KaGJXVmZaR2xuSUMweENpQWdJQ0JqWVd4c2MzVmlJRjloY0hCeWIzWmxDaUFnSUNCeVpYUnpkV0lLQ2dvdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk9rRnlZekl3TUM1aGNtTXlNREJmWVd4c2IzZGhibU5sS0c5M2JtVnlPaUJpZVhSbGN5d2djM0JsYm1SbGNqb2dZbmwwWlhNcElDMCtJR0o1ZEdWek9ncGhjbU15TURCZllXeHNiM2RoYm1ObE9nb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pFNE5pMHhPRGNLSUNBZ0lDOHZJRUJoY21NMExtRmlhVzFsZEdodlpDaDdJSEpsWVdSdmJteDVPaUIwY25WbElIMHBDaUFnSUNBdkx5QndkV0pzYVdNZ1lYSmpNakF3WDJGc2JHOTNZVzVqWlNodmQyNWxjam9nUVdSa2NtVnpjeXdnYzNCbGJtUmxjam9nUVdSa2NtVnpjeWs2SUdGeVl6UXVWV2x1ZEU0eU5UWWdld29nSUNBZ2NISnZkRzhnTWlBeENpQWdJQ0F2THlCamIyNTBjbUZqZEhNdllYSmpNakF3TG1Gc1oyOHVkSE02TVRnNENpQWdJQ0F2THlCeVpYUjFjbTRnZEdocGN5NWZZV3hzYjNkaGJtTmxLRzkzYm1WeUxDQnpjR1Z1WkdWeUtUc0tJQ0FnSUdaeVlXMWxYMlJwWnlBdE1nb2dJQ0FnWm5KaGJXVmZaR2xuSUMweENpQWdJQ0JqWVd4c2MzVmlJRjloYkd4dmQyRnVZMlVLSUNBZ0lISmxkSE4xWWdvS0NpOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6bzZRWEpqTWpBd0xsOWlZV3hoYm1ObFQyWW9iM2R1WlhJNklHSjVkR1Z6S1NBdFBpQmllWFJsY3pvS1gySmhiR0Z1WTJWUFpqb0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveE9URUtJQ0FnSUM4dklIQnlhWFpoZEdVZ1gySmhiR0Z1WTJWUFppaHZkMjVsY2pvZ1FXUmtjbVZ6Y3lrNklGVnBiblJPTWpVMklIc0tJQ0FnSUhCeWIzUnZJREVnTVFvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPall5Q2lBZ0lDQXZMeUJ3ZFdKc2FXTWdZbUZzWVc1alpYTWdQU0JDYjNoTllYQThRV1JrY21WemN5d2dWV2x1ZEU0eU5UWStLSHNnYTJWNVVISmxabWw0T2lBbllpY2dmU2s3Q2lBZ0lDQmllWFJsWTE4eElDOHZJQ0ppSWdvZ0lDQWdabkpoYldWZlpHbG5JQzB4Q2lBZ0lDQmpiMjVqWVhRS0lDQWdJR1IxY0FvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakU1TWdvZ0lDQWdMeThnYVdZZ0tDRjBhR2x6TG1KaGJHRnVZMlZ6S0c5M2JtVnlLUzVsZUdsemRITXBJSEpsZEhWeWJpQnVaWGNnVldsdWRFNHlOVFlvTUNrN0NpQWdJQ0JpYjNoZmJHVnVDaUFnSUNCaWRYSjVJREVLSUNBZ0lHSnVlaUJmWW1Gc1lXNWpaVTltWDJGbWRHVnlYMmxtWDJWc2MyVkFNZ29nSUNBZ1lubDBaV01nTlNBdkx5QXdlREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREFLSUNBZ0lITjNZWEFLSUNBZ0lISmxkSE4xWWdvS1gySmhiR0Z1WTJWUFpsOWhablJsY2w5cFpsOWxiSE5sUURJNkNpQWdJQ0F2THlCamIyNTBjbUZqZEhNdllYSmpNakF3TG1Gc1oyOHVkSE02TVRrekNpQWdJQ0F2THlCeVpYUjFjbTRnZEdocGN5NWlZV3hoYm1ObGN5aHZkMjVsY2lrdWRtRnNkV1U3Q2lBZ0lDQm1jbUZ0WlY5a2FXY2dNQW9nSUNBZ1ltOTRYMmRsZEFvZ0lDQWdZWE56WlhKMElDOHZJRUp2ZUNCdGRYTjBJR2hoZG1VZ2RtRnNkV1VLSUNBZ0lITjNZWEFLSUNBZ0lISmxkSE4xWWdvS0NpOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6bzZRWEpqTWpBd0xsOTBjbUZ1YzJabGNpaHpaVzVrWlhJNklHSjVkR1Z6TENCeVpXTnBjR2xsYm5RNklHSjVkR1Z6TENCaGJXOTFiblE2SUdKNWRHVnpLU0F0UGlCaWVYUmxjem9LWDNSeVlXNXpabVZ5T2dvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakU1TmdvZ0lDQWdMeThnY0hKcGRtRjBaU0JmZEhKaGJuTm1aWElvYzJWdVpHVnlPaUJCWkdSeVpYTnpMQ0J5WldOcGNHbGxiblE2SUVGa1pISmxjM01zSUdGdGIzVnVkRG9nVldsdWRFNHlOVFlwT2lCQ2IyOXNJSHNLSUNBZ0lIQnliM1J2SURNZ01Rb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pFNU53b2dJQ0FnTHk4Z1kyOXVjM1FnYzJWdVpHVnlYMkpoYkdGdVkyVWdQU0IwYUdsekxsOWlZV3hoYm1ObFQyWW9jMlZ1WkdWeUtUc0tJQ0FnSUdaeVlXMWxYMlJwWnlBdE13b2dJQ0FnWTJGc2JITjFZaUJmWW1Gc1lXNWpaVTltQ2lBZ0lDQmtkWEFLSUNBZ0lDOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6b3hPVGdLSUNBZ0lDOHZJR052Ym5OMElISmxZMmx3YVdWdWRGOWlZV3hoYm1ObElEMGdkR2hwY3k1ZlltRnNZVzVqWlU5bUtISmxZMmx3YVdWdWRDazdDaUFnSUNCbWNtRnRaVjlrYVdjZ0xUSUtJQ0FnSUdOaGJHeHpkV0lnWDJKaGJHRnVZMlZQWmdvZ0lDQWdjM2RoY0FvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakU1T1FvZ0lDQWdMeThnWVhOelpYSjBLSE5sYm1SbGNsOWlZV3hoYm1ObExtNWhkR2wyWlNBK1BTQmhiVzkxYm5RdWJtRjBhWFpsTENBblNXNXpkV1ptYVdOcFpXNTBJR0poYkdGdVkyVWdZWFFnZEdobElITmxibVJsY2lCaFkyTnZkVzUwSnlrN0NpQWdJQ0JtY21GdFpWOWthV2NnTFRFS0lDQWdJR0krUFFvZ0lDQWdZWE56WlhKMElDOHZJRWx1YzNWbVptbGphV1Z1ZENCaVlXeGhibU5sSUdGMElIUm9aU0J6Wlc1a1pYSWdZV05qYjNWdWRBb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pJd01Rb2dJQ0FnTHk4Z2FXWWdLSE5sYm1SbGNpQWhQVDBnY21WamFYQnBaVzUwS1NCN0NpQWdJQ0JtY21GdFpWOWthV2NnTFRNS0lDQWdJR1p5WVcxbFgyUnBaeUF0TWdvZ0lDQWdJVDBLSUNBZ0lHSjZJRjkwY21GdWMyWmxjbDloWm5SbGNsOXBabDlsYkhObFFESUtJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveU1ETUtJQ0FnSUM4dklIUm9hWE11WW1Gc1lXNWpaWE1vYzJWdVpHVnlLUzUyWVd4MVpTQTlJRzVsZHlCVmFXNTBUakkxTmloelpXNWtaWEpmWW1Gc1lXNWpaUzV1WVhScGRtVWdMU0JoYlc5MWJuUXVibUYwYVhabEtUc0tJQ0FnSUdaeVlXMWxYMlJwWnlBd0NpQWdJQ0JtY21GdFpWOWthV2NnTFRFS0lDQWdJR0l0Q2lBZ0lDQmtkWEFLSUNBZ0lHeGxiZ29nSUNBZ2FXNTBZMTh4SUM4dklETXlDaUFnSUNBOFBRb2dJQ0FnWVhOelpYSjBJQzh2SUc5MlpYSm1iRzkzQ2lBZ0lDQnBiblJqWHpFZ0x5OGdNeklLSUNBZ0lHSjZaWEp2Q2lBZ0lDQnpkMkZ3Q2lBZ0lDQmthV2NnTVFvZ0lDQWdZbndLSUNBZ0lDOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6bzJNZ29nSUNBZ0x5OGdjSFZpYkdsaklHSmhiR0Z1WTJWeklEMGdRbTk0VFdGd1BFRmtaSEpsYzNNc0lGVnBiblJPTWpVMlBpaDdJR3RsZVZCeVpXWnBlRG9nSjJJbklIMHBPd29nSUNBZ1lubDBaV05mTVNBdkx5QWlZaUlLSUNBZ0lHWnlZVzFsWDJScFp5QXRNd29nSUNBZ1kyOXVZMkYwQ2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZNakF6Q2lBZ0lDQXZMeUIwYUdsekxtSmhiR0Z1WTJWektITmxibVJsY2lrdWRtRnNkV1VnUFNCdVpYY2dWV2x1ZEU0eU5UWW9jMlZ1WkdWeVgySmhiR0Z1WTJVdWJtRjBhWFpsSUMwZ1lXMXZkVzUwTG01aGRHbDJaU2s3Q2lBZ0lDQnpkMkZ3Q2lBZ0lDQmliM2hmY0hWMENpQWdJQ0F2THlCamIyNTBjbUZqZEhNdllYSmpNakF3TG1Gc1oyOHVkSE02TWpBMENpQWdJQ0F2THlCMGFHbHpMbUpoYkdGdVkyVnpLSEpsWTJsd2FXVnVkQ2t1ZG1Gc2RXVWdQU0J1WlhjZ1ZXbHVkRTR5TlRZb2NtVmphWEJwWlc1MFgySmhiR0Z1WTJVdWJtRjBhWFpsSUNzZ1lXMXZkVzUwTG01aGRHbDJaU2tLSUNBZ0lHWnlZVzFsWDJScFp5QXhDaUFnSUNCbWNtRnRaVjlrYVdjZ0xURUtJQ0FnSUdJckNpQWdJQ0JrZFhBS0lDQWdJR3hsYmdvZ0lDQWdhVzUwWTE4eElDOHZJRE15Q2lBZ0lDQThQUW9nSUNBZ1lYTnpaWEowSUM4dklHOTJaWEptYkc5M0NpQWdJQ0JpZkFvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPall5Q2lBZ0lDQXZMeUJ3ZFdKc2FXTWdZbUZzWVc1alpYTWdQU0JDYjNoTllYQThRV1JrY21WemN5d2dWV2x1ZEU0eU5UWStLSHNnYTJWNVVISmxabWw0T2lBbllpY2dmU2s3Q2lBZ0lDQmllWFJsWTE4eElDOHZJQ0ppSWdvZ0lDQWdabkpoYldWZlpHbG5JQzB5Q2lBZ0lDQmpiMjVqWVhRS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem95TURRS0lDQWdJQzh2SUhSb2FYTXVZbUZzWVc1alpYTW9jbVZqYVhCcFpXNTBLUzUyWVd4MVpTQTlJRzVsZHlCVmFXNTBUakkxTmloeVpXTnBjR2xsYm5SZlltRnNZVzVqWlM1dVlYUnBkbVVnS3lCaGJXOTFiblF1Ym1GMGFYWmxLUW9nSUNBZ2MzZGhjQW9nSUNBZ1ltOTRYM0IxZEFvS1gzUnlZVzV6Wm1WeVgyRm1kR1Z5WDJsbVgyVnNjMlZBTWpvS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem95TURZS0lDQWdJQzh2SUdWdGFYUW9ibVYzSUdGeVl6SXdNRjlVY21GdWMyWmxjaWg3SUdaeWIyMDZJSE5sYm1SbGNpd2dkRzg2SUhKbFkybHdhV1Z1ZEN3Z2RtRnNkV1U2SUdGdGIzVnVkQ0I5S1NrN0NpQWdJQ0JtY21GdFpWOWthV2NnTFRNS0lDQWdJR1p5WVcxbFgyUnBaeUF0TWdvZ0lDQWdZMjl1WTJGMENpQWdJQ0JtY21GdFpWOWthV2NnTFRFS0lDQWdJR052Ym1OaGRBb2dJQ0FnWW5sMFpXTWdOQ0F2THlCdFpYUm9iMlFnSW1GeVl6SXdNRjlVY21GdWMyWmxjaWhoWkdSeVpYTnpMR0ZrWkhKbGMzTXNkV2x1ZERJMU5pa2lDaUFnSUNCemQyRndDaUFnSUNCamIyNWpZWFFLSUNBZ0lHeHZad29nSUNBZ0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qSXdOd29nSUNBZ0x5OGdjbVYwZFhKdUlHNWxkeUJDYjI5c0tIUnlkV1VwT3dvZ0lDQWdZbmwwWldOZk15QXZMeUF3ZURnd0NpQWdJQ0JtY21GdFpWOWlkWEo1SURBS0lDQWdJSEpsZEhOMVlnb0tDaTh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem82UVhKak1qQXdMbDloY0hCeWIzWmhiRXRsZVNodmQyNWxjam9nWW5sMFpYTXNJSE53Wlc1a1pYSTZJR0o1ZEdWektTQXRQaUJpZVhSbGN6b0tYMkZ3Y0hKdmRtRnNTMlY1T2dvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakl3T1FvZ0lDQWdMeThnY0hKcGRtRjBaU0JmWVhCd2NtOTJZV3hMWlhrb2IzZHVaWEk2SUVGa1pISmxjM01zSUhOd1pXNWtaWEk2SUVGa1pISmxjM01wT2lCVGRHRjBhV05DZVhSbGN6d3pNajRnZXdvZ0lDQWdjSEp2ZEc4Z01pQXhDaUFnSUNBdkx5QmpiMjUwY21GamRITXZZWEpqTWpBd0xtRnNaMjh1ZEhNNk1qRXdDaUFnSUNBdkx5QnlaWFIxY200Z2JtVjNJRk4wWVhScFkwSjVkR1Z6UERNeVBpaHZjQzV6YUdFeU5UWW9iM0F1WTI5dVkyRjBLRzkzYm1WeUxtSjVkR1Z6TENCemNHVnVaR1Z5TG1KNWRHVnpLU2twT3dvZ0lDQWdabkpoYldWZlpHbG5JQzB5Q2lBZ0lDQm1jbUZ0WlY5a2FXY2dMVEVLSUNBZ0lHTnZibU5oZEFvZ0lDQWdjMmhoTWpVMkNpQWdJQ0JrZFhBS0lDQWdJR3hsYmdvZ0lDQWdhVzUwWTE4eElDOHZJRE15Q2lBZ0lDQTlQUW9nSUNBZ1lYTnpaWEowSUM4dklHbHVkbUZzYVdRZ2MybDZaUW9nSUNBZ2NtVjBjM1ZpQ2dvS0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qcEJjbU15TURBdVgyRnNiRzkzWVc1alpTaHZkMjVsY2pvZ1lubDBaWE1zSUhOd1pXNWtaWEk2SUdKNWRHVnpLU0F0UGlCaWVYUmxjem9LWDJGc2JHOTNZVzVqWlRvS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem95TVRNS0lDQWdJQzh2SUhCeWFYWmhkR1VnWDJGc2JHOTNZVzVqWlNodmQyNWxjam9nUVdSa2NtVnpjeXdnYzNCbGJtUmxjam9nUVdSa2NtVnpjeWs2SUZWcGJuUk9NalUySUhzS0lDQWdJSEJ5YjNSdklESWdNUW9nSUNBZ0x5OGdZMjl1ZEhKaFkzUnpMMkZ5WXpJd01DNWhiR2R2TG5Sek9qSXhOQW9nSUNBZ0x5OGdZMjl1YzNRZ2EyVjVJRDBnZEdocGN5NWZZWEJ3Y205MllXeExaWGtvYjNkdVpYSXNJSE53Wlc1a1pYSXBPd29nSUNBZ1puSmhiV1ZmWkdsbklDMHlDaUFnSUNCbWNtRnRaVjlrYVdjZ0xURUtJQ0FnSUdOaGJHeHpkV0lnWDJGd2NISnZkbUZzUzJWNUNpQWdJQ0F2THlCamIyNTBjbUZqZEhNdllYSmpNakF3TG1Gc1oyOHVkSE02TmpRS0lDQWdJQzh2SUhCMVlteHBZeUJoY0hCeWIzWmhiSE1nUFNCQ2IzaE5ZWEE4VTNSaGRHbGpRbmwwWlhNOE16SStMQ0JCY0hCeWIzWmhiRk4wY25WamRENG9leUJyWlhsUWNtVm1hWGc2SUNkaEp5QjlLVHNLSUNBZ0lIQjFjMmhpZVhSbGN5QWlZU0lLSUNBZ0lITjNZWEFLSUNBZ0lHTnZibU5oZEFvZ0lDQWdaSFZ3Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZNakUxQ2lBZ0lDQXZMeUJwWmlBb0lYUm9hWE11WVhCd2NtOTJZV3h6S0d0bGVTa3VaWGhwYzNSektTQnlaWFIxY200Z2JtVjNJRlZwYm5ST01qVTJLREFwT3dvZ0lDQWdZbTk0WDJ4bGJnb2dJQ0FnWW5WeWVTQXhDaUFnSUNCaWJub2dYMkZzYkc5M1lXNWpaVjloWm5SbGNsOXBabDlsYkhObFFESUtJQ0FnSUdKNWRHVmpJRFVnTHk4Z01IZ3dNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdNREF3TURBd01EQXdDaUFnSUNCemQyRndDaUFnSUNCeVpYUnpkV0lLQ2w5aGJHeHZkMkZ1WTJWZllXWjBaWEpmYVdaZlpXeHpaVUF5T2dvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPakl4TmdvZ0lDQWdMeThnY21WMGRYSnVJSFJvYVhNdVlYQndjbTkyWVd4ektHdGxlU2t1ZG1Gc2RXVXVZWEJ3Y205MllXeEJiVzkxYm5RN0NpQWdJQ0JtY21GdFpWOWthV2NnTUFvZ0lDQWdZbTk0WDJkbGRBb2dJQ0FnWVhOelpYSjBJQzh2SUVKdmVDQnRkWE4wSUdoaGRtVWdkbUZzZFdVS0lDQWdJR1Y0ZEhKaFkzUWdNQ0F6TWlBdkx5QnZiaUJsY25KdmNqb2dTVzVrWlhnZ1lXTmpaWE56SUdseklHOTFkQ0J2WmlCaWIzVnVaSE1LSUNBZ0lITjNZWEFLSUNBZ0lISmxkSE4xWWdvS0NpOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6bzZRWEpqTWpBd0xsOWhjSEJ5YjNabEtHOTNibVZ5T2lCaWVYUmxjeXdnYzNCbGJtUmxjam9nWW5sMFpYTXNJR0Z0YjNWdWREb2dZbmwwWlhNcElDMCtJR0o1ZEdWek9ncGZZWEJ3Y205MlpUb0tJQ0FnSUM4dklHTnZiblJ5WVdOMGN5OWhjbU15TURBdVlXeG5ieTUwY3pveU1Ua0tJQ0FnSUM4dklIQnlhWFpoZEdVZ1gyRndjSEp2ZG1Vb2IzZHVaWEk2SUVGa1pISmxjM01zSUhOd1pXNWtaWEk2SUVGa1pISmxjM01zSUdGdGIzVnVkRG9nVldsdWRFNHlOVFlwT2lCQ2IyOXNJSHNLSUNBZ0lIQnliM1J2SURNZ01Rb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pJeU1Bb2dJQ0FnTHk4Z1kyOXVjM1FnYTJWNUlEMGdkR2hwY3k1ZllYQndjbTkyWVd4TFpYa29iM2R1WlhJc0lITndaVzVrWlhJcE93b2dJQ0FnWm5KaGJXVmZaR2xuSUMwekNpQWdJQ0JtY21GdFpWOWthV2NnTFRJS0lDQWdJR05oYkd4emRXSWdYMkZ3Y0hKdmRtRnNTMlY1Q2lBZ0lDQXZMeUJqYjI1MGNtRmpkSE12WVhKak1qQXdMbUZzWjI4dWRITTZNakl4TFRJeU5Rb2dJQ0FnTHk4Z1kyOXVjM1FnWVhCd2NtOTJZV3hDYjNnNklFRndjSEp2ZG1Gc1UzUnlkV04wSUQwZ2JtVjNJRUZ3Y0hKdmRtRnNVM1J5ZFdOMEtIc0tJQ0FnSUM4dklDQWdZWEJ3Y205MllXeEJiVzkxYm5RNklHRnRiM1Z1ZEN3S0lDQWdJQzh2SUNBZ2IzZHVaWEk2SUc5M2JtVnlMQW9nSUNBZ0x5OGdJQ0J6Y0dWdVpHVnlPaUJ6Y0dWdVpHVnlMQW9nSUNBZ0x5OGdmU2s3Q2lBZ0lDQm1jbUZ0WlY5a2FXY2dMVEVLSUNBZ0lHWnlZVzFsWDJScFp5QXRNd29nSUNBZ1kyOXVZMkYwQ2lBZ0lDQm1jbUZ0WlY5a2FXY2dMVElLSUNBZ0lHTnZibU5oZEFvZ0lDQWdMeThnWTI5dWRISmhZM1J6TDJGeVl6SXdNQzVoYkdkdkxuUnpPalkwQ2lBZ0lDQXZMeUJ3ZFdKc2FXTWdZWEJ3Y205MllXeHpJRDBnUW05NFRXRndQRk4wWVhScFkwSjVkR1Z6UERNeVBpd2dRWEJ3Y205MllXeFRkSEoxWTNRK0tIc2dhMlY1VUhKbFptbDRPaUFuWVNjZ2ZTazdDaUFnSUNCd2RYTm9ZbmwwWlhNZ0ltRWlDaUFnSUNCMWJtTnZkbVZ5SURJS0lDQWdJR052Ym1OaGRBb2dJQ0FnTHk4Z1kyOXVkSEpoWTNSekwyRnlZekl3TUM1aGJHZHZMblJ6T2pJeU5nb2dJQ0FnTHk4Z2RHaHBjeTVoY0hCeWIzWmhiSE1vYTJWNUtTNTJZV3gxWlNBOUlHRndjSEp2ZG1Gc1FtOTRMbU52Y0hrb0tUc0tJQ0FnSUhOM1lYQUtJQ0FnSUdKdmVGOXdkWFFLSUNBZ0lDOHZJR052Ym5SeVlXTjBjeTloY21NeU1EQXVZV3huYnk1MGN6b3lNamNLSUNBZ0lDOHZJR1Z0YVhRb2JtVjNJR0Z5WXpJd01GOUJjSEJ5YjNaaGJDaDdJRzkzYm1WeU9pQnZkMjVsY2l3Z2MzQmxibVJsY2pvZ2MzQmxibVJsY2l3Z2RtRnNkV1U2SUdGdGIzVnVkQ0I5S1NrN0NpQWdJQ0JtY21GdFpWOWthV2NnTFRNS0lDQWdJR1p5WVcxbFgyUnBaeUF0TWdvZ0lDQWdZMjl1WTJGMENpQWdJQ0JtY21GdFpWOWthV2NnTFRFS0lDQWdJR052Ym1OaGRBb2dJQ0FnY0hWemFHSjVkR1Z6SURCNE1UazJPV1k0TmpVZ0x5OGdiV1YwYUc5a0lDSmhjbU15TURCZlFYQndjbTkyWVd3b1lXUmtjbVZ6Y3l4aFpHUnlaWE56TEhWcGJuUXlOVFlwSWdvZ0lDQWdjM2RoY0FvZ0lDQWdZMjl1WTJGMENpQWdJQ0JzYjJjS0lDQWdJQzh2SUdOdmJuUnlZV04wY3k5aGNtTXlNREF1WVd4bmJ5NTBjem95TWpnS0lDQWdJQzh2SUhKbGRIVnliaUJ1WlhjZ1FtOXZiQ2gwY25WbEtUc0tJQ0FnSUdKNWRHVmpYek1nTHk4Z01IZzRNQW9nSUNBZ2NtVjBjM1ZpQ2c9PSIsImNsZWFyIjoiSTNCeVlXZHRZU0IyWlhKemFXOXVJREV3Q2lOd2NtRm5iV0VnZEhsd1pYUnlZV05ySUdaaGJITmxDZ292THlCQVlXeG5iM0poYm1SbWIzVnVaR0YwYVc5dUwyRnNaMjl5WVc1a0xYUjVjR1Z6WTNKcGNIUXZZbUZ6WlMxamIyNTBjbUZqZEM1a0xuUnpPanBDWVhObFEyOXVkSEpoWTNRdVkyeGxZWEpUZEdGMFpWQnliMmR5WVcwb0tTQXRQaUIxYVc1ME5qUTZDbTFoYVc0NkNpQWdJQ0J3ZFhOb2FXNTBJREVnTHk4Z01Rb2dJQ0FnY21WMGRYSnVDZz09In0sImJ5dGVDb2RlIjp7ImFwcHJvdmFsIjoiQ2lBRUFTQUFDQ1lHQkJVZmZIVUJZZ0YwQVlBRWVZUERYQ0FBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFERWJRUUVaZ2dvRWwxT0M0Z1JsZlJQc0JMYXVHaVVFaE93VDFRVHNtV0JCQklMbGM4UUUybkFsdVFSS2xvK1BCTFZDSVNVRXU3TVo4ellhQUk0S0FMQUFvQUNRQUlBQWNBQmRBRWNBTGdBWUFBSWtRekVaRkVReEdFUTJHZ0UyR2dLSUFaTW9URkN3SWtNeEdSUkVNUmhFTmhvQk5ob0NpQUZ3S0V4UXNDSkRNUmtVUkRFWVJEWWFBVFlhQWpZYUE0Z0JLU2hNVUxBaVF6RVpGRVF4R0VRMkdnRTJHZ0tJQVFZb1RGQ3dJa014R1JSRU1SaEVOaG9CaUFEcUtFeFFzQ0pETVJrVVJERVlSSWdBMVNoTVVMQWlRekVaRkVReEdFU0lBTDRvVEZDd0lrTXhHUlJFTVJoRWlBQ2ZLRXhRc0NKRE1Sa1VSREVZUklnQWdDaE1VTEFpUXpFWkZFUXhHRVEyR2dFMkdnSTJHZ00yR2dTSUFCRW9URkN3SWtNeEdVRC9MekVZRkVRaVE0b0VBVEVBTWdrU1JJdjhWd0lBRlVsRUl3NUVpLzFYQWdBVlNVUWxEa1FrS21WRkFSUkVnQUZ1aS94bmdBRnppLzFuS292L1o0QUJaSXYrWnpFQUtVc0JVSXYvdnpJRFRGQ0wvMUFuQkV4UXNDdUpKSUFCYm1WRVZ3SUFTUlVqRWtTSkpJQUJjMlZFVndJQVNSVWxFa1NKSklBQlpHVkVpU1FxWlVTSmlnRUJpLytJQUZTSmlnSUJNUUNML292L2lBQmZpWW9EQVRFQWkvMUxBWWdBdEVtTC82ZEVpLytoU1JVakRrUWpyNnVML1U0Q2lBREFTSXY5aS82TC80Z0FNWW1LQWdFeEFJditpLytJQUttSmlnSUJpLzZMLzRnQWU0bUtBUUVwaS85UVNiMUZBVUFBQkNjRlRJbUxBTDVFVEltS0F3R0wvWWovNEVtTC9vai8ya3lMLzZkRWkvMkwvaE5CQUNlTEFJdi9vVWtWSXc1RUk2OU1Td0dyS1l2OVVFeS9pd0dMLzZCSkZTTU9SS3NwaS81UVRMK0wvWXYrVUl2L1VDY0VURkN3SzR3QWlZb0NBWXYraS85UUFVa1ZJeEpFaVlvQ0FZditpLytJLytlQUFXRk1VRW05UlFGQUFBUW5CVXlKaXdDK1JGY0FJRXlKaWdNQmkvMkwvb2oveEl2L2kvMVFpLzVRZ0FGaFR3SlFUTCtML1l2K1VJdi9VSUFFR1duNFpVeFFzQ3VKIiwiY2xlYXIiOiJDb0VCUXc9PSJ9LCJjb21waWxlckluZm8iOnsiY29tcGlsZXIiOiJwdXlhIiwiY29tcGlsZXJWZXJzaW9uIjp7Im1ham9yIjo0LCJtaW5vciI6NywicGF0Y2giOjAsImNvbW1pdEhhc2giOm51bGx9fSwiZXZlbnRzIjpbeyJuYW1lIjoiYXJjMjAwX1RyYW5zZmVyIiwiZGVzYyI6bnVsbCwiYXJncyI6W3sidHlwZSI6ImFkZHJlc3MiLCJzdHJ1Y3QiOm51bGwsIm5hbWUiOiJmcm9tIiwiZGVzYyI6bnVsbH0seyJ0eXBlIjoiYWRkcmVzcyIsInN0cnVjdCI6bnVsbCwibmFtZSI6InRvIiwiZGVzYyI6bnVsbH0seyJ0eXBlIjoidWludDI1NiIsInN0cnVjdCI6bnVsbCwibmFtZSI6InZhbHVlIiwiZGVzYyI6bnVsbH1dfSx7Im5hbWUiOiJhcmMyMDBfQXBwcm92YWwiLCJkZXNjIjpudWxsLCJhcmdzIjpbeyJ0eXBlIjoiYWRkcmVzcyIsInN0cnVjdCI6bnVsbCwibmFtZSI6Im93bmVyIiwiZGVzYyI6bnVsbH0seyJ0eXBlIjoiYWRkcmVzcyIsInN0cnVjdCI6bnVsbCwibmFtZSI6InNwZW5kZXIiLCJkZXNjIjpudWxsfSx7InR5cGUiOiJ1aW50MjU2Iiwic3RydWN0IjpudWxsLCJuYW1lIjoidmFsdWUiLCJkZXNjIjpudWxsfV19XSwidGVtcGxhdGVWYXJpYWJsZXMiOnt9LCJzY3JhdGNoVmFyaWFibGVzIjp7fX0=";
    }

}
