using System;
using System.Collections.Generic;
using System.Text;
using Rave.Models.Charge;

namespace Rave.Models.Subaccount
{
    public class SubAccountParams : ParamsBase
    {
        public SubAccountParams(string secretKey, string accountNumber, string businessName, string businessEmail, string businessContact, string businessMobile) : base(secretKey)
        {

        }
    }
}
