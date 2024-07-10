using Gcsb.Connect.SAP.Application.UseCases.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IFileReadOnlyRepository
    {
        int GetSequentialFile(TypeRegister type);
        int GetTodaySequentialFile(TypeRegister type);
        int GetSequentialFileByCycle(TypeRegister type);
        int GetSequentialFileByType(TypeRegister type);
        Connect.Messaging.Messages.File.File GetById(Guid Id);
        bool ProcessedFile(string fileName, Status success);
        List<Connect.Messaging.Messages.File.File> GetFiles(FileRequest file);
        List<Connect.Messaging.Messages.File.File> GetFiles(TypeRegister type, Status status);
        Connect.Messaging.Messages.File.File GetFile(string fileName, Status success);
        Messaging.Messages.File.File GetFile(Expression<Func<Messaging.Messages.File.File, bool>> condition);

        List<Messaging.Messages.File.File> GetFiles(Expression<Func<Messaging.Messages.File.File, bool>> condition);
    }
}
