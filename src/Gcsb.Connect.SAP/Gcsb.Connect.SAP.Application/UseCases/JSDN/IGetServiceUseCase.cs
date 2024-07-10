using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN
{
    public interface IGetServiceUseCase
    {
        Task<List<Domain.JSDN.Service>> Execute(GetServiceRequest request);
    }
}
