using System;
using System.Security.Cryptography;

namespace Encryption.Lib.Hashes
{
    public class EncryptionUtils
    {
        private static EncryptionUtils _instance;

        private EncryptionUtils()
        {

        }

        public static EncryptionUtils Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new EncryptionUtils();
                }
                return _instance; 
            }
        }

        public string GenerateRandomSalt()
        {
            // generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}
