namespace Encryption.Lib.Symmetrical
{
    public interface ISymEncryptionAlgorithm
    {
        string Encrypt(string secret);
        string Decrypt(string secret);
    }
}
