using Gcsb.Connect.SAP.MoveJsdnFile.Model;
using Gcsb.Connect.SAP.MoveJsdnFile.UseCases.ExecuteJob;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service
{
    public class DownloadService : IDownloadService
    {
        private readonly IConnectionInformation connectionInfo;
        private readonly IProcessFile processFile;

        public DownloadService(IConnectionInformation connection, IProcessFile processFile)
        {
            this.connectionInfo = connection;
            this.processFile = processFile;
        }

        public DownloadService() { }

        public List<string> DownloadFiles(string sourceRemotePath, string destLocalPath, string extension, string pathProcess, bool includeProcess)
        {
            var lstFileNames = new List<string>();

            using (var client = Connect())
            {
                lstFileNames.AddRange(DownloadDirectory(client, sourceRemotePath, destLocalPath, extension, pathProcess, includeProcess));
            }

            return lstFileNames;
        }

        public SftpClient Connect()
        {
            var client = new SftpClient(this.connectionInfo.Host, this.connectionInfo.Port, this.connectionInfo.User, this.connectionInfo.Password);
            client.Connect();
            return client;
        }

        public List<string> DownloadDirectory(SftpClient sftpClient, string sourceRemotePath, string destLocalPath, string extension, string pathProcess, bool includeProcess)
        {
            Directory.CreateDirectory(destLocalPath);

            var files = sftpClient.ListDirectory(sourceRemotePath).ToList();
            var lstFileNames = new List<string>();

            Console.WriteLine($"Found: {files.Count}");

            files.ForEach(file =>
            {
                if ((file.Name != ".") && (file.Name != "..") && Path.GetExtension(file.FullName).Equals(extension))
                {
                    var sourceFilePath = sourceRemotePath + "/" + file.Name;
                    var destFilePath = Path.Combine(destLocalPath, file.Name);

                    if (file.IsDirectory)
                        DownloadDirectory(sftpClient, sourceFilePath, destFilePath, extension, pathProcess, includeProcess);
                    else
                    {
                        if (!File.Exists(destFilePath) && !processFile.ExistFile(pathProcess))
                        {
                            lstFileNames.Add(destFilePath);

                            using (Stream fileStream = File.Create(destFilePath))
                            {
                                sftpClient.DownloadFile(sourceFilePath, fileStream);
                            }

                            if (includeProcess)
                                File.Copy($"{destFilePath}", Path.Combine(pathProcess, file.Name), true);
                        }
                    }
                }
            });

            return lstFileNames;
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
