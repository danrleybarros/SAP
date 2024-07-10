using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.File.Upload
{
    public interface IUploadStatusUseCase
    {
        void Execute(UploadStatusRequest request);
    }
}
