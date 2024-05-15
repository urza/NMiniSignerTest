using NBitcoin.Secp256k1;

namespace NMiniSigner;
public class Verify
{
    public static bool VerifySig(string filepath, string pubkeyhex, string signature)
    {
        var pubkey = Keys.ImportPubkey(pubkeyhex);

        byte[] fileHash = Helpers.GetFileHash(filepath);

        var sign_as_bytes = Helpers.StringToByteArray(signature);

        SecpECDSASignature.TryCreateFromDer(sign_as_bytes, out var sig);

        bool isValid = pubkey.SigVerify(sig, fileHash);

        return isValid;
    }
}
