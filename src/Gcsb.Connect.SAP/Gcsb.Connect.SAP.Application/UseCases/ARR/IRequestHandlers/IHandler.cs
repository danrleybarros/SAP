using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers
{
    public interface IHandler<T>
    {
        void SetSucessor(IHandler<T> sucessor);
        void ProcessRequest(IARRRequest<T> request);
    }
}
