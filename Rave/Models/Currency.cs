using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using Rave.api;

namespace Rave.Models
{
    public enum CurrencyType { Cedi, Dollar, Euro, KenyanShilling, Naira, Pounds };

    public class Currency
    {
        public Currency(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public Currency(string name, CurrencyType currencyType)
        {
            Name = name;
            Code = Util.GetCurrencyStr(currencyType);
        }

        public string Name { get; set; }
        public string Code { get; set; }
    }

    internal static class Util
    {
        internal static string GetCurrencyStr(CurrencyType currency)
        {
            switch (currency)
            {
                case CurrencyType.Cedi:
                    return "GHS";
                case CurrencyType.Dollar:
                    return "USD";
                case CurrencyType.Euro:
                    return "EUR";
                case CurrencyType.KenyanShilling:
                    return "KES";
                case CurrencyType.Naira:
                    return "NGN";
                case CurrencyType.Pounds:
                    return "GBP";
                default:
                    return "NGN";
            }
        }
    }

    public class ExchangeRateRes : Charge.ChargeResponse
    {
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("origincurrency")]
        public string OriginCurrency { get; set; }

        [JsonProperty("destinationcurrency")]
        public string DestinationCurrency { get; set; }

        [JsonProperty("lastupdated")]
        public DateTime Lastupdated { get; set; }

        [JsonProperty("converted_amount")]
        public decimal ConvertedAmount { get; set; }

        [JsonProperty("original_amount")]
        public decimal OriginalAmount { get; set; }

    }

}
