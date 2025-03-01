using Algorand;
using AlgoStudio.Core;
using AlgoStudio.Core.Attributes;
using System;

namespace TestNamespace
{
    public abstract class BiatecIdentityProviderReference : SmartContractReference
    {
        public struct SelfRegistrationArgInfo
        {

            public ulong field0 { get; set; }

            public ulong field1 { get; set; }

            public bool field2 { get; set; }

            public string field3 { get; set; }

            public string field4 { get; set; }

            public ulong field5 { get; set; }

            public ulong field6 { get; set; }

            public ulong field7 { get; set; }

            public ulong field8 { get; set; }

            public ulong field9 { get; set; }

            public ulong field10 { get; set; }

            public bool field11 { get; set; }

            public ulong field12 { get; set; }

            public ulong field13 { get; set; }

            public bool field14 { get; set; }
        }

        public struct SetInfoArgInfo
        {

            public ulong field0 { get; set; }

            public ulong field1 { get; set; }

            public bool field2 { get; set; }

            public string field3 { get; set; }

            public string field4 { get; set; }

            public ulong field5 { get; set; }

            public ulong field6 { get; set; }

            public ulong field7 { get; set; }

            public ulong field8 { get; set; }

            public ulong field9 { get; set; }

            public ulong field10 { get; set; }

            public bool field11 { get; set; }

            public ulong field12 { get; set; }

            public ulong field13 { get; set; }

            public bool field14 { get; set; }
        }

        public struct GetUserReturn
        {

            public byte field0 { get; set; }

            public ulong field1 { get; set; }

            public ulong field2 { get; set; }

            public ulong field3 { get; set; }

            public ulong field4 { get; set; }

            public ulong field5 { get; set; }

            public ulong field6 { get; set; }

            public ulong field7 { get; set; }

            public ulong field8 { get; set; }

            public AlgoStudio.ABI.ARC4.Types.UInt256 field9 { get; set; }

            public AlgoStudio.ABI.ARC4.Types.UInt256 field10 { get; set; }

            public bool field11 { get; set; }

            public ulong field12 { get; set; }

            public ulong field13 { get; set; }

            public bool field14 { get; set; }
        }


        ///<summary>
        ///Initial setup
        ///</summary>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> CreateApplication();

        ///<summary>
        ///Biatec deploys single identity provider smart contract
        ///</summary>
        ///<param name="appBiatecConfigProvider">Biatec amm provider</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> Bootstrap(ulong appBiatecConfigProvider);

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
        ///<param name="user"></param>
        ///<param name="info"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> SelfRegistration(byte[] user, SelfRegistrationArgInfo info);

        ///<summary>
        ///
        ///</summary>
        ///<param name="user"></param>
        ///<param name="info"></param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> SetInfo(byte[] user, SetInfoArgInfo info);

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
        ///Returns user information - fee multiplier, verification class, engagement class ..
        ///</summary>
        ///<param name="user">Get info for specific user address</param>
        ///<param name="v">Version of the data structure to return</param>
        ///<param name="result"></param>
        [SmartContractMethod(OnCompleteType.NoOp)]
        public abstract ValueTuple<AppCall> GetUser(byte[] user, byte v, out GetUserReturn result);

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
