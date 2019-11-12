using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Rave.Models.Tokens;

namespace Rave.Models.VirtualCard
{
    public class VirtualCardParams : ParamsBase
    {
        public VirtualCardParams(string secretKey, string billingName, string currency, decimal amount, string billingAddress, string billingCity, string billingState, string billingPostalCode, string billingCountry ) : base(secretKey, currency)
        {
            BillingName = billingName;
            BillingAddress = billingAddress;
            BillingCity = billingCity;
            BillingState = billingState;
            BillingPostalCode = billingPostalCode;
            BillingCountry = billingCountry;
        }

        public VirtualCardParams(string secretKey, string page) : base(secretKey)
        {
            Pages = page;
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("page")]
        public string Pages { get; set;  }

        [JsonProperty("billing_name")]
        public string BillingName { get; set; }

        [JsonProperty("billing_address")]
        public string BillingAddress { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_state")]
        public string BillingState { get; set; }

        [JsonProperty("billing_postal_code")]
        public string BillingPostalCode { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }
    }
}
