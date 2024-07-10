using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface ILogWriteOnlyRepository
    {
        int Add(Log logError);
        void Add(List<Log> logs);
        int DeleteLogs(Expression<Func<Log, bool>> condition);
        int DeleteLogsDetails(Expression<Func<LogDetail, bool>> condition);
    }
}
