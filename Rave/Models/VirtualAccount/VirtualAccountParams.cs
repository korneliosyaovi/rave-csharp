using System;
using System.Collections.Generic;
using System.Text;
using Rave.Models.Charge;
using Newtonsoft.Json;

namespace Rave.Models.VirtualAccount
{
    public class VirtualAccountParams : ParamsBase
    {
        public VirtualAccountParams(bool is_permanent, int frequency, int duration, string narration, string secretKey, string email, string txref) : base(secretKey, email, txref)
        {
            Is_permanent = is_permanent;
            Frequency = frequency;
            Duration = duration;
            Narration = narration;
            seckey = base.SecretKey;
        }

        [JsonProperty("is_permanent")]
        public bool Is_permanent { get; set; }

        [JsonProperty("frequency")]
        public int Frequency { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("seckey")]
        public string seckey { get; set; }

    }
}
