using System;

namespace Gcsb.Connect.SAP.Application.Repositories.Upload
{
    public interface IUploadWriteOnlyRepository
    {
        int Add(Domain.Upload.Upload upload);

        int Delete(Guid id);

        int Update(Domain.Upload.Upload upload);

    }
}
