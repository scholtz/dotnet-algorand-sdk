using Algorand;
using Algorand.Algod;
using Algorand.Algod.Model;
using Algorand.Algod.Model.Transactions;
using Algorand.KMD;
using Algorand.Utils;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace test
{
    /// <summary>
    /// Tests for post-quantum Falcon-1024 account signatures (algod 5.0.0 / consensus v42).
    /// The offline tests need no network; SendPaymentFromFalconAccount needs an AlgoKit LocalNet
    /// running algod 5.0.0+ (consensus v42) on http://localhost:4001 / kmd on :4002.
    /// </summary>
    [TestFixture]
    public class PQSignatureTests
    {
        private static readonly byte[] TestSeed = Enumerable.Range(1, 32).Select(i => (byte)i).ToArray();

        [Test]
        public void DeterministicKeygenFromSeed()
        {
            var acc1 = new FalconAccount(TestSeed);
            var acc2 = new FalconAccount(TestSeed);

            Assert.That(acc1.PublicKey.Length, Is.EqualTo(FalconAccount.PublicKeySize));
            Assert.That(acc1.PrivateKey.Length, Is.EqualTo(FalconAccount.PrivateKeySize));
            Assert.That(acc1.PublicKey[0], Is.EqualTo(0x0A));
            Assert.That(acc1.PrivateKey[0], Is.EqualTo(0x5A));
            Assert.That(acc1.PublicKey, Is.EqualTo(acc2.PublicKey));
            Assert.That(acc1.PrivateKey, Is.EqualTo(acc2.PrivateKey));
            Assert.That(acc1.Address.ToString(), Is.EqualTo(acc2.Address.ToString()));
        }

        [Test]
        public void KeyImportRoundTrip()
        {
            var acc = new FalconAccount(TestSeed);
            var imported = new FalconAccount(acc.PublicKey, acc.PrivateKey);
            Assert.That(imported.Address.ToString(), Is.EqualTo(acc.Address.ToString()));
            Assert.That(imported.Salt, Is.EqualTo(acc.Salt));
        }

        [Test]
        public void CanonicalSaltAddressIsPQCompliant()
        {
            var acc = new FalconAccount(TestSeed);
            // The canonical address must not decode as an Edwards25519 point.
            Assert.That(PQSignature.IsEdwards25519Point(acc.Address.Bytes), Is.False);
            // And every lower salt must have been rejected because it *does* decode as a point.
            for (byte salt = 0; salt < acc.Salt; salt++)
            {
                var addr = PQSignature.ComputeAddress(PQSignature.SchemeFalcon1024, salt, acc.PublicKey);
                Assert.That(PQSignature.IsEdwards25519Point(addr.Bytes), Is.True);
            }
        }

        // Golden vector produced by go-algorand 5.0.0's `algokey pq generate` + `algokey pq info`:
        // the derived canonical salt and address must match the node's own derivation exactly.
        private const string AlgokeyPublicKeyB64 =
            "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";

        // The 25-word mnemonic algokey printed alongside the golden public key above.
        private const string AlgokeyMnemonic =
            "office route parade much super sphere wheel morning spawn true wire already siren unveil planet damage basket depend undo deer acquire popular what about clay";

        [Test]
        public void AddressDerivationMatchesAlgokey()
        {
            var publicKey = Convert.FromBase64String(AlgokeyPublicKeyB64);
            Assert.That(publicKey.Length, Is.EqualTo(FalconAccount.PublicKeySize));

            var salt = PQSignature.FindCanonicalSalt(PQSignature.SchemeFalcon1024, publicKey, out var address);
            Assert.That(salt, Is.EqualTo(0));
            Assert.That(address.ToString(), Is.EqualTo("HTKQVJJ3KYQDTRBAV2ZBHAHXCJKP2OXZXHJ4KQZFYDORVBOR676MY4NLQE"));
        }

        /// <summary>
        /// Full mnemonic interop with go-algorand's `algokey pq`: recovering from the algokey
        /// mnemonic must regenerate the byte-identical Falcon-1024 public key and address.
        /// </summary>
        [Test]
        public void MnemonicRecoveryMatchesAlgokey()
        {
            var acc = FalconAccount.FromMnemonic(AlgokeyMnemonic);

            Assert.That(acc.PublicKey, Is.EqualTo(Convert.FromBase64String(AlgokeyPublicKeyB64)));
            Assert.That(acc.Salt, Is.EqualTo(0));
            Assert.That(acc.Address.ToString(), Is.EqualTo("HTKQVJJ3KYQDTRBAV2ZBHAHXCJKP2OXZXHJ4KQZFYDORVBOR676MY4NLQE"));
            Assert.That(acc.ToMnemonic(), Is.EqualTo(AlgokeyMnemonic));
        }

        /// <summary>
        /// Bit-compatibility with go-algorand's deterministic Falcon-1024 signer: for each golden
        /// file (a transaction signed by `algokey pq sign` 5.0.0 with the golden mnemonic above),
        /// re-signing the same transaction with this SDK must produce the byte-identical pqsig -
        /// not merely a valid one. This is a security requirement, not cosmetics: the Algorand
        /// verifier re-adds the fixed det1024 salt and cannot police deterministic sampling, so two
        /// implementations emitting different valid signatures for the same (key, message) would
        /// hand an observer two distinct GPV preimages of one hash target, whose difference is a
        /// short vector of the secret NTRU lattice (key-recovery-grade leakage).
        /// </summary>
        [Test]
        public void DetSignaturesAreBitCompatibleWithAlgokey()
        {
            var files = Directory.GetFiles(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData"),
                    "algokey-pq-signed-*.stxn")
                .OrderBy(f => f)
                .ToArray();
            Assert.That(files, Has.Length.EqualTo(3));

            var acc = FalconAccount.FromMnemonic(AlgokeyMnemonic);
            Assert.Multiple(() =>
            {
                foreach (var file in files)
                {
                    var golden = File.ReadAllBytes(file);
                    var theirs = Encoder.DecodeFromMsgPack<SignedTransaction>(golden);
                    var ours = theirs.Tx.SignPQ(acc);
                    Assert.That(ours.PQSig.Signature, Is.EqualTo(theirs.PQSig.Signature),
                        $"signature bytes differ from algokey for {Path.GetFileName(file)}");
                    Assert.That(Encoder.EncodeToMsgPackOrdered(ours), Is.EqualTo(golden),
                        $"full signed-transaction encoding differs from algokey for {Path.GetFileName(file)}");
                }
            });
        }

        private sealed class AlgokeyPqVector
        {
            [JsonProperty("mnemonic")] public string Mnemonic { get; set; }
            [JsonProperty("address")] public string Address { get; set; }
            [JsonProperty("salt")] public byte Salt { get; set; }
            [JsonProperty("publicKey")] public string PublicKeyB64 { get; set; }
            [JsonProperty("privateKey")] public string PrivateKeyB64 { get; set; }
        }

        /// <summary>
        /// Dataset interop test: 50 accounts generated by go-algorand 5.0.0's `algokey pq generate`
        /// (commit da5946a1). For each account, TestData/algokey-pq-accounts.json records the
        /// mnemonic, canonical salt and address algokey printed, plus the raw 2305-byte private key
        /// and 1793-byte public key extracted from its keyfile. Recovering every account from its
        /// mnemonic alone must reproduce the byte-identical key pair, the same canonical salt and
        /// address, and round-trip back to the identical 25 words.
        /// </summary>
        [Test]
        public void AlgokeyGeneratedDatasetOf50AccountsMatches()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "algokey-pq-accounts.json");
            var vectors = JsonConvert.DeserializeObject<AlgokeyPqVector[]>(File.ReadAllText(path));
            Assert.That(vectors, Has.Length.EqualTo(50));
            Assert.That(vectors.Select(v => v.Address).Distinct().Count(), Is.EqualTo(50));

            Assert.Multiple(() =>
            {
                foreach (var v in vectors)
                {
                    var acc = FalconAccount.FromMnemonic(v.Mnemonic);
                    Assert.That(acc.PrivateKey, Is.EqualTo(Convert.FromBase64String(v.PrivateKeyB64)), $"private key mismatch for {v.Address}");
                    Assert.That(acc.PublicKey, Is.EqualTo(Convert.FromBase64String(v.PublicKeyB64)), $"public key mismatch for {v.Address}");
                    Assert.That(acc.Salt, Is.EqualTo(v.Salt), $"salt mismatch for {v.Address}");
                    Assert.That(acc.Address.ToString(), Is.EqualTo(v.Address), $"address mismatch for {v.Address}");
                    Assert.That(acc.ToMnemonic(), Is.EqualTo(v.Mnemonic), $"mnemonic round-trip mismatch for {v.Address}");
                }
            });
        }

        [Test]
        public void MnemonicRoundTrip()
        {
            var fresh = new FalconAccount();
            var mnemonic = fresh.ToMnemonic();
            Assert.That(mnemonic.Split(' ').Length, Is.EqualTo(25));

            var recovered = FalconAccount.FromMnemonic(mnemonic);
            Assert.That(recovered.PublicKey, Is.EqualTo(fresh.PublicKey));
            Assert.That(recovered.PrivateKey, Is.EqualTo(fresh.PrivateKey));
            Assert.That(recovered.Address.ToString(), Is.EqualTo(fresh.Address.ToString()));

            // Raw imports carry no entropy, so no mnemonic can be produced for them.
            var rawImport = new FalconAccount(fresh.PublicKey, fresh.PrivateKey);
            Assert.That(() => rawImport.ToMnemonic(), Throws.InvalidOperationException);
        }

        [Test]
        public void SignAndVerifyRoundTrip()
        {
            var acc = new FalconAccount(TestSeed);
            var message = System.Text.Encoding.UTF8.GetBytes("TXhello post-quantum world");

            var pqsig = acc.SignPQRawBytes(message);

            Assert.That(pqsig.Scheme, Is.EqualTo(PQSignature.SchemeFalcon1024));
            Assert.That(pqsig.Salt, Is.EqualTo(acc.Salt));
            Assert.That(pqsig.PublicKey, Is.EqualTo(acc.PublicKey));
            // det1024 "unsalted" compressed format: 0xBA header then the salt-version byte.
            Assert.That(pqsig.Signature[0], Is.EqualTo(0xBA));
            Assert.That(pqsig.Signature[1], Is.EqualTo(0));
            Assert.That(pqsig.Address.ToString(), Is.EqualTo(acc.Address.ToString()));

            Assert.That(pqsig.Verify(message), Is.True);

            var tampered = (byte[])message.Clone();
            tampered[5] ^= 0x01;
            Assert.That(pqsig.Verify(tampered), Is.False);
        }

        [Test]
        public void SigningIsDeterministic()
        {
            var acc = new FalconAccount(TestSeed);
            var message = System.Text.Encoding.UTF8.GetBytes("determinism check");
            var sig1 = acc.SignPQRawBytes(message);
            var sig2 = acc.SignPQRawBytes(message);
            Assert.That(sig1.Signature, Is.EqualTo(sig2.Signature));
        }

        [Test]
        public void SignedTransactionMsgPackRoundTrip()
        {
            var acc = new FalconAccount(TestSeed);
            var tx = new PaymentTransaction()
            {
                Sender = acc.Address,
                Receiver = new Address("5KFWCRTIJUMDBXELQGMRBGD2OQ2L3ZQ2MB54KT2XOQ3UWPKUU4Y7TQ4X7U"),
                Amount = 12345,
                Fee = 3000,
                FirstValid = 1,
                LastValid = 1000,
                GenesisId = "dockernet-v1",
                GenesisHash = new Digest(new byte[32]),
            };

            var stx = tx.SignPQ(acc);
            Assert.That(stx.PQSig, Is.Not.Null);
            Assert.That(stx.AuthAddr, Is.Null); // sender is the PQ address itself
            Assert.That(stx.PQSig.Verify(tx.BytesToSign()), Is.True);

            var encoded = Encoder.EncodeToMsgPackOrdered(stx);
            var decoded = Encoder.DecodeFromMsgPack<SignedTransaction>(encoded);

            Assert.That(decoded.PQSig, Is.Not.Null);
            Assert.That(decoded.PQSig.Scheme, Is.EqualTo(stx.PQSig.Scheme));
            Assert.That(decoded.PQSig.Salt, Is.EqualTo(stx.PQSig.Salt));
            Assert.That(decoded.PQSig.PublicKey, Is.EqualTo(stx.PQSig.PublicKey));
            Assert.That(decoded.PQSig.Signature, Is.EqualTo(stx.PQSig.Signature));
            Assert.That(decoded.PQSig.Verify(tx.BytesToSign()), Is.True);

            // Re-encoding the decoded transaction must be byte-identical (canonical encoding).
            var reencoded = Encoder.EncodeToMsgPackOrdered(decoded);
            Assert.That(reencoded, Is.EqualTo(encoded));
        }

        /// <summary>
        /// End-to-end: fund a Falcon PQ address from a LocalNet genesis account, then spend from it
        /// with a pqsig-authorized payment. Requires AlgoKit LocalNet on algod 5.0.0+.
        /// </summary>
        [Test]
        public async Task SendPaymentFromFalconAccount()
        {
            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            var algod = new DefaultApi(httpClient);

            var funder = await GetFundedLocalNetAccount();
            var falcon = new FalconAccount(); // fresh random PQ account

            // Fund the PQ address with a classic ed25519 payment.
            var transParams = await algod.TransactionParamsAsync();
            var fundTx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
                funder.Address, falcon.Address, 1_000_000, "fund falcon account", transParams);
            var fundSigned = fundTx.Sign(funder);
            var fundResp = await algod.SubmitTransaction(fundSigned);
            await algod.WaitTransactionToComplete(fundResp.Txid);

            // Spend from the PQ account: a Falcon-1024 pqsig owes 2x min fee on top of the base fee.
            transParams = await algod.TransactionParamsAsync();
            var minFee = transParams.MinFee == 0 ? 1000 : transParams.MinFee;
            var payTx = PaymentTransaction.GetPaymentTransactionFromNetworkTransactionParameters(
                falcon.Address, funder.Address, 100_000, "post-quantum payment", transParams);
            payTx.Fee = minFee * (1 + PQSignature.Falcon1024FeeContributionFactor);

            var paySigned = payTx.SignPQ(falcon);
            var payResp = await algod.SubmitTransaction(paySigned);
            var confirmed = await algod.WaitTransactionToComplete(payResp.Txid);
            Assert.That(confirmed.ConfirmedRound, Is.GreaterThan(0));

            var falconInfo = await algod.AccountInformationAsync(falcon.Address.ToString(), null, null);
            Assert.That(falconInfo.Amount, Is.EqualTo(1_000_000UL - 100_000UL - payTx.Fee));
        }

        private const string FundedWalletName = "unencrypted-default-wallet";

        private static async Task<Account> GetFundedLocalNetAccount()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-KMD-API-Token", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var kmdApi = new Api(client);
            kmdApi.BaseUrl = @"http://localhost:4002";

            var wallets = await kmdApi.ListWalletsAsync(null);
            var wallet = wallets.Wallets.First(w => w.Name == FundedWalletName);
            var handle = (await kmdApi.InitWalletHandleTokenAsync(new InitWalletHandleTokenRequest() { Wallet_id = wallet.Id, Wallet_password = "" })).Wallet_handle_token;
            var accs = await kmdApi.ListKeysInWalletAsync(new ListKeysRequest() { Wallet_handle_token = handle });

            var ALGOD_API_ADDR = "http://localhost:4001/";
            var ALGOD_API_TOKEN = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var httpClient = HttpClientConfigurator.ConfigureHttpClient(ALGOD_API_ADDR, ALGOD_API_TOKEN);
            var algod = new DefaultApi(httpClient);

            string best = null;
            ulong bestAmount = 0;
            foreach (var a in accs.Addresses)
            {
                var info = await algod.AccountInformationAsync(a, null, null);
                if (info.Amount > bestAmount) { bestAmount = info.Amount; best = a; }
            }
            Assert.That(best, Is.Not.Null, "no funded account in LocalNet default wallet");

            var resp = await kmdApi.ExportKeyAsync(new ExportKeyRequest() { Address = best, Wallet_handle_token = handle, Wallet_password = "" });
            return new Account(resp.Private_key);
        }
    }
}
