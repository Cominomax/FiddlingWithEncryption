using Encryption.Lib;
using Encryption.Lib.Symmetrical.AES;
using Entities.Lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Serialization;

namespace Encryption.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataPath = Path.Combine(Environment.CurrentDirectory, "data.gzip");
            if (!File.Exists(dataPath))
            {
                new PersonSeed().CreateData(dataPath);
            }
            var users = ReadData(dataPath);

            Console.WriteLine("Welcome to the Keep-A-Secret application!");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Choose a password:");
            var password = Console.ReadLine();

            var aesUtils = new AESCreator().Factory(password);

            var helloworldEncypted = aesUtils.Encrypt("Hello World!");
            Console.WriteLine(helloworldEncypted);

            Console.WriteLine($"That was {aesUtils.Decrypt(helloworldEncypted)} but encrypted!");
        }

        private static IList<IGotASecret> ReadData(string dataPath)
        {
            var gzipFile = File.Open(dataPath, FileMode.Open);
            using var decompressor = new GZipStream(gzipFile, CompressionMode.Decompress);
            XmlSerializer x = new XmlSerializer(typeof(List<Person>));
            return ((List<Person>)x.Deserialize(decompressor)).ToList<IGotASecret>();
        }
    }
}
