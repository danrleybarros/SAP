using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Moq
{
    public class DownloadServiceMoq : IDownloadService
    {
        private readonly IProcessFile processFile;

        public DownloadServiceMoq(IProcessFile processFile)
        {
            this.processFile = processFile;
        }

        public List<string> DownloadFiles(string sourceRemotePath, string destLocalPath, string extension, string pathProcess, bool includeProcess)
        {
            Console.WriteLine($"Reading files nfes in /app/sap/ftpdata/{sourceRemotePath}");

            var files = new DirectoryInfo($"/app/sap/ftpdata/{sourceRemotePath}").GetFiles("*.csv");
            var newFiles = new List<string>();

            Console.WriteLine($"There are {files.Count()} in the server FileName: {string.Join(Environment.NewLine, files?.Select(s=> s?.Name ?? string.Empty).ToList())}");

            foreach (var file in files)
            {
                var destFilePath = Path.Combine(destLocalPath, file.Name);
                var processFilePath = Path.Combine(pathProcess, file.Name);

                if (!File.Exists(destFilePath))
                {
                    File.Copy(file.FullName, destFilePath, true);

                    if (includeProcess)
                        File.Copy(file.FullName, processFilePath, true);

                    newFiles.Add(file.FullName);
                }
            }

            return newFiles;
        }

        public List<string> DownloadFilesLocal(string extension, string sourceLocalPath, string destLocalPath, string pathProcess)
        {
            var notFilesDownload = GetFileList(extension, destLocalPath).Select(s => s.Name).ToList();
            var files = GetFileList(extension, sourceLocalPath).Where(w => !notFilesDownload.Contains(w.Name)).OrderBy(o => o.CreationTime).ToList();
            var filesName = new List<string>();
            var file = files.FirstOrDefault();

            var inProcess = new List<string>();

            if (file != null)
            {
                if (!processFile.ExistFile(pathProcess))
                {
                    File.Copy($"{file.FullName}", Path.Combine(pathProcess, file.Name), true);
                    File.Copy($"{file.FullName}", Path.Combine(destLocalPath, file.Name), true);

                    filesName.Add(file.Name);
                }
                else
                {
                    inProcess.Add(file.Name);
                }
            }

            AddLogs(filesName, inProcess, notFilesDownload);

            return filesName;
        }

        public List<FileInfo> GetFileList(string extension, string path)
        {
            var directory = new DirectoryInfo(path);
            return directory.GetFiles($"*{extension}*", SearchOption.AllDirectories).ToList();
        }

        public bool ProcessFile(string extension, string pathProcess)
            => !(GetFileList(extension, pathProcess).Select(s => s.Name).ToList().Count() > 0);

        public void AddLogs(List<string> toProcess, List<string> dontProcess, List<string> inProcess)
        {
            using (Serilog.Context.LogContext.PushProperty("ToProcess", toProcess))
            using (Serilog.Context.LogContext.PushProperty("InProcess", inProcess))
            using (Serilog.Context.LogContext.PushProperty("DontProcess", dontProcess))
            {
                Serilog.Log.Information("Processing files (MoveJsdnFiles)");
            }
        }
    }
}
