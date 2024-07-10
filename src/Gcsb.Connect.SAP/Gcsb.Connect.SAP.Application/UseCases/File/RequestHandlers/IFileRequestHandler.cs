using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public interface IFileRequestHandler
    {
        List<FileResult> Execute(FileRequest request, string linkLog, string linkReprocess);
    }
}
