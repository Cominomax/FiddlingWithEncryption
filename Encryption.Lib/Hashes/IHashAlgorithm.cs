using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption.Lib.Hashes
{
    public interface IHashAlgorithm
    {
        string SaltAndHash(string password, string salt);
        bool CheckPassword(IPasswordProtected pp, string password);
    }
}
