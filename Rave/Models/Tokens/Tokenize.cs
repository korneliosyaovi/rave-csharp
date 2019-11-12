using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Rave.api;
using Rave.Models.Tokens;
using Newtonsoft.Json;

namespace Rave.Models.Tokens
{
    class Tokenize : Base<RaveResponse<Tokens.ResponseData>, Tokens.ResponseData>
    {
        public Tokenize(RaveConfig conf) : base(conf) { }

        public override async Task<RaveResponse<Tokens.ResponseData>> Charge(IParams Params, bool isRecurring = false)
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