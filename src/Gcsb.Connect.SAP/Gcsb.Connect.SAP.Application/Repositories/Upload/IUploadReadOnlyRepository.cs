using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Repositories.Upload
{
    public interface IUploadReadOnlyRepository
    {
        Domain.Upload.Upload GetById(Guid Id);

        List<Domain.Upload.Upload> GetAll();
    }
}
