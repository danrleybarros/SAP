using Gcsb.Connect.Messaging.Messages.File;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IFileWriteOnlyRepository
    {
        int Add(File file);

        int AddRange(IEnumerable<File> file);

        int UpdateStatus(Guid id, Messaging.Messages.File.Enum.Status status);

        int UpdateFileName(Guid id, string fileName);

        int Delete(Expression<Func<File, bool>> func);

        void UpdateParentId(Guid id, Guid parenteId);
    }
}
