using System;

namespace Entities.Lib
{
    public class Person
    {
        public string Login { get; set; }
        public string Salt { get; set; }
        public string HashedAndSaltedPassword { get; set; }
    }
}
