using NBitcoin.Secp256k1;
using static NMiniSigner.Helpers;
using static NMiniSigner.Keys;

namespace NMiniSigner;
public class Test
{
    public static void TestImportFromSecret()
    {
        (var privateKey, var publicKey) = ImportKeyFromSecret(secretHex: "C2D81912D7D2ACBD3A8F82717AD228980851D5FE7B2E5509E8715BAEC9F9648C");

        var should_be_pubkey = "039A74A25744FF8200B9E9A2C36D31A1235175B13FFBF4FE1FBD55C2C9B422DDE2";
        var is_pubkey = ByteArrayToString(publicKey.ToBytes());

        Console.WriteLine($"pubkey equals?? {should_be_pubkey == is_pubkey} ");

    }

    public static void TestPubKeyImport()
    {
        (var privateKey, var _) = ImportKeyFromSecret(secretHex: "C2D81912D7D2ACBD3A8F82717AD228980851D5FE7B2E5509E8715BAEC9F9648C");
        var pubkey_from_privatekey = privateKey.CreatePubKey();
        var pubkey_from_privatekey_text = ByteArrayToString(pubkey_from_privatekey.ToBytes());

        var succ = ECPubKey.TryCreate(StringToByteArray("039A74A25744FF8200B9E9A2C36D31A1235175B13FFBF4FE1FBD55C2C9B422DDE2"), null, out _, out ECPubKey pubkey);
        var pubkey_from_text = ByteArrayToString(pubkey.ToBytes());

        Console.WriteLine($"pubkey equals?? {pubkey_from_privatekey_text == pubkey_from_text} ");
    }

    public static void TestSign()
    {
        var sig_is = Sign.SignFileHash(filepath: "example.txt", secret: "C2D81912D7D2ACBD3A8F82717AD228980851D5FE7B2E5509E8715BAEC9F9648C");
        var sig_should_be = "304402202ED6565FB5B5F52B63CC033E58766FB3104CD72D959BDC63E1D9BE3FA101FB7E02203515601FE9B27D78798A5D222499A1EC77D8C421C291CCCB031E54B5511FF026";
        Console.WriteLine($"sig equals?? {sig_should_be == sig_is} ");
    }


    public static void TestVerify()
    {
        bool result = Verify.VerifySig("example.txt", "039A74A25744FF8200B9E9A2C36D31A1235175B13FFBF4FE1FBD55C2C9B422DDE2", "304402202ED6565FB5B5F52B63CC033E58766FB3104CD72D959BDC63E1D9BE3FA101FB7E02203515601FE9B27D78798A5D222499A1EC77D8C421C291CCCB031E54B5511FF026");
        Console.WriteLine($"TestVerify {result}");
    }
}
