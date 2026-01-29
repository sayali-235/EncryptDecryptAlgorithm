using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptPOC.Helper
{
    public class RsaEncryption
    {
        // Encrypt using PUBLIC KEY
        public static string Encrypt(string input, string base64PublicKey)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(input);
            byte[] publicKeyBytes = Convert.FromBase64String(base64PublicKey);

            using var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);

            byte[] encryptedBytes = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);

            return Convert.ToBase64String(encryptedBytes);
        }

        // Decrypt using PRIVATE KEY
        public static string Decrypt(string encryptedBase64, string base64PrivateKey)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(encryptedBase64);
            byte[] privateKeyBytes = Convert.FromBase64String(base64PrivateKey);

            using var rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(privateKeyBytes, out _);

            byte[] decryptedBytes = rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.OaepSHA256);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
