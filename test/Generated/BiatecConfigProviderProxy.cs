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

namespace BiatecConfig
{


    public class BiatecConfigProviderProxy : ProxyBase
    {

        public BiatecConfigProviderProxy(DefaultApi defaultApi, ulong appId) : base(defaultApi, appId)
        {
        }

        ///<summary>
        ///Initial setup
        ///No_op: CREATE, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        public async Task createApplication(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 184, 68, 123, 54 };
            var result = await base.CallApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> createApplication_Transactions(Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 184, 68, 123, 54 };
            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///addressUdpater from global biatec configuration is allowed to update application
        ///No_op: NEVER, Opt_in: NEVER, Close_out: NEVER, Update_application: CALL, Delete_application: NEVER
        ///</summary>
        /// <param name="newVersion"> ABI Type is byte[]  </param>
        public async Task updateApplication(byte[] newVersion, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 105, 54, 198, 47 };
            var result = await base.CallApp(new List<object> { abiHandle, newVersion }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> updateApplication_Transactions(byte[] newVersion, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 105, 54, 198, 47 };
            return await base.MakeTransactionList(new List<object> { abiHandle, newVersion }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Setup the contract
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="biatecFee">Biatec fees ABI Type is uint256  </param>
        /// <param name="appBiatecIdentityProvider"> ABI Type is uint64  </param>
        /// <param name="appBiatecPoolProvider"> ABI Type is uint64  </param>
        public async Task bootstrap(AVM.ClientGenerator.ABI.ARC4.Types.UInt256 biatecFee, ulong appBiatecIdentityProvider, ulong appBiatecPoolProvider, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 73, 92, 231, 237 };
            var result = await base.CallApp(new List<object> { abiHandle, biatecFee, appBiatecIdentityProvider, appBiatecPoolProvider }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> bootstrap_Transactions(AVM.ClientGenerator.ABI.ARC4.Types.UInt256 biatecFee, ulong appBiatecIdentityProvider, ulong appBiatecPoolProvider, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 73, 92, 231, 237 };
            return await base.MakeTransactionList(new List<object> { abiHandle, biatecFee, appBiatecIdentityProvider, appBiatecPoolProvider }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Top secret account with which it is possible update contracts or identity provider
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="a">Address ABI Type is address  </param>
        public async Task setAddressUdpater(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { a });
            byte[] abiHandle = { 191, 194, 8, 96 };
            var result = await base.CallApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setAddressUdpater_Transactions(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 191, 194, 8, 96 };
            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Kill switch. In the extreme case all services (deposit, trading, withdrawal, identity modifications and more) can be suspended.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="a">Address ABI Type is uint64  </param>
        public async Task setPaused(ulong a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 12, 220, 16, 252 };
            var result = await base.CallApp(new List<object> { abiHandle, a }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setPaused_Transactions(ulong a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 12, 220, 16, 252 };
            return await base.MakeTransactionList(new List<object> { abiHandle, a }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Execution address with which it is possible to opt in for governance
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="a">Address ABI Type is address  </param>
        public async Task setAddressGov(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { a });
            byte[] abiHandle = { 107, 149, 95, 75 };
            var result = await base.CallApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setAddressGov_Transactions(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 107, 149, 95, 75 };
            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Execution address with which it is possible to change global biatec fees
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="a">Address ABI Type is address  </param>
        public async Task setAddressExecutive(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { a });
            byte[] abiHandle = { 139, 24, 123, 61 };
            var result = await base.CallApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setAddressExecutive_Transactions(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 139, 24, 123, 61 };
            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Execution fee address is address which can take fees from pools.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="a">Address ABI Type is address  </param>
        public async Task setAddressExecutiveFee(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            _tx_accounts.AddRange(new List<Address> { a });
            byte[] abiHandle = { 80, 224, 125, 136 };
            var result = await base.CallApp(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setAddressExecutiveFee_Transactions(Address a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 80, 224, 125, 136 };
            return await base.MakeTransactionList(new List<object> { abiHandle }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///App identity setter
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="a">Address ABI Type is uint64  </param>
        public async Task setBiatecIdentity(ulong a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 186, 190, 30, 17 };
            var result = await base.CallApp(new List<object> { abiHandle, a }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setBiatecIdentity_Transactions(ulong a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 186, 190, 30, 17 };
            return await base.MakeTransactionList(new List<object> { abiHandle, a }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///App identity setter
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="a">Address ABI Type is uint64  </param>
        public async Task setBiatecPool(ulong a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 197, 139, 157, 164 };
            var result = await base.CallApp(new List<object> { abiHandle, a }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setBiatecPool_Transactions(ulong a, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 197, 139, 157, 164 };
            return await base.MakeTransactionList(new List<object> { abiHandle, a }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///Fees in 9 decimals. 1_000_000_000 = 100%
        ///Fees in 9 decimals. 10_000_000 = 1%
        ///Fees in 9 decimals. 100_000 = 0,01%
        ///
        ///
        ///Fees are respectful from the all fees taken to the LP providers. If LPs charge 1% fee, and biatec charges 10% fee, LP will receive 0.09% fee and biatec 0.01% fee
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="biatecFee">Fee ABI Type is uint256  </param>
        public async Task setBiatecFee(AVM.ClientGenerator.ABI.ARC4.Types.UInt256 biatecFee, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 202, 52, 74, 52 };
            var result = await base.CallApp(new List<object> { abiHandle, biatecFee }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> setBiatecFee_Transactions(AVM.ClientGenerator.ABI.ARC4.Types.UInt256 biatecFee, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 202, 52, 74, 52 };
            return await base.MakeTransactionList(new List<object> { abiHandle, biatecFee }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///addressExecutiveFee can perfom key registration for this LP pool
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="votePK"> ABI Type is byte[]  </param>
        /// <param name="selectionPK"> ABI Type is byte[]  </param>
        /// <param name="stateProofPK"> ABI Type is byte[]  </param>
        /// <param name="voteFirst"> ABI Type is uint64  </param>
        /// <param name="voteLast"> ABI Type is uint64  </param>
        /// <param name="voteKeyDilution"> ABI Type is uint64  </param>
        public async Task sendOnlineKeyRegistration(byte[] votePK, byte[] selectionPK, byte[] stateProofPK, ulong voteFirst, ulong voteLast, ulong voteKeyDilution, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 73, 243, 161, 127 };
            var result = await base.CallApp(new List<object> { abiHandle, votePK, selectionPK, stateProofPK, voteFirst, voteLast, voteKeyDilution }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        public async Task<List<Transaction>> sendOnlineKeyRegistration_Transactions(byte[] votePK, byte[] selectionPK, byte[] stateProofPK, ulong voteFirst, ulong voteLast, ulong voteKeyDilution, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 73, 243, 161, 127 };
            return await base.MakeTransactionList(new List<object> { abiHandle, votePK, selectionPK, stateProofPK, voteFirst, voteLast, voteKeyDilution }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        ///<summary>
        ///If someone deposits excess assets to this smart contract biatec can use them.
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="asset">Asset to withdraw. If native token, then zero ABI Type is uint64  </param>
        /// <param name="amount">Amount of the asset to be withdrawn ABI Type is uint64  </param>
        public async Task<ulong> withdrawExcessAssets(ulong asset, ulong amount, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            _tx_boxes ??= new List<BoxRef>();
            _tx_transactions ??= new List<Transaction>();
            _tx_assets ??= new List<ulong>();
            _tx_apps ??= new List<ulong>();
            _tx_accounts ??= new List<Address>();
            byte[] abiHandle = { 135, 40, 55, 48 };
            var result = await base.CallApp(new List<object> { abiHandle, asset, amount }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> withdrawExcessAssets_Transactions(ulong asset, ulong amount, Account _tx_sender, ulong? _tx_fee, string _tx_note = "", ulong _tx_roundValidity = 1000, List<BoxRef>? _tx_boxes = null, List<Transaction>? _tx_transactions = null, List<ulong>? _tx_assets = null, List<ulong>? _tx_apps = null, List<Address>? _tx_accounts = null, AVM.ClientGenerator.Core.OnCompleteType _tx_callType = AVM.ClientGenerator.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 135, 40, 55, 48 };
            return await base.MakeTransactionList(new List<object> { abiHandle, asset, amount }, _tx_fee: _tx_fee, _tx_callType: _tx_callType, _tx_roundValidity: _tx_roundValidity, _tx_note: _tx_note, _tx_sender: _tx_sender, _tx_transactions: _tx_transactions, _tx_apps: _tx_apps, _tx_assets: _tx_assets, _tx_accounts: _tx_accounts, _tx_boxes: _tx_boxes);

        }

        //Initial setup
        public class createApplication_Arc4GroupTransaction : ProxyBase
        {
            public createApplication_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private createApplication_Arc4GroupTransaction() : base(null, 0) { }
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 184, 68, 123, 54 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //addressUdpater from global biatec configuration is allowed to update application
        public class updateApplication_Arc4GroupTransaction : ProxyBase
        {
            public updateApplication_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private updateApplication_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte> newVersion { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.VariableArray<AVM.ClientGenerator.ABI.ARC4.Types.Byte>)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 105, 54, 198, 47 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { newVersion }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Setup the contract
        public class bootstrap_Arc4GroupTransaction : ProxyBase
        {
            public bootstrap_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private bootstrap_Arc4GroupTransaction() : base(null, 0) { }
            //Biatec fees
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt biatecFee { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt appBiatecIdentityProvider { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt appBiatecPoolProvider { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 73, 92, 231, 237 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { biatecFee, appBiatecIdentityProvider, appBiatecPoolProvider }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Top secret account with which it is possible update contracts or identity provider
        public class setAddressUdpater_Arc4GroupTransaction : ProxyBase
        {
            public setAddressUdpater_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setAddressUdpater_Arc4GroupTransaction() : base(null, 0) { }
            //Address
            public AVM.ClientGenerator.ABI.ARC4.Types.Address a { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Address)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 191, 194, 8, 96 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { a }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Kill switch. In the extreme case all services (deposit, trading, withdrawal, identity modifications and more) can be suspended.
        public class setPaused_Arc4GroupTransaction : ProxyBase
        {
            public setPaused_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setPaused_Arc4GroupTransaction() : base(null, 0) { }
            //Address
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt a { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 12, 220, 16, 252 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { a }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Execution address with which it is possible to opt in for governance
        public class setAddressGov_Arc4GroupTransaction : ProxyBase
        {
            public setAddressGov_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setAddressGov_Arc4GroupTransaction() : base(null, 0) { }
            //Address
            public AVM.ClientGenerator.ABI.ARC4.Types.Address a { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Address)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 107, 149, 95, 75 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { a }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Execution address with which it is possible to change global biatec fees
        public class setAddressExecutive_Arc4GroupTransaction : ProxyBase
        {
            public setAddressExecutive_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setAddressExecutive_Arc4GroupTransaction() : base(null, 0) { }
            //Address
            public AVM.ClientGenerator.ABI.ARC4.Types.Address a { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Address)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 139, 24, 123, 61 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { a }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Execution fee address is address which can take fees from pools.
        public class setAddressExecutiveFee_Arc4GroupTransaction : ProxyBase
        {
            public setAddressExecutiveFee_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setAddressExecutiveFee_Arc4GroupTransaction() : base(null, 0) { }
            //Address
            public AVM.ClientGenerator.ABI.ARC4.Types.Address a { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.Address)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("address");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 80, 224, 125, 136 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { a }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //App identity setter
        public class setBiatecIdentity_Arc4GroupTransaction : ProxyBase
        {
            public setBiatecIdentity_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setBiatecIdentity_Arc4GroupTransaction() : base(null, 0) { }
            //Address
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt a { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 186, 190, 30, 17 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { a }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //App identity setter
        public class setBiatecPool_Arc4GroupTransaction : ProxyBase
        {
            public setBiatecPool_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setBiatecPool_Arc4GroupTransaction() : base(null, 0) { }
            //Address
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt a { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 197, 139, 157, 164 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { a }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //Fees in 9 decimals. 1_000_000_000 = 100%\\nFees in 9 decimals. 10_000_000 = 1%\\nFees in 9 decimals. 100_000 = 0,01%\\n\\n\\nFees are respectful from the all fees taken to the LP providers. If LPs charge 1% fee, and biatec charges 10% fee, LP will receive 0.09% fee and biatec 0.01% fee
        public class setBiatecFee_Arc4GroupTransaction : ProxyBase
        {
            public setBiatecFee_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private setBiatecFee_Arc4GroupTransaction() : base(null, 0) { }
            //Fee
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt biatecFee { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 202, 52, 74, 52 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { biatecFee }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //addressExecutiveFee can perfom key registration for this LP pool\\n\\n\\nOnly addressExecutiveFee is allowed to execute this method.
        public class sendOnlineKeyRegistration_Arc4GroupTransaction : ProxyBase
        {
            public sendOnlineKeyRegistration_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private sendOnlineKeyRegistration_Arc4GroupTransaction() : base(null, 0) { }
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
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 73, 243, 161, 127 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { votePK, selectionPK, stateProofPK, voteFirst, voteLast, voteKeyDilution }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        //If someone deposits excess assets to this smart contract biatec can use them.\\n\\n\\nOnly addressExecutiveFee is allowed to execute this method.
        public class withdrawExcessAssets_Arc4GroupTransaction : ProxyBase
        {
            public withdrawExcessAssets_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private withdrawExcessAssets_Arc4GroupTransaction() : base(null, 0) { }
            //Asset to withdraw. If native token, then zero
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt asset { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Amount of the asset to be withdrawn
            public AVM.ClientGenerator.ABI.ARC4.Types.UInt amount { get; set; } = (AVM.ClientGenerator.ABI.ARC4.Types.UInt)AVM.ClientGenerator.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? _tx_fee, OnCompleteType _tx_onComplete, ulong _tx_roundValidity, string _tx_note, Account _tx_sender, List<ulong> _tx_foreignApps, List<ulong> _tx_foreignAssets, List<Address> _tx_accounts, List<BoxRef>? _tx_boxes = null)
            {

                byte[] abiHandle = { 135, 40, 55, 48 };
                return await base.MakeArc4TransactionList(null, _tx_fee, _tx_onComplete, _tx_roundValidity, _tx_note, _tx_sender, abiHandle, new List<AVM.ClientGenerator.ABI.ARC4.Types.WireType> { asset, amount }, _tx_foreignApps, _tx_foreignAssets, _tx_accounts, _tx_boxes);
            }
        }


        protected override string SourceApproval { get; set; } = "I3ByYWdtYSB2ZXJzaW9uIDEwCmludGNibG9jayAxIDMyIDAKYnl0ZWNibG9jayAweDc1IDB4NjU2NiAweDY1IDB4MDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAzYjlhY2EwMCAweDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDIgMHg3MzYzNzY2NTcyIDB4NjcgMHg3MyAweDY2IDB4NjkgMHg3MAoKLy8gVGhpcyBURUFMIHdhcyBnZW5lcmF0ZWQgYnkgVEVBTFNjcmlwdCB2MC4xMDYuMgovLyBodHRwczovL2dpdGh1Yi5jb20vYWxnb3JhbmRmb3VuZGF0aW9uL1RFQUxTY3JpcHQKCi8vIFRoaXMgY29udHJhY3QgaXMgY29tcGxpYW50IHdpdGggYW5kL29yIGltcGxlbWVudHMgdGhlIGZvbGxvd2luZyBBUkNzOiBbIEFSQzQgXQoKLy8gVGhlIGZvbGxvd2luZyB0ZW4gbGluZXMgb2YgVEVBTCBoYW5kbGUgaW5pdGlhbCBwcm9ncmFtIGZsb3cKLy8gVGhpcyBwYXR0ZXJuIGlzIHVzZWQgdG8gbWFrZSBpdCBlYXN5IGZvciBhbnlvbmUgdG8gcGFyc2UgdGhlIHN0YXJ0IG9mIHRoZSBwcm9ncmFtIGFuZCBkZXRlcm1pbmUgaWYgYSBzcGVjaWZpYyBhY3Rpb24gaXMgYWxsb3dlZAovLyBIZXJlLCBhY3Rpb24gcmVmZXJzIHRvIHRoZSBPbkNvbXBsZXRlIGluIGNvbWJpbmF0aW9uIHdpdGggd2hldGhlciB0aGUgYXBwIGlzIGJlaW5nIGNyZWF0ZWQgb3IgY2FsbGVkCi8vIEV2ZXJ5IHBvc3NpYmxlIGFjdGlvbiBmb3IgdGhpcyBjb250cmFjdCBpcyByZXByZXNlbnRlZCBpbiB0aGUgc3dpdGNoIHN0YXRlbWVudAovLyBJZiB0aGUgYWN0aW9uIGlzIG5vdCBpbXBsZW1lbnRlZCBpbiB0aGUgY29udHJhY3QsIGl0cyByZXNwZWN0aXZlIGJyYW5jaCB3aWxsIGJlICIqTk9UX0lNUExFTUVOVEVEIiB3aGljaCBqdXN0IGNvbnRhaW5zICJlcnIiCnR4biBBcHBsaWNhdGlvbklECiEKcHVzaGludCA2CioKdHhuIE9uQ29tcGxldGlvbgorCnN3aXRjaCAqY2FsbF9Ob09wICpOT1RfSU1QTEVNRU5URUQgKk5PVF9JTVBMRU1FTlRFRCAqTk9UX0lNUExFTUVOVEVEICpjYWxsX1VwZGF0ZUFwcGxpY2F0aW9uICpOT1RfSU1QTEVNRU5URUQgKmNyZWF0ZV9Ob09wICpOT1RfSU1QTEVNRU5URUQgKk5PVF9JTVBMRU1FTlRFRCAqTk9UX0lNUExFTUVOVEVEICpOT1RfSU1QTEVNRU5URUQgKk5PVF9JTVBMRU1FTlRFRAoKKk5PVF9JTVBMRU1FTlRFRDoKCS8vIFRoZSByZXF1ZXN0ZWQgYWN0aW9uIGlzIG5vdCBpbXBsZW1lbnRlZCBpbiB0aGlzIGNvbnRyYWN0LiBBcmUgeW91IHVzaW5nIHRoZSBjb3JyZWN0IE9uQ29tcGxldGU/IERpZCB5b3Ugc2V0IHlvdXIgYXBwIElEPwoJZXJyCgovLyBjcmVhdGVBcHBsaWNhdGlvbigpdm9pZAoqYWJpX3JvdXRlX2NyZWF0ZUFwcGxpY2F0aW9uOgoJLy8gZXhlY3V0ZSBjcmVhdGVBcHBsaWNhdGlvbigpdm9pZAoJY2FsbHN1YiBjcmVhdGVBcHBsaWNhdGlvbgoJaW50YyAwIC8vIDEKCXJldHVybgoKLy8gY3JlYXRlQXBwbGljYXRpb24oKTogdm9pZAovLwovLyBJbml0aWFsIHNldHVwCmNyZWF0ZUFwcGxpY2F0aW9uOgoJcHJvdG8gMCAwCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6NjEKCS8vIHRoaXMudmVyc2lvbi52YWx1ZSA9IHZlcnNpb24KCWJ5dGVjIDUgLy8gICJzY3ZlciIKCXB1c2hieXRlcyAiQklBVEVDLUNPTkZJRy0wMS0wMi0wMSIKCWFwcF9nbG9iYWxfcHV0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6NjIKCS8vIHRoaXMuYWRkcmVzc0V4ZWN1dGl2ZS52YWx1ZSA9IHRoaXMudHhuLnNlbmRlcgoJYnl0ZWMgMiAvLyAgImUiCgl0eG4gU2VuZGVyCglhcHBfZ2xvYmFsX3B1dAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjYzCgkvLyB0aGlzLmFkZHJlc3NHb3YudmFsdWUgPSB0aGlzLnR4bi5zZW5kZXIKCWJ5dGVjIDYgLy8gICJnIgoJdHhuIFNlbmRlcgoJYXBwX2dsb2JhbF9wdXQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czo2NAoJLy8gdGhpcy5hZGRyZXNzVWRwYXRlci52YWx1ZSA9IHRoaXMudHhuLnNlbmRlcgoJYnl0ZWMgMCAvLyAgInUiCgl0eG4gU2VuZGVyCglhcHBfZ2xvYmFsX3B1dAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjY1CgkvLyB0aGlzLmFkZHJlc3NFeGVjdXRpdmVGZWUudmFsdWUgPSB0aGlzLnR4bi5zZW5kZXIKCWJ5dGVjIDEgLy8gICJlZiIKCXR4biBTZW5kZXIKCWFwcF9nbG9iYWxfcHV0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6NjYKCS8vIHRoaXMuc3VzcGVuZGVkLnZhbHVlID0gMAoJYnl0ZWMgNyAvLyAgInMiCglpbnRjIDIgLy8gMAoJYXBwX2dsb2JhbF9wdXQKCXJldHN1YgoKLy8gdXBkYXRlQXBwbGljYXRpb24oYnl0ZVtdKXZvaWQKKmFiaV9yb3V0ZV91cGRhdGVBcHBsaWNhdGlvbjoKCS8vIG5ld1ZlcnNpb246IGJ5dGVbXQoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJZXh0cmFjdCAyIDAKCgkvLyBleGVjdXRlIHVwZGF0ZUFwcGxpY2F0aW9uKGJ5dGVbXSl2b2lkCgljYWxsc3ViIHVwZGF0ZUFwcGxpY2F0aW9uCglpbnRjIDAgLy8gMQoJcmV0dXJuCgovLyB1cGRhdGVBcHBsaWNhdGlvbihuZXdWZXJzaW9uOiBieXRlcyk6IHZvaWQKLy8KLy8gYWRkcmVzc1VkcGF0ZXIgZnJvbSBnbG9iYWwgYmlhdGVjIGNvbmZpZ3VyYXRpb24gaXMgYWxsb3dlZCB0byB1cGRhdGUgYXBwbGljYXRpb24KdXBkYXRlQXBwbGljYXRpb246Cglwcm90byAxIDAKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czo3MwoJLy8gYXNzZXJ0KAoJLy8gICAgICAgdGhpcy50eG4uc2VuZGVyID09PSB0aGlzLmFkZHJlc3NVZHBhdGVyLnZhbHVlLAoJLy8gICAgICAgJ09ubHkgYWRkcmVzc1VkcGF0ZXIgc2V0dXAgaW4gdGhlIGNvbmZpZyBjYW4gdXBkYXRlIGFwcGxpY2F0aW9uJwoJLy8gICAgICkKCXR4biBTZW5kZXIKCWJ5dGVjIDAgLy8gICJ1IgoJYXBwX2dsb2JhbF9nZXQKCT09CgoJLy8gT25seSBhZGRyZXNzVWRwYXRlciBzZXR1cCBpbiB0aGUgY29uZmlnIGNhbiB1cGRhdGUgYXBwbGljYXRpb24KCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjc3CgkvLyB0aGlzLnZlcnNpb24udmFsdWUgPSBuZXdWZXJzaW9uCglieXRlYyA1IC8vICAic2N2ZXIiCglmcmFtZV9kaWcgLTEgLy8gbmV3VmVyc2lvbjogYnl0ZXMKCWFwcF9nbG9iYWxfcHV0CglyZXRzdWIKCi8vIGJvb3RzdHJhcCh1aW50MjU2LHVpbnQ2NCx1aW50NjQpdm9pZAoqYWJpX3JvdXRlX2Jvb3RzdHJhcDoKCS8vIGFwcEJpYXRlY1Bvb2xQcm92aWRlcjogdWludDY0Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAzCglidG9pCgoJLy8gYXBwQmlhdGVjSWRlbnRpdHlQcm92aWRlcjogdWludDY0Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAyCglidG9pCgoJLy8gYmlhdGVjRmVlOiB1aW50MjU2Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglkdXAKCWxlbgoJaW50YyAxIC8vIDMyCgk9PQoKCS8vIGFyZ3VtZW50IDIgKGJpYXRlY0ZlZSkgZm9yIGJvb3RzdHJhcCBtdXN0IGJlIGEgdWludDI1NgoJYXNzZXJ0CgoJLy8gZXhlY3V0ZSBib290c3RyYXAodWludDI1Nix1aW50NjQsdWludDY0KXZvaWQKCWNhbGxzdWIgYm9vdHN0cmFwCglpbnRjIDAgLy8gMQoJcmV0dXJuCgovLyBib290c3RyYXAoYmlhdGVjRmVlOiB1aW50MjU2LCBhcHBCaWF0ZWNJZGVudGl0eVByb3ZpZGVyOiBBcHBJRCwgYXBwQmlhdGVjUG9vbFByb3ZpZGVyOiBBcHBJRCk6IHZvaWQKLy8KLy8gU2V0dXAgdGhlIGNvbnRyYWN0Ci8vIEBwYXJhbSBiaWF0ZWNGZWUgQmlhdGVjIGZlZXMKYm9vdHN0cmFwOgoJcHJvdG8gMyAwCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6ODUKCS8vIGFzc2VydCh0aGlzLnR4bi5zZW5kZXIgPT09IHRoaXMuYWRkcmVzc1VkcGF0ZXIudmFsdWUsICdPbmx5IHVwZGF0ZXIgY2FuIGNhbGwgYm9vdHN0cmFwIG1ldGhvZCcpCgl0eG4gU2VuZGVyCglieXRlYyAwIC8vICAidSIKCWFwcF9nbG9iYWxfZ2V0Cgk9PQoKCS8vIE9ubHkgdXBkYXRlciBjYW4gY2FsbCBib290c3RyYXAgbWV0aG9kCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czo4NgoJLy8gYXNzZXJ0KGJpYXRlY0ZlZSA8PSAoU0NBTEUgYXMgdWludDI1NikgLyAyLCAnQmlhdGVjIGNhbm5vdCBzZXQgZmVlcyBoaWdoZXIgdGhlbiA1MCUgb2YgbHAgZmVlcycpCglmcmFtZV9kaWcgLTEgLy8gYmlhdGVjRmVlOiB1aW50MjU2CglieXRlYyAzIC8vIDB4MDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAzYjlhY2EwMAoJYnl0ZWMgNCAvLyAweDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDIKCWIvCgliPD0KCgkvLyBCaWF0ZWMgY2Fubm90IHNldCBmZWVzIGhpZ2hlciB0aGVuIDUwJSBvZiBscCBmZWVzCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czo4NwoJLy8gdGhpcy5iaWF0ZWNGZWUudmFsdWUgPSBiaWF0ZWNGZWUKCWJ5dGVjIDggLy8gICJmIgoJZnJhbWVfZGlnIC0xIC8vIGJpYXRlY0ZlZTogdWludDI1NgoJYXBwX2dsb2JhbF9wdXQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czo4OAoJLy8gdGhpcy5hcHBCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLnZhbHVlID0gYXBwQmlhdGVjSWRlbnRpdHlQcm92aWRlcgoJYnl0ZWMgOSAvLyAgImkiCglmcmFtZV9kaWcgLTIgLy8gYXBwQmlhdGVjSWRlbnRpdHlQcm92aWRlcjogQXBwSUQKCWFwcF9nbG9iYWxfcHV0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6ODkKCS8vIHRoaXMuYXBwQmlhdGVjUG9vbFByb3ZpZGVyLnZhbHVlID0gYXBwQmlhdGVjUG9vbFByb3ZpZGVyCglieXRlYyAxMCAvLyAgInAiCglmcmFtZV9kaWcgLTMgLy8gYXBwQmlhdGVjUG9vbFByb3ZpZGVyOiBBcHBJRAoJYXBwX2dsb2JhbF9wdXQKCXJldHN1YgoKLy8gc2V0QWRkcmVzc1VkcGF0ZXIoYWRkcmVzcyl2b2lkCiphYmlfcm91dGVfc2V0QWRkcmVzc1VkcGF0ZXI6CgkvLyBhOiBhZGRyZXNzCgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglkdXAKCWxlbgoJaW50YyAxIC8vIDMyCgk9PQoKCS8vIGFyZ3VtZW50IDAgKGEpIGZvciBzZXRBZGRyZXNzVWRwYXRlciBtdXN0IGJlIGEgYWRkcmVzcwoJYXNzZXJ0CgoJLy8gZXhlY3V0ZSBzZXRBZGRyZXNzVWRwYXRlcihhZGRyZXNzKXZvaWQKCWNhbGxzdWIgc2V0QWRkcmVzc1VkcGF0ZXIKCWludGMgMCAvLyAxCglyZXR1cm4KCi8vIHNldEFkZHJlc3NVZHBhdGVyKGE6IEFkZHJlc3MpOiB2b2lkCi8vCi8vIFRvcCBzZWNyZXQgYWNjb3VudCB3aXRoIHdoaWNoIGl0IGlzIHBvc3NpYmxlIHVwZGF0ZSBjb250cmFjdHMgb3IgaWRlbnRpdHkgcHJvdmlkZXIKLy8KLy8gQHBhcmFtIGEgQWRkcmVzcwpzZXRBZGRyZXNzVWRwYXRlcjoKCXByb3RvIDEgMAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjk4CgkvLyBhc3NlcnQodGhpcy50eG4uc2VuZGVyID09PSB0aGlzLmFkZHJlc3NVZHBhdGVyLnZhbHVlLCAnT25seSB1cGRhdGVyIGNhbiBjaGFuZ2UgdXBkYXRlciBhZGRyZXNzJykKCXR4biBTZW5kZXIKCWJ5dGVjIDAgLy8gICJ1IgoJYXBwX2dsb2JhbF9nZXQKCT09CgoJLy8gT25seSB1cGRhdGVyIGNhbiBjaGFuZ2UgdXBkYXRlciBhZGRyZXNzCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czo5OQoJLy8gdGhpcy5hZGRyZXNzVWRwYXRlci52YWx1ZSA9IGEKCWJ5dGVjIDAgLy8gICJ1IgoJZnJhbWVfZGlnIC0xIC8vIGE6IEFkZHJlc3MKCWFwcF9nbG9iYWxfcHV0CglyZXRzdWIKCi8vIHNldFBhdXNlZCh1aW50NjQpdm9pZAoqYWJpX3JvdXRlX3NldFBhdXNlZDoKCS8vIGE6IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJYnRvaQoKCS8vIGV4ZWN1dGUgc2V0UGF1c2VkKHVpbnQ2NCl2b2lkCgljYWxsc3ViIHNldFBhdXNlZAoJaW50YyAwIC8vIDEKCXJldHVybgoKLy8gc2V0UGF1c2VkKGE6IHVpbnQ2NCk6IHZvaWQKLy8KLy8gS2lsbCBzd2l0Y2guIEluIHRoZSBleHRyZW1lIGNhc2UgYWxsIHNlcnZpY2VzIChkZXBvc2l0LCB0cmFkaW5nLCB3aXRoZHJhd2FsLCBpZGVudGl0eSBtb2RpZmljYXRpb25zIGFuZCBtb3JlKSBjYW4gYmUgc3VzcGVuZGVkLgovLwovLyBAcGFyYW0gYSBBZGRyZXNzCnNldFBhdXNlZDoKCXByb3RvIDEgMAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjEwOAoJLy8gYXNzZXJ0KHRoaXMudHhuLnNlbmRlciA9PT0gdGhpcy5hZGRyZXNzVWRwYXRlci52YWx1ZSwgJ09ubHkgdXBkYXRlciBjYW4gcGF1c2UgYW5kIHVucGF1c2UgdGhlIGJpYXRlYyBzZXJ2aWNlcycpCgl0eG4gU2VuZGVyCglieXRlYyAwIC8vICAidSIKCWFwcF9nbG9iYWxfZ2V0Cgk9PQoKCS8vIE9ubHkgdXBkYXRlciBjYW4gcGF1c2UgYW5kIHVucGF1c2UgdGhlIGJpYXRlYyBzZXJ2aWNlcwoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTA5CgkvLyB0aGlzLnN1c3BlbmRlZC52YWx1ZSA9IGEKCWJ5dGVjIDcgLy8gICJzIgoJZnJhbWVfZGlnIC0xIC8vIGE6IHVpbnQ2NAoJYXBwX2dsb2JhbF9wdXQKCXJldHN1YgoKLy8gc2V0QWRkcmVzc0dvdihhZGRyZXNzKXZvaWQKKmFiaV9yb3V0ZV9zZXRBZGRyZXNzR292OgoJLy8gYTogYWRkcmVzcwoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJZHVwCglsZW4KCWludGMgMSAvLyAzMgoJPT0KCgkvLyBhcmd1bWVudCAwIChhKSBmb3Igc2V0QWRkcmVzc0dvdiBtdXN0IGJlIGEgYWRkcmVzcwoJYXNzZXJ0CgoJLy8gZXhlY3V0ZSBzZXRBZGRyZXNzR292KGFkZHJlc3Mpdm9pZAoJY2FsbHN1YiBzZXRBZGRyZXNzR292CglpbnRjIDAgLy8gMQoJcmV0dXJuCgovLyBzZXRBZGRyZXNzR292KGE6IEFkZHJlc3MpOiB2b2lkCi8vCi8vIEV4ZWN1dGlvbiBhZGRyZXNzIHdpdGggd2hpY2ggaXQgaXMgcG9zc2libGUgdG8gb3B0IGluIGZvciBnb3Zlcm5hbmNlCi8vCi8vIEBwYXJhbSBhIEFkZHJlc3MKc2V0QWRkcmVzc0dvdjoKCXByb3RvIDEgMAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjExOAoJLy8gYXNzZXJ0KHRoaXMudHhuLnNlbmRlciA9PT0gdGhpcy5hZGRyZXNzVWRwYXRlci52YWx1ZSwgJ09ubHkgdXBkYXRlciBjYW4gY2hhbmdlIGdvdiBhZGRyZXNzJykKCXR4biBTZW5kZXIKCWJ5dGVjIDAgLy8gICJ1IgoJYXBwX2dsb2JhbF9nZXQKCT09CgoJLy8gT25seSB1cGRhdGVyIGNhbiBjaGFuZ2UgZ292IGFkZHJlc3MKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjExOQoJLy8gdGhpcy5hZGRyZXNzR292LnZhbHVlID0gYQoJYnl0ZWMgNiAvLyAgImciCglmcmFtZV9kaWcgLTEgLy8gYTogQWRkcmVzcwoJYXBwX2dsb2JhbF9wdXQKCXJldHN1YgoKLy8gc2V0QWRkcmVzc0V4ZWN1dGl2ZShhZGRyZXNzKXZvaWQKKmFiaV9yb3V0ZV9zZXRBZGRyZXNzRXhlY3V0aXZlOgoJLy8gYTogYWRkcmVzcwoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMQoJZHVwCglsZW4KCWludGMgMSAvLyAzMgoJPT0KCgkvLyBhcmd1bWVudCAwIChhKSBmb3Igc2V0QWRkcmVzc0V4ZWN1dGl2ZSBtdXN0IGJlIGEgYWRkcmVzcwoJYXNzZXJ0CgoJLy8gZXhlY3V0ZSBzZXRBZGRyZXNzRXhlY3V0aXZlKGFkZHJlc3Mpdm9pZAoJY2FsbHN1YiBzZXRBZGRyZXNzRXhlY3V0aXZlCglpbnRjIDAgLy8gMQoJcmV0dXJuCgovLyBzZXRBZGRyZXNzRXhlY3V0aXZlKGE6IEFkZHJlc3MpOiB2b2lkCi8vCi8vIEV4ZWN1dGlvbiBhZGRyZXNzIHdpdGggd2hpY2ggaXQgaXMgcG9zc2libGUgdG8gY2hhbmdlIGdsb2JhbCBiaWF0ZWMgZmVlcwovLwovLyBAcGFyYW0gYSBBZGRyZXNzCnNldEFkZHJlc3NFeGVjdXRpdmU6Cglwcm90byAxIDAKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoxMjgKCS8vIGFzc2VydCh0aGlzLnR4bi5zZW5kZXIgPT09IHRoaXMuYWRkcmVzc1VkcGF0ZXIudmFsdWUsICdPbmx5IHVwZGF0ZXIgY2FuIGNoYW5nZSBhZGRyZXNzRXhlY3V0aXZlJykKCXR4biBTZW5kZXIKCWJ5dGVjIDAgLy8gICJ1IgoJYXBwX2dsb2JhbF9nZXQKCT09CgoJLy8gT25seSB1cGRhdGVyIGNhbiBjaGFuZ2UgYWRkcmVzc0V4ZWN1dGl2ZQoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTI5CgkvLyB0aGlzLmFkZHJlc3NFeGVjdXRpdmUudmFsdWUgPSBhCglieXRlYyAyIC8vICAiZSIKCWZyYW1lX2RpZyAtMSAvLyBhOiBBZGRyZXNzCglhcHBfZ2xvYmFsX3B1dAoJcmV0c3ViCgovLyBzZXRBZGRyZXNzRXhlY3V0aXZlRmVlKGFkZHJlc3Mpdm9pZAoqYWJpX3JvdXRlX3NldEFkZHJlc3NFeGVjdXRpdmVGZWU6CgkvLyBhOiBhZGRyZXNzCgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglkdXAKCWxlbgoJaW50YyAxIC8vIDMyCgk9PQoKCS8vIGFyZ3VtZW50IDAgKGEpIGZvciBzZXRBZGRyZXNzRXhlY3V0aXZlRmVlIG11c3QgYmUgYSBhZGRyZXNzCglhc3NlcnQKCgkvLyBleGVjdXRlIHNldEFkZHJlc3NFeGVjdXRpdmVGZWUoYWRkcmVzcyl2b2lkCgljYWxsc3ViIHNldEFkZHJlc3NFeGVjdXRpdmVGZWUKCWludGMgMCAvLyAxCglyZXR1cm4KCi8vIHNldEFkZHJlc3NFeGVjdXRpdmVGZWUoYTogQWRkcmVzcyk6IHZvaWQKLy8KLy8gRXhlY3V0aW9uIGZlZSBhZGRyZXNzIGlzIGFkZHJlc3Mgd2hpY2ggY2FuIHRha2UgZmVlcyBmcm9tIHBvb2xzLgovLwovLyBAcGFyYW0gYSBBZGRyZXNzCnNldEFkZHJlc3NFeGVjdXRpdmVGZWU6Cglwcm90byAxIDAKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoxMzgKCS8vIGFzc2VydCh0aGlzLnR4bi5zZW5kZXIgPT09IHRoaXMuYWRkcmVzc0V4ZWN1dGl2ZS52YWx1ZSwgJ09ubHkgYWRkcmVzc0V4ZWN1dGl2ZSBjYW4gY2hhbmdlIGZlZSBleGVjdXRvciBhZGRyZXNzJykKCXR4biBTZW5kZXIKCWJ5dGVjIDIgLy8gICJlIgoJYXBwX2dsb2JhbF9nZXQKCT09CgoJLy8gT25seSBhZGRyZXNzRXhlY3V0aXZlIGNhbiBjaGFuZ2UgZmVlIGV4ZWN1dG9yIGFkZHJlc3MKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjEzOQoJLy8gdGhpcy5hZGRyZXNzRXhlY3V0aXZlRmVlLnZhbHVlID0gYQoJYnl0ZWMgMSAvLyAgImVmIgoJZnJhbWVfZGlnIC0xIC8vIGE6IEFkZHJlc3MKCWFwcF9nbG9iYWxfcHV0CglyZXRzdWIKCi8vIHNldEJpYXRlY0lkZW50aXR5KHVpbnQ2NCl2b2lkCiphYmlfcm91dGVfc2V0QmlhdGVjSWRlbnRpdHk6CgkvLyBhOiB1aW50NjQKCXR4bmEgQXBwbGljYXRpb25BcmdzIDEKCWJ0b2kKCgkvLyBleGVjdXRlIHNldEJpYXRlY0lkZW50aXR5KHVpbnQ2NCl2b2lkCgljYWxsc3ViIHNldEJpYXRlY0lkZW50aXR5CglpbnRjIDAgLy8gMQoJcmV0dXJuCgovLyBzZXRCaWF0ZWNJZGVudGl0eShhOiBBcHBJRCk6IHZvaWQKLy8KLy8gQXBwIGlkZW50aXR5IHNldHRlcgovLwovLyBAcGFyYW0gYSBBZGRyZXNzCnNldEJpYXRlY0lkZW50aXR5OgoJcHJvdG8gMSAwCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTQ4CgkvLyBhc3NlcnQodGhpcy50eG4uc2VuZGVyID09PSB0aGlzLmFkZHJlc3NVZHBhdGVyLnZhbHVlLCAnT25seSB1cGRhdGVyIGNhbiBjaGFuZ2UgYXBwSWRlbnRpdHlQcm92aWRlcicpCgl0eG4gU2VuZGVyCglieXRlYyAwIC8vICAidSIKCWFwcF9nbG9iYWxfZ2V0Cgk9PQoKCS8vIE9ubHkgdXBkYXRlciBjYW4gY2hhbmdlIGFwcElkZW50aXR5UHJvdmlkZXIKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjE0OQoJLy8gdGhpcy5hcHBCaWF0ZWNJZGVudGl0eVByb3ZpZGVyLnZhbHVlID0gYQoJYnl0ZWMgOSAvLyAgImkiCglmcmFtZV9kaWcgLTEgLy8gYTogQXBwSUQKCWFwcF9nbG9iYWxfcHV0CglyZXRzdWIKCi8vIHNldEJpYXRlY1Bvb2wodWludDY0KXZvaWQKKmFiaV9yb3V0ZV9zZXRCaWF0ZWNQb29sOgoJLy8gYTogdWludDY0Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglidG9pCgoJLy8gZXhlY3V0ZSBzZXRCaWF0ZWNQb29sKHVpbnQ2NCl2b2lkCgljYWxsc3ViIHNldEJpYXRlY1Bvb2wKCWludGMgMCAvLyAxCglyZXR1cm4KCi8vIHNldEJpYXRlY1Bvb2woYTogQXBwSUQpOiB2b2lkCi8vCi8vIEFwcCBpZGVudGl0eSBzZXR0ZXIKLy8KLy8gQHBhcmFtIGEgQWRkcmVzcwpzZXRCaWF0ZWNQb29sOgoJcHJvdG8gMSAwCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTU4CgkvLyBhc3NlcnQodGhpcy50eG4uc2VuZGVyID09PSB0aGlzLmFkZHJlc3NVZHBhdGVyLnZhbHVlLCAnT25seSB1cGRhdGVyIGNhbiBjaGFuZ2UgYXBwUG9vbFByb3ZpZGVyJykKCXR4biBTZW5kZXIKCWJ5dGVjIDAgLy8gICJ1IgoJYXBwX2dsb2JhbF9nZXQKCT09CgoJLy8gT25seSB1cGRhdGVyIGNhbiBjaGFuZ2UgYXBwUG9vbFByb3ZpZGVyCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoxNTkKCS8vIHRoaXMuYXBwQmlhdGVjUG9vbFByb3ZpZGVyLnZhbHVlID0gYQoJYnl0ZWMgMTAgLy8gICJwIgoJZnJhbWVfZGlnIC0xIC8vIGE6IEFwcElECglhcHBfZ2xvYmFsX3B1dAoJcmV0c3ViCgovLyBzZXRCaWF0ZWNGZWUodWludDI1Nil2b2lkCiphYmlfcm91dGVfc2V0QmlhdGVjRmVlOgoJLy8gYmlhdGVjRmVlOiB1aW50MjU2Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglkdXAKCWxlbgoJaW50YyAxIC8vIDMyCgk9PQoKCS8vIGFyZ3VtZW50IDAgKGJpYXRlY0ZlZSkgZm9yIHNldEJpYXRlY0ZlZSBtdXN0IGJlIGEgdWludDI1NgoJYXNzZXJ0CgoJLy8gZXhlY3V0ZSBzZXRCaWF0ZWNGZWUodWludDI1Nil2b2lkCgljYWxsc3ViIHNldEJpYXRlY0ZlZQoJaW50YyAwIC8vIDEKCXJldHVybgoKLy8gc2V0QmlhdGVjRmVlKGJpYXRlY0ZlZTogdWludDI1Nik6IHZvaWQKLy8KLy8gRmVlcyBpbiA5IGRlY2ltYWxzLiAxXzAwMF8wMDBfMDAwID0gMTAwJQovLyBGZWVzIGluIDkgZGVjaW1hbHMuIDEwXzAwMF8wMDAgPSAxJQovLyBGZWVzIGluIDkgZGVjaW1hbHMuIDEwMF8wMDAgPSAwLDAxJQovLwovLyBGZWVzIGFyZSByZXNwZWN0ZnVsIGZyb20gdGhlIGFsbCBmZWVzIHRha2VuIHRvIHRoZSBMUCBwcm92aWRlcnMuIElmIExQcyBjaGFyZ2UgMSUgZmVlLCBhbmQgYmlhdGVjIGNoYXJnZXMgMTAlIGZlZSwgTFAgd2lsbCByZWNlaXZlIDAuMDklIGZlZSBhbmQgYmlhdGVjIDAuMDElIGZlZQovLwovLyBAcGFyYW0gYmlhdGVjRmVlIEZlZQpzZXRCaWF0ZWNGZWU6Cglwcm90byAxIDAKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoxNzIKCS8vIGFzc2VydCh0aGlzLnR4bi5zZW5kZXIgPT09IHRoaXMuYWRkcmVzc0V4ZWN1dGl2ZS52YWx1ZSwgJ09ubHkgZXhlY3V0aXZlIGFkZHJlc3MgY2FuIGNoYW5nZSBmZWVzJykKCXR4biBTZW5kZXIKCWJ5dGVjIDIgLy8gICJlIgoJYXBwX2dsb2JhbF9nZXQKCT09CgoJLy8gT25seSBleGVjdXRpdmUgYWRkcmVzcyBjYW4gY2hhbmdlIGZlZXMKCWFzc2VydAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjE3MwoJLy8gYXNzZXJ0KGJpYXRlY0ZlZSA8PSAoU0NBTEUgYXMgdWludDI1NikgLyAyLCAnQmlhdGVjIGNhbm5vdCBzZXQgZmVlcyBoaWdoZXIgdGhlbiA1MCUgb2YgbHAgZmVlcycpCglmcmFtZV9kaWcgLTEgLy8gYmlhdGVjRmVlOiB1aW50MjU2CglieXRlYyAzIC8vIDB4MDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAzYjlhY2EwMAoJYnl0ZWMgNCAvLyAweDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDIKCWIvCgliPD0KCgkvLyBCaWF0ZWMgY2Fubm90IHNldCBmZWVzIGhpZ2hlciB0aGVuIDUwJSBvZiBscCBmZWVzCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoxNzQKCS8vIHRoaXMuYmlhdGVjRmVlLnZhbHVlID0gYmlhdGVjRmVlCglieXRlYyA4IC8vICAiZiIKCWZyYW1lX2RpZyAtMSAvLyBiaWF0ZWNGZWU6IHVpbnQyNTYKCWFwcF9nbG9iYWxfcHV0CglyZXRzdWIKCi8vIHNlbmRPbmxpbmVLZXlSZWdpc3RyYXRpb24oYnl0ZVtdLGJ5dGVbXSxieXRlW10sdWludDY0LHVpbnQ2NCx1aW50NjQpdm9pZAoqYWJpX3JvdXRlX3NlbmRPbmxpbmVLZXlSZWdpc3RyYXRpb246CgkvLyB2b3RlS2V5RGlsdXRpb246IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgNgoJYnRvaQoKCS8vIHZvdGVMYXN0OiB1aW50NjQKCXR4bmEgQXBwbGljYXRpb25BcmdzIDUKCWJ0b2kKCgkvLyB2b3RlRmlyc3Q6IHVpbnQ2NAoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgNAoJYnRvaQoKCS8vIHN0YXRlUHJvb2ZQSzogYnl0ZVtdCgl0eG5hIEFwcGxpY2F0aW9uQXJncyAzCglleHRyYWN0IDIgMAoKCS8vIHNlbGVjdGlvblBLOiBieXRlW10KCXR4bmEgQXBwbGljYXRpb25BcmdzIDIKCWV4dHJhY3QgMiAwCgoJLy8gdm90ZVBLOiBieXRlW10KCXR4bmEgQXBwbGljYXRpb25BcmdzIDEKCWV4dHJhY3QgMiAwCgoJLy8gZXhlY3V0ZSBzZW5kT25saW5lS2V5UmVnaXN0cmF0aW9uKGJ5dGVbXSxieXRlW10sYnl0ZVtdLHVpbnQ2NCx1aW50NjQsdWludDY0KXZvaWQKCWNhbGxzdWIgc2VuZE9ubGluZUtleVJlZ2lzdHJhdGlvbgoJaW50YyAwIC8vIDEKCXJldHVybgoKLy8gc2VuZE9ubGluZUtleVJlZ2lzdHJhdGlvbih2b3RlUEs6IGJ5dGVzLCBzZWxlY3Rpb25QSzogYnl0ZXMsIHN0YXRlUHJvb2ZQSzogYnl0ZXMsIHZvdGVGaXJzdDogdWludDY0LCB2b3RlTGFzdDogdWludDY0LCB2b3RlS2V5RGlsdXRpb246IHVpbnQ2NCk6IHZvaWQKLy8KLy8gYWRkcmVzc0V4ZWN1dGl2ZUZlZSBjYW4gcGVyZm9tIGtleSByZWdpc3RyYXRpb24gZm9yIHRoaXMgTFAgcG9vbAovLwovLyBPbmx5IGFkZHJlc3NFeGVjdXRpdmVGZWUgaXMgYWxsb3dlZCB0byBleGVjdXRlIHRoaXMgbWV0aG9kLgpzZW5kT25saW5lS2V5UmVnaXN0cmF0aW9uOgoJcHJvdG8gNiAwCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTkwCgkvLyBhc3NlcnQoCgkvLyAgICAgICB0aGlzLnR4bi5zZW5kZXIgPT09IHRoaXMuYWRkcmVzc0V4ZWN1dGl2ZUZlZS52YWx1ZSwKCS8vICAgICAgICdPbmx5IGZlZSBleGVjdXRvciBzZXR1cCBpbiB0aGUgY29uZmlnIGNhbiB0YWtlIHRoZSBjb2xsZWN0ZWQgZmVlcycKCS8vICAgICApCgl0eG4gU2VuZGVyCglieXRlYyAxIC8vICAiZWYiCglhcHBfZ2xvYmFsX2dldAoJPT0KCgkvLyBPbmx5IGZlZSBleGVjdXRvciBzZXR1cCBpbiB0aGUgY29uZmlnIGNhbiB0YWtlIHRoZSBjb2xsZWN0ZWQgZmVlcwoJYXNzZXJ0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTk0CgkvLyBzZW5kT25saW5lS2V5UmVnaXN0cmF0aW9uKHsKCS8vICAgICAgIHNlbGVjdGlvblBLOiBzZWxlY3Rpb25QSywKCS8vICAgICAgIHN0YXRlUHJvb2ZQSzogc3RhdGVQcm9vZlBLLAoJLy8gICAgICAgdm90ZUZpcnN0OiB2b3RlRmlyc3QsCgkvLyAgICAgICB2b3RlS2V5RGlsdXRpb246IHZvdGVLZXlEaWx1dGlvbiwKCS8vICAgICAgIHZvdGVMYXN0OiB2b3RlTGFzdCwKCS8vICAgICAgIHZvdGVQSzogdm90ZVBLLAoJLy8gICAgICAgZmVlOiAwLAoJLy8gICAgIH0pCglpdHhuX2JlZ2luCglwdXNoaW50IDIgLy8ga2V5cmVnCglpdHhuX2ZpZWxkIFR5cGVFbnVtCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTk1CgkvLyBzZWxlY3Rpb25QSzogc2VsZWN0aW9uUEsKCWZyYW1lX2RpZyAtMiAvLyBzZWxlY3Rpb25QSzogYnl0ZXMKCWl0eG5fZmllbGQgU2VsZWN0aW9uUEsKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoxOTYKCS8vIHN0YXRlUHJvb2ZQSzogc3RhdGVQcm9vZlBLCglmcmFtZV9kaWcgLTMgLy8gc3RhdGVQcm9vZlBLOiBieXRlcwoJaXR4bl9maWVsZCBTdGF0ZVByb29mUEsKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoxOTcKCS8vIHZvdGVGaXJzdDogdm90ZUZpcnN0CglmcmFtZV9kaWcgLTQgLy8gdm90ZUZpcnN0OiB1aW50NjQKCWl0eG5fZmllbGQgVm90ZUZpcnN0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MTk4CgkvLyB2b3RlS2V5RGlsdXRpb246IHZvdGVLZXlEaWx1dGlvbgoJZnJhbWVfZGlnIC02IC8vIHZvdGVLZXlEaWx1dGlvbjogdWludDY0CglpdHhuX2ZpZWxkIFZvdGVLZXlEaWx1dGlvbgoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjE5OQoJLy8gdm90ZUxhc3Q6IHZvdGVMYXN0CglmcmFtZV9kaWcgLTUgLy8gdm90ZUxhc3Q6IHVpbnQ2NAoJaXR4bl9maWVsZCBWb3RlTGFzdAoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjIwMAoJLy8gdm90ZVBLOiB2b3RlUEsKCWZyYW1lX2RpZyAtMSAvLyB2b3RlUEs6IGJ5dGVzCglpdHhuX2ZpZWxkIFZvdGVQSwoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjIwMQoJLy8gZmVlOiAwCglpbnRjIDIgLy8gMAoJaXR4bl9maWVsZCBGZWUKCgkvLyBTdWJtaXQgaW5uZXIgdHJhbnNhY3Rpb24KCWl0eG5fc3VibWl0CglyZXRzdWIKCi8vIHdpdGhkcmF3RXhjZXNzQXNzZXRzKHVpbnQ2NCx1aW50NjQpdWludDY0CiphYmlfcm91dGVfd2l0aGRyYXdFeGNlc3NBc3NldHM6CgkvLyBUaGUgQUJJIHJldHVybiBwcmVmaXgKCXB1c2hieXRlcyAweDE1MWY3Yzc1CgoJLy8gYW1vdW50OiB1aW50NjQKCXR4bmEgQXBwbGljYXRpb25BcmdzIDIKCWJ0b2kKCgkvLyBhc3NldDogdWludDY0Cgl0eG5hIEFwcGxpY2F0aW9uQXJncyAxCglidG9pCgoJLy8gZXhlY3V0ZSB3aXRoZHJhd0V4Y2Vzc0Fzc2V0cyh1aW50NjQsdWludDY0KXVpbnQ2NAoJY2FsbHN1YiB3aXRoZHJhd0V4Y2Vzc0Fzc2V0cwoJaXRvYgoJY29uY2F0Cglsb2cKCWludGMgMCAvLyAxCglyZXR1cm4KCi8vIHdpdGhkcmF3RXhjZXNzQXNzZXRzKGFzc2V0OiBBc3NldElELCBhbW91bnQ6IHVpbnQ2NCk6IHVpbnQ2NAovLwovLyBJZiBzb21lb25lIGRlcG9zaXRzIGV4Y2VzcyBhc3NldHMgdG8gdGhpcyBzbWFydCBjb250cmFjdCBiaWF0ZWMgY2FuIHVzZSB0aGVtLgovLwovLyBPbmx5IGFkZHJlc3NFeGVjdXRpdmVGZWUgaXMgYWxsb3dlZCB0byBleGVjdXRlIHRoaXMgbWV0aG9kLgovLwovLyBAcGFyYW0gYXNzZXQgQXNzZXQgdG8gd2l0aGRyYXcuIElmIG5hdGl2ZSB0b2tlbiwgdGhlbiB6ZXJvCi8vIEBwYXJhbSBhbW91bnQgQW1vdW50IG9mIHRoZSBhc3NldCB0byBiZSB3aXRoZHJhd24Kd2l0aGRyYXdFeGNlc3NBc3NldHM6Cglwcm90byAyIDEKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoyMTQKCS8vIGFzc2VydCgKCS8vICAgICAgIHRoaXMudHhuLnNlbmRlciA9PT0gdGhpcy5hZGRyZXNzRXhlY3V0aXZlRmVlLnZhbHVlLAoJLy8gICAgICAgJ09ubHkgZmVlIGV4ZWN1dG9yIHNldHVwIGluIHRoZSBjb25maWcgY2FuIHRha2UgdGhlIGNvbGxlY3RlZCBmZWVzJwoJLy8gICAgICkKCXR4biBTZW5kZXIKCWJ5dGVjIDEgLy8gICJlZiIKCWFwcF9nbG9iYWxfZ2V0Cgk9PQoKCS8vIE9ubHkgZmVlIGV4ZWN1dG9yIHNldHVwIGluIHRoZSBjb25maWcgY2FuIHRha2UgdGhlIGNvbGxlY3RlZCBmZWVzCglhc3NlcnQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoyMTkKCS8vIHRoaXMuZG9BeGZlcih0aGlzLnR4bi5zZW5kZXIsIGFzc2V0LCBhbW91bnQpCglmcmFtZV9kaWcgLTIgLy8gYW1vdW50OiB1aW50NjQKCWZyYW1lX2RpZyAtMSAvLyBhc3NldDogQXNzZXRJRAoJdHhuIFNlbmRlcgoJY2FsbHN1YiBkb0F4ZmVyCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MjIxCgkvLyByZXR1cm4gYW1vdW50OwoJZnJhbWVfZGlnIC0yIC8vIGFtb3VudDogdWludDY0CglyZXRzdWIKCi8vIGRvQXhmZXIocmVjZWl2ZXI6IEFkZHJlc3MsIGFzc2V0OiBBc3NldElELCBhbW91bnQ6IHVpbnQ2NCk6IHZvaWQKLy8KLy8gRXhlY3V0ZXMgeGZlciBvZiBwYXkgcGF5bWVudCBtZXRob2RzIHRvIHNwZWNpZmllZCByZWNlaXZlciBmcm9tIHNtYXJ0IGNvbnRyYWN0IGFnZ3JlZ2F0ZWQgYWNjb3VudCB3aXRoIHNwZWNpZmllZCBhc3NldCBhbmQgYW1vdW50IGluIHRva2VucyBkZWNpbWFscwovLyBAcGFyYW0gcmVjZWl2ZXIgUmVjZWl2ZXIKLy8gQHBhcmFtIGFzc2V0IEFzc2V0LiBaZXJvIGZvciBhbGdvCi8vIEBwYXJhbSBhbW91bnQgQW1vdW50IHRvIHRyYW5zZmVyCmRvQXhmZXI6Cglwcm90byAzIDAKCgkvLyAqaWYwX2NvbmRpdGlvbgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MjMxCgkvLyBhc3NldC5pZCA9PT0gMAoJZnJhbWVfZGlnIC0yIC8vIGFzc2V0OiBBc3NldElECglpbnRjIDIgLy8gMAoJPT0KCWJ6ICppZjBfZWxzZQoKCS8vICppZjBfY29uc2VxdWVudAoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MjMyCgkvLyBzZW5kUGF5bWVudCh7CgkvLyAgICAgICAgIHJlY2VpdmVyOiByZWNlaXZlciwKCS8vICAgICAgICAgYW1vdW50OiBhbW91bnQsCgkvLyAgICAgICAgIGZlZTogMCwKCS8vICAgICAgIH0pCglpdHhuX2JlZ2luCglpbnRjIDAgLy8gIHBheQoJaXR4bl9maWVsZCBUeXBlRW51bQoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjIzMwoJLy8gcmVjZWl2ZXI6IHJlY2VpdmVyCglmcmFtZV9kaWcgLTEgLy8gcmVjZWl2ZXI6IEFkZHJlc3MKCWl0eG5fZmllbGQgUmVjZWl2ZXIKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoyMzQKCS8vIGFtb3VudDogYW1vdW50CglmcmFtZV9kaWcgLTMgLy8gYW1vdW50OiB1aW50NjQKCWl0eG5fZmllbGQgQW1vdW50CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MjM1CgkvLyBmZWU6IDAKCWludGMgMiAvLyAwCglpdHhuX2ZpZWxkIEZlZQoKCS8vIFN1Ym1pdCBpbm5lciB0cmFuc2FjdGlvbgoJaXR4bl9zdWJtaXQKCWIgKmlmMF9lbmQKCippZjBfZWxzZToKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjIzOAoJLy8gc2VuZEFzc2V0VHJhbnNmZXIoewoJLy8gICAgICAgICBhc3NldFJlY2VpdmVyOiByZWNlaXZlciwKCS8vICAgICAgICAgeGZlckFzc2V0OiBhc3NldCwKCS8vICAgICAgICAgYXNzZXRBbW91bnQ6IGFtb3VudCwKCS8vICAgICAgICAgZmVlOiAwLAoJLy8gICAgICAgfSkKCWl0eG5fYmVnaW4KCXB1c2hpbnQgNCAvLyBheGZlcgoJaXR4bl9maWVsZCBUeXBlRW51bQoKCS8vIGNvbnRyYWN0c1xCaWF0ZWNDb25maWdQcm92aWRlci5hbGdvLnRzOjIzOQoJLy8gYXNzZXRSZWNlaXZlcjogcmVjZWl2ZXIKCWZyYW1lX2RpZyAtMSAvLyByZWNlaXZlcjogQWRkcmVzcwoJaXR4bl9maWVsZCBBc3NldFJlY2VpdmVyCgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MjQwCgkvLyB4ZmVyQXNzZXQ6IGFzc2V0CglmcmFtZV9kaWcgLTIgLy8gYXNzZXQ6IEFzc2V0SUQKCWl0eG5fZmllbGQgWGZlckFzc2V0CgoJLy8gY29udHJhY3RzXEJpYXRlY0NvbmZpZ1Byb3ZpZGVyLmFsZ28udHM6MjQxCgkvLyBhc3NldEFtb3VudDogYW1vdW50CglmcmFtZV9kaWcgLTMgLy8gYW1vdW50OiB1aW50NjQKCWl0eG5fZmllbGQgQXNzZXRBbW91bnQKCgkvLyBjb250cmFjdHNcQmlhdGVjQ29uZmlnUHJvdmlkZXIuYWxnby50czoyNDIKCS8vIGZlZTogMAoJaW50YyAyIC8vIDAKCWl0eG5fZmllbGQgRmVlCgoJLy8gU3VibWl0IGlubmVyIHRyYW5zYWN0aW9uCglpdHhuX3N1Ym1pdAoKKmlmMF9lbmQ6CglyZXRzdWIKCipjcmVhdGVfTm9PcDoKCXB1c2hieXRlcyAweGI4NDQ3YjM2IC8vIG1ldGhvZCAiY3JlYXRlQXBwbGljYXRpb24oKXZvaWQiCgl0eG5hIEFwcGxpY2F0aW9uQXJncyAwCgltYXRjaCAqYWJpX3JvdXRlX2NyZWF0ZUFwcGxpY2F0aW9uCgoJLy8gdGhpcyBjb250cmFjdCBkb2VzIG5vdCBpbXBsZW1lbnQgdGhlIGdpdmVuIEFCSSBtZXRob2QgZm9yIGNyZWF0ZSBOb09wCgllcnIKCipjYWxsX05vT3A6CglwdXNoYnl0ZXMgMHg0OTVjZTdlZCAvLyBtZXRob2QgImJvb3RzdHJhcCh1aW50MjU2LHVpbnQ2NCx1aW50NjQpdm9pZCIKCXB1c2hieXRlcyAweGJmYzIwODYwIC8vIG1ldGhvZCAic2V0QWRkcmVzc1VkcGF0ZXIoYWRkcmVzcyl2b2lkIgoJcHVzaGJ5dGVzIDB4MGNkYzEwZmMgLy8gbWV0aG9kICJzZXRQYXVzZWQodWludDY0KXZvaWQiCglwdXNoYnl0ZXMgMHg2Yjk1NWY0YiAvLyBtZXRob2QgInNldEFkZHJlc3NHb3YoYWRkcmVzcyl2b2lkIgoJcHVzaGJ5dGVzIDB4OGIxODdiM2QgLy8gbWV0aG9kICJzZXRBZGRyZXNzRXhlY3V0aXZlKGFkZHJlc3Mpdm9pZCIKCXB1c2hieXRlcyAweDUwZTA3ZDg4IC8vIG1ldGhvZCAic2V0QWRkcmVzc0V4ZWN1dGl2ZUZlZShhZGRyZXNzKXZvaWQiCglwdXNoYnl0ZXMgMHhiYWJlMWUxMSAvLyBtZXRob2QgInNldEJpYXRlY0lkZW50aXR5KHVpbnQ2NCl2b2lkIgoJcHVzaGJ5dGVzIDB4YzU4YjlkYTQgLy8gbWV0aG9kICJzZXRCaWF0ZWNQb29sKHVpbnQ2NCl2b2lkIgoJcHVzaGJ5dGVzIDB4Y2EzNDRhMzQgLy8gbWV0aG9kICJzZXRCaWF0ZWNGZWUodWludDI1Nil2b2lkIgoJcHVzaGJ5dGVzIDB4NDlmM2ExN2YgLy8gbWV0aG9kICJzZW5kT25saW5lS2V5UmVnaXN0cmF0aW9uKGJ5dGVbXSxieXRlW10sYnl0ZVtdLHVpbnQ2NCx1aW50NjQsdWludDY0KXZvaWQiCglwdXNoYnl0ZXMgMHg4NzI4MzczMCAvLyBtZXRob2QgIndpdGhkcmF3RXhjZXNzQXNzZXRzKHVpbnQ2NCx1aW50NjQpdWludDY0IgoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMAoJbWF0Y2ggKmFiaV9yb3V0ZV9ib290c3RyYXAgKmFiaV9yb3V0ZV9zZXRBZGRyZXNzVWRwYXRlciAqYWJpX3JvdXRlX3NldFBhdXNlZCAqYWJpX3JvdXRlX3NldEFkZHJlc3NHb3YgKmFiaV9yb3V0ZV9zZXRBZGRyZXNzRXhlY3V0aXZlICphYmlfcm91dGVfc2V0QWRkcmVzc0V4ZWN1dGl2ZUZlZSAqYWJpX3JvdXRlX3NldEJpYXRlY0lkZW50aXR5ICphYmlfcm91dGVfc2V0QmlhdGVjUG9vbCAqYWJpX3JvdXRlX3NldEJpYXRlY0ZlZSAqYWJpX3JvdXRlX3NlbmRPbmxpbmVLZXlSZWdpc3RyYXRpb24gKmFiaV9yb3V0ZV93aXRoZHJhd0V4Y2Vzc0Fzc2V0cwoKCS8vIHRoaXMgY29udHJhY3QgZG9lcyBub3QgaW1wbGVtZW50IHRoZSBnaXZlbiBBQkkgbWV0aG9kIGZvciBjYWxsIE5vT3AKCWVycgoKKmNhbGxfVXBkYXRlQXBwbGljYXRpb246CglwdXNoYnl0ZXMgMHg2OTM2YzYyZiAvLyBtZXRob2QgInVwZGF0ZUFwcGxpY2F0aW9uKGJ5dGVbXSl2b2lkIgoJdHhuYSBBcHBsaWNhdGlvbkFyZ3MgMAoJbWF0Y2ggKmFiaV9yb3V0ZV91cGRhdGVBcHBsaWNhdGlvbgoKCS8vIHRoaXMgY29udHJhY3QgZG9lcyBub3QgaW1wbGVtZW50IHRoZSBnaXZlbiBBQkkgbWV0aG9kIGZvciBjYWxsIFVwZGF0ZUFwcGxpY2F0aW9uCgllcnI=";
        protected override string SourceClear { get; set; } = "I3ByYWdtYSB2ZXJzaW9uIDEw";
        protected override string SourceApprovalAVM { get; set; } = "CiADASAAJgsBdQJlZgFlIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA7msoAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACBXNjdmVyAWcBcwFmAWkBcDEYFIEGCzEZCI0MAh0AAAAAAAACewAAAg8AAAAAAAAAAAAAAIgAAiJDigAAJwWAFkJJQVRFQy1DT05GSUctMDEtMDItMDFnKjEAZycGMQBnKDEAZykxAGcnByRniTYaAVcCAIgAAiJDigEAMQAoZBJEJwWL/2eJNhoDFzYaAhc2GgFJFSMSRIgAAiJDigMAMQAoZBJEi/8rJwSipkQnCIv/ZycJi/5nJwqL/WeJNhoBSRUjEkSIAAIiQ4oBADEAKGQSRCiL/2eJNhoBF4gAAiJDigEAMQAoZBJEJweL/2eJNhoBSRUjEkSIAAIiQ4oBADEAKGQSRCcGi/9niTYaAUkVIxJEiAACIkOKAQAxAChkEkQqi/9niTYaAUkVIxJEiAACIkOKAQAxACpkEkQpi/9niTYaAReIAAIiQ4oBADEAKGQSRCcJi/9niTYaAReIAAIiQ4oBADEAKGQSRCcKi/9niTYaAUkVIxJEiAACIkOKAQAxACpkEkSL/ysnBKKmRCcIi/9niTYaBhc2GgUXNhoEFzYaA1cCADYaAlcCADYaAVcCAIgAAiJDigYAMQApZBJEsYECshCL/rILi/2yP4v8sgyL+rIOi/uyDYv/sgoksgGziYAEFR98dTYaAhc2GgEXiAAFFlCwIkOKAgExAClkEkSL/ov/MQCIAAOL/omKAwCL/iQSQQATsSKyEIv/sgeL/bIIJLIBs0IAFbGBBLIQi/+yFIv+shGL/bISJLIBs4mABLhEezY2GgCOAf3lAIAESVzn7YAEv8IIYIAEDNwQ/IAEa5VfS4AEixh7PYAEUOB9iIAEur4eEYAExYudpIAEyjRKNIAESfOhf4AEhyg3MDYaAI4L/dr+EP4r/kP+X/56/pX+rf7F/un/NwCABGk2xi82GgCOAf2yAA==";
        protected override string SourceClearAVM { get; set; } = "Cg==";
        protected override ulong? GlobalNumByteSlices { get; set; } = 6;
        protected override ulong? GlobalNumUints { get; set; } = 3;
        protected override ulong? LocalNumByteSlices { get; set; } = 0;
        protected override ulong? LocalNumUints { get; set; } = 0;

    }

}
