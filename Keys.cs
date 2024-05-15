using NBitcoin.Secp256k1;
using System.Security.Cryptography;
using static NMiniSigner.Helpers;

namespace NMiniSigner;
public class Keys
{
    public static (ECPrivKey privateKey, ECPubKey publicKey) GenerateKey()
    {
        byte[] privateKeyBytes = new byte[32];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(privateKeyBytes);
        }
        var privateKey = ECPrivKey.Create(privateKeyBytes);
        var publicKey = privateKey.CreatePubKey();

        Console.WriteLine($"secret: {ByteArrayToString(privateKeyBytes)}");
        Console.WriteLine($"pubkey: {ByteArrayToString(publicKey.ToBytes())}");

        return (privateKey, publicKey);
    }

    public static (ECPrivKey privateKey, ECPubKey publicKey) ImportKeyFromSecret(string secretHex)
    {
        byte[] privateKeyBytes = StringToByteArray(secretHex);
        var privateKey = ECPrivKey.Create(privateKeyBytes);
        var publicKey = privateKey.CreatePubKey();

        Console.WriteLine($"secret: {ByteArrayToString(privateKeyBytes)}");
        Console.WriteLine($"pubkey: {ByteArrayToString(publicKey.ToBytes())}");

        return (privateKey, publicKey);
    }

    public static ECPubKey ImportPubkey(string publicHex)
    {
        var succ = ECPubKey.TryCreate(StringToByteArray(publicHex), null, out _, out var pubkey);

        if (!succ || pubkey is null)
        {
            throw new Exception($"ImportPubkey failed, hex: {publicHex}");
        }

        return pubkey;
    }
}
