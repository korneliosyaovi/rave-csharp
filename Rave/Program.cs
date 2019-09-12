using System;
using Rave.Models;
using Rave.Models.Charge;
using Rave.Models.Account;
using Rave.Models.Card;
using Rave.Models.Validation;
using NUnit.Framework;
using System.Diagnostics;
using System.Collections.Generic;
using Rave.Models.MobileMoney;

namespace Rave
{
    class Program
    {
        //Test for direct debit
        private const string txRef = "549494";
        private const string successfulFwRef = "FLW00920971";
        private const string unCapturedFwRef = "FLW00920978";

//        static void Main(string[] args)
//        {
//            var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);
//            var preauthCard = new PreAuth(raveConfig);

//            var card = new Card("5377283645077450", "09", "21", "789");

//            var preauthResponse = preauthCard.Preauthorize(new PreAuthParams(raveConfig.PbfPubKey, raveConfig.SecretKey, "Olufumi", "Obafumiso", "olufemi@gmail.com", 120, "USD", card) { TxRef = txRef }).Result;


//            try
//            {
//                Assert.IsNotNull(preauthResponse.Data);
//                Assert.AreEqual(preauthResponse.Status, "success");
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//            }




//        }
//    }
//}
 static void Main(string[] args)         {             var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);             var chargeMobileMoney = new ChargeMobileMoney(raveConfig);             var mobileMoneyParams = new MobileMoneyParams("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", "Cornelius", "Ashley-Osuzoka", "korneliosyaovi@gmail.com", 105, "ZMW", "054709929220", "MTN", "mobilemoneyzambia", txRef);              Console.WriteLine(mobileMoneyParams);             var cha = chargeMobileMoney.Charge(mobileMoneyParams).Result;              Console.WriteLine(cha);             Assert.IsNotNull(cha.Data);             Assert.AreEqual("success", cha.Status);          }     } }  