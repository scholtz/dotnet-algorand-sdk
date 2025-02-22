using System;
using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using AlgoStudio;
using AlgoStudio.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNamespace
{


    public class BiatecClammPoolProxy : ProxyBase
    {

        public BiatecClammPoolProxy(DefaultApi defaultApi, ulong appId) : base(defaultApi, appId)
        {
        }

        ///<summary>
        ///Initial setup
        ///No_op: CREATE, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        public async Task createApplication(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 184, 68, 123, 54 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);

        }

        public async Task<List<Transaction>> createApplication_Transactions(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 184, 68, 123, 54 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);

        }

        ///<summary>
        ///addressUdpater from global biatec configuration is allowed to update application
        ///No_op: NEVER, Opt_in: NEVER, Close_out: NEVER, Update_application: CALL, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider"> ABI Type is uint64  </param>
        /// <param name="newVersion"> ABI Type is byte[]  </param>
        public async Task updateApplication(Account sender, ulong? fee, ulong appBiatecConfigProvider, byte[] newVersion, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 95, 200, 133, 160 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, newVersion }, null, null, null, boxes);

        }

        public async Task<List<Transaction>> updateApplication_Transactions(Account sender, ulong? fee, ulong appBiatecConfigProvider, byte[] newVersion, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 95, 200, 133, 160 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, newVersion }, null, null, null, boxes);

        }

        ///<summary>
        ///
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        public async Task<ulong> getCurrentPrice(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 209, 113, 127, 229 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> getCurrentPrice_Transactions(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 209, 113, 127, 229 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);

        }

        ///<summary>
        ///
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        public async Task<ulong> getPriceDivider(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 227, 164, 58, 74 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> getPriceDivider_Transactions(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 227, 164, 58, 74 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);

        }

        ///<summary>
        ///
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        public async Task<ulong> getLPTokenId(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 29, 118, 74, 158 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> getLPTokenId_Transactions(Account sender, ulong? fee, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 29, 118, 74, 158 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle }, null, null, null, boxes);

        }

        ///<summary>
        ///Anybody can deploy the clamm smart contract
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="assetA">Asset A ID must be lower then Asset B ID ABI Type is uint64  </param>
        /// <param name="assetB">Asset B ABI Type is uint64  </param>
        /// <param name="appBiatecConfigProvider">Biatec amm provider ABI Type is uint64  </param>
        /// <param name="appBiatecPoolProvider">Pool provider ABI Type is uint64  </param>
        /// <param name="txSeed">Seed transaction so that smart contract can opt in to the assets ABI Type is pay  </param>
        /// <param name="fee">Fee in base level (9 decimals). value 1_000_000_000 = 1 = 100%. 10_000_000 = 1%. 1_000_000 = 0.1% ABI Type is uint64  </param>
        /// <param name="priceMin">Min price range. At this point all assets are in asset A. ABI Type is uint64  </param>
        /// <param name="priceMax">Max price range. At this point all assets are in asset B. ABI Type is uint64  </param>
        /// <param name="currentPrice">Deployer can specify the current price for easier deployemnt. ABI Type is uint64  </param>
        /// <param name="verificationClass">Minimum verification level from the biatec identity. Level 0 means no kyc. ABI Type is uint8  </param>
        public async Task<ulong> bootstrap(Account sender, ulong? fee1, PaymentTransaction txSeed, ulong assetA, ulong assetB, ulong appBiatecConfigProvider, ulong appBiatecPoolProvider, ulong fee, ulong priceMin, ulong priceMax, ulong currentPrice, byte verificationClass, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 179, 19, 1, 46 };
            var result = await base.CallApp(new List<Transaction> { txSeed }, fee, callType, 1000, note, sender, new List<object> { abiHandle, assetA, assetB, appBiatecConfigProvider, appBiatecPoolProvider, fee1, priceMin, priceMax, currentPrice, verificationClass }, null, null, null, boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> bootstrap_Transactions(Account sender, ulong? fee1, PaymentTransaction txSeed, ulong assetA, ulong assetB, ulong appBiatecConfigProvider, ulong appBiatecPoolProvider, ulong fee, ulong priceMin, ulong priceMax, ulong currentPrice, byte verificationClass, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 179, 19, 1, 46 };
            return await base.MakeTransactionList(new List<Transaction> { txSeed }, fee, callType, 1000, note, sender, new List<object> { abiHandle, assetA, assetB, appBiatecConfigProvider, appBiatecPoolProvider, fee1, priceMin, priceMax, currentPrice, verificationClass }, null, null, null, boxes);

        }

        ///<summary>
        ///This method adds Asset A and Asset B to the Automated Market Maker Concentrated Liqudidity Pool and send to the liqudidty provider the liqudity token
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider">Configuration reference ABI Type is uint64  </param>
        /// <param name="appBiatecIdentityProvider">Identity service reference ABI Type is uint64  </param>
        /// <param name="txAssetADeposit">Transfer of asset A to the LP pool ABI Type is txn  </param>
        /// <param name="txAssetBDeposit">Transfer of asset B to the LP pool ABI Type is txn  </param>
        /// <param name="assetA">Asset A ABI Type is uint64  </param>
        /// <param name="assetB">Asset B ABI Type is uint64  </param>
        /// <param name="assetLp">Liquidity pool asset ABI Type is uint64  </param>
        public async Task<ulong> addLiquidity(Account sender, ulong? fee, Transaction txAssetADeposit, Transaction txAssetBDeposit, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong assetA, ulong assetB, ulong assetLp, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 4, 64, 250, 143 };
            var result = await base.CallApp(new List<Transaction> { txAssetADeposit, txAssetBDeposit }, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, appBiatecIdentityProvider, assetA, assetB, assetLp }, null, null, null, boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> addLiquidity_Transactions(Account sender, ulong? fee, Transaction txAssetADeposit, Transaction txAssetBDeposit, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong assetA, ulong assetB, ulong assetLp, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 4, 64, 250, 143 };
            return await base.MakeTransactionList(new List<Transaction> { txAssetADeposit, txAssetBDeposit }, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, appBiatecIdentityProvider, assetA, assetB, assetLp }, null, null, null, boxes);

        }

        ///<summary>
        ///This method retrieves from the liquidity provider LP token and returns Asset A and Asset B from the Automated Market Maker Concentrated Liqudidity Pool
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider">Configuration reference ABI Type is uint64  </param>
        /// <param name="appBiatecIdentityProvider">Identity service reference ABI Type is uint64  </param>
        /// <param name="txLpXfer">Transfer of the LP token ABI Type is axfer  </param>
        /// <param name="assetA">Asset A ABI Type is uint64  </param>
        /// <param name="assetB">Asset B ABI Type is uint64  </param>
        /// <param name="assetLp">LP pool asset ABI Type is uint64  </param>
        public async Task<System.Numerics.BigInteger> removeLiquidity(Account sender, ulong? fee, AssetTransferTransaction txLpXfer, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong assetA, ulong assetB, ulong assetLp, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 84, 154, 144, 164 };
            var result = await base.CallApp(new List<Transaction> { txLpXfer }, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, appBiatecIdentityProvider, assetA, assetB, assetLp }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> removeLiquidity_Transactions(Account sender, ulong? fee, AssetTransferTransaction txLpXfer, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong assetA, ulong assetB, ulong assetLp, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 84, 154, 144, 164 };
            return await base.MakeTransactionList(new List<Transaction> { txLpXfer }, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, appBiatecIdentityProvider, assetA, assetB, assetLp }, null, null, null, boxes);

        }

        ///<summary>
        ///This method allows biatec admin to reduce the lp position created by lp fees allocation.Only addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method. ABI Type is uint64  </param>
        /// <param name="assetA">Asset A ABI Type is uint64  </param>
        /// <param name="assetB">Asset B ABI Type is uint64  </param>
        /// <param name="assetLp"> ABI Type is uint64  </param>
        /// <param name="amount">Amount to withdraw. If zero, removes all available lps from fees. ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> removeLiquidityAdmin(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong assetLp, System.Numerics.BigInteger amount, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 137, 74, 147, 79 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, assetLp, amount }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> removeLiquidityAdmin_Transactions(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong assetLp, System.Numerics.BigInteger amount, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 137, 74, 147, 79 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, assetLp, amount }, null, null, null, boxes);

        }

        ///<summary>
        ///Swap Asset A to Asset B or Asset B to Asst A
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider"> ABI Type is uint64  </param>
        /// <param name="appBiatecIdentityProvider"> ABI Type is uint64  </param>
        /// <param name="appBiatecPoolProvider"> ABI Type is uint64  </param>
        /// <param name="txSwap">Transfer of the token to be deposited to the pool. To the owner the other asset will be sent. ABI Type is txn  </param>
        /// <param name="assetA">Asset A ABI Type is uint64  </param>
        /// <param name="assetB">Asset B ABI Type is uint64  </param>
        /// <param name="minimumToReceive">If number greater then zero, the check is performed for the output of the other asset ABI Type is uint64  </param>
        public async Task<System.Numerics.BigInteger> swap(Account sender, ulong? fee, Transaction txSwap, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong appBiatecPoolProvider, ulong assetA, ulong assetB, ulong minimumToReceive, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 32, 19, 52, 158 };
            var result = await base.CallApp(new List<Transaction> { txSwap }, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, appBiatecIdentityProvider, appBiatecPoolProvider, assetA, assetB, minimumToReceive }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> swap_Transactions(Account sender, ulong? fee, Transaction txSwap, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong appBiatecPoolProvider, ulong assetA, ulong assetB, ulong minimumToReceive, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 32, 19, 52, 158 };
            return await base.MakeTransactionList(new List<Transaction> { txSwap }, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, appBiatecIdentityProvider, appBiatecPoolProvider, assetA, assetB, minimumToReceive }, null, null, null, boxes);

        }

        ///<summary>
        ///If someone deposits excess assets to the LP pool, addressExecutiveFee can either distribute them to the lp tokens or withdraw it, depending on the use case.If someone sent there assets in fault, the withrawing can be use to return them back. If the pool received assets for example for having its algo stake online and recieved rewards it is prefered to distribute them to the current LP holders.This method is used to distribute amount a and amount b of asset a and asset b to holders as the fee income.Only addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method. ABI Type is uint64  </param>
        /// <param name="assetA">Asset A ABI Type is uint64  </param>
        /// <param name="assetB">Asset B ABI Type is uint64  </param>
        /// <param name="amountA">Amount of asset A to be deposited to the liquidity. In base decimals (9) ABI Type is uint256  </param>
        /// <param name="amountB">Amount of asset B to be deposited to the liquidity. In base decimals (9) ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> distributeExcessAssets(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, System.Numerics.BigInteger amountA, System.Numerics.BigInteger amountB, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 206, 86, 68, 18 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, amountA, amountB }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> distributeExcessAssets_Transactions(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, System.Numerics.BigInteger amountA, System.Numerics.BigInteger amountB, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 206, 86, 68, 18 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, amountA, amountB }, null, null, null, boxes);

        }

        ///<summary>
        ///If someone deposits excess assets to the LP pool, addressExecutiveFee can either distribute them to the lp tokens or withdraw it, depending on the use case.If someone sent there assets in fault, the withrawing can be use to return them back. If the pool received assets for example for having its algo stake online and recieved rewards it is prefered to distribute them to the current LP holders.This method is used to distribute amount a and amount b of asset a and asset b to addressExecutiveFee account.Only addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method. ABI Type is uint64  </param>
        /// <param name="assetA">Asset A ABI Type is uint64  </param>
        /// <param name="assetB">Asset B ABI Type is uint64  </param>
        /// <param name="amountA">Amount of asset A to be deposited to the liquidity. In asset a decimals ABI Type is uint64  </param>
        /// <param name="amountB">Amount of asset B to be deposited to the liquidity. In asset b decimals ABI Type is uint64  </param>
        public async Task<ulong> withdrawExcessAssets(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong amountA, ulong amountB, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 34, 183, 70, 200 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, amountA, amountB }, null, null, null, boxes);
            return BitConverter.ToUInt64(ReverseIfLittleEndian(result.First().ToArray()), 0);

        }

        public async Task<List<Transaction>> withdrawExcessAssets_Transactions(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong amountA, ulong amountB, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 34, 183, 70, 200 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, amountA, amountB }, null, null, null, boxes);

        }

        ///<summary>
        ///addressExecutiveFee can perfom key registration for this LP poolOnly addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider"> ABI Type is uint64  </param>
        /// <param name="votePk"> ABI Type is byte[]  </param>
        /// <param name="selectionPk"> ABI Type is byte[]  </param>
        /// <param name="stateProofPk"> ABI Type is byte[]  </param>
        /// <param name="voteFirst"> ABI Type is uint64  </param>
        /// <param name="voteLast"> ABI Type is uint64  </param>
        /// <param name="voteKeyDilution"> ABI Type is uint64  </param>
        public async Task sendOnlineKeyRegistration(Account sender, ulong? fee, ulong appBiatecConfigProvider, byte[] votePk, byte[] selectionPk, byte[] stateProofPk, ulong voteFirst, ulong voteLast, ulong voteKeyDilution, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 131, 146, 92, 23 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, votePk, selectionPk, stateProofPk, voteFirst, voteLast, voteKeyDilution }, null, null, null, boxes);

        }

        public async Task<List<Transaction>> sendOnlineKeyRegistration_Transactions(Account sender, ulong? fee, ulong appBiatecConfigProvider, byte[] votePk, byte[] selectionPk, byte[] stateProofPk, ulong voteFirst, ulong voteLast, ulong voteKeyDilution, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 131, 146, 92, 23 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, votePk, selectionPk, stateProofPk, voteFirst, voteLast, voteKeyDilution }, null, null, null, boxes);

        }

        ///<summary>
        ///addressExecutiveFee can perfom key unregistration for this LP poolOnly addressExecutiveFee is allowed to execute this method.
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider"> ABI Type is uint64  </param>
        public async Task sendOfflineKeyRegistration(Account sender, ulong? fee, ulong appBiatecConfigProvider, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 9, 85, 194, 90 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider }, null, null, null, boxes);

        }

        public async Task<List<Transaction>> sendOfflineKeyRegistration_Transactions(Account sender, ulong? fee, ulong appBiatecConfigProvider, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 9, 85, 194, 90 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates the number of LP tokens issued to users
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="assetLp"> ABI Type is uint64  </param>
        /// <param name="currentDeposit"> ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateDistributedLiquidity(Account sender, ulong? fee, ulong assetLp, System.Numerics.BigInteger currentDeposit, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 57, 236, 168, 84 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, assetLp, currentDeposit }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateDistributedLiquidity_Transactions(Account sender, ulong? fee, ulong assetLp, System.Numerics.BigInteger currentDeposit, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 57, 236, 168, 84 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, assetLp, currentDeposit }, null, null, null, boxes);

        }

        ///<summary>
        ///
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="x"> ABI Type is uint256  </param>
        /// <param name="y"> ABI Type is uint256  </param>
        /// <param name="price"> ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateLiquidityFlatPrice(Account sender, ulong? fee, System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger price, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 255, 105, 88, 22 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, x, y, price }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateLiquidityFlatPrice_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger price, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 255, 105, 88, 22 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, x, y, price }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates the liquidity  from the x - Asset A position and y - Asset B positionThis method calculates discriminant - first part of the calculation.It is divided so that the readonly method does not need to charge fees
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="x">Asset A position balanced on the curve ABI Type is uint256  </param>
        /// <param name="y">Asset B position balanced on the curve ABI Type is uint256  </param>
        /// <param name="priceMin">Minimum price variable in base scale decimals (pa) ABI Type is uint256  </param>
        /// <param name="priceMax">Maximum price variable in base scale decimals (pb) ABI Type is uint256  </param>
        /// <param name="priceMinSqrt">sqrt(priceMin) in base scale decimals Variable pas ABI Type is uint256  </param>
        /// <param name="priceMaxSqrt">sqrt(priceMax) in base scale decimals Variable pbs ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateLiquidityD(Account sender, ulong? fee, System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger priceMin, System.Numerics.BigInteger priceMax, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 220, 163, 212, 214 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, x, y, priceMin, priceMax, priceMinSqrt, priceMaxSqrt }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateLiquidityD_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger priceMin, System.Numerics.BigInteger priceMax, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 220, 163, 212, 214 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, x, y, priceMin, priceMax, priceMinSqrt, priceMaxSqrt }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates the liquidity  from the x - Asset A position and y - Asset B position
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="x">Asset A position balanced on the curve ABI Type is uint256  </param>
        /// <param name="y">Asset B position balanced on the curve ABI Type is uint256  </param>
        /// <param name="priceMinSqrt">sqrt(priceMin) in base scale decimals Variable pas ABI Type is uint256  </param>
        /// <param name="priceMaxSqrt">sqrt(priceMax) in base scale decimals Variable pbs ABI Type is uint256  </param>
        /// <param name="dSqrt"> ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateLiquidityWithD(Account sender, ulong? fee, System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger dSqrt, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 105, 214, 35, 177 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, x, y, priceMinSqrt, priceMaxSqrt, dSqrt }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateLiquidityWithD_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger dSqrt, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 105, 214, 35, 177 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, x, y, priceMinSqrt, priceMaxSqrt, dSqrt }, null, null, null, boxes);

        }

        ///<summary>
        ///Get the current price when asset a has x
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="assetAQuantity">x ABI Type is uint256  </param>
        /// <param name="assetBQuantity">y ABI Type is uint256  </param>
        /// <param name="priceMinSqrt">sqrt(priceMin) ABI Type is uint256  </param>
        /// <param name="priceMaxSqrt">sqrt(priceMax) ABI Type is uint256  </param>
        /// <param name="liquidity">Current pool liquidity - L variable ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculatePrice(Account sender, ulong? fee, System.Numerics.BigInteger assetAQuantity, System.Numerics.BigInteger assetBQuantity, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger liquidity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 60, 44, 126, 74 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, assetAQuantity, assetBQuantity, priceMinSqrt, priceMaxSqrt, liquidity }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculatePrice_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger assetAQuantity, System.Numerics.BigInteger assetBQuantity, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger liquidity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 60, 44, 126, 74 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, assetAQuantity, assetBQuantity, priceMinSqrt, priceMaxSqrt, liquidity }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates how much asset B will be taken from the smart contract on asset A deposit
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="inAmount">Asset A amount in Base decimal representation.. If asset has 6 decimals, 1 is represented as 1000000000 ABI Type is uint256  </param>
        /// <param name="assetABalance">Asset A balance. Variable ab, in base scale ABI Type is uint256  </param>
        /// <param name="assetBBalance">Asset B balance. Variable bb, in base scale ABI Type is uint256  </param>
        /// <param name="priceMinSqrt">sqrt(Min price). Variable pMinS, in base scale ABI Type is uint256  </param>
        /// <param name="priceMaxSqrt">sqrt(Max price). Variable pMaxS, in base scale ABI Type is uint256  </param>
        /// <param name="liqudity">sqrt(Max price). Variable L, in base scale ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateAssetBWithdrawOnAssetADeposit(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 75, 245, 113, 182 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetABalance, assetBBalance, priceMinSqrt, priceMaxSqrt, liqudity }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateAssetBWithdrawOnAssetADeposit_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 75, 245, 113, 182 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetABalance, assetBBalance, priceMinSqrt, priceMaxSqrt, liqudity }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates how much asset A will be taken from the smart contract on asset B deposit
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="inAmount">Asset B amount in Base decimal representation.. If asset has 6 decimals, 1 is represented as 1000000000 ABI Type is uint256  </param>
        /// <param name="assetABalance">Asset A balance. Variable ab, in base scale ABI Type is uint256  </param>
        /// <param name="assetBBalance">Asset B balance. Variable bb, in base scale ABI Type is uint256  </param>
        /// <param name="priceMinSqrt">sqrt(Min price). Variable pMinS, in base scale ABI Type is uint256  </param>
        /// <param name="priceMaxSqrt">sqrt(Max price). Variable pMaxS, in base scale ABI Type is uint256  </param>
        /// <param name="liqudity">sqrt(Max price). Variable L, in base scale ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateAssetAWithdrawOnAssetBDeposit(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 82, 247, 146, 63 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetABalance, assetBBalance, priceMinSqrt, priceMaxSqrt, liqudity }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateAssetAWithdrawOnAssetBDeposit_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, System.Numerics.BigInteger priceMinSqrt, System.Numerics.BigInteger priceMaxSqrt, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 82, 247, 146, 63 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetABalance, assetBBalance, priceMinSqrt, priceMaxSqrt, liqudity }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates how much asset A will be taken from the smart contract on LP asset deposit
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="inAmount">LP Asset amount in Base decimal representation.. ABI Type is uint256  </param>
        /// <param name="assetABalance">Asset A balance. Variable ab, in base scale ABI Type is uint256  </param>
        /// <param name="liqudity">Current liqudity. Variable L, in base scale ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateAssetAWithdrawOnLpDeposit(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 108, 37, 179, 243 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetABalance, liqudity }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateAssetAWithdrawOnLpDeposit_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 108, 37, 179, 243 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetABalance, liqudity }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates how much asset B will be taken from the smart contract on LP asset deposit
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="inAmount">LP Asset amount in Base decimal representation.. ABI Type is uint256  </param>
        /// <param name="assetBBalance">Asset B balance. Variable ab, in base scale ABI Type is uint256  </param>
        /// <param name="liqudity">Current liqudity. Variable L, in base scale ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateAssetBWithdrawOnLpDeposit(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetBBalance, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 5, 252, 35, 140 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetBBalance, liqudity }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateAssetBWithdrawOnLpDeposit_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger inAmount, System.Numerics.BigInteger assetBBalance, System.Numerics.BigInteger liqudity, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 5, 252, 35, 140 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmount, assetBBalance, liqudity }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates how much asset B should be deposited when user deposit asset a and b.On deposit min(calculateAssetBDepositOnAssetADeposit, calculateAssetADepositOnAssetBDeposit) should be considered for the real deposit and rest should be swapped or returned back to user
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="inAmountA">Asset A amount in Base decimal representation ABI Type is uint256  </param>
        /// <param name="inAmountB">Asset B amount in Base decimal representation ABI Type is uint256  </param>
        /// <param name="assetABalance">Asset A balance. Variable ab, in base scale ABI Type is uint256  </param>
        /// <param name="assetBBalance">Asset B balance. Variable bb, in base scale ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateAssetBDepositOnAssetADeposit(Account sender, ulong? fee, System.Numerics.BigInteger inAmountA, System.Numerics.BigInteger inAmountB, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 230, 77, 221, 130 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmountA, inAmountB, assetABalance, assetBBalance }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateAssetBDepositOnAssetADeposit_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger inAmountA, System.Numerics.BigInteger inAmountB, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 230, 77, 221, 130 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmountA, inAmountB, assetABalance, assetBBalance }, null, null, null, boxes);

        }

        ///<summary>
        ///Calculates how much asset A should be deposited when user deposit asset a and bOn deposit min(calculateAssetBDepositOnAssetADeposit, calculateAssetADepositOnAssetBDeposit) should be considered for the real deposit and rest should be swapped or returned back to user
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="inAmountA">Asset A amount in Base decimal representation ABI Type is uint256  </param>
        /// <param name="inAmountB">Asset B amount in Base decimal representation ABI Type is uint256  </param>
        /// <param name="assetABalance">Asset A balance. Variable ab, in base scale ABI Type is uint256  </param>
        /// <param name="assetBBalance">Asset B balance. Variable bb, in base scale ABI Type is uint256  </param>
        public async Task<System.Numerics.BigInteger> calculateAssetADepositOnAssetBDeposit(Account sender, ulong? fee, System.Numerics.BigInteger inAmountA, System.Numerics.BigInteger inAmountB, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 73, 246, 131, 112 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmountA, inAmountB, assetABalance, assetBBalance }, null, null, null, boxes);
            return new System.Numerics.BigInteger(result.First());

        }

        public async Task<List<Transaction>> calculateAssetADepositOnAssetBDeposit_Transactions(Account sender, ulong? fee, System.Numerics.BigInteger inAmountA, System.Numerics.BigInteger inAmountB, System.Numerics.BigInteger assetABalance, System.Numerics.BigInteger assetBBalance, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 73, 246, 131, 112 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, inAmountA, inAmountB, assetABalance, assetBBalance }, null, null, null, boxes);

        }

        ///<summary>
        ///
        ///No_op: CALL, Opt_in: NEVER, Close_out: NEVER, Update_application: NEVER, Delete_application: NEVER
        ///</summary>
        /// <param name="appBiatecConfigProvider"> ABI Type is uint64  </param>
        /// <param name="assetA"> ABI Type is uint64  </param>
        /// <param name="assetB"> ABI Type is uint64  </param>
        /// <param name="assetLp"> ABI Type is uint64  </param>
        public async Task<BiatecClammPoolReference.statusreturn> status(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong assetLp, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 79, 236, 163, 89 };
            var result = await base.CallApp(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, assetLp }, null, null, null, boxes);
            throw new Exception("Conversion not implemented"); // <unknown return conversion>
        }

        public async Task<List<Transaction>> status_Transactions(Account sender, ulong? fee, ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong assetLp, string note, List<BoxRef> boxes, AlgoStudio.Core.OnCompleteType callType = AlgoStudio.Core.OnCompleteType.NoOp)
        {
            byte[] abiHandle = { 79, 236, 163, 89 };
            return await base.MakeTransactionList(null, fee, callType, 1000, note, sender, new List<object> { abiHandle, appBiatecConfigProvider, assetA, assetB, assetLp }, null, null, null, boxes);

        }

        //Initial setup
        public class createApplication_Arc4GroupTransaction : ProxyBase
        {
            public createApplication_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private createApplication_Arc4GroupTransaction() : base(null, 0) { }
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 184, 68, 123, 54 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //addressUdpater from global biatec configuration is allowed to update application
        public class updateApplication_Arc4GroupTransaction : ProxyBase
        {
            public updateApplication_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private updateApplication_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte> newVersion { get; set; } = (AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte>)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 95, 200, 133, 160 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, newVersion }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //
        public class getCurrentPrice_Arc4GroupTransaction : ProxyBase
        {
            public getCurrentPrice_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private getCurrentPrice_Arc4GroupTransaction() : base(null, 0) { }
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 209, 113, 127, 229 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //
        public class getPriceDivider_Arc4GroupTransaction : ProxyBase
        {
            public getPriceDivider_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private getPriceDivider_Arc4GroupTransaction() : base(null, 0) { }
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 227, 164, 58, 74 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //
        public class getLPTokenId_Arc4GroupTransaction : ProxyBase
        {
            public getLPTokenId_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private getLPTokenId_Arc4GroupTransaction() : base(null, 0) { }
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 29, 118, 74, 158 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Anybody can deploy the clamm smart contract
        public class bootstrap_Arc4GroupTransaction : ProxyBase
        {
            public bootstrap_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private bootstrap_Arc4GroupTransaction() : base(null, 0) { }
            //Asset A ID must be lower then Asset B ID
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset B
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Biatec amm provider
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Pool provider
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecPoolProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Fee in base level (9 decimals). value 1_000_000_000 = 1 = 100%. 10_000_000 = 1%. 1_000_000 = 0.1%
            public AlgoStudio.ABI.ARC4.Types.UInt fee1 { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Min price range. At this point all assets are in asset A.
            public AlgoStudio.ABI.ARC4.Types.UInt priceMin { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Max price range. At this point all assets are in asset B.
            public AlgoStudio.ABI.ARC4.Types.UInt priceMax { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Deployer can specify the current price for easier deployemnt.
            public AlgoStudio.ABI.ARC4.Types.UInt currentPrice { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Minimum verification level from the biatec identity. Level 0 means no kyc.
            public AlgoStudio.ABI.ARC4.Types.UInt verificationClass { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint8");
            public async Task<List<Transaction>> Invoke(PaymentTransaction txSeed, ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 179, 19, 1, 46 };
                return await base.MakeArc4TransactionList(new List<Transaction> { txSeed }, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { assetA, assetB, appBiatecConfigProvider, appBiatecPoolProvider, fee1, priceMin, priceMax, currentPrice, verificationClass }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //This method adds Asset A and Asset B to the Automated Market Maker Concentrated Liqudidity Pool and send to the liqudidty provider the liqudity token
        public class addLiquidity_Arc4GroupTransaction : ProxyBase
        {
            public addLiquidity_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private addLiquidity_Arc4GroupTransaction() : base(null, 0) { }
            //Configuration reference
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Identity service reference
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecIdentityProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset A
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset B
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Liquidity pool asset
            public AlgoStudio.ABI.ARC4.Types.UInt assetLp { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(Transaction txAssetADeposit, Transaction txAssetBDeposit, ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 4, 64, 250, 143 };
                return await base.MakeArc4TransactionList(new List<Transaction> { txAssetADeposit, txAssetBDeposit }, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, appBiatecIdentityProvider, assetA, assetB, assetLp }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //This method retrieves from the liquidity provider LP token and returns Asset A and Asset B from the Automated Market Maker Concentrated Liqudidity Pool
        public class removeLiquidity_Arc4GroupTransaction : ProxyBase
        {
            public removeLiquidity_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private removeLiquidity_Arc4GroupTransaction() : base(null, 0) { }
            //Configuration reference
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Identity service reference
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecIdentityProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset A
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset B
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //LP pool asset
            public AlgoStudio.ABI.ARC4.Types.UInt assetLp { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(AssetTransferTransaction txLpXfer, ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 84, 154, 144, 164 };
                return await base.MakeArc4TransactionList(new List<Transaction> { txLpXfer }, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, appBiatecIdentityProvider, assetA, assetB, assetLp }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //This method allows biatec admin to reduce the lp position created by lp fees allocation.Only addressExecutiveFee is allowed to execute this method.
        public class removeLiquidityAdmin_Arc4GroupTransaction : ProxyBase
        {
            public removeLiquidityAdmin_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private removeLiquidityAdmin_Arc4GroupTransaction() : base(null, 0) { }
            //Biatec config app. Only addressExecutiveFee is allowed to execute this method.
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset A
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset B
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt assetLp { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Amount to withdraw. If zero, removes all available lps from fees.
            public AlgoStudio.ABI.ARC4.Types.UInt amount { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 137, 74, 147, 79 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, assetA, assetB, assetLp, amount }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Swap Asset A to Asset B or Asset B to Asst A
        public class swap_Arc4GroupTransaction : ProxyBase
        {
            public swap_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private swap_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecIdentityProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecPoolProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset A
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset B
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //If number greater then zero, the check is performed for the output of the other asset
            public AlgoStudio.ABI.ARC4.Types.UInt minimumToReceive { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(Transaction txSwap, ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 32, 19, 52, 158 };
                return await base.MakeArc4TransactionList(new List<Transaction> { txSwap }, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, appBiatecIdentityProvider, appBiatecPoolProvider, assetA, assetB, minimumToReceive }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //If someone deposits excess assets to the LP pool, addressExecutiveFee can either distribute them to the lp tokens or withdraw it, depending on the use case.If someone sent there assets in fault, the withrawing can be use to return them back. If the pool received assets for example for having its algo stake online and recieved rewards it is prefered to distribute them to the current LP holders.This method is used to distribute amount a and amount b of asset a and asset b to holders as the fee income.Only addressExecutiveFee is allowed to execute this method.
        public class distributeExcessAssets_Arc4GroupTransaction : ProxyBase
        {
            public distributeExcessAssets_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private distributeExcessAssets_Arc4GroupTransaction() : base(null, 0) { }
            //Biatec config app. Only addressExecutiveFee is allowed to execute this method.
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset A
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset B
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Amount of asset A to be deposited to the liquidity. In base decimals (9)
            public AlgoStudio.ABI.ARC4.Types.UInt amountA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Amount of asset B to be deposited to the liquidity. In base decimals (9)
            public AlgoStudio.ABI.ARC4.Types.UInt amountB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 206, 86, 68, 18 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, assetA, assetB, amountA, amountB }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //If someone deposits excess assets to the LP pool, addressExecutiveFee can either distribute them to the lp tokens or withdraw it, depending on the use case.If someone sent there assets in fault, the withrawing can be use to return them back. If the pool received assets for example for having its algo stake online and recieved rewards it is prefered to distribute them to the current LP holders.This method is used to distribute amount a and amount b of asset a and asset b to addressExecutiveFee account.Only addressExecutiveFee is allowed to execute this method.
        public class withdrawExcessAssets_Arc4GroupTransaction : ProxyBase
        {
            public withdrawExcessAssets_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private withdrawExcessAssets_Arc4GroupTransaction() : base(null, 0) { }
            //Biatec config app. Only addressExecutiveFee is allowed to execute this method.
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset A
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Asset B
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Amount of asset A to be deposited to the liquidity. In asset a decimals
            public AlgoStudio.ABI.ARC4.Types.UInt amountA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //Amount of asset B to be deposited to the liquidity. In asset b decimals
            public AlgoStudio.ABI.ARC4.Types.UInt amountB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 34, 183, 70, 200 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, assetA, assetB, amountA, amountB }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //addressExecutiveFee can perfom key registration for this LP poolOnly addressExecutiveFee is allowed to execute this method.
        public class sendOnlineKeyRegistration_Arc4GroupTransaction : ProxyBase
        {
            public sendOnlineKeyRegistration_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private sendOnlineKeyRegistration_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte> votePk { get; set; } = (AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte>)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            //
            public AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte> selectionPk { get; set; } = (AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte>)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            //
            public AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte> stateProofPk { get; set; } = (AlgoStudio.ABI.ARC4.Types.VariableArray<AlgoStudio.ABI.ARC4.Types.Byte>)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("byte[]");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt voteFirst { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt voteLast { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt voteKeyDilution { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 131, 146, 92, 23 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, votePk, selectionPk, stateProofPk, voteFirst, voteLast, voteKeyDilution }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //addressExecutiveFee can perfom key unregistration for this LP poolOnly addressExecutiveFee is allowed to execute this method.
        public class sendOfflineKeyRegistration_Arc4GroupTransaction : ProxyBase
        {
            public sendOfflineKeyRegistration_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private sendOfflineKeyRegistration_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 9, 85, 194, 90 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates the number of LP tokens issued to users
        public class calculateDistributedLiquidity_Arc4GroupTransaction : ProxyBase
        {
            public calculateDistributedLiquidity_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateDistributedLiquidity_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AlgoStudio.ABI.ARC4.Types.UInt assetLp { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt currentDeposit { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 57, 236, 168, 84 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { assetLp, currentDeposit }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //
        public class calculateLiquidityFlatPrice_Arc4GroupTransaction : ProxyBase
        {
            public calculateLiquidityFlatPrice_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateLiquidityFlatPrice_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AlgoStudio.ABI.ARC4.Types.UInt x { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt y { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt price { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 255, 105, 88, 22 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { x, y, price }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates the liquidity  from the x - Asset A position and y - Asset B positionThis method calculates discriminant - first part of the calculation.It is divided so that the readonly method does not need to charge fees
        public class calculateLiquidityD_Arc4GroupTransaction : ProxyBase
        {
            public calculateLiquidityD_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateLiquidityD_Arc4GroupTransaction() : base(null, 0) { }
            //Asset A position balanced on the curve
            public AlgoStudio.ABI.ARC4.Types.UInt x { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B position balanced on the curve
            public AlgoStudio.ABI.ARC4.Types.UInt y { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Minimum price variable in base scale decimals (pa)
            public AlgoStudio.ABI.ARC4.Types.UInt priceMin { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Maximum price variable in base scale decimals (pb)
            public AlgoStudio.ABI.ARC4.Types.UInt priceMax { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(priceMin) in base scale decimals Variable pas
            public AlgoStudio.ABI.ARC4.Types.UInt priceMinSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(priceMax) in base scale decimals Variable pbs
            public AlgoStudio.ABI.ARC4.Types.UInt priceMaxSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 220, 163, 212, 214 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { x, y, priceMin, priceMax, priceMinSqrt, priceMaxSqrt }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates the liquidity  from the x - Asset A position and y - Asset B position
        public class calculateLiquidityWithD_Arc4GroupTransaction : ProxyBase
        {
            public calculateLiquidityWithD_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateLiquidityWithD_Arc4GroupTransaction() : base(null, 0) { }
            //Asset A position balanced on the curve
            public AlgoStudio.ABI.ARC4.Types.UInt x { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B position balanced on the curve
            public AlgoStudio.ABI.ARC4.Types.UInt y { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(priceMin) in base scale decimals Variable pas
            public AlgoStudio.ABI.ARC4.Types.UInt priceMinSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(priceMax) in base scale decimals Variable pbs
            public AlgoStudio.ABI.ARC4.Types.UInt priceMaxSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt dSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 105, 214, 35, 177 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { x, y, priceMinSqrt, priceMaxSqrt, dSqrt }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Get the current price when asset a has x
        public class calculatePrice_Arc4GroupTransaction : ProxyBase
        {
            public calculatePrice_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculatePrice_Arc4GroupTransaction() : base(null, 0) { }
            //x
            public AlgoStudio.ABI.ARC4.Types.UInt assetAQuantity { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //y
            public AlgoStudio.ABI.ARC4.Types.UInt assetBQuantity { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(priceMin)
            public AlgoStudio.ABI.ARC4.Types.UInt priceMinSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(priceMax)
            public AlgoStudio.ABI.ARC4.Types.UInt priceMaxSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Current pool liquidity - L variable
            public AlgoStudio.ABI.ARC4.Types.UInt liquidity { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 60, 44, 126, 74 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { assetAQuantity, assetBQuantity, priceMinSqrt, priceMaxSqrt, liquidity }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates how much asset B will be taken from the smart contract on asset A deposit
        public class calculateAssetBWithdrawOnAssetADeposit_Arc4GroupTransaction : ProxyBase
        {
            public calculateAssetBWithdrawOnAssetADeposit_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateAssetBWithdrawOnAssetADeposit_Arc4GroupTransaction() : base(null, 0) { }
            //Asset A amount in Base decimal representation.. If asset has 6 decimals, 1 is represented as 1000000000
            public AlgoStudio.ABI.ARC4.Types.UInt inAmount { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset A balance. Variable ab, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetABalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B balance. Variable bb, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetBBalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(Min price). Variable pMinS, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt priceMinSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(Max price). Variable pMaxS, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt priceMaxSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(Max price). Variable L, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt liqudity { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 75, 245, 113, 182 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { inAmount, assetABalance, assetBBalance, priceMinSqrt, priceMaxSqrt, liqudity }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates how much asset A will be taken from the smart contract on asset B deposit
        public class calculateAssetAWithdrawOnAssetBDeposit_Arc4GroupTransaction : ProxyBase
        {
            public calculateAssetAWithdrawOnAssetBDeposit_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateAssetAWithdrawOnAssetBDeposit_Arc4GroupTransaction() : base(null, 0) { }
            //Asset B amount in Base decimal representation.. If asset has 6 decimals, 1 is represented as 1000000000
            public AlgoStudio.ABI.ARC4.Types.UInt inAmount { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset A balance. Variable ab, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetABalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B balance. Variable bb, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetBBalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(Min price). Variable pMinS, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt priceMinSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(Max price). Variable pMaxS, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt priceMaxSqrt { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //sqrt(Max price). Variable L, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt liqudity { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 82, 247, 146, 63 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { inAmount, assetABalance, assetBBalance, priceMinSqrt, priceMaxSqrt, liqudity }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates how much asset A will be taken from the smart contract on LP asset deposit
        public class calculateAssetAWithdrawOnLpDeposit_Arc4GroupTransaction : ProxyBase
        {
            public calculateAssetAWithdrawOnLpDeposit_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateAssetAWithdrawOnLpDeposit_Arc4GroupTransaction() : base(null, 0) { }
            //LP Asset amount in Base decimal representation..
            public AlgoStudio.ABI.ARC4.Types.UInt inAmount { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset A balance. Variable ab, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetABalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Current liqudity. Variable L, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt liqudity { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 108, 37, 179, 243 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { inAmount, assetABalance, liqudity }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates how much asset B will be taken from the smart contract on LP asset deposit
        public class calculateAssetBWithdrawOnLpDeposit_Arc4GroupTransaction : ProxyBase
        {
            public calculateAssetBWithdrawOnLpDeposit_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateAssetBWithdrawOnLpDeposit_Arc4GroupTransaction() : base(null, 0) { }
            //LP Asset amount in Base decimal representation..
            public AlgoStudio.ABI.ARC4.Types.UInt inAmount { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B balance. Variable ab, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetBBalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Current liqudity. Variable L, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt liqudity { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 5, 252, 35, 140 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { inAmount, assetBBalance, liqudity }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates how much asset B should be deposited when user deposit asset a and b.On deposit min(calculateAssetBDepositOnAssetADeposit, calculateAssetADepositOnAssetBDeposit) should be considered for the real deposit and rest should be swapped or returned back to user
        public class calculateAssetBDepositOnAssetADeposit_Arc4GroupTransaction : ProxyBase
        {
            public calculateAssetBDepositOnAssetADeposit_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateAssetBDepositOnAssetADeposit_Arc4GroupTransaction() : base(null, 0) { }
            //Asset A amount in Base decimal representation
            public AlgoStudio.ABI.ARC4.Types.UInt inAmountA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B amount in Base decimal representation
            public AlgoStudio.ABI.ARC4.Types.UInt inAmountB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset A balance. Variable ab, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetABalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B balance. Variable bb, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetBBalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 230, 77, 221, 130 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { inAmountA, inAmountB, assetABalance, assetBBalance }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //Calculates how much asset A should be deposited when user deposit asset a and bOn deposit min(calculateAssetBDepositOnAssetADeposit, calculateAssetADepositOnAssetBDeposit) should be considered for the real deposit and rest should be swapped or returned back to user
        public class calculateAssetADepositOnAssetBDeposit_Arc4GroupTransaction : ProxyBase
        {
            public calculateAssetADepositOnAssetBDeposit_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private calculateAssetADepositOnAssetBDeposit_Arc4GroupTransaction() : base(null, 0) { }
            //Asset A amount in Base decimal representation
            public AlgoStudio.ABI.ARC4.Types.UInt inAmountA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B amount in Base decimal representation
            public AlgoStudio.ABI.ARC4.Types.UInt inAmountB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset A balance. Variable ab, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetABalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            //Asset B balance. Variable bb, in base scale
            public AlgoStudio.ABI.ARC4.Types.UInt assetBBalance { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint256");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 73, 246, 131, 112 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { inAmountA, inAmountB, assetABalance, assetBBalance }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


        //
        public class status_Arc4GroupTransaction : ProxyBase
        {
            public status_Arc4GroupTransaction(DefaultApi algodApi, ulong appId) : base(algodApi, appId) { }
            private status_Arc4GroupTransaction() : base(null, 0) { }
            //
            public AlgoStudio.ABI.ARC4.Types.UInt appBiatecConfigProvider { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt assetA { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt assetB { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            //
            public AlgoStudio.ABI.ARC4.Types.UInt assetLp { get; set; } = (AlgoStudio.ABI.ARC4.Types.UInt)AlgoStudio.ABI.ARC4.Types.WireType.FromABIDescription("uint64");
            public async Task<List<Transaction>> Invoke(ulong? fee, OnCompleteType onComplete, ulong roundValidity, string note, Account sender, List<ulong> foreignApps, List<ulong> foreignAssets, List<Address> accounts, List<BoxRef> boxes = null)
            {

                byte[] abiHandle = { 79, 236, 163, 89 };
                return await base.MakeArc4TransactionList(null, fee, onComplete, roundValidity, note, sender, abiHandle, new List<AlgoStudio.ABI.ARC4.Types.WireType> { appBiatecConfigProvider, assetA, assetB, assetLp }, foreignApps, foreignAssets, accounts, boxes);
            }
        }


    }

}
