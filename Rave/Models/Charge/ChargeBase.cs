using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rave.api;
using Rave.data;
using Rave.encryption;

namespace Rave.Models.Charge
{
    public abstract class ChargeBase <T1, T2> : ICharge<T1, T2> where T1 : RaveResponse<T2>, new() where T2 : ChargeResponse
    {
        internal ChargeBase (raveConfig conf)
        {
            Config = conf;
            RaveApiRequest = new RaveRequest<T1, T2>(conf);
            PayDataEncrypt = new DataEncryption();
        }

        internal raveConfig Config { get; }
        internal IRaveRequest<T1, T2> RaveApiRequest { get; }

        public IDataEncryption PayDataEncrypt { get; }
        public abstract Task<T1> Charge(IParams Params, bool isRecurring = false);
    }
}
