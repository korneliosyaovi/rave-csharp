using System;
using System.Collections.Generic;
using System.Text;

namespace Rave
{
    class Config
    {
        public Config(bool isLive)
        {
            IsLive = isLive;
        }

        public Config(string publicKey, string secretKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
            SecretKey = secretKey;
        }

        public Config(string publicKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
        }

        public Config(string publicKey, string secretKey)
        {
            IsLive = false;
            PbfPubKey = publicKey;
            SecretKey = secretKey;
        }

        public bool IsLive { get; set; }
        public string PbfPubKey { get; set; }
        public string SecretKey { get; set; }


    }
}
