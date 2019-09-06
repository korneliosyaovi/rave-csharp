using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rave.Models.Charge
{
    public enum AuthTypes { PIN, VBVSECURECODE, AVS_VBVSECURECODE }

    public abstract class ParamsBase : IParams
    {
        protected ParamsBase(string PfbPubKey, string firstName, string lastName, string email)
        {
            PfbPubKey = PbfPubKey;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Currency = "NGN";
            Country = "NG";
        }

        protected static string GetAuthType(AuthTypes authType)
        {
            switch (authType)
            {
                case AuthTypes.PIN:
                    return "PIN";
                case AuthTypes.VBVSECURECODE:
                    return "VBVSECURECODE";
                case AuthTypes.AVS_VBVSECURECODE:
                    return "AVS_VBVSECURECODE";
                default:
                    return "PIN";
            }

        }

        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }
        

        [JsonProperty("currency")]
        public string Currency { get; set; }
        

        [JsonProperty("country")]
        public string Country { get; set; }
       

        [JsonProperty("amount")]
        public decimal Amount { get; set; }


        [JsonProperty("txRef")]
        public string TxRef { get; set; }


        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }


        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        
        [JsonProperty("lastname")]
        public string LastName { get; set; }
    }
}
