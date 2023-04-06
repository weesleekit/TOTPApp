using System.Security.Cryptography;
using System.Text;

namespace TOTPApp.Classes
{
    internal class Encrypter
    {
        internal static string Encrypt(string plainText, string password)
        {
            byte[] ivBytes = new byte[16]; // The initialization vector (IV) is a random value used to ensure that the same plaintext does not produce the same ciphertext

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = GetKey(password);
            aesAlg.IV = ivBytes;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        internal static string Decrypt(string cipherText, string password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] keyBytes = GetKey(password);
            byte[] ivBytes = new byte[16];

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = keyBytes;
            aesAlg.IV = ivBytes;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(cipherBytes);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }

        private static byte[] GetKey(string password)
        {
            // The salt value, which should be unique for each password
            byte[] salt = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };

            // The number of iterations for the PBKDF2 algorithm
            int iterations = 10000;

            // The length of the AES key in bits
            int keySize = 256;

            // The hash algorithm to use
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

            // Convert the password and salt to byte arrays
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = salt;

            // Create a new instance of the Rfc2898DeriveBytes class to derive the key
            using Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(passwordBytes, saltBytes, iterations, hashAlgorithm);

            // Generate the key using the PBKDF2 algorithm
            byte[] key = keyGenerator.GetBytes(keySize / 8);

            return key;
        }
    }
}
