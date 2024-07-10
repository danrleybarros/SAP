using Gcsb.Connect.SAP.Application.Repositories;
using Renci.SshNet;
using System;
using System.IO;

namespace Gcsb.Connect.SAP.Infrastructure.FtpFile.GF
{
    public class FtpFileUpload : IUploadFile
    {
        public bool Execute(string strFile, string strFileName, string strPath)
        {
            var host = Environment.GetEnvironmentVariable("SFTP_HOST");
            var port = int.Parse(Environment.GetEnvironmentVariable("SFTP_PORT"));
            var username = Environment.GetEnvironmentVariable("SFTP_USER");
            var password = Environment.GetEnvironmentVariable("SFTP_PASS");
            var pathNf = Environment.GetEnvironmentVariable("SFTP_PATH");

            var connection = new ConnectionInfo(host, port, username, new PasswordAuthenticationMethod(username, password));

            try
            {
                using(var sftp = new SftpClient(connection))
                {
                    sftp.Connect();

                    if (!sftp.IsConnected)
                        return false;

                    var path = Path.Combine(new string[] { strPath, strFileName });
                    var strPathNf = (!pathNf.EndsWith("/") ? pathNf + "/" : pathNf) + strFileName;

                    using (var file = new FileStream(Path.Combine(path), FileMode.Open))
                    {
                        sftp.BufferSize = 1024;
                        sftp.UploadFile(file, strPathNf, true);
                    }

                    sftp.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
