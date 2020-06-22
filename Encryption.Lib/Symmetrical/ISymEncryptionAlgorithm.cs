namespace Encryption.Lib.Symmetrical
{
    public interface ISymEncryptionAlgorithm
    {
        string Encrypt(string plainText);
        string Decrypt(string encryptedText);
    }
}
