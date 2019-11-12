using Newtonsoft.Json;

namespace Rave.Models.Charge
{
    public class Token
    {
        [JsonProperty("embed_token")]
        public string EmbedToken { get; set; }

        [JsonProperty("user_token")]
        public string UserToken { get; set; }
    }
}
