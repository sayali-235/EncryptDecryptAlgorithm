using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Security;
using System.Text;
using Org.BouncyCastle.Crypto.Engines;

namespace EncryptDecryptPOC.Helper
{
    public static class TwofishEncryption
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes

        public static string Encrypt(string plainText)
        {
            var engine = new TwofishEngine();
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));
            var keyParam = new ParametersWithIV(new KeyParameter(Key), IV);

            cipher.Init(true, keyParam);

            byte[] input = Encoding.UTF8.GetBytes(plainText);
            byte[] output = new byte[cipher.GetOutputSize(input.Length)];

            int length = cipher.ProcessBytes(input, 0, input.Length, output, 0);
            length += cipher.DoFinal(output, length);

            return Convert.ToBase64String(output, 0, length);
        }

        public static string Decrypt(string cipherText)
        {
            var engine = new TwofishEngine();
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));
            var keyParam = new ParametersWithIV(new KeyParameter(Key), IV);

            cipher.Init(false, keyParam);

            byte[] input = Convert.FromBase64String(cipherText);
            byte[] output = new byte[cipher.GetOutputSize(input.Length)];

            int length = cipher.ProcessBytes(input, 0, input.Length, output, 0);
            length += cipher.DoFinal(output, length);

            return Encoding.UTF8.GetString(output, 0, length);
        }
    }
}
