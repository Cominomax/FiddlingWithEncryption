using System.Security.Cryptography;

namespace Encryption.Lib.Hashes.Sha256
{
    public class Sha256Creator : HashCreator
    {
        public override IHashAlgorithm Factory()
        {
            return new Sha256Utils(SHA256.Create());
        }
    }
}
