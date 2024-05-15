using static NMiniSigner.Helpers;

namespace NMiniSigner;
public class Sign
{
    public static string SignFileHash(string filepath, string secret)
    {
        byte[] fileHash = GetFileHash(filepath);

        var (privateKey, _) = Keys.ImportKeyFromSecret(secret);

        bool signed_success = privateKey.TrySignECDSA(fileHash, out var signatureBytes);

        if(!signed_success)
        {
            throw new Exception("signed_success == false");
        }

        var sig_is = ByteArrayToString(signatureBytes!.ToDER());

        return sig_is;
    }
}
