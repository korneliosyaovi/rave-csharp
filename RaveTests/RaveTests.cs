using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rave;
using Rave.Models;
using Rave.Models.Account;
using Rave.Models.Card;
using Rave.Models.Charge;
using Rave.Models.MobileMoney;
using Rave.Models.Subaccount;

namespace RaveTests
{
    [TestClass]
    public class UnitTest1
    {

        private const string txRef = Environment.GetEnvironmentVariable("txRef");
        private const string successfulFwRef = Environment.GetEnvironmentVariable("successfulFwRef");
        private const string unCapturedFwRef = Environment.GetEnvironmentVariable("unCapturedFwRef");
        private static string tranxRef = Environment.GetEnvironmentVariable("tranxRef");
        private static string PbKey = Environment.GetEnvironmentVariable("PbKey");
        private static string ScKey = Environment.GetEnvironmentVariable("ScKey");


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
                // This usually means the user needs to validate the transaction with an OTP
                Payload.Otp = "12345";
                chargeResponse = accountc.Charge(Payload).Result;
            }
           // ValidateAccountCharge(chargeResponse.Data.FlwRef);

            //Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
            //Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
            //Trace.WriteLine(chargeResponse.Data.ValidateInstruction);
            Assert.IsNotNull(chargeResponse.Data);
            Assert.AreEqual("success", chargeResponse.Status);
        }
        }
}
