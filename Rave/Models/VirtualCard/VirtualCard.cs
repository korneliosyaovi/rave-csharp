using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Rave.api;
using Rave.config;
using Newtonsoft.Json;

namespace Rave.Models.VirtualCard
{
    public class VirtualCard
    {
        public VirtualCard(RaveConfig config)
        {
            Config = config;
            PayDataEncrypt = new DataEncryption();
            RaveApiRequest = new RaveRequest<RaveResponse<ResponseData>, ResponseData>(config);
        }

        private RaveConfig Config { get; }
        private IDataEncryption PayDataEncrypt { get; }
        private IRaveRequest<RaveResponse<ResponseData>, ResponseData> RaveApiRequest { get; }

        public async Task<RaveResponse<ResponseData>> Create(VirtualCardParams virtualCardParams)
        {
            var encryptedKey = PayDataEncrypt.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PayDataEncrypt.EncryptData(encryptedKey, JsonConvert.SerializeObject(virtualCardParams));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = virtualCardParams.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.VirtualCardCreate) { Content = content };

            var result =  await RaveApiRequest.Request(requestMessage);
            return result;
        }
    }
}
