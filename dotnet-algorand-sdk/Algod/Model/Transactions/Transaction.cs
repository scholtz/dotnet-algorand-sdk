
using Algorand.Utils;
using JsonSubTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Algorand.Algod.Model
{


    [JsonConverter(typeof(ReturnedTransactionConverter))]
    public interface IReturnableTransaction { }

    [JsonConverter(typeof(JsonSubtypes), "type")]
    [JsonSubtypes.KnownSubType(typeof(ApplicationCallTransaction), "appl")]
    [JsonSubtypes.KnownSubType(typeof(KeyRegistrationTransaction), "keyreg")]
    [JsonSubtypes.KnownSubType(typeof(PaymentTransaction), "pay")]
    [JsonSubtypes.KnownSubType(typeof(AssetFreezeTransaction), "afrz")]
    [JsonSubtypes.KnownSubType(typeof(AssetMovementsTransaction), "axfer")]
    [JsonSubtypes.KnownSubType(typeof(AssetConfigurationTransaction), "acfg")]

    public abstract class Transaction : IReturnableTransaction
    {
        private const ulong MIN_TX_FEE_UALGOS = 1000;
        private static readonly byte[] TX_SIGN_PREFIX = Encoding.UTF8.GetBytes("TX");




        [JsonProperty(PropertyName = "snd")]
        public Address Sender;
       
        
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

        //used by newtonsoft
        public bool ShouldSerializeNote() { return Note?.Length > 0; }

        [JsonProperty(PropertyName = "gen")]
        [DefaultValue("")]
        public string GenesisID = "";


      
        [JsonProperty(PropertyName = "gh")]
        public Digest GenesisHash;



        [JsonProperty(PropertyName = "grp")]
        public Digest Group;



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


        public bool ShouldSerializeLease() { return Lease?.Length > 0; }

        [JsonProperty("rekey")]
        public Address RekeyTo;

        [JsonIgnore]
        public bool Committed => (ConfirmedRound ?? 0) > 0;


        [JsonIgnore]
        public ulong? ConfirmedRound { get; internal set; }

        [JsonIgnore]
        public string PoolError { get; internal set; }

        [JsonIgnore]
        public ulong? ReceiverRewards { get; internal set; }

        [JsonIgnore]
        public ulong? SenderRewards { get; internal set; }

        [JsonIgnore]
        public ulong? CloseRewards { get; internal set; }

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
            byte[] encodedTx = Algorand.Utils.Encoder.EncodeToMsgPackOrdered(this);
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

        public void SetFee(ulong fee)
        {
            if (fee < MIN_TX_FEE_UALGOS) fee = MIN_TX_FEE_UALGOS;
            Fee = fee;
        }

        public SignedTransaction Sign(Account signingAccount)
        {
            byte[] prefixEncodedTx = BytesToSign();
            Signature txSig = signingAccount.SignRawBytes(prefixEncodedTx);
            var stx = new SignedTransaction(this, txSig);
            if (!Sender.Equals(signingAccount.Address))
                stx.AuthAddr = signingAccount.Address;
            
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

        public SignedTransaction Sign(LogicsigSignature lsig)
        {
            if (!lsig.Verify(Sender))
            {
                throw new ArgumentException("verification failed");
            }
            return new SignedTransaction(this,null, null, lsig,null);
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
                    mSig.Subsigs.Add(new MultisigSubsig(signingAccount.KeyPair.PublicKey, txSig.Sig));
                }
                else
                {
                    mSig.Subsigs.Add(new MultisigSubsig(from.publicKeys[i]));
                }
            }
            return new SignedTransaction(this, null,mSig,null,null);
        }


       

        public int EstimatedEncodedSize()
        {
            Account acc = new Account();
            return Utils.Encoder.EncodeToMsgPackOrdered(
                new SignedTransaction(this, acc.SignRawBytes(BytesToSign()))).Length;
        }


    }
}
