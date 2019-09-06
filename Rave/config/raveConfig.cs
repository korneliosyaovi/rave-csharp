using System;
using System.Collections.Generic;
using System.Text;

namespace Rave
{
    class raveConfig
    {
        public raveConfig(bool isLive)
        {
            IsLive = isLive;
        }

        public raveConfig(string publicKey, string secretKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
            SecretKey = secretKey;
        }

        public raveConfig(string publicKey, bool isLive)
        {
            IsLive = isLive;
            PbfPubKey = publicKey;
        }

        public raveConfig(string publicKey, string secretKey)
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
