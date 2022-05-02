using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Crypto
{
    public class KeyPair
    {
        internal const int SK_SIZE = 32;
        internal const int SK_SIZE_BITS = SK_SIZE * 8;
        private const int PK_SIZE = 32;
    
        private Ed25519PrivateKeyParameters ed25519PrivateKey;
        private Ed25519PublicKeyParameters ed25519PublicKey;
  


        public KeyPair(byte[] privateKey)
        {
            if (privateKey.Length != SK_SIZE)
                throw new ArgumentException("Incorrect private key length");

            ClearTextPrivateKey= privateKey;

            ed25519PrivateKey = new Ed25519PrivateKeyParameters(ClearTextPrivateKey, 0);
            ed25519PublicKey = ed25519PrivateKey.GeneratePublicKey();
            Pair = new AsymmetricCipherKeyPair(ed25519PrivateKey, ed25519PublicKey);
        }


        public KeyPair(SecureRandom random)
        {
            Ed25519KeyPairGenerator keyPairGenerator = new Ed25519KeyPairGenerator();
            keyPairGenerator.Init(new Ed25519KeyGenerationParameters(random));
            Pair = keyPairGenerator.GenerateKeyPair();
            ed25519PrivateKey = Pair.Private as Ed25519PrivateKeyParameters;
            ed25519PublicKey = Pair.Public as Ed25519PublicKeyParameters;
            ClearTextPrivateKey = ed25519PrivateKey.GetEncoded(); 

          
 


            this.Address = new Address(raw);
        }

        public byte[] ClearTextPrivateKey { get; private set; }

        public byte[] ClearTextPublicKey { 
            get 
            {
                byte[] b = ed25519PublicKey.GetEncoded(); // X.509 prepended with ASN.1 prefix

                if (b.Length != PK_SIZE)
                {
                    throw new Exception("Generated public key is the wrong size");
                }

                return b;
            } 
        }

        public Ed25519PublicKeyParameters PublicKey { 
            get
            {

                return ed25519PublicKey;
            } 
        }

        public AsymmetricCipherKeyPair Pair { get; private set; }
    }
    
}
