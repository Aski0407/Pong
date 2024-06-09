using System;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class Cryptography
    {
        private static RSACryptoServiceProvider rsaDecrypt; //rsa used for decryption and getting own set of keys
        private static RSACryptoServiceProvider rsaEncrypt; //rsa used for encryption and importing other party's public key
        public static string PublicKey { get; private set; }
        private static readonly string privateKey;

        static Cryptography()
        {
            rsaDecrypt = new RSACryptoServiceProvider(2048);
            PublicKey = Convert.ToBase64String(rsaDecrypt.ExportCspBlob(false)); // Export the public key
            privateKey = Convert.ToBase64String(rsaDecrypt.ExportCspBlob(true)); // Export the private key
            rsaDecrypt.ImportCspBlob(Convert.FromBase64String(privateKey)); // Import the private key
        }

        public static RSACryptoServiceProvider CreateProvider(string publicKey)//the public key of the other party
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048);
            provider.ImportCspBlob(Convert.FromBase64String(publicKey)); // Import the public key
            return provider;
        }

        public static void InitializeEncryption(string publicKey)//the public key of the other party
        {
            rsaEncrypt = CreateProvider(publicKey);
        }

        public static byte[] Encrypt(string data)
        {
            return Cryptography.Encrypt(data, rsaEncrypt);
        }

        public static byte[] Encrypt(string data, RSACryptoServiceProvider provider)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var encryptedBytes = provider.Encrypt(dataBytes, true); // Encrypt the data using OAEP padding
            return encryptedBytes;
        }

        public static string Decrypt(byte[] encryptedData)
        {
            var decryptedBytes = rsaDecrypt.Decrypt(encryptedData, true); // Decrypt the data using OAEP padding
            return Encoding.UTF8.GetString(decryptedBytes);
        }

    }
}
