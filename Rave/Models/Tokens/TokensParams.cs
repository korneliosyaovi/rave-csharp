using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Rave.Models.Charge
{
    public class TokensParams : IParams
    {
        public TokensParams(string secretKey, string firstName, string lastName, string email, string txRef, decimal amount)
        {
            SecretKey = secretKey;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            TxRef = txRef;
            Amount = amount;
            Country = "NG";
            Currency = "NGN";
        }
        /// <summary>
        /// This is a unique Secret key generated for each account created on Rave. It can be gotten in the API section of settings. It starts with a prefix FLWSECK and ends with suffix X.
        /// </summary>
        [JsonProperty("SECKEY")]
        public string SecretKey { get; set; }

        /// <summary>
        /// This is the embed_token property returned from the call to charge a card e.g."chargeToken":{"user_token":"0209","embed_token":"flw-t0-9f3aa69a806f6440fbb78cc9e8b2f135-k3n"}
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// This is a unique Public key generated for each account created on Rave. It can be gotten in the API section of settings. It starts with a prefix FLWPUBK and ends with suffix X.
        /// </summary>
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

        [JsonProperty("IP")]
        public string Ip { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }
    }
}
