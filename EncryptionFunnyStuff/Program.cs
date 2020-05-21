
using SecurityLibrary.AES;
using System;

namespace EncryptionFunnyStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a password:");
            var password = Console.ReadLine();

            var aesUtils = new AESUtils();
            Console.WriteLine(aesUtils.Encrypt("Hello World!", password));
        }
    }
}
