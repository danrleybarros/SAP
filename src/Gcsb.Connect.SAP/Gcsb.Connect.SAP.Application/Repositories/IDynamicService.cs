using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IDynamicService
    {
        List<KeyValuePair<int, string>> GetParticipantCode(List<int> bankNumbers);
    }
}
