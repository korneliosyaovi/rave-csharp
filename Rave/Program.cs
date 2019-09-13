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
using Rave.Models.Subaccount;

namespace Rave
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var raveConfig = new RaveConfig("FLWPUBK_TEST-dc4f2335f2c3a75e9b723d81414fc131-X", "FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", false);
            var subAccount = new SubAccounts(raveConfig);
            var subaccParams = new SubAccountParams("FLWSECK_TEST-ea98d7c9a29c80779060fa435fb8efdb-X", "044", "0690000035", "CM", "info@cm.net", "Cornelius Micheals", "09087930450");

            var cha = subAccount.Create(subaccParams).Result;

            Console.WriteLine(cha);
            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);

        }

    }
}

