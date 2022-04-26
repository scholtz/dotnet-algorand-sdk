
#nullable enable

using Newtonsoft.Json;

namespace Algorand.V2.Algod.Model
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SignedTransaction
    {
        [JsonProperty(PropertyName = "txn")]
        public Transaction tx;

        [JsonProperty(PropertyName = "sig")]
        public Signature? sig; 

        [JsonProperty(PropertyName = "msig")]
        public MultisigSignature? mSig;

        [JsonProperty(PropertyName = "lsig")]
        public LogicsigSignature? lSig;

        [JsonProperty(PropertyName = "sgnr")]
        public Address authAddr = new Address();
        public void SetAuthAddr(byte[] sigAddr)
        {
            authAddr = new Address(sigAddr);
        }

        [JsonIgnore]
        public string transactionID = "";

        public SignedTransaction(Transaction tx, Signature sig, MultisigSignature mSig, LogicsigSignature lSig, string transactionID)
        {
            this.tx = tx;
            this.mSig = mSig;
            this.sig = sig;
            this.lSig = lSig;
            this.transactionID = transactionID;
        }

        public SignedTransaction(Transaction tx, Signature sig, string txId) :
            this(tx, sig, new MultisigSignature(), new LogicsigSignature(), txId)
        { }

        public SignedTransaction(Transaction tx, MultisigSignature mSig, string txId) :
            this(tx, new Signature(), mSig, new LogicsigSignature(), txId)
        { }

        public SignedTransaction(Transaction tx, LogicsigSignature lSig, string txId) :
            this(tx, new Signature(), new MultisigSignature(), lSig, txId)
        { }

        public SignedTransaction() { }

        [JsonConstructor]
        public SignedTransaction(Transaction txn, byte[] sig, MultisigSignature msig, LogicsigSignature lsig, byte[] sgnr)
        {
            if (txn != null) this.tx = txn;
            if (sig != null) this.sig = new Signature(sig);
            if (msig != null) this.mSig = msig;
            if (lsig != null) this.lSig = lsig;
            if (sgnr != null) this.authAddr = new Address(sgnr);
            // don't recover the txid yet
        }

        public override bool Equals(object obj)
        {
            if (obj is SignedTransaction actual)
            {
                if (!tx.Equals(actual.tx)) return false;
                if (!sig.Equals(actual.sig)) return false;
                if (!lSig.Equals(actual.lSig)) return false;
                if (!authAddr.Equals(actual.authAddr)) return false;
                return this.mSig.Equals(actual.mSig);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
