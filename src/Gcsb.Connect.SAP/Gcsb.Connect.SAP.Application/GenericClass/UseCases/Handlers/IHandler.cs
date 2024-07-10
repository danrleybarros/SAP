using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers
{
    public interface IHandler<T>
    {
        void SetSucessor(IHandler<T> sucessor);
        void ProcessRequest(T request);
    }
}
