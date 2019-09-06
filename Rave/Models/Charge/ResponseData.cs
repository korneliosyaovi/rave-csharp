using Newtonsoft.Json;
using Rave.data;
using System;
namespace Rave.Models.Charge
{
    
        public class ResponseData : ChargeResponse
    {
            /// <summary>
            /// Represnts the mode of authentication for given transaction
            /// values could be "PIN"
            /// </summary>
            [JsonProperty("suggested_auth")]
            public string SuggestedAuth { get; set; }
            [JsonProperty("authModelUsed")]
            public string AuthModelUsed { get; set; }

        }


        
    }
