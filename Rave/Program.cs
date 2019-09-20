//using System;
//using Rave.Models;
//using Rave.Models.Charge;
//using Rave.Models.Account;
//using Rave.Models.Card;
//using Rave.Models.Validation;
//using NUnit.Framework;
//using System.Diagnostics;
//using System.Collections.Generic;
//using Rave.Models.MobileMoney;
//using Rave.Models.VirtualCard;
//using Rave.Models.Subaccount;

//namespace Rave
//{
//    class Program
//    {

//        //Test for direct debit
//        private const string txRef = "549494";
//        private const string successfulFwRef = "FLW00920971";
//        private const string unCapturedFwRef = "FLW00920978";
//        private static string tranxRef = "454839";
//        private static string PbKey = "FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X";
//        private static string ScKey = "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X";

//        static void Main(string[] args)
//        //  public override string ToString()
//        {
//            var raveConfig = new RaveConfig(PbKey, ScKey, false);
//            var accountc = new ChargeAccount(raveConfig);

//            var Payload = new AccountParams(PbKey, ScKey, "customer", "customer", "user@example.com", "0690000031", 1000, "044", "NGN", "MC-0292920");
//            var chargeResponse = accountc.Charge(Payload).Result;

//            if (chargeResponse.Data.Status == "success-pending-validation")
//            {
//                // This usually means the user needs to validate the transaction with an OTP
//                Payload.Otp = "12345";
//                chargeResponse = accountc.Charge(Payload).Result;
//            }
//            // ValidateAccountCharge(chargeResponse.Data.FlwRef);

//            //Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
//            //Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
//            //Trace.WriteLine(chargeResponse.Data.ValidateInstruction);
//            Assert.IsNotNull(chargeResponse.Data);
//            Assert.AreEqual("success", chargeResponse.Status);
//        }
//    }
//}


