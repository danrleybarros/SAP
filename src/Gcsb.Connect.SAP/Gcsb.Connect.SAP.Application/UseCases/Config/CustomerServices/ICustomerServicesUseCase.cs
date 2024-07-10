using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices
{
    public interface ICustomerServicesUseCase
    {
        void Execute(CustomerServicesRequest request);
    }
}
