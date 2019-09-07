﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Rave.api;
using Rave.config;
using Newtonsoft.Json;

namespace Rave.Models.Charge
{
    public class ChargeAccount : ChargeBase<RaveResponse<Account.ResponseData>, Account.ResponseData>
    {
        public ChargeAccount(RaveConfig conf) : base(conf) { }

        public override async Task<RaveResponse<Account.ResponseData>> Charge(IParams Params, bool isRecurring = false)
        {
            var encryptedKey = PayDataEncrypt.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PayDataEncrypt.EncryptData(encryptedKey, JsonConvert.SerializeObject(Params));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = Params.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.CardCharge) { Content = content };
            var result = await RaveApiRequest.Request(requestMessage); 

            return result;
        }
    }
}