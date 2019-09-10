using System;
using Rave.Models.Charge;
using Rave.Models.Account;
using Rave.Models.Card;
using Rave.Models.Validation;
using NUnit.Framework;
using System.Diagnostics;
using System.Collections.Generic;

namespace Rave
{
    class Program
    {
        //Test for direct debit
        private static string tranxRef = "454839";

        public static void ValidateCardCharge(string txRef)
        {
            var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);
            var cardValidation = new ValidateCardCharge(raveConfig);
            var val = cardValidation.ValidateCharge(new ValidateCardParams("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", txRef, "12345")).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            Assert.IsNotNull(val.Data);
            //Trace.WriteLine($"Message: {val.Data.TX.CardChargeToken.EmbedToken}");
            Assert.AreEqual("success", val.Status);
            //Assert.IsFalse(string.IsNullOrEmpty(val.Data.TX.CardChargeToken.EmbedToken));
            //Assert.IsFalse(string.IsNullOrEmpty(val.Data.TX.CardChargeToken.UserToken));

        }
        static void Main(string[] args)
        {
            var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);
            var cardCharge = new ChargeCard(raveConfig);
            var cardParams = new CardParams("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", "Cornelius", "Ashley-Osuzoka", "korneliosyaovi@gmail.com", 105, "USD")
            {
                CardNo = "5438898014560229",
                Cvv = "789",
                Expirymonth = "09",
                Expiryyear = "19",
                TxRef = tranxRef
            };

            var cha = cardCharge.Charge(cardParams).Result;

            if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";
                cha = cardCharge.Charge(cardParams).Result;
            }

            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);
            ValidateCardCharge(cha.Data.FlwRef);



        }
    }
}
