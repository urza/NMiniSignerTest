using System.Security.Cryptography;

namespace NMiniSigner;
public class Helpers
{
    public static byte[] GetFileHash(string filePath)
    {
        // Read the file contents
        byte[] fileBytes = File.ReadAllBytes(filePath);

        // Create a SHA256 hash of the file
        var sha256 = SHA256.Create();
        var fileHash = sha256.ComputeHash(fileBytes);
        return fileHash;
    }

    public static string ByteArrayToString(byte[] array)
    {
        return BitConverter.ToString(array).Replace("-", "");
    }

    public static byte[] StringToByteArray(string hex)
    {
        int numberChars = hex.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }
}
