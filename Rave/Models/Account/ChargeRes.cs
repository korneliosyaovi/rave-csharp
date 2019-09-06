using System;
using System.Collections.Generic;
using System.Text;
using Rave.api;
using Rave.Models.Account;

namespace Rave.Models.Account
{
    public class ChargeRes<T> : RaveResponse<T> where T : ResponseData
    {
    }
}
