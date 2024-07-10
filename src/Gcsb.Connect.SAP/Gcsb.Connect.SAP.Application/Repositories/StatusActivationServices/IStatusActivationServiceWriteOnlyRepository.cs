using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.Deferral.StatusActivationService;

namespace Gcsb.Connect.SAP.Application.Repositories.StatusActivationServices
{
    public interface IStatusActivationServiceWriteOnlyRepository
    {
        int Add(IEnumerable<StatusActivationService> statusActivationServices);
        int Add(StatusActivationService statusActivationServices);
    }
}
