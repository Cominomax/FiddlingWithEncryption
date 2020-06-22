using Encryption.Lib;

namespace Entities.Lib
{
    public class Person : IGotASecret
    {
        public string Login { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }
    }
}
