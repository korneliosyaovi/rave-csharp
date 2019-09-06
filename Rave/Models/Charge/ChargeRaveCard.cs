using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rave.api;


namespace Rave.Models.Charge
{
    public class RaveCardCharge : ChargeBase<RaveResponse<ResponseData>, ResponseData>
    {
        public RaveCardCharge(raveConfig conf) : base(conf)
        {
        }

        //Cahrge error..check later
        public override async Task<RaveResponse<ResponseData>>Charge(IParams Params, bool isRecurring = false)

        {
            var encryptedKey = PayDataEncrypt.GetEncryptionKey(Config.SecretKey);
            var encryptedData = PayDataEncrypt.EncryptData(encryptedKey, JsonConvert.SerializeObject(Params));

            var content = new StringContent(JsonConvert.SerializeObject(new { PBFPubKey = Params.PbfPubKey, client = encryptedData, alg = "3DES-24" }), Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.CardCharge) { Content = content };
            var result = await RaveApiRequest.Request(requestMessage);

            // try to get the auth mode used. expected values are: "PIN","VBVSECURECODE", "AVS_VBVSECURECODE"
            return result;
        }

        public override Task<RaveResponse<ResponseData>> Charge(IParams Params, bool isRecurring = false, object Enpoints = null)
        {
            throw new System.NotImplementedException();
        }
    }
}