using System;
using System.Collections.Generic;
using System.Text;

namespace Rave.Models.Charge
{
    class CardChargeResponse
    {
        public class CardCharge<T> : api.RaveResponse<T> where T : ResponseData
        {
            public override T Data { get; set; }
        }
    }
}
