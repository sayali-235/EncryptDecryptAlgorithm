using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptPOC.Helper
{
    public class BlowfishEncryption
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("this_is_blowfish_key_16b");

        public static string Encrypt(string plainText)
        {
            byte[] iv = GenerateIV();  // 8-byte IV for Blowfish (64-bit block)

            var engine = new BlowfishEngine();
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));

            var keyParam = new ParametersWithIV(new KeyParameter(Key), iv);
            cipher.Init(true, keyParam);

            byte[] input = Encoding.UTF8.GetBytes(plainText);
            byte[] output = new byte[cipher.GetOutputSize(input.Length)];

            int length = cipher.ProcessBytes(input, 0, input.Length, output, 0);
            length += cipher.DoFinal(output, length);

            // final output = IV + ciphertext
            byte[] finalResult = new byte[iv.Length + length];
            Buffer.BlockCopy(iv, 0, finalResult, 0, iv.Length);
            Buffer.BlockCopy(output, 0, finalResult, iv.Length, length);

            return Convert.ToBase64String(finalResult);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);

            // Extract IV (first 8 bytes)
            byte[] iv = new byte[8];
            Buffer.BlockCopy(fullCipher, 0, iv, 0, 8);

            // Extract Cipher (remaining bytes)
            byte[] cipherBytes = new byte[fullCipher.Length - 8];
            Buffer.BlockCopy(fullCipher, 8, cipherBytes, 0, cipherBytes.Length);

            var engine = new BlowfishEngine();
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));
            var keyParam = new ParametersWithIV(new KeyParameter(Key), iv);

            cipher.Init(false, keyParam);

            byte[] output = new byte[cipher.GetOutputSize(cipherBytes.Length)];

            int length = cipher.ProcessBytes(cipherBytes, 0, cipherBytes.Length, output, 0);
            length += cipher.DoFinal(output, length);

            return Encoding.UTF8.GetString(output, 0, length);
        }

        private static byte[] GenerateIV()
        {
            // Blowfish block size = 64 bits → IV = 8 bytes
            byte[] iv = new byte[8];
            RandomNumberGenerator.Fill(iv);
            return iv;
        }
    }
}
