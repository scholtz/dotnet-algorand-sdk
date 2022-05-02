
using Algorand.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Algorand.V2.Algod.Model
{
  

    public abstract class Transaction
    {
        private const ulong MIN_TX_FEE_UALGOS = 1000;
        private static readonly byte[] TX_SIGN_PREFIX = Encoding.UTF8.GetBytes("TX");


        [JsonProperty(PropertyName = "snd")]
        public Address Sender = new Address();
       
        
        [JsonProperty(PropertyName = "fee")]
        [DefaultValue(0)]
        public ulong? Fee = 0;
  

        [JsonProperty(PropertyName = "fv")]
        [DefaultValue(0)]
        public ulong? FirstValid = 0;


        [JsonProperty(PropertyName = "lv")]
        [DefaultValue(0)]
        public ulong? LastValid = 0;


        [JsonIgnore]
        private byte[] _note;
        [JsonProperty(PropertyName = "note")]
        public byte[] Note
        {
            get
            {
                return _note;
            }
            set
            {
                if (value != null && value.Length > 0)
                    _note = value;
            }
        }

        [JsonProperty(PropertyName = "gen")]
        [DefaultValue("")]
        public string GenesisID = "";



        [JsonProperty(PropertyName = "gh")]
        public Digest GenesisHash = new Digest();



        [JsonProperty(PropertyName = "grp")]
        public Digest Group = new Digest();



        [JsonIgnore]
        private byte[] _lease;
        [JsonProperty(PropertyName = "lx")]
        public byte[] Lease
        {
            get
            {
                return _lease;
            }
            set
            {
                if (value != null && value.Length > 0)
                    _lease = value;
            }
        }


        [JsonProperty("rekey")]
        public Address RekeyTo = new Address();


        /// <summary>
        /// Sets the transaction fee according to suggestedFeePerByte * estimateTxSize.
        /// </summary>
        /// <param name="tx">transaction to populate fee field</param>
        /// <param name="suggestedFeePerByte">suggestedFee given by network</param>
        public void SetFeeByFeePerByte( ulong? suggestedFeePerByte)
        {
            ulong? newFee = suggestedFeePerByte * (ulong)EstimatedEncodedSize();
            if (newFee < MIN_TX_FEE_UALGOS)
            {
                newFee = MIN_TX_FEE_UALGOS;
            }
            Fee = newFee;
        }

        /// <summary>
        /// Return encoded representation of the transaction with a prefix
        /// suitable for signing
        /// </summary>
        /// <returns></returns>
        public byte[] BytesToSign()
        {
            byte[] encodedTx = Algorand.Utils.Encoder.EncodeToMsgPack(this);
            var retList = new List<byte>();
            retList.AddRange(TX_SIGN_PREFIX);
            retList.AddRange(encodedTx);
            return retList.ToArray();
        }
        /// <summary>
        /// Return transaction ID as Digest
        /// </summary>
        /// <returns></returns>
        public Digest RawTxID()
        {
            return new Digest(Digester.Digest(BytesToSign()));
        }
        /// <summary>
        /// Return transaction ID as string
        /// </summary>
        /// <returns></returns>
        public string TxID()
        {
            return Base32.EncodeToString(this.RawTxID().Bytes, false);
        }

        public SignedTransaction Sign(Account signingAccount)
        {
            byte[] prefixEncodedTx = BytesToSign();
            Signature txSig = signingAccount.SignRawBytes(prefixEncodedTx);
            var stx = new SignedTransaction(this, txSig, TxID());
            if (!Sender.Equals(signingAccount.Address))
                stx.authAddr = signingAccount.Address;
            
            return stx;
        }

        /// <summary>
        /// Sign a transaction with this account, replacing the fee with the given feePerByte.
        /// </summary>
        /// <param name="tx">transaction to sign</param>
        /// <param name="feePerByte">feePerByte fee per byte, often returned as a suggested fee</param>
        /// <returns>a signed transaction</returns>
        public SignedTransaction Sign(ulong feePerByte,Account signingAccount)
        {
            SetFeeByFeePerByte(feePerByte);
            return Sign(signingAccount);
        }

        public SignedTransaction Sign(LogicsigSignature lsig, Account signingAccount)
        {
            if (!lsig.Verify(Sender))
            {
                throw new ArgumentException("verification failed");
            }
            return new SignedTransaction(this, lsig, TxID());
        }

        public SignedTransaction Sign(MultisigAddress from, Account signingAccount)
        {
            // check that from addr of tx matches multisig preimage
            if (!Sender.ToString().Equals(from.ToString()))
            {
                throw new ArgumentException("Transaction sender does not match multisig account");
            }
            // check that account secret key is in multisig pk list
            var myEncoded = signingAccount.KeyPair.ClearTextPublicKey;
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
            SignedTransaction txSig = Sign(signingAccount);
            MultisigSignature mSig = new MultisigSignature(from.version, from.threshold);
            for (int i = 0; i < from.publicKeys.Count; i++)
            {
                if (i == myI)
                {
                    mSig.subsigs.Add(new MultisigSubsig(signingAccount.KeyPair.PublicKey, txSig.Sig));
                }
                else
                {
                    mSig.subsigs.Add(new MultisigSubsig(from.publicKeys[i]));
                }
            }
            return new SignedTransaction(this, mSig, txSig.transactionID);
        }


       

        public int EstimatedEncodedSize()
        {
            Account acc = new Account();
            return Utils.Encoder.EncodeToMsgPack(
                new SignedTransaction(this, acc.SignRawBytes(BytesToSign()), TxID())).Length;
        }


    }
}
