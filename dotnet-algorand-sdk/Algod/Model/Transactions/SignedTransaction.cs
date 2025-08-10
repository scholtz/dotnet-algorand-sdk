﻿


using Algorand.Utils;
using AVM.ClientGenerator.ABI.ARC4.Types;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;



namespace Algorand.Algod.Model.Transactions
{
    [MessagePack.MessagePackObject]
    public partial class ValueDelta
    {
        [Newtonsoft.Json.JsonProperty("at", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("at")]
        public ulong DeltaAction { get; set; }
        [Newtonsoft.Json.JsonProperty("bs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("bs")]
        public object? Bytes { get; set; }
        [Newtonsoft.Json.JsonProperty("ui", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("ui")]
        public ulong? Uint64 { get; set; }
    }

    [MessagePack.MessagePackObject]
    public partial class SignedTransactionDetail
    {
        [Newtonsoft.Json.JsonProperty("gd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("gd")]
        public Dictionary<object, ValueDelta>? GlobalDelta { get; set; }

        [Newtonsoft.Json.JsonProperty("ld", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("ld")]
        public Dictionary<ulong, Dictionary<object, ValueDelta>>? LocalDelta { get; set; }

        [Newtonsoft.Json.JsonProperty("itx", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("itx")]
        public ICollection<SignedTransaction>? InnerTxns { get; set; }
    }

    public partial class SignedTransaction
    {
        [Newtonsoft.Json.JsonProperty("dt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [MessagePack.Key("dt")]
        public SignedTransactionDetail Detail { get; set; }

        //TODO hgi & hgh flags

        public void SetAuthAddr(byte[] sigAddr)
        {
            AuthAddr = new Address(sigAddr);
        }

        public SignedTransaction() { }

        [JsonConstructor]
        public SignedTransaction(Transaction txn, byte[] sig, MultisigSignature msig, LogicsigSignature lsig, Address sgnr)
        {
            if (txn != null) Tx = txn;
            if (sig != null) Sig = new Signature(sig);
            if (msig != null) MSig = msig;
            if (lsig != null) LSig = lsig;
            if (sgnr != null) AuthAddr = sgnr;

        }

        public SignedTransaction(Transaction txn, Signature sig)
        {
            if (txn != null) Tx = txn;
            if (sig != null) Sig = sig;

        }



        /// <summary>
        /// MergeMultisigTransactions merges the given (partially) signed multisig transactions.
        /// </summary>
        /// <param name="txs">partially signed multisig transactions to merge. Underlying transactions may be mutated.</param>
        /// <returns>merged multisig transaction</returns>
        public static SignedTransaction MergeMultisigTransactions(params SignedTransaction[] txs)
        {
            if (txs.Length < 2)
            {
                throw new ArgumentException("cannot merge a single transaction");
            }
            SignedTransaction merged = txs[0];
            for (int i = 0; i < txs.Length; i++)
            {
                // check that multisig parameters match
                SignedTransaction tx = txs[i];
                if (tx.MSig.Version != merged.MSig.Version ||
                        tx.MSig.Threshold != merged.MSig.Threshold)
                {
                    throw new ArgumentException("transaction msig parameters do not match");
                }
                for (int j = 0; j < tx.MSig.Subsigs.Count; j++)
                {
                    MultisigSubsig myMsig = merged.MSig.Subsigs[j];
                    MultisigSubsig theirMsig = tx.MSig.Subsigs[j];
                    if (!theirMsig.key.Equals(myMsig.key))
                    {
                        throw new ArgumentException("transaction msig public keys do not match");
                    }
                    if (myMsig.sig.Equals(new Signature()))
                    {
                        myMsig.sig = theirMsig.sig;
                    }
                    else if (!myMsig.sig.Equals(theirMsig.sig) &&
                          !theirMsig.sig.Equals(new Signature()))
                    {
                        throw new ArgumentException("transaction msig has mismatched signatures");
                    }
                    merged.MSig.Subsigs[j] = myMsig;
                }
            }
            return merged;
        }

        /// <summary>
        /// a convenience method for working directly with raw transaction files.
        /// </summary>
        /// <param name="txsBytes">list of multisig transactions to merge</param>
        /// <returns>an encoded, merged multisignature transaction</returns>
        public static byte[] MergeMultisigTransactionBytes(params byte[][] txsBytes)
        {

            SignedTransaction[] sTxs = new SignedTransaction[txsBytes.Length];
            for (int i = 0; i < txsBytes.Length; i++)
            {
                sTxs[i] = Encoder.DecodeFromMsgPack<SignedTransaction>(txsBytes[i]);
            }
            SignedTransaction merged = MergeMultisigTransactions(sTxs);
            return Encoder.EncodeToMsgPackOrdered(merged);
        }

        /// <summary>
        /// AppendMultisigTransaction appends our signature to the given multisig transaction.
        /// </summary>
        /// <param name="from">the multisig public identity we are signing for</param>
        /// <param name="signedTx">the partially signed msig tx to which to append signature</param>
        /// <returns>merged multisig transaction</returns>
        public SignedTransaction AppendMultisigTransaction(MultisigAddress from, Account signingAccount)
        {
            SignedTransaction sTx = Tx.Sign(from, signingAccount);
            return MergeMultisigTransactions(sTx);
        }


        public override bool Equals(object? obj)
        {
            if (obj is SignedTransaction actual)
            {
                if (!Tx.Equals(actual.Tx)) return false;
                if (!Sig.Equals(actual.Sig)) return false;
                if (!LSig.Equals(actual.LSig)) return false;
                if (!AuthAddr.Equals(actual.AuthAddr)) return false;
                return MSig.Equals(actual.MSig);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
