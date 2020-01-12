//using System; //using System.Collections.Generic; //using System.Text; //using System.Net.Http; //using System.Threading.Tasks; //using Rave.api; //using Rave.config; //using Newtonsoft.Json;
//using Rave.Models.VirtualAccount;

//namespace Rave.Models.Charge
//{
//    public class CreateVirtualAccounts : Base<RaveResponse<Card.ResponseData>, Card.ResponseData>
//    {
//        public CreateVirtualAccounts(RaveConfig conf) : base(conf) { }


//        public override async Task<RaveResponse<Card.ResponseData>> Create(VirtualAccountParams virtualaccountparams)
//        {

//            var content = new StringContent(JsonConvert.SerializeObject(new { virtualaccountparams }), Encoding.UTF8, "application/json");
//            var requestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoints.CreateaccountNumber) { Content = content };

//            var result = await RaveRequest.Request(requestMessage);
//            return result;
//        } 
//    }
//}
