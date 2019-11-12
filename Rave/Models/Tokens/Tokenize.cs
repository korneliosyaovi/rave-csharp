using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rave.Models.Charge;
using Rave.api;

namespace Rave.Models.Tokens
{
    class Tokenize : Base<RaveResponse<ResponseDataTokens>, ResponseDataTokens>
    {
        public Tokenize(RaveConfig config) : base(config)
        {
        }

        public override async Task<RaveResponse<ResponseDataTokens>> Charge(IParams Params, bool isRecurring = false)
        {
            var encryptedKey = PayDataEncrypt.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PayDataEncrypt.EncryptData(encryptedKey, JsonConvert.SerializeObject(Params));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = Params.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.TokenizeCharge) { Content = content };
            var result = await RaveRequest.Request(requestMessage);

            return result;
        }
    }
}
