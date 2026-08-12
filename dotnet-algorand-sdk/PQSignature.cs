using Algorand.Algod.Model.Converters.MsgPack;
using Algorand.Utils;
using Newtonsoft.Json;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using System;
using System.Linq;
using System.Numerics;

namespace Algorand
{
    /// <summary>
    /// A post-quantum transaction authorization proof (algod 5.0.0 / consensus v42, wire field "pqsig").
    ///
    /// The authorizer address is derived from the scheme tag, a 1-byte public salt and the
    /// scheme-canonical public key as SHA-512/256("PQA" || scheme || salt || publicKey), and the
    /// signature is a deterministic-profile Falcon signature ("unsalted" det1024 compressed format:
    /// header 0xBA, salt-version byte, compressed s2) over the signed message bytes.
    /// </summary>
    [JsonObject]
    [MessagePack.MessagePackObject]
    [MessagePack.MessagePackFormatter(typeof(NoDefaultsFormatter<PQSignature>))]
    public class PQSignature
    {
        /// <summary>The "f1" scheme tag: Falcon-1024 with the deterministic signing profile.</summary>
        public static readonly byte[] SchemeFalcon1024 = { (byte)'f', (byte)'1' };

        /// <summary>Size of a Falcon-1024 public key (1-byte header + 1792 bytes of modq-encoded h).</summary>
        public const int FalconPublicKeySize = 1793;

        /// <summary>
        /// Additional fee factor charged for a Falcon-1024 authorized transaction, on top of the 1x
        /// base fee - a plain "f1" pqsig transaction owes at least (1 + 2) = 3x the network min fee.
        /// </summary>
        public const ulong Falcon1024FeeContributionFactor = 2;

        private const byte SaltedCompressedHeader = 0x3A;   // 0x30 + logn(10)
        private const byte UnsaltedCompressedHeader = 0xBA; // salted header | 0x80
        private const byte CurrentSaltVersion = 0;
        private static readonly byte[] PQ_ADDRESS_PREFIX = System.Text.Encoding.UTF8.GetBytes("PQA");

        [JsonProperty(PropertyName = "sch")]
        [MessagePack.Key("sch")]
        public byte[] Scheme { get; set; }

        [JsonProperty(PropertyName = "slt")]
        [MessagePack.Key("slt")]
        public byte Salt { get; set; }

        [JsonProperty(PropertyName = "pk")]
        [MessagePack.Key("pk")]
        public byte[] PublicKey { get; set; }

        [JsonProperty(PropertyName = "sig")]
        [MessagePack.Key("sig")]
        public byte[] Signature { get; set; }

        public PQSignature() { }

        [JsonConstructor]
        public PQSignature(
            [JsonProperty("sch")] byte[] sch,
            [JsonProperty("slt")] byte slt = 0,
            [JsonProperty("pk")] byte[] pk = null,
            [JsonProperty("sig")] byte[] sig = null)
        {
            Scheme = sch;
            Salt = slt;
            PublicKey = pk;
            Signature = sig;
        }

        /// <summary>The authorizer address this proof stands for.</summary>
        [JsonIgnore]
        [MessagePack.IgnoreMember]
        public Address Address => ComputeAddress(Scheme, Salt, PublicKey);

        /// <summary>
        /// Derives the post-quantum account address for a scheme tag, salt and public key:
        /// SHA-512/256("PQA" || scheme || salt || publicKey).
        /// </summary>
        public static Address ComputeAddress(byte[] scheme, byte salt, byte[] publicKey)
        {
            if (scheme == null || scheme.Length != 2) throw new ArgumentException("scheme must be 2 bytes", nameof(scheme));
            if (publicKey == null) throw new ArgumentNullException(nameof(publicKey));
            var preimage = new byte[PQ_ADDRESS_PREFIX.Length + scheme.Length + 1 + publicKey.Length];
            int o = 0;
            Array.Copy(PQ_ADDRESS_PREFIX, 0, preimage, o, PQ_ADDRESS_PREFIX.Length); o += PQ_ADDRESS_PREFIX.Length;
            Array.Copy(scheme, 0, preimage, o, scheme.Length); o += scheme.Length;
            preimage[o++] = salt;
            Array.Copy(publicKey, 0, preimage, o, publicKey.Length);
            return new Address(Digester.Digest(preimage));
        }

        /// <summary>
        /// Finds the canonical salt for a scheme/public-key pair: the lowest salt (ascending 0..255)
        /// whose derived address is not decodable as an Edwards25519 curve point. Non-compliant
        /// addresses are rejected at transaction admission unless skip-pq-address-check is used.
        /// </summary>
        public static byte FindCanonicalSalt(byte[] scheme, byte[] publicKey, out Address address)
        {
            for (int salt = 0; salt <= byte.MaxValue; salt++)
            {
                var addr = ComputeAddress(scheme, (byte)salt, publicKey);
                if (!IsEdwards25519Point(addr.Bytes))
                {
                    address = addr;
                    return (byte)salt;
                }
            }
            // Probability of reaching this is ~2^-256.
            throw new InvalidOperationException("no canonical salt exists for this public key and scheme");
        }

        /// <summary>
        /// Verifies this proof over the given signed message bytes (e.g. Transaction.BytesToSign()).
        /// Only the "f1" (Falcon-1024) scheme is supported.
        /// </summary>
        public bool Verify(byte[] data)
        {
            if (Scheme == null || !Scheme.SequenceEqual(SchemeFalcon1024)) return false;
            if (PublicKey == null || PublicKey.Length != FalconPublicKeySize) return false;
            if (Signature == null || Signature.Length < 2 || Signature[0] != UnsaltedCompressedHeader) return false;

            // Rebuild the salted compressed-format signature the reference verifier consumes:
            // header 0x3A, the fixed 40-byte versioned salt, then the compressed s2 bytes.
            var salted = new byte[1 + 40 + Signature.Length - 2];
            salted[0] = SaltedCompressedHeader;
            WriteSalt(salted, 1, Signature[1]);
            Array.Copy(Signature, 2, salted, 41, Signature.Length - 2);

            var pk = new FalconPublicKeyParameters(FalconParameters.falcon_1024, PublicKey.Skip(1).ToArray());
            var verifier = new FalconSigner();
            verifier.Init(false, pk);
            return verifier.VerifySignature(data, salted);
        }

        /// <summary>
        /// Writes the fixed 40-byte deterministic-Falcon salt for a salt version:
        /// version || logn(10) || "FALCON_DET" || 28 zero bytes.
        /// </summary>
        internal static void WriteSalt(byte[] dst, int offset, byte saltVersion)
        {
            var rest = System.Text.Encoding.UTF8.GetBytes("FALCON_DET");
            Array.Clear(dst, offset, 40);
            dst[offset] = saltVersion;
            dst[offset + 1] = 10; // logn for Falcon-1024
            Array.Copy(rest, 0, dst, offset + 2, rest.Length);
        }

        internal static byte[] MakeSalt(byte saltVersion)
        {
            var salt = new byte[40];
            WriteSalt(salt, 0, saltVersion);
            return salt;
        }

        internal static byte DefaultSaltVersion => CurrentSaltVersion;

        internal static byte[] RepackToUnsalted(byte[] bcDetachedSignature, byte[] expectedSalt, byte saltVersion)
        {
            // BouncyCastle's detached Falcon signature is header(0x3A) || nonce(40) || compressed s2.
            if (bcDetachedSignature == null || bcDetachedSignature.Length < 42 || bcDetachedSignature[0] != SaltedCompressedHeader)
                throw new InvalidOperationException("unexpected Falcon signature format");
            for (int i = 0; i < 40; i++)
                if (bcDetachedSignature[1 + i] != expectedSalt[i])
                    throw new InvalidOperationException("Falcon signature was not produced over the deterministic salt");
            var sig = new byte[bcDetachedSignature.Length - 40 + 1];
            sig[0] = UnsaltedCompressedHeader;
            sig[1] = saltVersion;
            Array.Copy(bcDetachedSignature, 41, sig, 2, bcDetachedSignature.Length - 41);
            return sig;
        }

        private static readonly BigInteger Ed25519P = (BigInteger.One << 255) - 19;

        /// <summary>
        /// Reports whether the 32 bytes decode as an Edwards25519 curve point, mirroring
        /// go-algorand's crypto.IsEdwards25519Point (filippo.io/edwards25519 Point.SetBytes
        /// semantics: the sign bit is split off and the y coordinate is accepted non-canonically,
        /// i.e. reduced mod p before decoding).
        /// </summary>
        public static bool IsEdwards25519Point(byte[] encoded)
        {
            if (encoded == null || encoded.Length != 32) return false;

            var y = new byte[32];
            Array.Copy(encoded, y, 32);
            int sign = (y[31] & 0x80) >> 7;
            y[31] &= 0x7F;

            // Reduce y mod p so non-canonical encodings (y >= p) are accepted like SetBytes does.
            var le = new byte[33];
            Array.Copy(y, le, 32);
            var yInt = new BigInteger(le);
            yInt %= Ed25519P;
            var reduced = yInt.ToByteArray();
            var canonical = new byte[32];
            Array.Copy(reduced, canonical, Math.Min(reduced.Length, 32));
            canonical[31] |= (byte)(sign << 7);

            return Org.BouncyCastle.Math.EC.Rfc8032.Ed25519.ValidatePublicKeyPartial(canonical, 0);
        }

        public override bool Equals(object obj)
        {
            if (obj is PQSignature other)
            {
                return BytesEqual(Scheme, other.Scheme)
                    && Salt == other.Salt
                    && BytesEqual(PublicKey, other.PublicKey)
                    && BytesEqual(Signature, other.Signature);
            }
            return false;
        }

        private static bool BytesEqual(byte[] a, byte[] b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a.SequenceEqual(b);
        }

        public override int GetHashCode()
        {
            return (Scheme?.Length ?? 0) ^ Salt ^ (PublicKey?.Length ?? 0) ^ (Signature?.Length ?? 0);
        }
    }
}
