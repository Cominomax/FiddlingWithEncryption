using Encryption.Lib.Symmetrical.AES;
using System;

namespace Encryption.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a password:");
            var password = Console.ReadLine();

            var aesUtils = new AESCreator().Factory(password);

            var helloworldEncypted = aesUtils.Encrypt("Hello World!");
            Console.WriteLine(helloworldEncypted);

            Console.WriteLine($"That was {aesUtils.Decrypt(helloworldEncypted)} but encrypted!");
        }
    }
}
