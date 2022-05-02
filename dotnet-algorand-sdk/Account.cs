using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorand
{
    /// <summary>
    /// Create and manage secrets, and perform account-based work such as signing transactions.
    /// </summary>
    public class Account
    {
        
        

    
       
      



    

        /// <summary>
        /// Sign a transaction with this account
        /// </summary>
        /// <param name="tx">the transaction to sign</param>
        /// <returns>a signed transaction</returns>
        public SignedTransaction SignTransaction(Transaction tx)
        {
            byte[] prefixEncodedTx = tx.BytesToSign();
            Signature txSig = RawSignBytes(prefixEncodedTx);
            var stx = new SignedTransaction(tx, txSig, tx.TxID());
            if (!tx.sender.Equals(this.Address))
                stx.authAddr = this.Address;
            return stx;
        }
        /// <summary>
        /// Sign a transaction with this account, replacing the fee with the given feePerByte.
        /// </summary>
        /// <param name="tx">transaction to sign</param>
        /// <param name="feePerByte">feePerByte fee per byte, often returned as a suggested fee</param>
        /// <returns>a signed transaction</returns>
        public SignedTransaction SignTransactionWithFeePerByte(Transaction tx, ulong feePerByte)
        {
            SetFeeByFeePerByte(tx, feePerByte);
            return this.SignTransaction(tx);
        }
       
       
        /// <summary>
        /// EstimateEncodedSize returns the estimated encoded size of the transaction including the signature.
        /// This function is useful for calculating the fee from suggested fee per byte.
        /// </summary>
        /// <param name="tx">the transaction</param>
        /// <returns>an estimated byte size for the transaction.</returns>
        public static int EstimatedEncodedSize(Transaction tx)
        {
            Account acc = new Account();
            return Encoder.EncodeToMsgPack(
                new SignedTransaction(tx, acc.RawSignBytes(tx.BytesToSign()), tx.TxID())).Length;
        }
        /// <summary>
        /// Sign the given bytes, and wrap in Signature.
        /// </summary>
        /// <param name="bytes">bytes the data to sign</param>
        /// <returns>a signature</returns>
        private Signature RawSignBytes(byte[] bytes)
        {
            var signer = new Ed25519Signer();
            signer.Init(true, privateKeyPair.Private);
            signer.BlockUpdate(bytes, 0, bytes.Length);
            byte[] signature = signer.GenerateSignature();
            return new Signature(signature);
        }
        /// <summary>
        /// Sign the given bytes, and wrap in signature. The message is prepended with "MX" for domain separation.
        /// </summary>
        /// <param name="bytes">bytes the data to sign</param>
        /// <returns>signature</returns>
        public Signature SignBytes(byte[] bytes) //throws NoSuchAlgorithmException
        {
            List<byte> retByte = new List<byte>();
            retByte.AddRange(BYTES_SIGN_PREFIX);
            retByte.AddRange(bytes);
            return RawSignBytes(retByte.ToArray());
        }
        #region Multisignature support
        /// <summary>
        /// SignMultisigTransaction creates a multisig transaction from the input and the multisig account.
        /// </summary>
        /// <param name="from">sign as this multisignature account</param>
        /// <param name="tx">the transaction to sign</param>
        /// <returns>SignedTransaction a partially signed multisig transaction</returns>
        public SignedTransaction SignMultisigTransaction(MultisigAddress from, Transaction tx) //throws NoSuchAlgorithmException
        {
            // check that from addr of tx matches multisig preimage
            if (!tx.sender.ToString().Equals(from.ToString()))
            {
                throw new ArgumentException("Transaction sender does not match multisig account");
            }
            // check that account secret key is in multisig pk list
            var myPK = this.GetEd25519PublicKey();
            byte[] myEncoded = myPK.GetEncoded();
            int myI = -1;
            for (int i = 0; i < from.publicKeys.Count; i++)
                if (Enumerable.SequenceEqual(myEncoded, from.publicKeys[i].GetEncoded()))
                {
                    myI = i;
                    break;
                }

            if (myI == -1)
            {
                throw new ArgumentException("Multisig account does not contain this secret key");
            }
            // now, create the multisignature
            SignedTransaction txSig = this.SignTransaction(tx);
            MultisigSignature mSig = new MultisigSignature(from.version, from.threshold);
            for (int i = 0; i < from.publicKeys.Count; i++)
            {
                if (i == myI)
                {
                    mSig.subsigs.Add(new MultisigSubsig(myPK, txSig.sig));
                }
                else
                {
                    mSig.subsigs.Add(new MultisigSubsig(from.publicKeys[i]));
                }
            }
            return new SignedTransaction(tx, mSig, txSig.transactionID);
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
                if (tx.mSig.version != merged.mSig.version ||
                        tx.mSig.threshold != merged.mSig.threshold)
                {
                    throw new ArgumentException("transaction msig parameters do not match");
                }
                for (int j = 0; j < tx.mSig.subsigs.Count; j++)
                {
                    MultisigSubsig myMsig = merged.mSig.subsigs[j];
                    MultisigSubsig theirMsig = tx.mSig.subsigs[j];
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
                    merged.mSig.subsigs[j] = myMsig;
                }
            }
            return merged;
        }
        /// <summary>
        /// AppendMultisigTransaction appends our signature to the given multisig transaction.
        /// </summary>
        /// <param name="from">the multisig public identity we are signing for</param>
        /// <param name="signedTx">the partially signed msig tx to which to append signature</param>
        /// <returns>merged multisig transaction</returns>
        public SignedTransaction AppendMultisigTransaction(MultisigAddress from, SignedTransaction signedTx)
        {
            SignedTransaction sTx = this.SignMultisigTransaction(from, signedTx.tx);
            return MergeMultisigTransactions(sTx, signedTx);
        }

        /// <summary>
        /// a convenience method for working directly with raw transaction files.
        /// </summary>
        /// <param name="txsBytes">list of multisig transactions to merge</param>
        /// <returns>an encoded, merged multisignature transaction</returns>
        public static byte[] MergeMultisigTransactionBytes(params byte[][] txsBytes)
        {

            SignedTransaction[] sTxs = new SignedTransaction[txsBytes.Length];
            for (int i = 0; i < txsBytes.Length; i++) {
                sTxs[i] = Encoder.DecodeFromMsgPack<SignedTransaction>(txsBytes[i]);
            }
            SignedTransaction merged = Account.MergeMultisigTransactions(sTxs);
            return Encoder.EncodeToMsgPack(merged);
        }
        /// <summary>
        /// a convenience method for directly appending our signature to a raw tx file
        /// </summary>
        /// <param name="from">the public identity we are signing as</param>
        /// <param name="txBytes">the multisig transaction to append signature to</param>
        /// <returns>merged multisignature transaction inclukding our signature</returns>
        public byte[] AppendMultisigTransactionBytes(MultisigAddress from, byte[] txBytes)
        {
            SignedTransaction inTx = Encoder.DecodeFromMsgPack<SignedTransaction>(txBytes);
            SignedTransaction appended = this.AppendMultisigTransaction(from, inTx);
            return Encoder.EncodeToMsgPack(appended);
        }
        #endregion

        #region LogicSig
        /// <summary>
        /// Sign LogicSig with account's secret key
        /// </summary>
        /// <param name="lsig">LogicsigSignature to sign</param>
        /// <returns>LogicsigSignature with updated signature</returns>
        public LogicsigSignature SignLogicsig(LogicsigSignature lsig)
        {
            byte[] bytesToSign = lsig.BytesToSign();
            Signature sig = this.RawSignBytes(bytesToSign);
            lsig.sig = sig;
            return lsig;
        }

        /// <summary>
        /// Sign LogicSig as multisig
        /// </summary>
        /// <param name="lsig">LogicsigSignature to sign</param>
        /// <param name="ma">MultisigAddress to format multi signature from</param>
        /// <returns>LogicsigSignature</returns>
        public LogicsigSignature SignLogicsig(LogicsigSignature lsig, MultisigAddress ma)
        {
            var pk = this.GetEd25519PublicKey();
            int pkIndex = -1;
            for (int i = 0; i < ma.publicKeys.Count; i++)
            {
                if (Enumerable.SequenceEqual(pk.GetEncoded(), ma.publicKeys[i].GetEncoded())){
                    pkIndex = i;
                    break;
                }
            }

            if (pkIndex == -1)
            {
                throw new ArgumentException("Multisig account does not contain this secret key");
            }
            // now, create the multisignature
            byte[] bytesToSign = lsig.BytesToSign();
            Signature sig = this.RawSignBytes(bytesToSign);
            MultisigSignature mSig = new MultisigSignature(ma.version, ma.threshold);
            for (int i = 0; i < ma.publicKeys.Count; i++)
            {
                if (i == pkIndex)
                {
                    mSig.subsigs.Add(new MultisigSubsig(pk, sig));
                }
                else
                {
                    mSig.subsigs.Add(new MultisigSubsig(ma.publicKeys[i]));
                }
            }
            lsig.msig = mSig;
            return lsig;
        }

        /// <summary>
        /// Appends a signature to multisig logic signed transaction
        /// </summary>
        /// <param name="lsig">LogicsigSignature append to</param>
        /// <returns>LogicsigSignature</returns>
        public LogicsigSignature AppendToLogicsig(LogicsigSignature lsig)
        {
            var pk = this.GetEd25519PublicKey();
            int pkIndex = -1;
            for (int i = 0; i < lsig.msig.subsigs.Count; i++)
            {
                MultisigSubsig subsig = lsig.msig.subsigs[i];
                if (Enumerable.SequenceEqual(subsig.key.GetEncoded(), pk.GetEncoded()))
                {
                    pkIndex = i;
                }
            }
            if (pkIndex == -1)
            {
                throw new ArgumentException("Multisig account does not contain this secret key");
            }
            // now, create the multisignature
            byte[] bytesToSign = lsig.BytesToSign();
            Signature sig = this.RawSignBytes(bytesToSign);
            lsig.msig.subsigs[pkIndex] = new MultisigSubsig(pk, sig);
            return lsig;
        }
        /// <summary>
        /// Creates SignedTransaction from LogicsigSignature and Transaction.
        /// LogicsigSignature must be valid and verifiable against transaction sender field.
        /// </summary>
        /// <param name="lsig">LogicsigSignature</param>
        /// <param name="tx">Transaction</param>
        /// <returns>SignedTransaction</returns>
        public static SignedTransaction SignLogicsigTransaction(LogicsigSignature lsig, Transaction tx)
        {
            if (!lsig.Verify(tx.sender))
            {
                throw new ArgumentException("verification failed");
            }
            return new SignedTransaction(tx, lsig, tx.TxID());
        }

        //public static SignedTransaction SignLogicsigDelegatedTransaction(LogicsigSignature lsig, Transaction tx)
        //{

        //    return new SignedTransaction(tx, lsig, tx.TxID());
        //}
        #endregion

        /// <summary>
        /// Creates Signature compatible with ed25519verify TEAL opcode from data and contract address(program hash).
        /// </summary>
        /// <param name="data">data byte[]</param>
        /// <param name="contractAddress">contractAddress Address</param>
        /// <returns>Signature</returns>
        public Signature TealSign(byte[] data, Address contractAddress)
        {
            byte[] rawAddress = contractAddress.Bytes;
            List<byte> baos = new List<byte>();
            baos.AddRange(PROGDATA_SIGN_PREFIX);
            baos.AddRange(rawAddress);
            baos.AddRange(data);
            return this.RawSignBytes(baos.ToArray());
        }

        /// <summary>
        /// Creates Signature compatible with ed25519verify TEAL opcode from data and program bytes
        /// </summary>
        /// <param name="data">data byte[]</param>
        /// <param name="program">program byte[]</param>
        /// <returns>Signature</returns>
        public Signature TealSignFromProgram(byte[] data, byte[] program)
        {
            LogicsigSignature lsig = new LogicsigSignature(program);
            return this.TealSign(data, lsig.Address);
        }
}


   

}
