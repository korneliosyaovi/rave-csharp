using System;
using System.Collections.Generic;
using System.Text;

namespace Rave.Models.Charge
{
    class Card
    {
        public Card(string cardNum, string expirymonth, string expiryyear, string cvv)
        {
            CardNum = cardNum;
            Expirymonth = expirymonth;
            Expiryyear = expiryyear;
            Cvv = cvv;
        }

        public Card(string cardNum, string expirymonth, string expiryyear, string cvv, string pin)
        {
            CardNum = cardNum;
            Expirymonth = expirymonth;
            Expiryyear = expiryyear;
            Cvv = cvv;
            Pin = pin;
        }

        public string CardNum { get; set; }
        public string Expirymonth { get; set; }
        public string Expiryyear { get; set; }
        public string Cvv { get; set; }
        public string Pin { get; set; }
    }


}

