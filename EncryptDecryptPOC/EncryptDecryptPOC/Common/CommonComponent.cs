using System.Security.Cryptography;
using EncryptDecryptPOC.Helper;

namespace EncryptDecryptPOC.Common
{
    public class CommonComponent
    {
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly byte[] receiverPublicKey;
        private readonly byte[] receiverPrivateKey;

        public CommonComponent(IConfiguration config)
        {
            _publicKey = config["EncryptionKeys:PublicKey"];
            _privateKey = config["EncryptionKeys:PrivateKey"];
            receiverPublicKey = Convert.FromBase64String(config["EccKeys:PublicKey"]);
            receiverPrivateKey = Convert.FromBase64String(config["EccKeys:PrivateKey"]);
        }
        //AES
        public string EncryptAES(string input) => AesEncryption.EncryptString(input);
        public string DecryptAES(string input) => AesEncryption.DecryptString(input);
        // RSA
        public string EncryptRSA(string input) => RsaEncryption.Encrypt(input, _publicKey);
        public string DecryptRSA(string input) => RsaEncryption.Decrypt(input, _privateKey);
        //Triple DES
        public string EncryptDES(string input) => TripleDes.EncryptString(input);
        public string DecryptDES(string input) => TripleDes.DecryptString(input);
        //ECC 
        public byte[] EncryptECC(string input)
        {
            return ECCEncryption.Encrypt(input, receiverPublicKey);
        }

        public string DecryptECC(byte[] encryptedData)
        {
            return ECCEncryption.Decrypt(encryptedData, receiverPrivateKey);
        }
        //Twofish
        public string EncryptTwofish(string msg)
        {
            return TwofishEncryption.Encrypt(msg);
        }

        public string DecryptTwofish(string cipher)
        {
            return TwofishEncryption.Decrypt(cipher);
        }
        //Blowfish 
        public string EncryptBlowfish(string input) => BlowfishEncryption.Encrypt(input);
        public string DecryptBlowfish(string input) => BlowfishEncryption.Decrypt(input);
    }
}
