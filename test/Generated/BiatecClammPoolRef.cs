using Algorand;
using AlgoStudio.Core;
using AlgoStudio.Core.Attributes;
using System;

namespace BiatecClammPool
{
    public abstract class BiatecClammPoolReference : SmartContractReference
    {
        public struct StatusReturn
        {

            public ulong field0 { get; set; }

            public ulong field1 { get; set; }

            public ulong field2 { get; set; }

            public ulong field3 { get; set; }

            public ulong field4 { get; set; }

            public ulong field5 { get; set; }

            public ulong field6 { get; set; }

            public ulong field7 { get; set; }

            public ulong field8 { get; set; }

            public ulong field9 { get; set; }

            public ulong field10 { get; set; }

            public ulong field11 { get; set; }

            public ulong field12 { get; set; }

            public ulong field13 { get; set; }

            public ulong field14 { get; set; }

            public ulong field15 { get; set; }

            public ulong field16 { get; set; }

            public ulong field17 { get; set; }
        }


        ///<summary>
        ///Initial setup
        ///</summary>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CreateApplication();

        ///<summary>
        ///addressUdpater from global biatec configuration is allowed to update application
        ///</summary>
        ///<param name="appBiatecConfigProvider"></param>
        ///<param name="newVersion"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> UpdateApplication(ulong appBiatecConfigProvider, byte[] newVersion);

        ///<summary>
        ///
        ///</summary>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> GetCurrentPrice(out ulong result);

        ///<summary>
        ///
        ///</summary>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> GetPriceDivider(out ulong result);

        ///<summary>
        ///
        ///</summary>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> GetLPTokenId(out ulong result);

        ///<summary>
        ///Anybody can deploy the clamm smart contract
        ///</summary>
        ///<param name="assetA">Asset A ID must be lower then Asset B ID</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="appBiatecConfigProvider">Biatec amm provider</param>
        ///<param name="appBiatecPoolProvider">Pool provider</param>
        ///<param name="fee">Fee in base level (9 decimals). value 1_000_000_000 = 1 = 100%. 10_000_000 = 1%. 1_000_000 = 0.1%</param>
        ///<param name="priceMin">Min price range. At this point all assets are in asset A.</param>
        ///<param name="priceMax">Max price range. At this point all assets are in asset B.</param>
        ///<param name="currentPrice">Deployer can specify the current price for easier deployemnt.</param>
        ///<param name="verificationClass">Minimum verification level from the biatec identity. Level 0 means no kyc.</param>
        ///<param name="result">LP token ID</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract (Payment txSeed, AppCall) Bootstrap(Payment txSeed, ulong assetA, ulong assetB, ulong appBiatecConfigProvider, ulong appBiatecPoolProvider, ulong fee, ulong priceMin, ulong priceMax, ulong currentPrice, byte verificationClass, out ulong result);

        ///<summary>
        ///This method adds Asset A and Asset B to the Automated Market Maker Concentrated Liqudidity Pool and send to the liqudidty provider the liqudity token
        ///</summary>
        ///<param name="appBiatecConfigProvider">Configuration reference</param>
        ///<param name="appBiatecIdentityProvider">Identity service reference</param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="assetLp">Liquidity pool asset</param>
        ///<param name="result">LP Token quantity distributed</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract (InnerTransaction txAssetADeposit, InnerTransaction txAssetBDeposit, AppCall) AddLiquidity(InnerTransaction txAssetADeposit, InnerTransaction txAssetBDeposit, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong assetA, ulong assetB, ulong assetLp, out ulong result);

        ///<summary>
        ///This method retrieves from the liquidity provider LP token and returns Asset A and Asset B from the Automated Market Maker Concentrated Liqudidity Pool
        ///</summary>
        ///<param name="appBiatecConfigProvider">Configuration reference</param>
        ///<param name="appBiatecIdentityProvider">Identity service reference</param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="assetLp">LP pool asset</param>
        ///<param name="result">LP position reduced</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract (AssetTransfer txLpXfer, AppCall) RemoveLiquidity(AssetTransfer txLpXfer, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong assetA, ulong assetB, ulong assetLp, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///This method allows biatec admin to reduce the lp position created by lp fees allocation.
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method.</param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="assetLp"></param>
        ///<param name="amount">Amount to withdraw. If zero, removes all available lps from fees.</param>
        ///<param name="result">LP position reduced</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> RemoveLiquidityAdmin(ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong assetLp, AlgoStudio.ABI.ARC4.Types.UInt256 amount, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Swap Asset A to Asset B or Asset B to Asst A
        ///</summary>
        ///<param name="appBiatecConfigProvider"></param>
        ///<param name="appBiatecIdentityProvider"></param>
        ///<param name="appBiatecPoolProvider"></param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="minimumToReceive">If number greater then zero, the check is performed for the output of the other asset</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract (InnerTransaction txSwap, AppCall) Swap(InnerTransaction txSwap, ulong appBiatecConfigProvider, ulong appBiatecIdentityProvider, ulong appBiatecPoolProvider, ulong assetA, ulong assetB, ulong minimumToReceive, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///If someone deposits excess assets to the LP pool, addressExecutiveFee can either distribute them to the lp tokens or withdraw it, depending on the use case.
        ///If someone sent there assets in fault, the withrawing can be use to return them back. If the pool received assets for example for having its algo stake online and recieved rewards it is prefered to distribute them to the current LP holders.
        ///
        ///
        ///This method is used to distribute amount a and amount b of asset a and asset b to holders as the fee income.
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method.</param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="amountA">Amount of asset A to be deposited to the liquidity. In base decimals (9)</param>
        ///<param name="amountB">Amount of asset B to be deposited to the liquidity. In base decimals (9)</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> DistributeExcessAssets(ulong appBiatecConfigProvider, ulong assetA, ulong assetB, AlgoStudio.ABI.ARC4.Types.UInt256 amountA, AlgoStudio.ABI.ARC4.Types.UInt256 amountB, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///If someone deposits excess assets to the LP pool, addressExecutiveFee can either distribute them to the lp tokens or withdraw it, depending on the use case.
        ///If someone sent there assets in fault, the withrawing can be use to return them back. If the pool received assets for example for having its algo stake online and recieved rewards it is prefered to distribute them to the current LP holders.
        ///
        ///
        ///This method is used to distribute amount a and amount b of asset a and asset b to addressExecutiveFee account.
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method.</param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="amountA">Amount of asset A to be deposited to the liquidity. In asset a decimals</param>
        ///<param name="amountB">Amount of asset B to be deposited to the liquidity. In asset b decimals</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> WithdrawExcessAssets(ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong amountA, ulong amountB, out ulong result);

        ///<summary>
        ///addressExecutiveFee can perfom key registration for this LP pool
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="appBiatecConfigProvider"></param>
        ///<param name="votePk"></param>
        ///<param name="selectionPk"></param>
        ///<param name="stateProofPk"></param>
        ///<param name="voteFirst"></param>
        ///<param name="voteLast"></param>
        ///<param name="voteKeyDilution"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> SendOnlineKeyRegistration(ulong appBiatecConfigProvider, byte[] votePk, byte[] selectionPk, byte[] stateProofPk, ulong voteFirst, ulong voteLast, ulong voteKeyDilution);

        ///<summary>
        ///addressExecutiveFee can perfom key unregistration for this LP pool
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="appBiatecConfigProvider"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> SendOfflineKeyRegistration(ulong appBiatecConfigProvider);

        ///<summary>
        ///Calculates the number of LP tokens issued to users
        ///</summary>
        ///<param name="assetLp"></param>
        ///<param name="currentDeposit"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateDistributedLiquidity(ulong assetLp, AlgoStudio.ABI.ARC4.Types.UInt256 currentDeposit, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///
        ///</summary>
        ///<param name="x"></param>
        ///<param name="y"></param>
        ///<param name="price"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateLiquidityFlatPrice(AlgoStudio.ABI.ARC4.Types.UInt256 x, AlgoStudio.ABI.ARC4.Types.UInt256 y, AlgoStudio.ABI.ARC4.Types.UInt256 price, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates the liquidity  from the x - Asset A position and y - Asset B position
        ///This method calculates discriminant - first part of the calculation.
        ///It is divided so that the readonly method does not need to charge fees
        ///</summary>
        ///<param name="x">Asset A position balanced on the curve</param>
        ///<param name="y">Asset B position balanced on the curve</param>
        ///<param name="priceMin">Minimum price variable in base scale decimals (pa)</param>
        ///<param name="priceMax">Maximum price variable in base scale decimals (pb)</param>
        ///<param name="priceMinSqrt">sqrt(priceMin) in base scale decimals Variable pas</param>
        ///<param name="priceMaxSqrt">sqrt(priceMax) in base scale decimals Variable pbs</param>
        ///<param name="result">Liquidity is constant in swapping each direction. On deposit the diff between the liquidity is number of LP tokens received by user.</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateLiquidityD(AlgoStudio.ABI.ARC4.Types.UInt256 x, AlgoStudio.ABI.ARC4.Types.UInt256 y, AlgoStudio.ABI.ARC4.Types.UInt256 priceMin, AlgoStudio.ABI.ARC4.Types.UInt256 priceMax, AlgoStudio.ABI.ARC4.Types.UInt256 priceMinSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 priceMaxSqrt, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates the liquidity  from the x - Asset A position and y - Asset B position
        ///</summary>
        ///<param name="x">Asset A position balanced on the curve</param>
        ///<param name="y">Asset B position balanced on the curve</param>
        ///<param name="priceMinSqrt">sqrt(priceMin) in base scale decimals Variable pas</param>
        ///<param name="priceMaxSqrt">sqrt(priceMax) in base scale decimals Variable pbs</param>
        ///<param name="dSqrt"></param>
        ///<param name="result">Liquidity is constant in swapping each direction. On deposit the diff between the liquidity is number of LP tokens received by user.</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateLiquidityWithD(AlgoStudio.ABI.ARC4.Types.UInt256 x, AlgoStudio.ABI.ARC4.Types.UInt256 y, AlgoStudio.ABI.ARC4.Types.UInt256 priceMinSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 priceMaxSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 dSqrt, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Get the current price when asset a has x
        ///</summary>
        ///<param name="assetAQuantity">x</param>
        ///<param name="assetBQuantity">y</param>
        ///<param name="priceMinSqrt">sqrt(priceMin)</param>
        ///<param name="priceMaxSqrt">sqrt(priceMax)</param>
        ///<param name="liquidity">Current pool liquidity - L variable</param>
        ///<param name="result">the price with specified quantity with the price range set in the contract</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculatePrice(AlgoStudio.ABI.ARC4.Types.UInt256 assetAQuantity, AlgoStudio.ABI.ARC4.Types.UInt256 assetBQuantity, AlgoStudio.ABI.ARC4.Types.UInt256 priceMinSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 priceMaxSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 liquidity, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates how much asset B will be taken from the smart contract on asset A deposit
        ///</summary>
        ///<param name="inAmount">Asset A amount in Base decimal representation.. If asset has 6 decimals, 1 is represented as 1000000000</param>
        ///<param name="assetABalance">Asset A balance. Variable ab, in base scale</param>
        ///<param name="assetBBalance">Asset B balance. Variable bb, in base scale</param>
        ///<param name="priceMinSqrt">sqrt(Min price). Variable pMinS, in base scale</param>
        ///<param name="priceMaxSqrt">sqrt(Max price). Variable pMaxS, in base scale</param>
        ///<param name="liqudity">sqrt(Max price). Variable L, in base scale</param>
        ///<param name="result">Amount of asset B to be given to the caller before fees. The result is in Base decimals (9)</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateAssetBWithdrawOnAssetADeposit(AlgoStudio.ABI.ARC4.Types.UInt256 inAmount, AlgoStudio.ABI.ARC4.Types.UInt256 assetABalance, AlgoStudio.ABI.ARC4.Types.UInt256 assetBBalance, AlgoStudio.ABI.ARC4.Types.UInt256 priceMinSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 priceMaxSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 liqudity, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates how much asset A will be taken from the smart contract on asset B deposit
        ///</summary>
        ///<param name="inAmount">Asset B amount in Base decimal representation.. If asset has 6 decimals, 1 is represented as 1000000000</param>
        ///<param name="assetABalance">Asset A balance. Variable ab, in base scale</param>
        ///<param name="assetBBalance">Asset B balance. Variable bb, in base scale</param>
        ///<param name="priceMinSqrt">sqrt(Min price). Variable pMinS, in base scale</param>
        ///<param name="priceMaxSqrt">sqrt(Max price). Variable pMaxS, in base scale</param>
        ///<param name="liqudity">sqrt(Max price). Variable L, in base scale</param>
        ///<param name="result">Amount of asset A to be given to the caller before fees. The result is in Base decimals (9)</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateAssetAWithdrawOnAssetBDeposit(AlgoStudio.ABI.ARC4.Types.UInt256 inAmount, AlgoStudio.ABI.ARC4.Types.UInt256 assetABalance, AlgoStudio.ABI.ARC4.Types.UInt256 assetBBalance, AlgoStudio.ABI.ARC4.Types.UInt256 priceMinSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 priceMaxSqrt, AlgoStudio.ABI.ARC4.Types.UInt256 liqudity, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates how much asset A will be taken from the smart contract on LP asset deposit
        ///</summary>
        ///<param name="inAmount">LP Asset amount in Base decimal representation..</param>
        ///<param name="assetABalance">Asset A balance. Variable ab, in base scale</param>
        ///<param name="liqudity">Current liqudity. Variable L, in base scale</param>
        ///<param name="result">Amount of asset A to be given to the caller before fees. The result is in Base decimals (9)</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateAssetAWithdrawOnLpDeposit(AlgoStudio.ABI.ARC4.Types.UInt256 inAmount, AlgoStudio.ABI.ARC4.Types.UInt256 assetABalance, AlgoStudio.ABI.ARC4.Types.UInt256 liqudity, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates how much asset B will be taken from the smart contract on LP asset deposit
        ///</summary>
        ///<param name="inAmount">LP Asset amount in Base decimal representation..</param>
        ///<param name="assetBBalance">Asset B balance. Variable ab, in base scale</param>
        ///<param name="liqudity">Current liqudity. Variable L, in base scale</param>
        ///<param name="result">Amount of asset B to be given to the caller before fees. The result is in Base decimals (9)</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateAssetBWithdrawOnLpDeposit(AlgoStudio.ABI.ARC4.Types.UInt256 inAmount, AlgoStudio.ABI.ARC4.Types.UInt256 assetBBalance, AlgoStudio.ABI.ARC4.Types.UInt256 liqudity, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates how much asset B should be deposited when user deposit asset a and b.
        ///
        ///
        ///On deposit min(calculateAssetBDepositOnAssetADeposit, calculateAssetADepositOnAssetBDeposit) should be considered for the real deposit and rest should be swapped or returned back to user
        ///</summary>
        ///<param name="inAmountA">Asset A amount in Base decimal representation</param>
        ///<param name="inAmountB">Asset B amount in Base decimal representation</param>
        ///<param name="assetABalance">Asset A balance. Variable ab, in base scale</param>
        ///<param name="assetBBalance">Asset B balance. Variable bb, in base scale</param>
        ///<param name="result">Amount of asset B to be given to the caller before fees. The result is in Base decimals (9)</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateAssetBDepositOnAssetADeposit(AlgoStudio.ABI.ARC4.Types.UInt256 inAmountA, AlgoStudio.ABI.ARC4.Types.UInt256 inAmountB, AlgoStudio.ABI.ARC4.Types.UInt256 assetABalance, AlgoStudio.ABI.ARC4.Types.UInt256 assetBBalance, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///Calculates how much asset A should be deposited when user deposit asset a and b
        ///
        ///
        ///On deposit min(calculateAssetBDepositOnAssetADeposit, calculateAssetADepositOnAssetBDeposit) should be considered for the real deposit and rest should be swapped or returned back to user
        ///</summary>
        ///<param name="inAmountA">Asset A amount in Base decimal representation</param>
        ///<param name="inAmountB">Asset B amount in Base decimal representation</param>
        ///<param name="assetABalance">Asset A balance. Variable ab, in base scale</param>
        ///<param name="assetBBalance">Asset B balance. Variable bb, in base scale</param>
        ///<param name="result">Amount of asset A to be deposited. The result is in Base decimals (9)</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CalculateAssetADepositOnAssetBDeposit(AlgoStudio.ABI.ARC4.Types.UInt256 inAmountA, AlgoStudio.ABI.ARC4.Types.UInt256 inAmountB, AlgoStudio.ABI.ARC4.Types.UInt256 assetABalance, AlgoStudio.ABI.ARC4.Types.UInt256 assetBBalance, out AlgoStudio.ABI.ARC4.Types.UInt256 result);

        ///<summary>
        ///
        ///</summary>
        ///<param name="appBiatecConfigProvider"></param>
        ///<param name="assetA"></param>
        ///<param name="assetB"></param>
        ///<param name="assetLp"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> Status(ulong appBiatecConfigProvider, ulong assetA, ulong assetB, ulong assetLp, out StatusReturn result);
    }
}
