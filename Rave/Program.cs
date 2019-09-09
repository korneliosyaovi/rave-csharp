using System;
using Rave.Models.Charge;
using Rave.Models.Account;
using Rave.Models.Validation;
using NUnit.Framework;
using System.Diagnostics;
using System.Collections.Generic;

namespace Rave
{
    class Program
    {
        //Test for direct debit
        //private static string transRef = "Ref105";
        private static string sampleSuccessfulFwRef = "ACHG-1521196019857";
        public void ValidateAccountTest()
        {
            var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);
            var accountValidate = new ValidateAccountCharge(raveConfig);
            var val = accountValidate.ValidateCharge(new ValidateAccountChargeParams("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", sampleSuccessfulFwRef, "12345")).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            if (val.Status == "error")
            {
                var desiredResponses = new List<string> { "Transaction already complete", "TRANSACTION ALREADY VERIFIED" }; // These are also accepted values depending on whether the transaction has be verified before
                Assert.IsTrue(desiredResponses.Contains(val.Message));
            }
            else
            {
                Assert.IsNotNull(val.Data);
                Assert.AreEqual("success", val.Status);
                Assert.AreEqual("Charge Complete", val.Message);
            }

        }
        static void Main(string[] args)
        {
            var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);
            var accountCharge = new ChargeAccount(raveConfig);
            var accountParams = new AccountParams("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", "Cornelius", "Ashley", "user@example.com", "0690000031", 509, "044", "MC-7663-YU");
            var chargeRes = accountCharge.Charge(accountParams).Result;

            if (chargeRes.Data.Status == "success-pending-validation")
            {
                //If it asks for otp. Do request again
                accountParams.Otp = "12345";
                chargeRes = accountCharge.Charge(accountParams).Result;
            }

            Trace.WriteLine(chargeRes.Data.ValidateInstructions.Instruction);
            Trace.WriteLine(chargeRes.Data.ValidateInstructions.Valparams);
            Trace.WriteLine(chargeRes.Data.ValidateInstruction);
            Assert.IsNotNull(chargeRes.Data);
            Assert.AreEqual("success", chargeRes.Status);


        }
    }
}
