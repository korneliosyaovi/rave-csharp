using System;
using System.Collections.Generic;
using System.Text;
using Rave.api;

namespace Rave.Models.Card
{
    public class ChargeRes<T> : RaveResponse<T> where T : ResponseData
    {
        public override T Data { get ;  set ; }
    }
}
