using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecurityLibrary.AES
{
    public class AESUtils
    {
        // salt size must be at least 8 bytes, we will use 16 bytes
        private readonly byte[] _salt;
        // iterations must be at least 1000, we will use 2000
        private readonly int _iterations = 2000;

        public AESUtils(int iteration = 1000, string saltText = "7BANANAS")
        {
            _iterations = iteration;
            _salt = Encoding.Unicode.GetBytes(saltText);
        }
       
        public string Encrypt(string plainText, string password)
        {
            Aes aes = SetUpAESAlgorithm(password);
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            byte[] encryptedBytes = Transform(plainBytes, aes.CreateEncryptor);
            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string encryptedText, string password)
        {
            Aes aes = SetUpAESAlgorithm(password);
            byte[] encryptedBytes = Encoding.Unicode.GetBytes(encryptedText);
            byte[] plainBytes = Transform(encryptedBytes, aes.CreateDecryptor);
            return Convert.ToBase64String(encryptedBytes);
        }

        private static byte[] Transform(byte[] plainBytes, Func<ICryptoTransform> action)
        {
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, action(), CryptoStreamMode.Write);
            cs.Write(plainBytes, 0, plainBytes.Length);
            return ms.ToArray();
        }

        private Aes SetUpAESAlgorithm(string password)
        {
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, _salt, _iterations);
            aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key
            aes.IV = pbkdf2.GetBytes(16); // set a 128-bit IV
            return aes;
        }
    }
}
