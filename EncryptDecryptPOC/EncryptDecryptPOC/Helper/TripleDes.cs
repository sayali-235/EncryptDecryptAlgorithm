using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptPOC.Helper
{
    public class TripleDes
    {
        public static string EncryptString(string Message = "")
        {
            string Passphrase = "nEo@^!n@23";
            byte[] Results;
            UTF8Encoding UTF8 = new UTF8Encoding();

            // Step 1. Use MD5.Create() instead of MD5CryptoServiceProvider
            using var hashProvider = MD5.Create();
            byte[] TDESKey = hashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Use TripleDES.Create() instead of TripleDESCryptoServiceProvider
            using var tdesAlgorithm = TripleDES.Create();

            // Step 3. Setup the encoder
            tdesAlgorithm.Key = TDESKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            ICryptoTransform Encryptor = tdesAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }


        public static string DecryptString(string Message = "mI6qJoSmlR4=")
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                Message = "mI6qJoSmlR4=";
            }

            UTF8Encoding UTF8 = new UTF8Encoding();
            byte[] Results;
            string Passphrase = "nEo@^!n@23";

            try
            {
                // Step 1: Hash passphrase using MD5 (replaces MD5CryptoServiceProvider)
                using var hashProvider = MD5.Create();
                byte[] TDESKey = hashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

                // Step 2: Use TripleDES.Create() instead of TripleDESCryptoServiceProvider
                using var TDESAlgorithm = TripleDES.Create();
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 3: Decrypt the data
                byte[] DataToDecrypt = Convert.FromBase64String(Message);
                using var Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch
            {
                return "";
            }

            // Step 4: Return decrypted string
            return UTF8.GetString(Results);
        }

    }
}
