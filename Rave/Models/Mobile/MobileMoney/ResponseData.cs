using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Rave.api;

namespace Rave.Models.Mobile.MobileMoney
{
    public class ResponseData : Tokens.ChargeResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("validateInstruction")]
        public string ValidateInstruction { get; set; }


        [JsonProperty("validateInstructions")]

        public Validate ValidateInstructions { get; set; }

        public class Validate
        {
            [JsonProperty("valparams")]
            public string[] Valparams { get; set; }
            [JsonProperty("instruction")]
            public string Instruction { get; set; }
        }
    }
}
