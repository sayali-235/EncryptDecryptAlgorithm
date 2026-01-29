using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptPOC.Helper
{
    public static class ECCEncryption
    {
        // Encrypt using Receiver Public Key
        public static byte[] Encrypt(string plainText, byte[] receiverPublicKey)
        {
            // 1️ Create sender ECDH key
            using var sender = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);

            // Export sender public key (DER format)
            byte[] senderPublicKey = sender.PublicKey.ExportSubjectPublicKeyInfo();

            // 2️ Import receiver's public key
            using var receiver = ECDiffieHellman.Create();
            receiver.ImportSubjectPublicKeyInfo(receiverPublicKey, out _);

            // 3️ Create shared secret
            byte[] sharedSecret = sender.DeriveKeyMaterial(receiver.PublicKey);

            using var sha = SHA256.Create();
            byte[] aesKey = sha.ComputeHash(sharedSecret);

            // 4️ AES encryption
            using var aes = Aes.Create();
            aes.GenerateIV();
            aes.Key = aesKey;

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            // FORMAT → senderPublicKey + IV + cipherText
            return senderPublicKey.Concat(aes.IV).Concat(cipherBytes).ToArray();
        }

        // ------------------- DECRYPT -------------------
        public static string Decrypt(byte[] encryptedData, byte[] receiverPrivateKey)
        {
            // 1️ Read DER public key length dynamically
            int derKeyLen = ReadDerKeyLength(encryptedData);

            byte[] senderPublicKey = encryptedData.Take(derKeyLen).ToArray();
            byte[] iv = encryptedData.Skip(derKeyLen).Take(16).ToArray();
            byte[] cipherBytes = encryptedData.Skip(derKeyLen + 16).ToArray();

            // 2️ Import private key
            using var receiver = ECDiffieHellman.Create();
            receiver.ImportPkcs8PrivateKey(receiverPrivateKey, out _);

            // 3️ Import sender public key
            using var sender = ECDiffieHellman.Create();
            sender.ImportSubjectPublicKeyInfo(senderPublicKey, out _);

            // 4️ Generate shared secret
            byte[] sharedSecret = receiver.DeriveKeyMaterial(sender.PublicKey);

            using var sha = SHA256.Create();
            byte[] aesKey = sha.ComputeHash(sharedSecret);

            // 5️ AES decrypt
            using var aes = Aes.Create();
            aes.Key = aesKey;
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }

        // ----------- Helper: Detect DER Length Automatically -----------
        private static int ReadDerKeyLength(byte[] data)
        {
            if (data[0] != 0x30)
                throw new Exception("Invalid DER key format");

            int lengthByte = data[1];

            if (lengthByte < 0x80)
            {
                return 2 + lengthByte;
            }
            else
            {
                int numLenBytes = lengthByte - 0x80;
                int length = 0;

                for (int i = 0; i < numLenBytes; i++)
                    length = (length << 8) + data[2 + i];

                return 2 + numLenBytes + length;
            }
        }
    }
}
