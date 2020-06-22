namespace Encryption.Lib.Symmetrical
{
    public abstract class SymEncryptionCreator
    {
        public abstract ISymEncryptionAlgorithm Factory(string password, int iteration = 1000, string saltText = "7BANANAS");
    }
}
