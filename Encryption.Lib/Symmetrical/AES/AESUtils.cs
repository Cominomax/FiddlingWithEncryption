using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Encryption.Lib.Symmetrical.AES
{
    public class AESUtils : ISymEncryptionAlgorithm
    {
        private readonly Aes _aes;

        internal AESUtils(Aes aes)
        {
            _aes = aes;
        }
       
        public string Encrypt(string secret)
        {
            byte[] plainBytes = Encoding.Unicode.GetBytes(secret);
            byte[] encryptedBytes = Transform(plainBytes, _aes.CreateEncryptor);
            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string secret)
        {
            byte[] encryptedBytes = Convert.FromBase64String(secret);
            byte[] plainBytes = Transform(encryptedBytes, _aes.CreateDecryptor);
            return Encoding.Unicode.GetString(plainBytes);
        }

        private static byte[] Transform(byte[] bytes, Func<ICryptoTransform> action)
        {
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, action(), CryptoStreamMode.Write))
            {
                cs.Write(bytes, 0, bytes.Length);
            }
            return ms.ToArray();
        }
    }
}
