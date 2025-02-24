using Algorand;
using AlgoStudio.ABI.ARC4.Types;
using AlgoStudio.Core;
using AlgoStudio.Core.Attributes;
using System;

namespace TestNamespace
{
    public abstract class BiatecConfigProviderReference : SmartContractReference
    {

        ///<summary>
        ///Initial setup
        ///</summary>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> createApplication();

        ///<summary>
        ///addressUdpater from global biatec configuration is allowed to update application
        ///</summary>
        ///<param name="newVersion"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> updateApplication(byte[] newVersion);

        ///<summary>
        ///Setup the contract
        ///</summary>
        ///<param name="biatecFee">Biatec fees</param>
        ///<param name="appBiatecIdentityProvider"></param>
        ///<param name="appBiatecPoolProvider"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> bootstrap(AlgoStudio.ABI.ARC4.Types.UInt256 biatecFee, ulong appBiatecIdentityProvider, ulong appBiatecPoolProvider);

        ///<summary>
        ///Top secret account with which it is possible update contracts or identity provider
        ///</summary>
        ///<param name="a">Address</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> setAddressUdpater(byte[] a);

        ///<summary>
        ///Kill switch. In the extreme case all services (deposit, trading, withdrawal, identity modifications and more) can be suspended.
        ///</summary>
        ///<param name="a">Address</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> setPaused(ulong a);

        ///<summary>
        ///Execution address with which it is possible to opt in for governance
        ///</summary>
        ///<param name="a">Address</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> setAddressGov(byte[] a);

        ///<summary>
        ///Execution address with which it is possible to change global biatec fees
        ///</summary>
        ///<param name="a">Address</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> setAddressExecutive(byte[] a);

        ///<summary>
        ///Execution fee address is address which can take fees from pools.
        ///</summary>
        ///<param name="a">Address</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> setAddressExecutiveFee(byte[] a);

        ///<summary>
        ///App identity setter
        ///</summary>
        ///<param name="a">Address</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> setBiatecIdentity(ulong a);

        ///<summary>
        ///App identity setter
        ///</summary>
        ///<param name="a">Address</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> setBiatecPool(ulong a);

        ///<summary>
        ///Fees in 9 decimals. 1_000_000_000 = 100%
        ///Fees in 9 decimals. 10_000_000 = 1%
        ///Fees in 9 decimals. 100_000 = 0,01%
        ///Fees are respectful from the all fees taken to the LP providers.If LPs charge 1% fee, and biatec charges 10% fee, LP will receive 0.09% fee and biatec 0.01% fee
        ///</summary>
        ///<param name="biatecFee">Fee</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]

        public abstract ValueTuple<AppCall> setBiatecFee(AlgoStudio.ABI.ARC4.Types.UInt256 biatecFee);

        ///<summary>
        ///addressExecutiveFee can perfom key registration for this LP pool
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="votePK"></param>
        ///<param name="selectionPK"></param>
        ///<param name="stateProofPK"></param>
        ///<param name="voteFirst"></param>
        ///<param name="voteLast"></param>
        ///<param name="voteKeyDilution"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]

        public abstract ValueTuple<AppCall> sendOnlineKeyRegistration(byte[] votePK, byte[] selectionPK, byte[] stateProofPK, ulong voteFirst, ulong voteLast, ulong voteKeyDilution);

        ///<summary>
        ///If someone deposits excess assets to this smart contract biatec can use them.
        ///
        ///Only addressExecutiveFee is allowed to execute this method.
        ///</summary>
        ///<param name="asset">Asset to withdraw. If native token, then zero</param>
        ///<param name="amount">Amount of the asset to be withdrawn</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]

        public abstract ValueTuple<AppCall> withdrawExcessAssets(ulong asset, ulong amount, out ulong result);
    }
}
