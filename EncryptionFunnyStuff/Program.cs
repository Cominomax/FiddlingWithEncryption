
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
            var aesUtils = new AESUtils(password);

            var helloworldEncypted = aesUtils.Encrypt("Hello World!");
            Console.WriteLine(helloworldEncypted);

            Console.WriteLine($"That was {aesUtils.Decrypt(helloworldEncypted)} but encrypted! Hahaha!");
        }
    }
}
