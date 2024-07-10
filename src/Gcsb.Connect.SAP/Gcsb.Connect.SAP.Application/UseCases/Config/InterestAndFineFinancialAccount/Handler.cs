using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount
{
    public abstract class Handler<T> where T : class
    {
        protected Handler<T> Sucessor;

        public Handler<T> SetSucessor(Handler<T> sucessor) 
            => Sucessor = sucessor;

        public abstract void ProcessRequest(T request);
    }
}
