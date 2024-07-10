using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IJsdnService
    {
        Task<List<Domain.JSDN.Service>> GetServices(string token);
        Task<List<Domain.JSDN.Service>> GetServices(string token, CancellationToken cancellationToken);
        string GetToken();
    }
}
