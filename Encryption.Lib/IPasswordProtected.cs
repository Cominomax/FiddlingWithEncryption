namespace Encryption.Lib
{
    public interface IPasswordProtected
    {
        public string Login { get; set; }
        public string Salt { get; }
        public string Password { get; }
    }
}