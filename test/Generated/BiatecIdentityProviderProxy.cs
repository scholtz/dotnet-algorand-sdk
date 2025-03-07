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

namespace BiatecIdentity
{


    public class BiatecIdentityProviderProxy : ProxyBase
    {

        public BiatecIdentityProviderProxy(DefaultApi defaultApi, ulong appId) : base(defaultApi, appId)
        {
        }

        ///<summary>
        ///Initial setup
        ///No_op: CREATE, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        public async Task createApplication(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 184, 68, 123, 54 };
            var result = await base.CallApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> createApplication_Transactions(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 184, 68, 123, 54 };
            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Biatec deploys single identity provider smart contract
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider">Biatec amm provider ABI Type is uint64  </param>
        public async Task bootstrap(ulong appBiatecConfigProvider, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 160, 202, 223, 138 };
            var result = await base.CallApp(new List<object> { abiHandle, appBiatecConfigProvider }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> bootstrap_Transactions(ulong appBiatecConfigProvider, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 160, 202, 223, 138 };
            return await base.MakeTransactionList(new List<object> { abiHandle, appBiatecConfigProvider }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///addressUdpater from global biatec configuration is allowed to update application
        ///No_op: NEVER, Opt_in: NEVER, Close_out: NEVER, Update_application: CALL, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider"> ABI Type is uint64  </param>
        /// <param name="newVersion"> ABI Type is byte[]  </param>
        public async Task updateApplication(ulong appBiatecConfigProvider, byte[] newVersion, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 95, 200, 133, 160 };
            var result = await base.CallApp(new List<object> { abiHandle, appBiatecConfigProvider, newVersion }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> updateApplication_Transactions(ulong appBiatecConfigProvider, byte[] newVersion, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 95, 200, 133, 160 };
            return await base.MakeTransactionList(new List<object> { abiHandle, appBiatecConfigProvider, newVersion }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="user"> ABI Type is address  </param>
        /// <param name="info"> ABI Type is (uint64,uint64,bool,string,string,uint64,uint64,uint64,uint64,uint64,uint64,bool,uint64,uint64,bool)  </param>
        public async Task selfRegistration(Address user, BiatecIdentityProviderReference.SelfRegistrationArgInfo info, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { user });
            byte[] abiHandle = { 232, 200, 238, 217 };
            var result = await base.CallApp(new List<object> { abiHandle, info }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> selfRegistration_Transactions(Address user, BiatecIdentityProviderReference.SelfRegistrationArgInfo info, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 232, 200, 238, 217 };
            return await base.MakeTransactionList(new List<object> { abiHandle, info }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="user"> ABI Type is address  </param>
        /// <param name="info"> ABI Type is (uint64,uint64,bool,string,string,uint64,uint64,uint64,uint64,uint64,uint64,bool,uint64,uint64,bool)  </param>
        public async Task setInfo(Address user, BiatecIdentityProviderReference.SetInfoArgInfo info, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { user });
            byte[] abiHandle = { 213, 131, 167, 89 };
            var result = await base.CallApp(new List<object> { abiHandle, info }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setInfo_Transactions(Address user, BiatecIdentityProviderReference.SetInfoArgInfo info, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 213, 131, 167, 89 };
            return await base.MakeTransactionList(new List<object> { abiHandle, info }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///addressExecutiveFee can perfom key registration for this LP pool
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider"> ABI Type is uint64  </param>
        /// <param name="votePK"> ABI Type is byte[]  </param>
        /// <param name="selectionPK"> ABI Type is byte[]  </param>
        /// <param name="stateProofPK"> ABI Type is byte[]  </param>
        /// <param name="voteFirst"> ABI Type is uint64  </param>
        /// <param name="voteLast"> ABI Type is uint64  </param>
        /// <param name="voteKeyDilution"> ABI Type is uint64  </param>
        public async Task sendOnlineKeyRegistration(ulong appBiatecConfigProvider, byte[] votePK, byte[] selectionPK, byte[] stateProofPK, ulong voteFirst, ulong voteLast, ulong voteKeyDilution, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 131, 146, 92, 23 };
            var result = await base.CallApp(new List<object> { abiHandle, appBiatecConfigProvider, votePK, selectionPK, stateProofPK, voteFirst, voteLast, voteKeyDilution }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> sendOnlineKeyRegistration_Transactions(ulong appBiatecConfigProvider, byte[] votePK, byte[] selectionPK, byte[] stateProofPK, ulong voteFirst, ulong voteLast, ulong voteKeyDilution, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 131, 146, 92, 23 };
            return await base.MakeTransactionList(new List<object> { abiHandle, appBiatecConfigProvider, votePK, selectionPK, stateProofPK, voteFirst, voteLast, voteKeyDilution }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Returns user information - fee multiplier, verification class, engagement class ..
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="user">Get info for specific user address ABI Type is address  </param>
        /// <param name="v">Version of the data structure to return ABI Type is uint8  </param>
        public async Task<BiatecIdentityProviderReference.GetUserReturn> getUser(Address user, byte v, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { user });
            byte[] abiHandle = { 153, 54, 161, 109 };
            var result = await base.CallApp(new List<object> { abiHandle, v }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            throw new Exception("Conversion not implemented"); // <unknown return conversion>

        }

        public async Task<List<Transaction>> getUser_Transactions(Address user, byte v, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 153, 54, 161, 109 };
            return await base.MakeTransactionList(new List<object> { abiHandle, v }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///If someone deposits excess assets to this smart contract biatec can use them.
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method. ABI Type is uint64  </param>
        /// <param name="asset">Asset to withdraw. If native token, then zero ABI Type is uint64  </param>
        /// <param name="amount">Amount of the asset to be withdrawn ABI Type is uint64  </param>
        public async Task<ulong> withdrawExcessAssets(ulong appBiatecConfigProvider, ulong asset, ulong amount, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 203, 162, 233, 93 };
            var result = await base.CallApp(new List<object> { abiHandle, appBiatecConfigProvider, asset, amount }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> withdrawExcessAssets_Transactions(ulong appBiatecConfigProvider, ulong asset, ulong amount, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef> _tx_boxes = null, List<Transaction> _tx_transactions = null, List<ulong> _tx_assets = null, List<ulong> _tx_apps = null, List<Address> _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 203, 162, 233, 93 };
            return await base.MakeTransactionList(new List<object> { abiHandle, appBiatecConfigProvider, asset, amount }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        //Initial setup
        public class createApplication_Arc4GroupTransaction : ProxyBase
        {
            public createApplication_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private createApplication_Arc4GroupTransaction() : base(null, 0) { }
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 184, 68, 123, 54 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Biatec deploys single identity provider smart contract
        public class bootstrap_Arc4GroupTransaction : ProxyBase
        {
            public bootstrap_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private bootstrap_Arc4GroupTransaction() : base(null, 0) { }
            //Biatec amm provider
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 160, 202, 223, 138 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { appBiatecConfigProvider }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //addressUdpater from global biatec configuration is allowed to update application
        public class updateApplication_Arc4GroupTransaction : ProxyBase
        {
            public updateApplication_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private updateApplication_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte> newVersion { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 95, 200, 133, 160 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, newVersion }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //
        public class selfRegistration_Arc4GroupTransaction : ProxyBase
        {
            public selfRegistration_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private selfRegistration_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.Address user { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Address)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.Tuple info { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Tuple)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("(uint64,uint64,bool,string,string,uint64,uint64,uint64,uint64,uint64,uint64,bool,uint64,uint64,bool)");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 232, 200, 238, 217 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { user, info }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //
        public class setInfo_Arc4GroupTransaction : ProxyBase
        {
            public setInfo_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setInfo_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.Address user { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Address)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.Tuple info { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Tuple)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("(uint64,uint64,bool,string,string,uint64,uint64,uint64,uint64,uint64,uint64,bool,uint64,uint64,bool)");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 213, 131, 167, 89 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { user, info }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //addressExecutiveFee can perfom key registration for this LP pool\\n\\n\\nOnly addressExecutiveFee is allowed to execute this method.
        public class sendOnlineKeyRegistration_Arc4GroupTransaction : ProxyBase
        {
            public sendOnlineKeyRegistration_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private sendOnlineKeyRegistration_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte> votePK { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte> selectionPK { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte> stateProofPK { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt voteFirst { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt voteLast { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt voteKeyDilution { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 131, 146, 92, 23 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, votePK, selectionPK, stateProofPK, voteFirst, voteLast, voteKeyDilution }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Returns user information - fee multiplier, verification class, engagement class ..
        public class getUser_Arc4GroupTransaction : ProxyBase
        {
            public getUser_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private getUser_Arc4GroupTransaction() : base(null, 0) { }
            //Get info for specific user address
            public AVM.ClientGenerator.ABI.ARC4.Types.Address user { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Address)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
            //Version of the data structure to return
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt v { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint8");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 153, 54, 161, 109 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { user, v }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //If someone deposits excess assets to this smart contract biatec can use them.\\n\\n\\nOnly addressExecutiveFee is allowed to execute this method.
        public class withdrawExcessAssets_Arc4GroupTransaction : ProxyBase
        {
            public withdrawExcessAssets_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private withdrawExcessAssets_Arc4GroupTransaction() : base(null, 0) { }
            //Biatec config app. Only addressExecutiveFee is allowed to execute this method.
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset to withdraw. If native token, then zero
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt asset { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Amount of the asset to be withdrawn
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt amount { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef> _tx_boxes = null)
            {

                byte[] abiHandle = { 203, 162, 233, 93 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, asset, amount }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        protected override string SourceApproval { get; set; } = "I3ByYWdtYSB2ZXJzaW9uIDEwCmludGNibG9jayAwIDEgMzIgMiAyNTYgNTUyIDY4OApieXRlY2Jsb2NrIDB4MDAwMDAwMDAwMDAwMDAwMCAweCAweDY5IDB4NDIgMHg3MyAweDAwIDB4MzAzMDMwMzAzMDMwMzAzMDJkMzAzMDMwMzAyZDMwMzAzMDMwMmQzMDMwMzAzMDJkMzAzMDMwMzAzMDMwMzAzMDMwMzAzMDMwIDB4RkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRiAweDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwM2I5YWNhMDAgMHgwMDAwMDAwMDc3MzU5NDAwIDB4MDAwMDAwMDAzYjlhY2EwMCAweDczNjM3NjY1NzIgMHgxNTFmN2M3NSAweDY1NjYKCi8vIFRoaXMgVEVBTCB3YXMgZ2VuZXJhdGVkIGJ5IFRFQUxTY3JpcHQgdjAuMTA2LjIKLy8gaHR0cHM6Ly9naXRodWIuY29tL2FsZ29yYW5kZm91bmRhdGlvbi9URUFMU2NyaXB0CgovLyBUaGlzIGNvbnRyYWN0IGlzIGNvbXBsaWFudCB3aXRoIGFuZC9vciBpbXBsZW1lbnRzIHRoZSBmb2xsb3dpbmcgQVJDczogWyBBUkM0IF0KCi8vIFRoZSBmb2xsb3dpbmcgdGVuIGxpbmVzIG9mIFRFQUwgaGFuZGxlIGluaXRpYWwgcHJvZ3JhbSBmbG93Ci8vIFRoaXMgcGF0dGVybiBpcyB1c2VkIHRvIG1ha2UgaXQgZWFzeSBmb3IgYW55b25lIHRvIHBhcnNlIHRoZSBzdGFydCBvZiB0aGUgcHJvZ3JhbSBhbmQgZGV0ZXJtaW5lIGlmIGEgc3BlY2lmaWMgYWN0aW9uIGlzIGFsbG93ZWQKLy8gSGVyZSwgYWN0aW9uIHJlZmVycyB0byB0aGUgT25Db21wbGV0ZSBpbiBjb21iaW5hdGlvbiB3aXRoIHdoZXRoZXIgdGhlIGFwcCBpcyBiZWluZyBjcmVhdGVkIG9yIGNhbGxlZAovLyBFdmVyeSBwb3NzaWJsZSBhY3Rpb24gZm9yIHRoaXMgY29udHJhY3QgaXMgcmVwcmVzZW50ZWQgaW4gdGhlIHN3aXRjaCBzdGF0ZW1lbnQKLy8gSWYgdGhlIGFjdGlvbiBpcyBub3QgaW1wbGVtZW50ZWQgaW4gdGhlIGNvbnRyYWN0LCBpdHMgcmVzcGVjdGl2ZSBicmFuY2ggd2lsbCBiZSAiKk5PVF9JTVBMRU1FTlRFRCIgd2hpY2gganVzdCBjb250YWlucyAiZXJyIgp0eG4gQXBwbGljYXRpb25JRAohCnB1c2hpbnQgNgoqCnR4biBPbkNvbXBsZXRpb24KKwpzd2l0Y2ggKmNhbGxfTm9PcCAqTk9UX0lNUExFTUVOVEVEICpOT1RfSU1QTEVNRU5URUQgKk5PVF9JTVBMRU1FTlRFRCAqY2FsbF9VcGRhdGVBcHBsaWNhdGlvbiAqTk9UX0lNUExFTUVOVEVEICpjcmVhdGVfTm9PcCAqTk9UX0lNUExFTUVOVEVEICpOT1RfSU1QTEVNRU5URUQgKk5PVF9JTVBMRU1FTlRFRCAqTk9UX0lNUExFTUVOVEVEICpOT1RfSU1QTEVNRU5URUQKCipOT1RfSU1QTEVNRU5URUQ6CgkvLyBUaGUgcmVxdWVzdGVkIGFjdGlvbiBpcyBub3QgaW1wbGVtZW50ZWQgaW4gdGhpcyBjb250cmFjdC4gQXJlIHlvdSB1c2luZyB0aGUgY29ycmVjdCBPbkNvbXBsZXRlPyBEaWQgeW91IHNldCB5b3VyIGFwcCBJRD8KCWVycgoKLy8gY3JlYXRlQXBwbGljYXRpb24oKXZvaWQKKmFiaV9yb3V0ZV9jcmVhdGVBcHBsaWNhdGlvbjoKCS8vIGV4ZWN1dGUgY3JlYXRlQXBwbGljYXRpb24oKXZvaWQKCWNhbGxzdWIgY3JlYXRlQXBwbGljYXRpb24KCWludGMgMSAvLyAxCglyZXR1cm4KCi8vIGNyZWF0ZUFwcGxpY2F0aW9uKCk6IHZvaWQKLy8KLy8gSW5pdGlhbCBzZXR1cApjcmVhdGVBcHBsaWNhdGlvbjoKCXByb3RvIDAgMAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MTU5CgkvLyB0aGlzLnZlcnNpb24udmFsdWUgPSB2ZXJzaW9uCglieXRlYyAxMSAvLyAgInNjdmVyIgoJcHVzaGJ5dGVzICJCSUFURUMtSURFTlQtMDEtMDItMDEiCglhcHBfZ2xvYmFsX3B1dAoJcmV0c3ViCgovLyBib290c3RyYXAodWludDY0KXZvaWQKKmFiaV9yb3V0ZV9ib290c3RyYXA6CgkvLyBhcHBCaWF0ZWNDb25maWdQcm92aWRlcjogdWludDY0Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglidG9pCgoJLy8gZXhlY3V0ZSBib290c3RyYXAodWludDY0KXZvaWQKCWNhbGxzdWIgYm9vdHN0cmFwCglpbnRjIDEgLy8gMQoJcmV0dXJuCgovLyBib290c3RyYXAoYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXI6IEFwcElEKTogdm9pZAovLwovLyBCaWF0ZWMgZGVwbG95cyBzaW5nbGUgaWRlbnRpdHkgcHJvdmlkZXIgc21hcnQgY29udHJhY3QKLy8gQHBhcmFtIGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyIEJpYXRlYyBhbW0gcHJvdmlkZXIKYm9vdHN0cmFwOgoJcHJvdG8gMSAwCgoJLy8gUHVzaCBlbXB0eSBieXRlcyBhZnRlciB0aGUgZnJhbWUgcG9pbnRlciB0byByZXNlcnZlIHNwYWNlIGZvciBsb2NhbCB2YXJpYWJsZXMKCWJ5dGVjIDEgLy8gMHgKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjE2NwoJLy8gYXNzZXJ0KHRoaXMudHhuLnNlbmRlciA9PT0gdGhpcy5hcHAuY3JlYXRvciwgJ09ubHkgY3JlYXRvciBvZiB0aGUgYXBwIGNhbiBzZXQgaXQgdXAnKQoJdHhuIFNlbmRlcgoJdHhuYSBBcHBsaWNhdGlvbnMgMAoJYXBwX3BhcmFtc19nZXQgQXBwQ3JlYXRvcgoJcG9wCgk9PQoKCS8vIE9ubHkgY3JlYXRvciBvZiB0aGUgYXBwIGNhbiBzZXQgaXQgdXAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MTY4CgkvLyB0aGlzLmFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLnZhbHVlID0gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXIKCWJ5dGVjIDMgLy8gICJCIgoJZnJhbWVfZGlnIC0xIC8vIGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyOiBBcHBJRAoJYXBwX2dsb2JhbF9wdXQKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjE2OQoJLy8gcGF1c2VkID0gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXIuZ2xvYmFsU3RhdGUoJ3MnKSBhcyB1aW50NjQKCWZyYW1lX2RpZyAtMSAvLyBhcHBCaWF0ZWNDb25maWdQcm92aWRlcjogQXBwSUQKCWJ5dGVjIDQgLy8gICJzIgoJYXBwX2dsb2JhbF9nZXRfZXgKCgkvLyBnbG9iYWwgc3RhdGUgdmFsdWUgZG9lcyBub3QgZXhpc3Q6IGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmdsb2JhbFN0YXRlKCdzJykKCWFzc2VydAoJZnJhbWVfYnVyeSAwIC8vIHBhdXNlZDogdWludDY0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoxNzAKCS8vIGFzc2VydChwYXVzZWQgPT09IDAsICdFUlJfUEFVU0VEJykKCWZyYW1lX2RpZyAwIC8vIHBhdXNlZDogdWludDY0CglpbnRjIDAgLy8gMAoJPT0KCgkvLyBFUlJfUEFVU0VECglhc3NlcnQKCXJldHN1YgoKLy8gdXBkYXRlQXBwbGljYXRpb24odWludDY0LGJ5dGVbXSl2b2lkCiphYmlfcm91dGVfdXBkYXRlQXBwbGljYXRpb246CgkvLyBuZXdWZXJzaW9uOiBieXRlW10KCXR4bmEgQXBwbGljYXRpb25BcmdzIDIKCWV4dHJhY3QgMiAwCgoJLy8gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXI6IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJYnRvaQoKCS8vIGV4ZWN1dGUgdXBkYXRlQXBwbGljYXRpb24odWludDY0LGJ5dGVbXSl2b2lkCgljYWxsc3ViIHVwZGF0ZUFwcGxpY2F0aW9uCglpbnRjIDEgLy8gMQoJcmV0dXJuCgovLyB1cGRhdGVBcHBsaWNhdGlvbihhcHBCaWF0ZWNDb25maWdQcm92aWRlcjogQXBwSUQsIG5ld1ZlcnNpb246IGJ5dGVzKTogdm9pZAovLwovLyBhZGRyZXNzVWRwYXRlciBmcm9tIGdsb2JhbCBiaWF0ZWMgY29uZmlndXJhdGlvbiBpcyBhbGxvd2VkIHRvIHVwZGF0ZSBhcHBsaWNhdGlvbgp1cGRhdGVBcHBsaWNhdGlvbjoKCXByb3RvIDIgMAoKCS8vIFB1c2ggZW1wdHkgYnl0ZXMgYWZ0ZXIgdGhlIGZyYW1lIHBvaW50ZXIgdG8gcmVzZXJ2ZSBzcGFjZSBmb3IgbG9jYWwgdmFyaWFibGVzCglieXRlYyAxIC8vIDB4CglkdXAKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjE3NwoJLy8gYXNzZXJ0KGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyID09PSB0aGlzLmFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLnZhbHVlLCAnQ29uZmlndXJhdGlvbiBhcHAgZG9lcyBub3QgbWF0Y2gnKQoJZnJhbWVfZGlnIC0xIC8vIGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyOiBBcHBJRAoJYnl0ZWMgMyAvLyAgIkIiCglhcHBfZ2xvYmFsX2dldAoJPT0KCgkvLyBDb25maWd1cmF0aW9uIGFwcCBkb2VzIG5vdCBtYXRjaAoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoxNzgKCS8vIGFkZHJlc3NVZHBhdGVyID0gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXIuZ2xvYmFsU3RhdGUoJ3UnKSBhcyBBZGRyZXNzCglmcmFtZV9kaWcgLTEgLy8gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXI6IEFwcElECglwdXNoYnl0ZXMgMHg3NSAvLyAidSIKCWFwcF9nbG9iYWxfZ2V0X2V4CgoJLy8gZ2xvYmFsIHN0YXRlIHZhbHVlIGRvZXMgbm90IGV4aXN0OiBhcHBCaWF0ZWNDb25maWdQcm92aWRlci5nbG9iYWxTdGF0ZSgndScpCglhc3NlcnQKCWZyYW1lX2J1cnkgMCAvLyBhZGRyZXNzVWRwYXRlcjogYWRkcmVzcwoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MTc5CgkvLyBhc3NlcnQodGhpcy50eG4uc2VuZGVyID09PSBhZGRyZXNzVWRwYXRlciwgJ09ubHkgYWRkcmVzc1VkcGF0ZXIgc2V0dXAgaW4gdGhlIGNvbmZpZyBjYW4gdXBkYXRlIGFwcGxpY2F0aW9uJykKCXR4biBTZW5kZXIKCWZyYW1lX2RpZyAwIC8vIGFkZHJlc3NVZHBhdGVyOiBhZGRyZXNzCgk9PQoKCS8vIE9ubHkgYWRkcmVzc1VkcGF0ZXIgc2V0dXAgaW4gdGhlIGNvbmZpZyBjYW4gdXBkYXRlIGFwcGxpY2F0aW9uCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjE4MAoJLy8gcGF1c2VkID0gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXIuZ2xvYmFsU3RhdGUoJ3MnKSBhcyB1aW50NjQKCWZyYW1lX2RpZyAtMSAvLyBhcHBCaWF0ZWNDb25maWdQcm92aWRlcjogQXBwSUQKCWJ5dGVjIDQgLy8gICJzIgoJYXBwX2dsb2JhbF9nZXRfZXgKCgkvLyBnbG9iYWwgc3RhdGUgdmFsdWUgZG9lcyBub3QgZXhpc3Q6IGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmdsb2JhbFN0YXRlKCdzJykKCWFzc2VydAoJZnJhbWVfYnVyeSAxIC8vIHBhdXNlZDogdWludDY0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoxODEKCS8vIGFzc2VydChwYXVzZWQgPT09IDAsICdFUlJfUEFVU0VEJykKCWZyYW1lX2RpZyAxIC8vIHBhdXNlZDogdWludDY0CglpbnRjIDAgLy8gMAoJPT0KCgkvLyBFUlJfUEFVU0VECglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjE4MgoJLy8gdGhpcy52ZXJzaW9uLnZhbHVlID0gbmV3VmVyc2lvbgoJYnl0ZWMgMTEgLy8gICJzY3ZlciIKCWZyYW1lX2RpZyAtMiAvLyBuZXdWZXJzaW9uOiBieXRlcwoJYXBwX2dsb2JhbF9wdXQKCXJldHN1YgoKLy8gc2VsZlJlZ2lzdHJhdGlvbihhZGRyZXNzLCh1aW50NjQsdWludDY0LGJvb2wsc3RyaW5nLHN0cmluZyx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCxib29sLHVpbnQ2NCx1aW50NjQsYm9vbCkpdm9pZAoqYWJpX3JvdXRlX3NlbGZSZWdpc3RyYXRpb246CgkvLyBpbmZvOiAodWludDY0LHVpbnQ2NCxib29sLHN0cmluZyxzdHJpbmcsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsYm9vbCx1aW50NjQsdWludDY0LGJvb2wpCgl0eG5hIEFwcGxpY2F0aW9uQXJncyAyCgoJLy8gdXNlcjogYWRkcmVzcwoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJZHVwCglsZW4KCWludGMgMiAvLyAzMgoJPT0KCgkvLyBhcmd1bWVudCAxICh1c2VyKSBmb3Igc2VsZlJlZ2lzdHJhdGlvbiBtdXN0IGJlIGEgYWRkcmVzcwoJYXNzZXJ0CgoJLy8gZXhlY3V0ZSBzZWxmUmVnaXN0cmF0aW9uKGFkZHJlc3MsKHVpbnQ2NCx1aW50NjQsYm9vbCxzdHJpbmcsc3RyaW5nLHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LGJvb2wsdWludDY0LHVpbnQ2NCxib29sKSl2b2lkCgljYWxsc3ViIHNlbGZSZWdpc3RyYXRpb24KCWludGMgMSAvLyAxCglyZXR1cm4KCi8vIHNlbGZSZWdpc3RyYXRpb24odXNlcjogQWRkcmVzcywgaW5mbzogSWRlbnRpdHlJbmZvKTogdm9pZApzZWxmUmVnaXN0cmF0aW9uOgoJcHJvdG8gMiAwCgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoxODYKCS8vIGFzc2VydCghdGhpcy5pZGVudGl0aWVzKHVzZXIpLmV4aXN0cywgJ1NlbGYgcmVnaXN0cmF0aW9uIGNhbm5vdCBiZSBleGVjdXRlZCBpZiBhZGRyZXNzIGlzIGFscmVhZHkgcmVnaXN0ZXJlZCcpCglieXRlYyAyIC8vICAiaSIKCWZyYW1lX2RpZyAtMSAvLyB1c2VyOiBBZGRyZXNzCgljb25jYXQKCWJveF9sZW4KCXN3YXAKCXBvcAoJIQoKCS8vIFNlbGYgcmVnaXN0cmF0aW9uIGNhbm5vdCBiZSBleGVjdXRlZCBpZiBhZGRyZXNzIGlzIGFscmVhZHkgcmVnaXN0ZXJlZAoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoxODkKCS8vIGFzc2VydChpbmZvLnZlcmlmaWNhdGlvblN0YXR1cyA9PT0gMSwgJ1ZlcmlmaWNhdGlvbiBzdGF0dXMgbXVzdCBiZSBlbXB0eScpCglmcmFtZV9kaWcgLTIgLy8gaW5mbzogSWRlbnRpdHlJbmZvCglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJZXh0cmFjdCAwIDgKCWJ0b2kKCWludGMgMSAvLyAxCgk9PQoKCS8vIFZlcmlmaWNhdGlvbiBzdGF0dXMgbXVzdCBiZSBlbXB0eQoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoxOTEKCS8vIGFzc2VydChpbmZvLnZlcmlmaWNhdGlvbkNsYXNzID09PSAwLCAndmVyaWZpY2F0aW9uQ2xhc3MgbXVzdCBlcXVhbCB0byAwJykKCWZyYW1lX2RpZyAtMiAvLyBpbmZvOiBJZGVudGl0eUluZm8KCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglleHRyYWN0IDggOAoJYnRvaQoJaW50YyAwIC8vIDAKCT09CgoJLy8gdmVyaWZpY2F0aW9uQ2xhc3MgbXVzdCBlcXVhbCB0byAwCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjE5NAoJLy8gYXNzZXJ0KAoJLy8gICAgICAgaW5mby5wZXJzb25VVUlEID09PSAnMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwJywKCS8vICAgICAgICdwZXJzb25VVUlEIG11c3QgZXF1YWwgdG8gMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwJwoJLy8gICAgICkKCWZyYW1lX2RpZyAtMiAvLyBpbmZvOiBJZGVudGl0eUluZm8KCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5CglwdXNoaW50IDE3Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5Cgl1bmNvdmVyIDIKCWV4dHJhY3RfdWludDE2CglkdXAgLy8gZHVwbGljYXRlIHN0YXJ0IG9mIGVsZW1lbnQKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCXN3YXAKCWV4dHJhY3RfdWludDE2IC8vIGdldCBudW1iZXIgb2YgZWxlbWVudHMKCWludGMgMSAvLyAgZ2V0IHR5cGUgbGVuZ3RoCgkqIC8vIG11bHRpcGx5IGJ5IHR5cGUgbGVuZ3RoCglpbnRjIDMgLy8gMgoJKyAvLyBhZGQgdHdvIGZvciBsZW5ndGgKCWV4dHJhY3QzCglleHRyYWN0IDIgMAoJYnl0ZWMgNiAvLyAgIjAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMCIKCT09CgoJLy8gcGVyc29uVVVJRCBtdXN0IGVxdWFsIHRvIDAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMAoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoxOTkKCS8vIGFzc2VydCgKCS8vICAgICAgIGluZm8ubGVnYWxFbnRpdHlVVUlEID09PSAnMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwJywKCS8vICAgICAgICdsZWdhbEVudGl0eVVVSUQgbXVzdCBlcXVhbCB0byAwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDAnCgkvLyAgICAgKQoJZnJhbWVfZGlnIC0yIC8vIGluZm86IElkZW50aXR5SW5mbwoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCXB1c2hpbnQgMTkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCXVuY292ZXIgMgoJZXh0cmFjdF91aW50MTYKCWR1cCAvLyBkdXBsaWNhdGUgc3RhcnQgb2YgZWxlbWVudAoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJc3dhcAoJZXh0cmFjdF91aW50MTYgLy8gZ2V0IG51bWJlciBvZiBlbGVtZW50cwoJaW50YyAxIC8vICBnZXQgdHlwZSBsZW5ndGgKCSogLy8gbXVsdGlwbHkgYnkgdHlwZSBsZW5ndGgKCWludGMgMyAvLyAyCgkrIC8vIGFkZCB0d28gZm9yIGxlbmd0aAoJZXh0cmFjdDMKCWV4dHJhY3QgMiAwCglieXRlYyA2IC8vICAiMDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwIgoJPT0KCgkvLyBsZWdhbEVudGl0eVVVSUQgbXVzdCBlcXVhbCB0byAwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjA0CgkvLyBhc3NlcnQoaW5mby5iaWF0ZWNFbmdhZ2VtZW50UG9pbnRzID09PSAwLCAnYmlhdGVjRW5nYWdlbWVudFBvaW50cyBtdXN0IGVxdWFsIHRvIDAnKQoJZnJhbWVfZGlnIC0yIC8vIGluZm86IElkZW50aXR5SW5mbwoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWV4dHJhY3QgMjEgOAoJYnRvaQoJaW50YyAwIC8vIDAKCT09CgoJLy8gYmlhdGVjRW5nYWdlbWVudFBvaW50cyBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjA2CgkvLyBhc3NlcnQoaW5mby5iaWF0ZWNFbmdhZ2VtZW50UmFuayA9PT0gMCwgJ2JpYXRlY0VuZ2FnZW1lbnRSYW5rIG11c3QgZXF1YWwgdG8gMCcpCglmcmFtZV9kaWcgLTIgLy8gaW5mbzogSWRlbnRpdHlJbmZvCglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJZXh0cmFjdCAyOSA4CglidG9pCglpbnRjIDAgLy8gMAoJPT0KCgkvLyBiaWF0ZWNFbmdhZ2VtZW50UmFuayBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjA4CgkvLyBhc3NlcnQoaW5mby5hdm1FbmdhZ2VtZW50UG9pbnRzID09PSAwLCAnYXZtRW5nYWdlbWVudFBvaW50cyBtdXN0IGVxdWFsIHRvIDAnKQoJZnJhbWVfZGlnIC0yIC8vIGluZm86IElkZW50aXR5SW5mbwoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWV4dHJhY3QgMzcgOAoJYnRvaQoJaW50YyAwIC8vIDAKCT09CgoJLy8gYXZtRW5nYWdlbWVudFBvaW50cyBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjEwCgkvLyBhc3NlcnQoaW5mby5hdm1FbmdhZ2VtZW50UmFuayA9PT0gMCwgJ2F2bUVuZ2FnZW1lbnRSYW5rIG11c3QgZXF1YWwgdG8gMCcpCglmcmFtZV9kaWcgLTIgLy8gaW5mbzogSWRlbnRpdHlJbmZvCglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJZXh0cmFjdCA0NSA4CglidG9pCglpbnRjIDAgLy8gMAoJPT0KCgkvLyBhdm1FbmdhZ2VtZW50UmFuayBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjEyCgkvLyBhc3NlcnQoaW5mby50cmFkaW5nRW5nYWdlbWVudFBvaW50cyA9PT0gMCwgJ3RyYWRpbmdFbmdhZ2VtZW50UG9pbnRzIG11c3QgZXF1YWwgdG8gMCcpCglmcmFtZV9kaWcgLTIgLy8gaW5mbzogSWRlbnRpdHlJbmZvCglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJZXh0cmFjdCA1MyA4CglidG9pCglpbnRjIDAgLy8gMAoJPT0KCgkvLyB0cmFkaW5nRW5nYWdlbWVudFBvaW50cyBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjE0CgkvLyBhc3NlcnQoaW5mby50cmFkaW5nRW5nYWdlbWVudFJhbmsgPT09IDAsICd0cmFkaW5nRW5nYWdlbWVudFJhbmsgbXVzdCBlcXVhbCB0byAwJykKCWZyYW1lX2RpZyAtMiAvLyBpbmZvOiBJZGVudGl0eUluZm8KCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglleHRyYWN0IDYxIDgKCWJ0b2kKCWludGMgMCAvLyAwCgk9PQoKCS8vIHRyYWRpbmdFbmdhZ2VtZW50UmFuayBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjE2CgkvLyBhc3NlcnQoaW5mby5pc0xvY2tlZCA9PT0gZmFsc2UsICdpc0xvY2tlZCBtdXN0IGVxdWFsIHRvIGZhbHNlJykKCWZyYW1lX2RpZyAtMiAvLyBpbmZvOiBJZGVudGl0eUluZm8KCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglpbnRjIDUgLy8gNTUyCglnZXRiaXQKCWludGMgMCAvLyAwCgk9PQoKCS8vIGlzTG9ja2VkIG11c3QgZXF1YWwgdG8gZmFsc2UKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjE4CgkvLyBhc3NlcnQoaW5mby5reWNFeHBpcmF0aW9uID09PSAwLCAna3ljRXhwaXJhdGlvbiBtdXN0IGVxdWFsIHRvIDAnKQoJZnJhbWVfZGlnIC0yIC8vIGluZm86IElkZW50aXR5SW5mbwoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWV4dHJhY3QgNzAgOAoJYnRvaQoJaW50YyAwIC8vIDAKCT09CgoJLy8ga3ljRXhwaXJhdGlvbiBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjIwCgkvLyBhc3NlcnQoaW5mby5pbnZlc3RvckZvckV4cGlyYXRpb24gPT09IDAsICdpbnZlc3RvckZvckV4cGlyYXRpb24gbXVzdCBlcXVhbCB0byAwJykKCWZyYW1lX2RpZyAtMiAvLyBpbmZvOiBJZGVudGl0eUluZm8KCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglleHRyYWN0IDc4IDgKCWJ0b2kKCWludGMgMCAvLyAwCgk9PQoKCS8vIGludmVzdG9yRm9yRXhwaXJhdGlvbiBtdXN0IGVxdWFsIHRvIDAKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjIyCgkvLyBhc3NlcnQoaW5mby5pc1Byb2Zlc3Npb25hbEludmVzdG9yID09PSBmYWxzZSwgJ2lzUHJvZmVzc2lvbmFsSW52ZXN0b3IgbXVzdCBlcXVhbCB0byBmYWxzZScpCglmcmFtZV9kaWcgLTIgLy8gaW5mbzogSWRlbnRpdHlJbmZvCglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJaW50YyA2IC8vIDY4OAoJZ2V0Yml0CglpbnRjIDAgLy8gMAoJPT0KCgkvLyBpc1Byb2Zlc3Npb25hbEludmVzdG9yIG11c3QgZXF1YWwgdG8gZmFsc2UKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjI0CgkvLyB0aGlzLmlkZW50aXRpZXModXNlcikudmFsdWUgPSBpbmZvCglieXRlYyAyIC8vICAiaSIKCWZyYW1lX2RpZyAtMSAvLyB1c2VyOiBBZGRyZXNzCgljb25jYXQKCWR1cAoJYm94X2RlbAoJcG9wCglmcmFtZV9kaWcgLTIgLy8gaW5mbzogSWRlbnRpdHlJbmZvCglib3hfcHV0CglyZXRzdWIKCi8vIHNldEluZm8oYWRkcmVzcywodWludDY0LHVpbnQ2NCxib29sLHN0cmluZyxzdHJpbmcsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsYm9vbCx1aW50NjQsdWludDY0LGJvb2wpKXZvaWQKKmFiaV9yb3V0ZV9zZXRJbmZvOgoJLy8gaW5mbzogKHVpbnQ2NCx1aW50NjQsYm9vbCxzdHJpbmcsc3RyaW5nLHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LGJvb2wsdWludDY0LHVpbnQ2NCxib29sKQoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMgoKCS8vIHVzZXI6IGFkZHJlc3MKCXR4bmEgQXBwbGljYXRpb25BcmdzIDEKCWR1cAoJbGVuCglpbnRjIDIgLy8gMzIKCT09CgoJLy8gYXJndW1lbnQgMSAodXNlcikgZm9yIHNldEluZm8gbXVzdCBiZSBhIGFkZHJlc3MKCWFzc2VydAoKCS8vIGV4ZWN1dGUgc2V0SW5mbyhhZGRyZXNzLCh1aW50NjQsdWludDY0LGJvb2wsc3RyaW5nLHN0cmluZyx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCxib29sLHVpbnQ2NCx1aW50NjQsYm9vbCkpdm9pZAoJY2FsbHN1YiBzZXRJbmZvCglpbnRjIDEgLy8gMQoJcmV0dXJuCgovLyBzZXRJbmZvKHVzZXI6IEFkZHJlc3MsIGluZm86IElkZW50aXR5SW5mbyk6IHZvaWQKc2V0SW5mbzoKCXByb3RvIDIgMAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjI4CgkvLyBhc3NlcnQodGhpcy50eG4uc2VuZGVyID09PSB0aGlzLmVuZ2FnZW1lbnRTZXR0ZXIudmFsdWUpCgl0eG4gU2VuZGVyCglwdXNoYnl0ZXMgMHg2NSAvLyAiZSIKCWFwcF9nbG9iYWxfZ2V0Cgk9PQoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyMjkKCS8vIHRoaXMuaWRlbnRpdGllcyh1c2VyKS52YWx1ZSA9IGluZm8KCWJ5dGVjIDIgLy8gICJpIgoJZnJhbWVfZGlnIC0xIC8vIHVzZXI6IEFkZHJlc3MKCWNvbmNhdAoJZHVwCglib3hfZGVsCglwb3AKCWZyYW1lX2RpZyAtMiAvLyBpbmZvOiBJZGVudGl0eUluZm8KCWJveF9wdXQKCXJldHN1YgoKLy8gc2VuZE9ubGluZUtleVJlZ2lzdHJhdGlvbih1aW50NjQsYnl0ZVtdLGJ5dGVbXSxieXRlW10sdWludDY0LHVpbnQ2NCx1aW50NjQpdm9pZAoqYWJpX3JvdXRlX3NlbmRPbmxpbmVLZXlSZWdpc3RyYXRpb246CgkvLyB2b3RlS2V5RGlsdXRpb246IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgNwoJYnRvaQoKCS8vIHZvdGVMYXN0OiB1aW50NjQKCXR4bmEgQXBwbGljYXRpb25BcmdzIDYKCWJ0b2kKCgkvLyB2b3RlRmlyc3Q6IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgNQoJYnRvaQoKCS8vIHN0YXRlUHJvb2ZQSzogYnl0ZVtdCgl0eG5hIEFwcGxpY2F0aW9uQXJncyA0CglleHRyYWN0IDIgMAoKCS8vIHNlbGVjdGlvblBLOiBieXRlW10KCXR4bmEgQXBwbGljYXRpb25BcmdzIDMKCWV4dHJhY3QgMiAwCgoJLy8gdm90ZVBLOiBieXRlW10KCXR4bmEgQXBwbGljYXRpb25BcmdzIDIKCWV4dHJhY3QgMiAwCgoJLy8gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXI6IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJYnRvaQoKCS8vIGV4ZWN1dGUgc2VuZE9ubGluZUtleVJlZ2lzdHJhdGlvbih1aW50NjQsYnl0ZVtdLGJ5dGVbXSxieXRlW10sdWludDY0LHVpbnQ2NCx1aW50NjQpdm9pZAoJY2FsbHN1YiBzZW5kT25saW5lS2V5UmVnaXN0cmF0aW9uCglpbnRjIDEgLy8gMQoJcmV0dXJuCgovLyBzZW5kT25saW5lS2V5UmVnaXN0cmF0aW9uKGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyOiBBcHBJRCwgdm90ZVBLOiBieXRlcywgc2VsZWN0aW9uUEs6IGJ5dGVzLCBzdGF0ZVByb29mUEs6IGJ5dGVzLCB2b3RlRmlyc3Q6IHVpbnQ2NCwgdm90ZUxhc3Q6IHVpbnQ2NCwgdm90ZUtleURpbHV0aW9uOiB1aW50NjQpOiB2b2lkCi8vCi8vIGFkZHJlc3NFeGVjdXRpdmVGZWUgY2FuIHBlcmZvbSBrZXkgcmVnaXN0cmF0aW9uIGZvciB0aGlzIExQIHBvb2wKLy8KLy8gT25seSBhZGRyZXNzRXhlY3V0aXZlRmVlIGlzIGFsbG93ZWQgdG8gZXhlY3V0ZSB0aGlzIG1ldGhvZC4Kc2VuZE9ubGluZUtleVJlZ2lzdHJhdGlvbjoKCXByb3RvIDcgMAoKCS8vIFB1c2ggZW1wdHkgYnl0ZXMgYWZ0ZXIgdGhlIGZyYW1lIHBvaW50ZXIgdG8gcmVzZXJ2ZSBzcGFjZSBmb3IgbG9jYWwgdmFyaWFibGVzCglieXRlYyAxIC8vIDB4CglkdXAKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI0NgoJLy8gYXNzZXJ0KGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyID09PSB0aGlzLmFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLnZhbHVlLCAnQ29uZmlndXJhdGlvbiBhcHAgZG9lcyBub3QgbWF0Y2gnKQoJZnJhbWVfZGlnIC0xIC8vIGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyOiBBcHBJRAoJYnl0ZWMgMyAvLyAgIkIiCglhcHBfZ2xvYmFsX2dldAoJPT0KCgkvLyBDb25maWd1cmF0aW9uIGFwcCBkb2VzIG5vdCBtYXRjaAoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyNDcKCS8vIGFkZHJlc3NFeGVjdXRpdmVGZWUgPSBhcHBCaWF0ZWNDb25maWdQcm92aWRlci5nbG9iYWxTdGF0ZSgnZWYnKSBhcyBBZGRyZXNzCglmcmFtZV9kaWcgLTEgLy8gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXI6IEFwcElECglieXRlYyAxMyAvLyAgImVmIgoJYXBwX2dsb2JhbF9nZXRfZXgKCgkvLyBnbG9iYWwgc3RhdGUgdmFsdWUgZG9lcyBub3QgZXhpc3Q6IGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmdsb2JhbFN0YXRlKCdlZicpCglhc3NlcnQKCWZyYW1lX2J1cnkgMCAvLyBhZGRyZXNzRXhlY3V0aXZlRmVlOiBhZGRyZXNzCgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyNDgKCS8vIGFzc2VydCgKCS8vICAgICAgIHRoaXMudHhuLnNlbmRlciA9PT0gYWRkcmVzc0V4ZWN1dGl2ZUZlZSwKCS8vICAgICAgICdPbmx5IGZlZSBleGVjdXRvciBzZXR1cCBpbiB0aGUgY29uZmlnIGNhbiB0YWtlIHRoZSBjb2xsZWN0ZWQgZmVlcycKCS8vICAgICApCgl0eG4gU2VuZGVyCglmcmFtZV9kaWcgMCAvLyBhZGRyZXNzRXhlY3V0aXZlRmVlOiBhZGRyZXNzCgk9PQoKCS8vIE9ubHkgZmVlIGV4ZWN1dG9yIHNldHVwIGluIHRoZSBjb25maWcgY2FuIHRha2UgdGhlIGNvbGxlY3RlZCBmZWVzCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI1MgoJLy8gcGF1c2VkID0gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXIuZ2xvYmFsU3RhdGUoJ3MnKSBhcyB1aW50NjQKCWZyYW1lX2RpZyAtMSAvLyBhcHBCaWF0ZWNDb25maWdQcm92aWRlcjogQXBwSUQKCWJ5dGVjIDQgLy8gICJzIgoJYXBwX2dsb2JhbF9nZXRfZXgKCgkvLyBnbG9iYWwgc3RhdGUgdmFsdWUgZG9lcyBub3QgZXhpc3Q6IGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmdsb2JhbFN0YXRlKCdzJykKCWFzc2VydAoJZnJhbWVfYnVyeSAxIC8vIHBhdXNlZDogdWludDY0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyNTMKCS8vIGFzc2VydChwYXVzZWQgPT09IDAsICdFUlJfUEFVU0VEJykKCWZyYW1lX2RpZyAxIC8vIHBhdXNlZDogdWludDY0CglpbnRjIDAgLy8gMAoJPT0KCgkvLyBFUlJfUEFVU0VECglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI1NAoJLy8gc2VuZE9ubGluZUtleVJlZ2lzdHJhdGlvbih7CgkvLyAgICAgICBzZWxlY3Rpb25QSzogc2VsZWN0aW9uUEssCgkvLyAgICAgICBzdGF0ZVByb29mUEs6IHN0YXRlUHJvb2ZQSywKCS8vICAgICAgIHZvdGVGaXJzdDogdm90ZUZpcnN0LAoJLy8gICAgICAgdm90ZUtleURpbHV0aW9uOiB2b3RlS2V5RGlsdXRpb24sCgkvLyAgICAgICB2b3RlTGFzdDogdm90ZUxhc3QsCgkvLyAgICAgICB2b3RlUEs6IHZvdGVQSywKCS8vICAgICAgIGZlZTogMCwKCS8vICAgICB9KQoJaXR4bl9iZWdpbgoJaW50YyAzIC8vICBrZXlyZWcKCWl0eG5fZmllbGQgVHlwZUVudW0KCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI1NQoJLy8gc2VsZWN0aW9uUEs6IHNlbGVjdGlvblBLCglmcmFtZV9kaWcgLTMgLy8gc2VsZWN0aW9uUEs6IGJ5dGVzCglpdHhuX2ZpZWxkIFNlbGVjdGlvblBLCgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyNTYKCS8vIHN0YXRlUHJvb2ZQSzogc3RhdGVQcm9vZlBLCglmcmFtZV9kaWcgLTQgLy8gc3RhdGVQcm9vZlBLOiBieXRlcwoJaXR4bl9maWVsZCBTdGF0ZVByb29mUEsKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI1NwoJLy8gdm90ZUZpcnN0OiB2b3RlRmlyc3QKCWZyYW1lX2RpZyAtNSAvLyB2b3RlRmlyc3Q6IHVpbnQ2NAoJaXR4bl9maWVsZCBWb3RlRmlyc3QKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI1OAoJLy8gdm90ZUtleURpbHV0aW9uOiB2b3RlS2V5RGlsdXRpb24KCWZyYW1lX2RpZyAtNyAvLyB2b3RlS2V5RGlsdXRpb246IHVpbnQ2NAoJaXR4bl9maWVsZCBWb3RlS2V5RGlsdXRpb24KCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI1OQoJLy8gdm90ZUxhc3Q6IHZvdGVMYXN0CglmcmFtZV9kaWcgLTYgLy8gdm90ZUxhc3Q6IHVpbnQ2NAoJaXR4bl9maWVsZCBWb3RlTGFzdAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjYwCgkvLyB2b3RlUEs6IHZvdGVQSwoJZnJhbWVfZGlnIC0yIC8vIHZvdGVQSzogYnl0ZXMKCWl0eG5fZmllbGQgVm90ZVBLCgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyNjEKCS8vIGZlZTogMAoJaW50YyAwIC8vIDAKCWl0eG5fZmllbGQgRmVlCgoJLy8gU3VibWl0IGlubmVyIHRyYW5zYWN0aW9uCglpdHhuX3N1Ym1pdAoJcmV0c3ViCgovLyBnZXRVc2VyKGFkZHJlc3MsdWludDgpKHVpbnQ4LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDI1Nix1aW50MjU2LGJvb2wsdWludDY0LHVpbnQ2NCxib29sKQoqYWJpX3JvdXRlX2dldFVzZXI6CgkvLyBUaGUgQUJJIHJldHVybiBwcmVmaXgKCWJ5dGVjIDEyIC8vIDB4MTUxZjdjNzUKCgkvLyB2OiB1aW50OAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMgoJZHVwCglsZW4KCWludGMgMSAvLyAxCgk9PQoKCS8vIGFyZ3VtZW50IDAgKHYpIGZvciBnZXRVc2VyIG11c3QgYmUgYSB1aW50OAoJYXNzZXJ0CglidG9pCgoJLy8gdXNlcjogYWRkcmVzcwoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJZHVwCglsZW4KCWludGMgMiAvLyAzMgoJPT0KCgkvLyBhcmd1bWVudCAxICh1c2VyKSBmb3IgZ2V0VXNlciBtdXN0IGJlIGEgYWRkcmVzcwoJYXNzZXJ0CgoJLy8gZXhlY3V0ZSBnZXRVc2VyKGFkZHJlc3MsdWludDgpKHVpbnQ4LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDI1Nix1aW50MjU2LGJvb2wsdWludDY0LHVpbnQ2NCxib29sKQoJY2FsbHN1YiBnZXRVc2VyCgljb25jYXQKCWxvZwoJaW50YyAxIC8vIDEKCXJldHVybgoKLy8gZ2V0VXNlcih1c2VyOiBBZGRyZXNzLCB2OiB1aW50OCk6IFVzZXJJbmZvVjEKLy8KLy8gUmV0dXJucyB1c2VyIGluZm9ybWF0aW9uIC0gZmVlIG11bHRpcGxpZXIsIHZlcmlmaWNhdGlvbiBjbGFzcywgZW5nYWdlbWVudCBjbGFzcyAuLgovLwovLyBAcGFyYW0gdXNlciBHZXQgaW5mbyBmb3Igc3BlY2lmaWMgdXNlciBhZGRyZXNzCi8vIEBwYXJhbSB2IFZlcnNpb24gb2YgdGhlIGRhdGEgc3RydWN0dXJlIHRvIHJldHVybgpnZXRVc2VyOgoJcHJvdG8gMiAxCgoJLy8gUHVzaCBlbXB0eSBieXRlcyBhZnRlciB0aGUgZnJhbWUgcG9pbnRlciB0byByZXNlcnZlIHNwYWNlIGZvciBsb2NhbCB2YXJpYWJsZXMKCWJ5dGVjIDEgLy8gMHgKCWR1cG4gMgoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjczCgkvLyBhc3NlcnQodiA9PT0gMSwgIkN1cnJlbnRseSBzdXBwb3J0ZWQgdmVyc2lvbiBvZiB0aGUgZGF0YSBzdHJ1Y3R1cmUgaXMgJzEnIikKCWZyYW1lX2RpZyAtMiAvLyB2OiB1aW50OAoJaW50YyAxIC8vIDEKCT09CgoJLy8gQ3VycmVudGx5IHN1cHBvcnRlZCB2ZXJzaW9uIG9mIHRoZSBkYXRhIHN0cnVjdHVyZSBpcyAnMScKCWFzc2VydAoKCS8vICppZjBfY29uZGl0aW9uCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjI3NAoJLy8gIXRoaXMuaWRlbnRpdGllcyh1c2VyKS5leGlzdHMKCWJ5dGVjIDIgLy8gICJpIgoJZnJhbWVfZGlnIC0xIC8vIHVzZXI6IEFkZHJlc3MKCWNvbmNhdAoJYm94X2xlbgoJc3dhcAoJcG9wCgkhCglieiAqaWYwX2VuZAoKCS8vICppZjBfY29uc2VxdWVudAoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyNzUKCS8vIHJldE5vSWRlbnRpdHk6IFVzZXJJbmZvVjEgPSB7CgkvLyAgICAgICAgIHZlcnNpb246IHYsCgkvLyAgICAgICAgIGJhc2U6IFNDQUxFIGFzIHVpbnQyNTYsCgkvLyAgICAgICAgIGZlZU11bHRpcGxpZXI6ICgyICogU0NBTEUpIGFzIHVpbnQyNTYsCgkvLyAgICAgICAgIGlzTG9ja2VkOiBmYWxzZSwKCS8vICAgICAgICAgdmVyaWZpY2F0aW9uQ2xhc3M6IDAsCgkvLyAgICAgICAgIHZlcmlmaWNhdGlvblN0YXR1czogMCwKCS8vICAgICAgICAgYmlhdGVjRW5nYWdlbWVudFBvaW50czogMCwKCS8vICAgICAgICAgYmlhdGVjRW5nYWdlbWVudFJhbms6IDAsCgkvLyAgICAgICAgIGF2bUVuZ2FnZW1lbnRQb2ludHM6IDAsCgkvLyAgICAgICAgIGF2bUVuZ2FnZW1lbnRSYW5rOiAwLAoJLy8gICAgICAgICB0cmFkaW5nRW5nYWdlbWVudFBvaW50czogMCwKCS8vICAgICAgICAgdHJhZGluZ0VuZ2FnZW1lbnRSYW5rOiAwLAoJLy8gICAgICAgICBreWNFeHBpcmF0aW9uOiAwLAoJLy8gICAgICAgICBpbnZlc3RvckZvckV4cGlyYXRpb246IDAsCgkvLyAgICAgICAgIGlzUHJvZmVzc2lvbmFsSW52ZXN0b3I6IGZhbHNlLAoJLy8gICAgICAgfQoJZnJhbWVfZGlnIC0yIC8vIHY6IHVpbnQ4CglpdG9iCglleHRyYWN0IDcgMQoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgMCAvLyAweDAwMDAwMDAwMDAwMDAwMDAKCWNvbmNhdAoJYnl0ZWMgOSAvLyAweDAwMDAwMDAwNzczNTk0MDAKCWR1cAoJYml0bGVuCglpbnRjIDQgLy8gMjU2Cgk8PQoKCS8vICgyICogU0NBTEUpIGFzIHVpbnQyNTYgb3ZlcmZsb3dlZCAyNTYgYml0cwoJYXNzZXJ0CglieXRlYyA3IC8vIDB4RkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRgoJYiYKCWR1cAoJbGVuCglkdXAKCWludGMgMiAvLyAzMgoJLQoJc3dhcAoJc3Vic3RyaW5nMwoJY29uY2F0CglieXRlYyA4IC8vIDB4MDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAzYjlhY2EwMAoJY29uY2F0CglieXRlYyA1IC8vIDB4MDAKCWludGMgMCAvLyAwCglkdXAKCXNldGJpdAoJY29uY2F0IC8vIDEyCglieXRlYyAwIC8vIDB4MDAwMDAwMDAwMDAwMDAwMAoJY29uY2F0CglieXRlYyAwIC8vIDB4MDAwMDAwMDAwMDAwMDAwMAoJY29uY2F0CglieXRlYyA1IC8vIDB4MDAKCWludGMgMCAvLyAwCglkdXAKCXNldGJpdAoJY29uY2F0CglmcmFtZV9idXJ5IDAgLy8gcmV0Tm9JZGVudGl0eTogVXNlckluZm9WMQoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MjkyCgkvLyByZXR1cm4gcmV0Tm9JZGVudGl0eTsKCWZyYW1lX2RpZyAwIC8vIHJldE5vSWRlbnRpdHk6IFVzZXJJbmZvVjEKCWIgKmdldFVzZXIqcmV0dXJuCgoqaWYwX2VuZDoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6Mjk0CgkvLyBpZGVudGl0eSA9IHRoaXMuaWRlbnRpdGllcyh1c2VyKS52YWx1ZQoJYnl0ZWMgMiAvLyAgImkiCglmcmFtZV9kaWcgLTEgLy8gdXNlcjogQWRkcmVzcwoJY29uY2F0CglmcmFtZV9idXJ5IDEgLy8gc3RvcmFnZSBrZXkvL2lkZW50aXR5CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czoyOTYKCS8vIHJldDogVXNlckluZm9WMSA9IHsKCS8vICAgICAgIHZlcnNpb246IHYsCgkvLyAgICAgICBiYXNlOiBTQ0FMRSBhcyB1aW50MjU2LAoJLy8gICAgICAgZmVlTXVsdGlwbGllcjogKDEgKiBTQ0FMRSkgYXMgdWludDI1NiwKCS8vICAgICAgIGlzTG9ja2VkOiBpZGVudGl0eS5pc0xvY2tlZCwKCS8vICAgICAgIHZlcmlmaWNhdGlvbkNsYXNzOiBpZGVudGl0eS52ZXJpZmljYXRpb25DbGFzcywKCS8vICAgICAgIHZlcmlmaWNhdGlvblN0YXR1czogaWRlbnRpdHkudmVyaWZpY2F0aW9uU3RhdHVzLAoJLy8gICAgICAgYmlhdGVjRW5nYWdlbWVudFBvaW50czogaWRlbnRpdHkuYmlhdGVjRW5nYWdlbWVudFBvaW50cywKCS8vICAgICAgIGJpYXRlY0VuZ2FnZW1lbnRSYW5rOiBpZGVudGl0eS5iaWF0ZWNFbmdhZ2VtZW50UmFuaywKCS8vICAgICAgIGF2bUVuZ2FnZW1lbnRQb2ludHM6IGlkZW50aXR5LmF2bUVuZ2FnZW1lbnRQb2ludHMsCgkvLyAgICAgICBhdm1FbmdhZ2VtZW50UmFuazogaWRlbnRpdHkuYXZtRW5nYWdlbWVudFJhbmssCgkvLyAgICAgICB0cmFkaW5nRW5nYWdlbWVudFBvaW50czogaWRlbnRpdHkudHJhZGluZ0VuZ2FnZW1lbnRQb2ludHMsCgkvLyAgICAgICB0cmFkaW5nRW5nYWdlbWVudFJhbms6IGlkZW50aXR5LnRyYWRpbmdFbmdhZ2VtZW50UmFuaywKCS8vICAgICAgIGt5Y0V4cGlyYXRpb246IGlkZW50aXR5Lmt5Y0V4cGlyYXRpb24sCgkvLyAgICAgICBpbnZlc3RvckZvckV4cGlyYXRpb246IGlkZW50aXR5LmludmVzdG9yRm9yRXhwaXJhdGlvbiwKCS8vICAgICAgIGlzUHJvZmVzc2lvbmFsSW52ZXN0b3I6IGlkZW50aXR5LmlzUHJvZmVzc2lvbmFsSW52ZXN0b3IsCgkvLyAgICAgfQoJZnJhbWVfZGlnIC0yIC8vIHY6IHVpbnQ4CglpdG9iCglleHRyYWN0IDcgMQoJZnJhbWVfZGlnIDEgLy8gc3RvcmFnZSBrZXkvL2lkZW50aXR5Cglib3hfZ2V0CgoJLy8gYm94IHZhbHVlIGRvZXMgbm90IGV4aXN0OiB0aGlzLmlkZW50aXRpZXModXNlcikudmFsdWUKCWFzc2VydAoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWV4dHJhY3QgMCA4CglidG9pCglpdG9iCgljb25jYXQKCWZyYW1lX2RpZyAxIC8vIHN0b3JhZ2Uga2V5Ly9pZGVudGl0eQoJYm94X2dldAoKCS8vIGJveCB2YWx1ZSBkb2VzIG5vdCBleGlzdDogdGhpcy5pZGVudGl0aWVzKHVzZXIpLnZhbHVlCglhc3NlcnQKCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglleHRyYWN0IDggOAoJYnRvaQoJaXRvYgoJY29uY2F0CglmcmFtZV9kaWcgMSAvLyBzdG9yYWdlIGtleS8vaWRlbnRpdHkKCWJveF9nZXQKCgkvLyBib3ggdmFsdWUgZG9lcyBub3QgZXhpc3Q6IHRoaXMuaWRlbnRpdGllcyh1c2VyKS52YWx1ZQoJYXNzZXJ0CglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJZXh0cmFjdCAyMSA4CglidG9pCglpdG9iCgljb25jYXQKCWZyYW1lX2RpZyAxIC8vIHN0b3JhZ2Uga2V5Ly9pZGVudGl0eQoJYm94X2dldAoKCS8vIGJveCB2YWx1ZSBkb2VzIG5vdCBleGlzdDogdGhpcy5pZGVudGl0aWVzKHVzZXIpLnZhbHVlCglhc3NlcnQKCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglleHRyYWN0IDI5IDgKCWJ0b2kKCWl0b2IKCWNvbmNhdAoJZnJhbWVfZGlnIDEgLy8gc3RvcmFnZSBrZXkvL2lkZW50aXR5Cglib3hfZ2V0CgoJLy8gYm94IHZhbHVlIGRvZXMgbm90IGV4aXN0OiB0aGlzLmlkZW50aXRpZXModXNlcikudmFsdWUKCWFzc2VydAoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWV4dHJhY3QgMzcgOAoJYnRvaQoJaXRvYgoJY29uY2F0CglmcmFtZV9kaWcgMSAvLyBzdG9yYWdlIGtleS8vaWRlbnRpdHkKCWJveF9nZXQKCgkvLyBib3ggdmFsdWUgZG9lcyBub3QgZXhpc3Q6IHRoaXMuaWRlbnRpdGllcyh1c2VyKS52YWx1ZQoJYXNzZXJ0CglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJZXh0cmFjdCA0NSA4CglidG9pCglpdG9iCgljb25jYXQKCWZyYW1lX2RpZyAxIC8vIHN0b3JhZ2Uga2V5Ly9pZGVudGl0eQoJYm94X2dldAoKCS8vIGJveCB2YWx1ZSBkb2VzIG5vdCBleGlzdDogdGhpcy5pZGVudGl0aWVzKHVzZXIpLnZhbHVlCglhc3NlcnQKCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglleHRyYWN0IDUzIDgKCWJ0b2kKCWl0b2IKCWNvbmNhdAoJZnJhbWVfZGlnIDEgLy8gc3RvcmFnZSBrZXkvL2lkZW50aXR5Cglib3hfZ2V0CgoJLy8gYm94IHZhbHVlIGRvZXMgbm90IGV4aXN0OiB0aGlzLmlkZW50aXRpZXModXNlcikudmFsdWUKCWFzc2VydAoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWV4dHJhY3QgNjEgOAoJYnRvaQoJaXRvYgoJY29uY2F0CglieXRlYyAxMCAvLyAweDAwMDAwMDAwM2I5YWNhMDAKCWR1cAoJYml0bGVuCglpbnRjIDQgLy8gMjU2Cgk8PQoKCS8vICgxICogU0NBTEUpIGFzIHVpbnQyNTYgb3ZlcmZsb3dlZCAyNTYgYml0cwoJYXNzZXJ0CglieXRlYyA3IC8vIDB4RkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRkZGRgoJYiYKCWR1cAoJbGVuCglkdXAKCWludGMgMiAvLyAzMgoJLQoJc3dhcAoJc3Vic3RyaW5nMwoJY29uY2F0CglieXRlYyA4IC8vIDB4MDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAzYjlhY2EwMAoJY29uY2F0CglieXRlYyA1IC8vIDB4MDAKCWludGMgMCAvLyAwCglmcmFtZV9kaWcgMSAvLyBzdG9yYWdlIGtleS8vaWRlbnRpdHkKCWJveF9nZXQKCgkvLyBib3ggdmFsdWUgZG9lcyBub3QgZXhpc3Q6IHRoaXMuaWRlbnRpdGllcyh1c2VyKS52YWx1ZQoJYXNzZXJ0CglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJaW50YyA1IC8vIDU1MgoJZ2V0Yml0CglzZXRiaXQKCWNvbmNhdCAvLyAxMgoJZnJhbWVfZGlnIDEgLy8gc3RvcmFnZSBrZXkvL2lkZW50aXR5Cglib3hfZ2V0CgoJLy8gYm94IHZhbHVlIGRvZXMgbm90IGV4aXN0OiB0aGlzLmlkZW50aXRpZXModXNlcikudmFsdWUKCWFzc2VydAoJc3RvcmUgMjU1IC8vIGZ1bGwgYXJyYXkKCWxvYWQgMjU1IC8vIGZ1bGwgYXJyYXkKCWV4dHJhY3QgNzAgOAoJYnRvaQoJaXRvYgoJY29uY2F0CglmcmFtZV9kaWcgMSAvLyBzdG9yYWdlIGtleS8vaWRlbnRpdHkKCWJveF9nZXQKCgkvLyBib3ggdmFsdWUgZG9lcyBub3QgZXhpc3Q6IHRoaXMuaWRlbnRpdGllcyh1c2VyKS52YWx1ZQoJYXNzZXJ0CglzdG9yZSAyNTUgLy8gZnVsbCBhcnJheQoJbG9hZCAyNTUgLy8gZnVsbCBhcnJheQoJZXh0cmFjdCA3OCA4CglidG9pCglpdG9iCgljb25jYXQKCWJ5dGVjIDUgLy8gMHgwMAoJaW50YyAwIC8vIDAKCWZyYW1lX2RpZyAxIC8vIHN0b3JhZ2Uga2V5Ly9pZGVudGl0eQoJYm94X2dldAoKCS8vIGJveCB2YWx1ZSBkb2VzIG5vdCBleGlzdDogdGhpcy5pZGVudGl0aWVzKHVzZXIpLnZhbHVlCglhc3NlcnQKCXN0b3JlIDI1NSAvLyBmdWxsIGFycmF5Cglsb2FkIDI1NSAvLyBmdWxsIGFycmF5CglpbnRjIDYgLy8gNjg4CglnZXRiaXQKCXNldGJpdAoJY29uY2F0CglmcmFtZV9idXJ5IDIgLy8gcmV0OiBVc2VySW5mb1YxCgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czozMTMKCS8vIHJldHVybiByZXQ7CglmcmFtZV9kaWcgMiAvLyByZXQ6IFVzZXJJbmZvVjEKCipnZXRVc2VyKnJldHVybjoKCS8vIHNldCB0aGUgc3Vicm91dGluZSByZXR1cm4gdmFsdWUKCWZyYW1lX2J1cnkgMAoKCS8vIHBvcCBhbGwgbG9jYWwgdmFyaWFibGVzIGZyb20gdGhlIHN0YWNrCglwb3BuIDIKCXJldHN1YgoKLy8gd2l0aGRyYXdFeGNlc3NBc3NldHModWludDY0LHVpbnQ2NCx1aW50NjQpdWludDY0CiphYmlfcm91dGVfd2l0aGRyYXdFeGNlc3NBc3NldHM6CgkvLyBUaGUgQUJJIHJldHVybiBwcmVmaXgKCWJ5dGVjIDEyIC8vIDB4MTUxZjdjNzUKCgkvLyBhbW91bnQ6IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMwoJYnRvaQoKCS8vIGFzc2V0OiB1aW50NjQKCXR4bmEgQXBwbGljYXRpb25BcmdzIDIKCWJ0b2kKCgkvLyBhcHBCaWF0ZWNDb25maWdQcm92aWRlcjogdWludDY0Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglidG9pCgoJLy8gZXhlY3V0ZSB3aXRoZHJhd0V4Y2Vzc0Fzc2V0cyh1aW50NjQsdWludDY0LHVpbnQ2NCl1aW50NjQKCWNhbGxzdWIgd2l0aGRyYXdFeGNlc3NBc3NldHMKCWl0b2IKCWNvbmNhdAoJbG9nCglpbnRjIDEgLy8gMQoJcmV0dXJuCgovLyB3aXRoZHJhd0V4Y2Vzc0Fzc2V0cyhhcHBCaWF0ZWNDb25maWdQcm92aWRlcjogQXBwSUQsIGFzc2V0OiBBc3NldElELCBhbW91bnQ6IHVpbnQ2NCk6IHVpbnQ2NAovLwovLyBJZiBzb21lb25lIGRlcG9zaXRzIGV4Y2VzcyBhc3NldHMgdG8gdGhpcyBzbWFydCBjb250cmFjdCBiaWF0ZWMgY2FuIHVzZSB0aGVtLgovLwovLyBPbmx5IGFkZHJlc3NFeGVjdXRpdmVGZWUgaXMgYWxsb3dlZCB0byBleGVjdXRlIHRoaXMgbWV0aG9kLgovLwovLyBAcGFyYW0gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXIgQmlhdGVjIGNvbmZpZyBhcHAuIE9ubHkgYWRkcmVzc0V4ZWN1dGl2ZUZlZSBpcyBhbGxvd2VkIHRvIGV4ZWN1dGUgdGhpcyBtZXRob2QuCi8vIEBwYXJhbSBhc3NldCBBc3NldCB0byB3aXRoZHJhdy4gSWYgbmF0aXZlIHRva2VuLCB0aGVuIHplcm8KLy8gQHBhcmFtIGFtb3VudCBBbW91bnQgb2YgdGhlIGFzc2V0IHRvIGJlIHdpdGhkcmF3bgp3aXRoZHJhd0V4Y2Vzc0Fzc2V0czoKCXByb3RvIDMgMQoKCS8vIFB1c2ggZW1wdHkgYnl0ZXMgYWZ0ZXIgdGhlIGZyYW1lIHBvaW50ZXIgdG8gcmVzZXJ2ZSBzcGFjZSBmb3IgbG9jYWwgdmFyaWFibGVzCglieXRlYyAxIC8vIDB4CglkdXAKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjMyNgoJLy8gYXNzZXJ0KGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyID09PSB0aGlzLmFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLnZhbHVlLCAnQ29uZmlndXJhdGlvbiBhcHAgZG9lcyBub3QgbWF0Y2gnKQoJZnJhbWVfZGlnIC0xIC8vIGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyOiBBcHBJRAoJYnl0ZWMgMyAvLyAgIkIiCglhcHBfZ2xvYmFsX2dldAoJPT0KCgkvLyBDb25maWd1cmF0aW9uIGFwcCBkb2VzIG5vdCBtYXRjaAoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czozMjcKCS8vIGFkZHJlc3NFeGVjdXRpdmVGZWUgPSBhcHBCaWF0ZWNDb25maWdQcm92aWRlci5nbG9iYWxTdGF0ZSgnZWYnKSBhcyBBZGRyZXNzCglmcmFtZV9kaWcgLTEgLy8gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXI6IEFwcElECglieXRlYyAxMyAvLyAgImVmIgoJYXBwX2dsb2JhbF9nZXRfZXgKCgkvLyBnbG9iYWwgc3RhdGUgdmFsdWUgZG9lcyBub3QgZXhpc3Q6IGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmdsb2JhbFN0YXRlKCdlZicpCglhc3NlcnQKCWZyYW1lX2J1cnkgMCAvLyBhZGRyZXNzRXhlY3V0aXZlRmVlOiBhZGRyZXNzCgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czozMjgKCS8vIHBhdXNlZCA9IGFwcEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmdsb2JhbFN0YXRlKCdzJykgYXMgdWludDY0CglmcmFtZV9kaWcgLTEgLy8gYXBwQmlhdGVjQ29uZmlnUHJvdmlkZXI6IEFwcElECglieXRlYyA0IC8vICAicyIKCWFwcF9nbG9iYWxfZ2V0X2V4CgoJLy8gZ2xvYmFsIHN0YXRlIHZhbHVlIGRvZXMgbm90IGV4aXN0OiBhcHBCaWF0ZWNDb25maWdQcm92aWRlci5nbG9iYWxTdGF0ZSgncycpCglhc3NlcnQKCWZyYW1lX2J1cnkgMSAvLyBwYXVzZWQ6IHVpbnQ2NAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzI5CgkvLyBhc3NlcnQocGF1c2VkID09PSAwLCAnRVJSX1BBVVNFRCcpCglmcmFtZV9kaWcgMSAvLyBwYXVzZWQ6IHVpbnQ2NAoJaW50YyAwIC8vIDAKCT09CgoJLy8gRVJSX1BBVVNFRAoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czozMzAKCS8vIGFzc2VydCgKCS8vICAgICAgIHRoaXMudHhuLnNlbmRlciA9PT0gYWRkcmVzc0V4ZWN1dGl2ZUZlZSwKCS8vICAgICAgICdPbmx5IGZlZSBleGVjdXRvciBzZXR1cCBpbiB0aGUgY29uZmlnIGNhbiB0YWtlIHRoZSBjb2xsZWN0ZWQgZmVlcycKCS8vICAgICApCgl0eG4gU2VuZGVyCglmcmFtZV9kaWcgMCAvLyBhZGRyZXNzRXhlY3V0aXZlRmVlOiBhZGRyZXNzCgk9PQoKCS8vIE9ubHkgZmVlIGV4ZWN1dG9yIHNldHVwIGluIHRoZSBjb25maWcgY2FuIHRha2UgdGhlIGNvbGxlY3RlZCBmZWVzCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjMzNQoJLy8gdGhpcy5kb0F4ZmVyKHRoaXMudHhuLnNlbmRlciwgYXNzZXQsIGFtb3VudCkKCWZyYW1lX2RpZyAtMyAvLyBhbW91bnQ6IHVpbnQ2NAoJZnJhbWVfZGlnIC0yIC8vIGFzc2V0OiBBc3NldElECgl0eG4gU2VuZGVyCgljYWxsc3ViIGRvQXhmZXIKCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjMzNwoJLy8gcmV0dXJuIGFtb3VudDsKCWZyYW1lX2RpZyAtMyAvLyBhbW91bnQ6IHVpbnQ2NAoKCS8vIHNldCB0aGUgc3Vicm91dGluZSByZXR1cm4gdmFsdWUKCWZyYW1lX2J1cnkgMAoKCS8vIHBvcCBhbGwgbG9jYWwgdmFyaWFibGVzIGZyb20gdGhlIHN0YWNrCglwb3BuIDEKCXJldHN1YgoKLy8gZG9BeGZlcihyZWNlaXZlcjogQWRkcmVzcywgYXNzZXQ6IEFzc2V0SUQsIGFtb3VudDogdWludDY0KTogdm9pZAovLwovLyBFeGVjdXRlcyB4ZmVyIG9mIHBheSBwYXltZW50IG1ldGhvZHMgdG8gc3BlY2lmaWVkIHJlY2VpdmVyIGZyb20gc21hcnQgY29udHJhY3QgYWdncmVnYXRlZCBhY2NvdW50IHdpdGggc3BlY2lmaWVkIGFzc2V0IGFuZCBhbW91bnQgaW4gdG9rZW5zIGRlY2ltYWxzCi8vIEBwYXJhbSByZWNlaXZlciBSZWNlaXZlcgovLyBAcGFyYW0gYXNzZXQgQXNzZXQuIFplcm8gZm9yIGFsZ28KLy8gQHBhcmFtIGFtb3VudCBBbW91bnQgdG8gdHJhbnNmZXIKZG9BeGZlcjoKCXByb3RvIDMgMAoKCS8vICppZjFfY29uZGl0aW9uCgkvLyBjb250cmFjdHNcQmlhdGVjSWRlbnRpdHlQcm92aWRlci5hbGdvLnRzOjM0NwoJLy8gYXNzZXQuaWQgPT09IDAKCWZyYW1lX2RpZyAtMiAvLyBhc3NldDogQXNzZXRJRAoJaW50YyAwIC8vIDAKCT09CglieiAqaWYxX2Vsc2UKCgkvLyAqaWYxX2NvbnNlcXVlbnQKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzQ4CgkvLyBzZW5kUGF5bWVudCh7CgkvLyAgICAgICAgIHJlY2VpdmVyOiByZWNlaXZlciwKCS8vICAgICAgICAgYW1vdW50OiBhbW91bnQsCgkvLyAgICAgICAgIGZlZTogMCwKCS8vICAgICAgIH0pCglpdHhuX2JlZ2luCglpbnRjIDEgLy8gIHBheQoJaXR4bl9maWVsZCBUeXBlRW51bQoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzQ5CgkvLyByZWNlaXZlcjogcmVjZWl2ZXIKCWZyYW1lX2RpZyAtMSAvLyByZWNlaXZlcjogQWRkcmVzcwoJaXR4bl9maWVsZCBSZWNlaXZlcgoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzUwCgkvLyBhbW91bnQ6IGFtb3VudAoJZnJhbWVfZGlnIC0zIC8vIGFtb3VudDogdWludDY0CglpdHhuX2ZpZWxkIEFtb3VudAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzUxCgkvLyBmZWU6IDAKCWludGMgMCAvLyAwCglpdHhuX2ZpZWxkIEZlZQoKCS8vIFN1Ym1pdCBpbm5lciB0cmFuc2FjdGlvbgoJaXR4bl9zdWJtaXQKCWIgKmlmMV9lbmQKCippZjFfZWxzZToKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzU0CgkvLyBzZW5kQXNzZXRUcmFuc2Zlcih7CgkvLyAgICAgICAgIGFzc2V0UmVjZWl2ZXI6IHJlY2VpdmVyLAoJLy8gICAgICAgICB4ZmVyQXNzZXQ6IGFzc2V0LAoJLy8gICAgICAgICBhc3NldEFtb3VudDogYW1vdW50LAoJLy8gICAgICAgICBmZWU6IDAsCgkvLyAgICAgICB9KQoJaXR4bl9iZWdpbgoJcHVzaGludCA0IC8vIGF4ZmVyCglpdHhuX2ZpZWxkIFR5cGVFbnVtCgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czozNTUKCS8vIGFzc2V0UmVjZWl2ZXI6IHJlY2VpdmVyCglmcmFtZV9kaWcgLTEgLy8gcmVjZWl2ZXI6IEFkZHJlc3MKCWl0eG5fZmllbGQgQXNzZXRSZWNlaXZlcgoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzU2CgkvLyB4ZmVyQXNzZXQ6IGFzc2V0CglmcmFtZV9kaWcgLTIgLy8gYXNzZXQ6IEFzc2V0SUQKCWl0eG5fZmllbGQgWGZlckFzc2V0CgoJLy8gY29udHJhY3RzXEJpYXRlY0lkZW50aXR5UHJvdmlkZXIuYWxnby50czozNTcKCS8vIGFzc2V0QW1vdW50OiBhbW91bnQKCWZyYW1lX2RpZyAtMyAvLyBhbW91bnQ6IHVpbnQ2NAoJaXR4bl9maWVsZCBBc3NldEFtb3VudAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLmFsZ28udHM6MzU4CgkvLyBmZWU6IDAKCWludGMgMCAvLyAwCglpdHhuX2ZpZWxkIEZlZQoKCS8vIFN1Ym1pdCBpbm5lciB0cmFuc2FjdGlvbgoJaXR4bl9zdWJtaXQKCippZjFfZW5kOgoJcmV0c3ViCgoqY3JlYXRlX05vT3A6CglwdXNoYnl0ZXMgMHhiODQ0N2IzNiAvLyBtZXRob2QgImNyZWF0ZUFwcGxpY2F0aW9uKCl2b2lkIgoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMAoJbWF0Y2ggKmFiaV9yb3V0ZV9jcmVhdGVBcHBsaWNhdGlvbgoKCS8vIHRoaXMgY29udHJhY3QgZG9lcyBub3QgaW1wbGVtZW50IHRoZSBnaXZlbiBBQkkgbWV0aG9kIGZvciBjcmVhdGUgTm9PcAoJZXJyCgoqY2FsbF9Ob09wOgoJcHVzaGJ5dGVzIDB4YTBjYWRmOGEgLy8gbWV0aG9kICJib290c3RyYXAodWludDY0KXZvaWQiCglwdXNoYnl0ZXMgMHhlOGM4ZWVkOSAvLyBtZXRob2QgInNlbGZSZWdpc3RyYXRpb24oYWRkcmVzcywodWludDY0LHVpbnQ2NCxib29sLHN0cmluZyxzdHJpbmcsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsYm9vbCx1aW50NjQsdWludDY0LGJvb2wpKXZvaWQiCglwdXNoYnl0ZXMgMHhkNTgzYTc1OSAvLyBtZXRob2QgInNldEluZm8oYWRkcmVzcywodWludDY0LHVpbnQ2NCxib29sLHN0cmluZyxzdHJpbmcsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsYm9vbCx1aW50NjQsdWludDY0LGJvb2wpKXZvaWQiCglwdXNoYnl0ZXMgMHg4MzkyNWMxNyAvLyBtZXRob2QgInNlbmRPbmxpbmVLZXlSZWdpc3RyYXRpb24odWludDY0LGJ5dGVbXSxieXRlW10sYnl0ZVtdLHVpbnQ2NCx1aW50NjQsdWludDY0KXZvaWQiCglwdXNoYnl0ZXMgMHg5OTM2YTE2ZCAvLyBtZXRob2QgImdldFVzZXIoYWRkcmVzcyx1aW50OCkodWludDgsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50NjQsdWludDY0LHVpbnQ2NCx1aW50MjU2LHVpbnQyNTYsYm9vbCx1aW50NjQsdWludDY0LGJvb2wpIgoJcHVzaGJ5dGVzIDB4Y2JhMmU5NWQgLy8gbWV0aG9kICJ3aXRoZHJhd0V4Y2Vzc0Fzc2V0cyh1aW50NjQsdWludDY0LHVpbnQ2NCl1aW50NjQiCgl0eG5hIEFwcGxpY2F0aW9uQXJncyAwCgltYXRjaCAqYWJpX3JvdXRlX2Jvb3RzdHJhcCAqYWJpX3JvdXRlX3NlbGZSZWdpc3RyYXRpb24gKmFiaV9yb3V0ZV9zZXRJbmZvICphYmlfcm91dGVfc2VuZE9ubGluZUtleVJlZ2lzdHJhdGlvbiAqYWJpX3JvdXRlX2dldFVzZXIgKmFiaV9yb3V0ZV93aXRoZHJhd0V4Y2Vzc0Fzc2V0cwoKCS8vIHRoaXMgY29udHJhY3QgZG9lcyBub3QgaW1wbGVtZW50IHRoZSBnaXZlbiBBQkkgbWV0aG9kIGZvciBjYWxsIE5vT3AKCWVycgoKKmNhbGxfVXBkYXRlQXBwbGljYXRpb246CglwdXNoYnl0ZXMgMHg1ZmM4ODVhMCAvLyBtZXRob2QgInVwZGF0ZUFwcGxpY2F0aW9uKHVpbnQ2NCxieXRlW10pdm9pZCIKCXR4bmEgQXBwbGljYXRpb25BcmdzIDAKCW1hdGNoICphYmlfcm91dGVfdXBkYXRlQXBwbGljYXRpb24KCgkvLyB0aGlzIGNvbnRyYWN0IGRvZXMgbm90IGltcGxlbWVudCB0aGUgZ2l2ZW4gQUJJIG1ldGhvZCBmb3IgY2FsbCBVcGRhdGVBcHBsaWNhdGlvbgoJZXJy";
        protected override string SourceClear { get; set; } = "I3ByYWdtYSB2ZXJzaW9uIDEw";
        protected override string SourceApprovalAVM { get; set; } = "CiAHAAEgAoACqASwBSYOCAAAAAAAAAAAAAFpAUIBcwEAJDAwMDAwMDAwLTAwMDAtMDAwMC0wMDAwLTAwMDAwMDAwMDAwMCD//////////////////////////////////////////yAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAO5rKAAgAAAAAdzWUAAgAAAAAO5rKAAVzY3ZlcgQVH3x1AmVmMRgUgQYLMRkIjQwD8QAAAAAAAAQnAAAD4wAAAAAAAAAAAAAAiAACI0OKAAAnC4AVQklBVEVDLUlERU5ULTAxLTAyLTAxZ4k2GgEXiAACI0OKAQApMQA2MgByB0gSRCuL/2eL/ycEZUSMAIsAIhJEiTYaAlcCADYaAReIAAIjQ4oCAClJi/8rZBJEi/+AAXVlRIwAMQCLABJEi/8nBGVEjAGLASISRCcLi/5niTYaAjYaAUkVJBJEiAACI0OKAgAqi/9QvUxIFESL/jX/NP9XAAgXIxJEi/41/zT/VwgIFyISRIv+Nf+BETT/NP9PAllJNP9MWSMLJQhYVwIAJwYSRIv+Nf+BEzT/NP9PAllJNP9MWSMLJQhYVwIAJwYSRIv+Nf80/1cVCBciEkSL/jX/NP9XHQgXIhJEi/41/zT/VyUIFyISRIv+Nf80/1ctCBciEkSL/jX/NP9XNQgXIhJEi/41/zT/Vz0IFyISRIv+Nf80/yEFUyISRIv+Nf80/1dGCBciEkSL/jX/NP9XTggXIhJEi/41/zT/IQZTIhJEKov/UEm8SIv+v4k2GgI2GgFJFSQSRIgAAiNDigIAMQCAAWVkEkQqi/9QSbxIi/6/iTYaBxc2GgYXNhoFFzYaBFcCADYaA1cCADYaAlcCADYaAReIAAIjQ4oHAClJi/8rZBJEi/8nDWVEjAAxAIsAEkSL/ycEZUSMAYsBIhJEsSWyEIv9sguL/LI/i/uyDIv5sg6L+rINi/6yCiKyAbOJJww2GgJJFSMSRBc2GgFJFSQSRIgABFCwI0OKAgEpRwKL/iMSRCqL/1C9TEgUQQBDi/4WVwcBKFAoUChQKFAoUChQKFAoUCcJSZMhBA5EJwesSRVJJAlMUlAnCFAnBSJJVFAoUChQJwUiSVRQjACLAEIA0iqL/1CMAYv+FlcHAYsBvkQ1/zT/VwAIFxZQiwG+RDX/NP9XCAgXFlCLAb5ENf80/1cVCBcWUIsBvkQ1/zT/Vx0IFxZQiwG+RDX/NP9XJQgXFlCLAb5ENf80/1ctCBcWUIsBvkQ1/zT/VzUIFxZQiwG+RDX/NP9XPQgXFlAnCkmTIQQORCcHrEkVSSQJTFJQJwhQJwUiiwG+RDX/NP8hBVNUUIsBvkQ1/zT/V0YIFxZQiwG+RDX/NP9XTggXFlAnBSKLAb5ENf80/yEGU1RQjAKLAowARgKJJww2GgMXNhoCFzYaAReIAAUWULAjQ4oDASlJi/8rZBJEi/8nDWVEjACL/ycEZUSMAYsBIhJEMQCLABJEi/2L/jEAiAAHi/2MAEYBiYoDAIv+IhJBABOxI7IQi/+yB4v9sggisgGzQgAVsYEEshCL/7IUi/6yEYv9shIisgGziYAEuER7NjYaAI4B/BEAgASgyt+KgAToyO7ZgATVg6dZgASDklwXgASZNqFtgATLouldNhoAjgb7/vxj/WD9hv30/z4AgARfyIWgNhoAjgH8GQA=";
        protected override string SourceClearAVM { get; set; } = "Cg==";
        protected override ulong? GlobalNumByteSlices { get; set; } = 4;
        protected override ulong? GlobalNumUints { get; set; } = 1;
        protected override ulong? LocalNumByteSlices { get; set; } = 0;
        protected override ulong? LocalNumUints { get; set; } = 0;

    }

}
