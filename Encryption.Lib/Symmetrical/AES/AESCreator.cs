using System.Security.Cryptography;
using System.Text;

namespace Encryption.Lib.Symmetrical.AES
{
    public class AESCreator : SymEncryptionCreator
    {
        public override ISymEncryptionAlgorithm Factory(string password, int iteration = 1000, string saltText = "7BANANAS")
        {
            Aes aes = SetUpeAESAlgorithm(password, iteration, saltText);
            return new AESUtils(aes);
        }

        private static Aes SetUpeAESAlgorithm(string password, int iteration, string saltText)
        {
            var aes = Aes.Create();
            var salt = Encoding.Unicode.GetBytes(saltText);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iteration);
            aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key
            aes.IV = pbkdf2.GetBytes(16); // set a 128-bit IV
            aes.Padding = PaddingMode.PKCS7;
            return aes;
        }
    }
}
