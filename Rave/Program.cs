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
            var raveConfig = new RaveConfig("FLWPUBK-54d9d49207af4381bb60d58d15e9a407-X", "FLWSECK-48d1d4efb35538a59372377bd3780957-X", false);
            var virtCard = new VirtualCard(raveConfig);
            var virtCardParams = new VirtualCardParams("FLWSECK-48d1d4efb35538a59372377bd3780957-X", "Cornelius Micheals", "USD", 340, "333 Fremont Street", "San Francisco", "California", "94105", "USA");

            Console.WriteLine(virtCardParams);
            var cha = virtCard.Create(virtCardParams).Result;

            Console.WriteLine(cha);
            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);

        }

    }
}

