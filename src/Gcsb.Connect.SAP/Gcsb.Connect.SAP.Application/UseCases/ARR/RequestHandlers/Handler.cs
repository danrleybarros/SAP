using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers
{
    public abstract class Handler<T> : IHandler<T>
    {
        protected IHandler<T> sucessor;

        public void SetSucessor(IHandler<T> sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(IARRRequest<T> request);
    }
}
