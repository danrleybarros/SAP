using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface ILogReadOnlyRepository
    {
        List<Log> GetLogsByServiceAndDate(string service, DateTime dateIni, DateTime dateEnd);
        List<Log> GetLogsByFileId(Guid id);
        List<Log> GetLogsByDate(DateTime dateIni, DateTime dateEnd);
        List<Log> GetLogs(Expression<Func<Log, bool>> condition);
    }
}
