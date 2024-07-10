using System.Collections.Generic;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service
{
    public interface IDownloadService
    {
        List<string> DownloadFiles(string sourceRemotePath, string destLocalPath, string extension, string pathProcess, bool includeProcess);
        List<string> DownloadFilesLocal(string extension, string sourceRemotePath, string destLocalPath, string pathProcess);
    }
}