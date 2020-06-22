using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Encryption.Lib.Hashes.Sha256
{
    class Sha256Utils : IHashAlgorithm
    {
        private readonly SHA256 _sha;
        internal Sha256Utils(SHA256 sha)
        {
            _sha = sha;
        }

        public string SaltAndHash(string password, string salt)
        {
            var saltedPassword = password + salt;
            return Convert.ToBase64String(_sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        public bool CheckPassword(IPasswordProtected pp, string password)
        {
            // re-generate the salted and hashed password
            var saltedhashedPassword = SaltAndHash(password, pp.Salt);
            return (saltedhashedPassword == pp.Password);
        }
    }
}
