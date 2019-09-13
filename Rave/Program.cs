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
using Rave.Models.VirtualCard;

namespace Rave
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);
            var virtCard = new VirtualCard(raveConfig);
            var virtCardParams = new VirtualCardParams("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "Cornelius Micheals", "USD", 340, "333 Fremont Street", "San Francisco", "California", "94105", "USA");

            Console.WriteLine(virtCardParams);
            var cha = virtCard.Create(virtCardParams).Result;

            Console.WriteLine(cha);
            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);

        }

    }
}

