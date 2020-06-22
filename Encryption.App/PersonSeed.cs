using Encryption.Lib.Hashes;
using Encryption.Lib.Hashes.Sha256;
using Encryption.Lib.Symmetrical.AES;
using Entities.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;

namespace Encryption.App
{
    class PersonSeed
    {
        internal void CreateData(string dataPath)
        {
            var person1 = new Person()
            {
                Login = "BruceWayne",
                Salt = EncryptionUtils.Instance.GenerateRandomSalt()
            };
            person1.Password = new Sha256Creator().Factory().SaltAndHash("Alfred", person1.Salt);
            person1.Secret = new AESCreator().Factory(person1.Password).Encrypt("I am Batman!");

            var person2 = new Person()
            {
                Login = "ClarkKent",
                Salt = EncryptionUtils.Instance.GenerateRandomSalt()
            };
            person2.Password = new Sha256Creator().Factory().SaltAndHash("Lois", person2.Salt);
            person2.Secret = new AESCreator().Factory(person1.Password).Encrypt("I am Superman!");

            var person3 = new Person()
            {
                Login = "MaximeCominotto",
                Salt = EncryptionUtils.Instance.GenerateRandomSalt()
            };
            person3.Password = new Sha256Creator().Factory().SaltAndHash("Azerty18!", person3.Salt);
            person3.Secret = new AESCreator().Factory(person3.Password).Encrypt("I am a good developper!");

            FileStream gzipFile = File.Create(dataPath);
            using GZipStream compressor = new GZipStream(gzipFile, CompressionMode.Compress); 
            XmlSerializer x = new XmlSerializer(typeof(List<Person>));
            x.Serialize(compressor, new List<Person>() { person1, person2, person3 });
        }
    }
}
