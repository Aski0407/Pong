using Common;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test
{
    internal class testing
    {
        public static void GenerateKeys(out string publicKey, out string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                publicKey = Convert.ToBase64String(rsa.ExportCspBlob(false)); // Export the public key
                privateKey = Convert.ToBase64String(rsa.ExportCspBlob(true)); // Export the private key
            }
        }

        public static string Encrypt(string data, string publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportCspBlob(Convert.FromBase64String(publicKey)); // Import the public key
                var dataBytes = Encoding.UTF8.GetBytes(data);
                var encryptedBytes = rsa.Encrypt(dataBytes, true); // Encrypt the data using OAEP padding
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Decrypt(string encryptedData, string privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportCspBlob(Convert.FromBase64String(privateKey)); // Import the private key
                var encryptedBytes = Convert.FromBase64String(encryptedData);
                var decryptedBytes = rsa.Decrypt(encryptedBytes, true); // Decrypt the data using OAEP padding
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }


        public static void Main(String[] args)
        {
            GenerateKeys(out string publicKey, out string privateKey);


            Console.WriteLine("Public Key:");
            Console.WriteLine(publicKey);
            Console.WriteLine("Private Key:");
            Console.WriteLine(privateKey);

            // Original data to encrypt
            string originalData = "This is a secret message.";

            // Encrypt the data
            string encryptedData = Encrypt(originalData, publicKey);
            Console.WriteLine("Encrypted Data:");
            Console.WriteLine(encryptedData);

            // Decrypt the data
            string decryptedData = Decrypt(encryptedData, privateKey);
            Console.WriteLine("Decrypted Data:");
            Console.WriteLine(decryptedData);
        }
    }
}

