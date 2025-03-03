using Algorand;
using AlgoStudio.Core;
using AlgoStudio.Core.Attributes;
using System;

namespace BiatecPoolProvider
{
    public abstract class BiatecPoolProviderReference : SmartContractReference
    {
        public struct GetCurrentStatusReturn
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

            public ulong field18 { get; set; }

            public ulong field19 { get; set; }

            public ulong field20 { get; set; }

            public ulong field21 { get; set; }

            public ulong field22 { get; set; }

            public ulong field23 { get; set; }

            public ulong field24 { get; set; }

            public ulong field25 { get; set; }

            public ulong field26 { get; set; }

            public ulong field27 { get; set; }

            public ulong field28 { get; set; }

            public ulong field29 { get; set; }

            public ulong field30 { get; set; }

            public ulong field31 { get; set; }

            public ulong field32 { get; set; }

            public ulong field33 { get; set; }

            public ulong field34 { get; set; }

            public ulong field35 { get; set; }

            public ulong field36 { get; set; }

            public ulong field37 { get; set; }

            public ulong field38 { get; set; }

            public ulong field39 { get; set; }

            public ulong field40 { get; set; }

            public ulong field41 { get; set; }

            public ulong field42 { get; set; }

            public ulong field43 { get; set; }

            public ulong field44 { get; set; }

            public ulong field45 { get; set; }

            public ulong field46 { get; set; }

            public ulong field47 { get; set; }

            public ulong field48 { get; set; }

            public ulong field49 { get; set; }

            public ulong field50 { get; set; }

            public ulong field51 { get; set; }

            public ulong field52 { get; set; }

            public ulong field53 { get; set; }

            public ulong field54 { get; set; }

            public ulong field55 { get; set; }

            public ulong field56 { get; set; }

            public ulong field57 { get; set; }

            public ulong field58 { get; set; }

            public ulong field59 { get; set; }

            public ulong field60 { get; set; }

            public ulong field61 { get; set; }

            public ulong field62 { get; set; }

            public ulong field63 { get; set; }

            public ulong field64 { get; set; }

            public ulong field65 { get; set; }

            public ulong field66 { get; set; }

            public ulong field67 { get; set; }

            public ulong field68 { get; set; }

            public ulong field69 { get; set; }

            public ulong field70 { get; set; }

            public ulong field71 { get; set; }

            public ulong field72 { get; set; }

            public ulong field73 { get; set; }

            public ulong field74 { get; set; }

            public ulong field75 { get; set; }

            public ulong field76 { get; set; }

            public ulong field77 { get; set; }

            public ulong field78 { get; set; }

            public ulong field79 { get; set; }

            public ulong field80 { get; set; }

            public ulong field81 { get; set; }

            public ulong field82 { get; set; }
        }


        ///<summary>
        ///Biatec deploys single pool provider smart contract
        ///</summary>
        ///<param name="appBiatecConfigProvider">Biatec amm provider</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> Bootstrap(ulong appBiatecConfigProvider);

        ///<summary>
        ///Returns current status
        ///</summary>
        ///<param name="appPoolId">Pool id to retrieve the stats</param>
        ///<param name="result">Pool info statistics</param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> GetCurrentStatus(ulong appPoolId, out GetCurrentStatusReturn result);

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
        ///This method is called by constructor of the luquidity pool
        ///</summary>
        ///<param name="appPoolId">Luquidity pool id</param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="verificationClass">Verification class</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> RegisterPool(ulong appPoolId, ulong assetA, ulong assetB, byte verificationClass);

        ///<summary>
        ///This metod registers the trade and calculates and store the trade statistics
        ///</summary>
        ///<param name="appPoolId">Liqudity pool smart contract</param>
        ///<param name="assetA">Asset A</param>
        ///<param name="assetB">Asset B</param>
        ///<param name="priceFrom">The original price</param>
        ///<param name="priceTo">The new price</param>
        ///<param name="amountA">Asset A amount spent or received</param>
        ///<param name="amountB">Asset B amount spent or received</param>
        ///<param name="feeAmountA">Fees paid in asset A if any</param>
        ///<param name="feeAmountB">Fees paid in asset B if any</param>
        ///<param name="s">Scale multiplier</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> RegisterTrade(ulong appPoolId, ulong assetA, ulong assetB, ulong priceFrom, ulong priceTo, ulong amountA, ulong amountB, ulong feeAmountA, ulong feeAmountB, ulong s);

        ///<summary>
        ///
        ///</summary>
        ///<param name="defaultVerified"></param>
        ///<param name="requirement"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> SetGlobalVerifiedValues(ulong defaultVerified, ulong requirement);

        ///<summary>
        ///addressExecutiveFee can perfom key registration for this LP pool
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="appBiatecConfigProvider"></param>
        ///<param name="votePK"></param>
        ///<param name="selectionPK"></param>
        ///<param name="stateProofPK"></param>
        ///<param name="voteFirst"></param>
        ///<param name="voteLast"></param>
        ///<param name="voteKeyDilution"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> SendOnlineKeyRegistration(ulong appBiatecConfigProvider, byte[] votePK, byte[] selectionPK, byte[] stateProofPK, ulong voteFirst, ulong voteLast, ulong voteKeyDilution);

        ///<summary>
        ///If someone deposits excess assets to this smart contract biatec can use them.
        ///
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="appBiatecConfigProvider">Biatec config app. Only addressExecutiveFee is allowed to execute this method.</param>
        ///<param name="asset">Asset to withdraw. If native token, then zero</param>
        ///<param name="amount">Amount of the asset to be withdrawn</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> WithdrawExcessAssets(ulong appBiatecConfigProvider, ulong asset, ulong amount, out ulong result);
    }
}
