using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rave;
using Rave.Models;
using Rave.Models.Account;
using Rave.Models.Card;
using Rave.Models.Tokens;
using Rave.Models.MobileMoney;
using Rave.Models.Subaccount;

namespace RaveTests
{
    [TestClass]
    public class UnitTest1
    {

        string txRef = Environment.GetEnvironmentVariable("txRef");
        string successfulFwRef = Environment.GetEnvironmentVariable("successfulFwRef");
        string unCapturedFwRef = Environment.GetEnvironmentVariable("unCapturedFwRef");
        string tranxRef = Environment.GetEnvironmentVariable("tranxRef");
        string PbKey = Environment.GetEnvironmentVariable("PbKey");
        string ScKey = Environment.GetEnvironmentVariable("ScKey");


        [TestMethod]
        public void preauthTest()
        {

            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var preauthCard = new PreAuth(raveConfig);

            var card = new Card("5377283645077450", "09", "21", "789");

            var preauthResponse = preauthCard.Preauthorize(new PreAuthParams(raveConfig.PbfPubKey, raveConfig.SecretKey, "Olufumi", "Obafumiso", "olufemi@gmail.com", 120, "USD", card) { TxRef = txRef }).Result;


            try
            {
                Assert.IsNotNull(preauthResponse.Data);
                Assert.AreEqual(preauthResponse.Status, "success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        [TestMethod]
        public void mobileMoneyTest()
        {

            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var mobilemoney = new ChargeMobileMoney(raveConfig);

            var Payload = new MobileMoneyParams(PbKey, ScKey, "Anonymous", "customer", "user@example.com", 1055, "GHS", "054709929220", "MTN", "GH", "mobilemoneygh", tranxRef);
            var cha = mobilemoney.Charge(Payload).Result;

            try
            {
                Assert.IsNotNull(cha.Data);
                Console.WriteLine(cha.Data);
                Assert.AreEqual("success", cha.Status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        [TestMethod]
        public void accountTest()
        {
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var accountc = new ChargeAccount(raveConfig);

            var Payload = new AccountParams(PbKey, ScKey, "customer", "customer", "user@example.com", "0690000031", 1000, "044", "NGN","MC-0292920");
            var chargeResponse = accountc.Charge(Payload).Result;

            if (chargeResponse.Data.Status == "success-pending-validation")
            {

                Payload.Otp = "12345";
                chargeResponse = accountc.Charge(Payload).Result;
            }
           // ValidateAccountCharge(chargeResponse.Data.FlwRef);

            Assert.IsNotNull(chargeResponse.Data);
            Assert.AreEqual("success", chargeResponse.Status);
        }


        [TestMethod]
        public void CreateSubAccountTest()
        {
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var subacc = new CreateSubAccount(raveConfig);

            var payload = new SubAccountParams(ScKey, "0690000031", "0690000031", "TEST BUSINESS", "user@example.com", "0900000000", "0900000000");
            var chargeResponse = subacc.Charge(payload).Result;

           // Assert.IsNotNull(chargeResponse.Data);
            Assert.AreEqual("error", chargeResponse.Status);
        }

        }
}
