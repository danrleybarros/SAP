using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public interface IFileReprocessUseCase
    {
         int Execute(FileReprocessRequest request);
    }
}
