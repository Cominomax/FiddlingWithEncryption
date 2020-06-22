using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption.Lib
{
    public interface IGotASecret : IPasswordProtected
    {
        public string Secret { get; set; }
    }
}
