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

        static Cryptography() //constructor. creates new provider and keys
        {
            rsaDecrypt = new RSACryptoServiceProvider(2048);
            PublicKey = Convert.ToBase64String(rsaDecrypt.ExportCspBlob(false)); // export the public key
            privateKey = Convert.ToBase64String(rsaDecrypt.ExportCspBlob(true)); // export the private key
            rsaDecrypt.ImportCspBlob(Convert.FromBase64String(privateKey)); // import the private key for the decryption provider
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
            return Cryptography.Encrypt(data, rsaEncrypt);// encrypt the data using OAEP padding (available only on windows XP or later)
        }

        public static byte[] Encrypt(string data, RSACryptoServiceProvider provider) 
        // an override of the encrypt method. receives both the data and the provider with which to encrypt (used in the server where there are multiple encryption keys)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            return provider.Encrypt(dataBytes, true); 
        }

        public static string Decrypt(byte[] encryptedData)
        {
            var decryptedBytes = rsaDecrypt.Decrypt(encryptedData, true);// decrypt the data using OAEP padding (available only on windows XP or later)
            return Encoding.UTF8.GetString(decryptedBytes);
        }

    }
}
