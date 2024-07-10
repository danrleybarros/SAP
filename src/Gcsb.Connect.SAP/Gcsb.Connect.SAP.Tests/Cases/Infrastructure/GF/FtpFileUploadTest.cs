using Gcsb.Connect.SAP.Infrastructure.FtpFile.GF;
using System;
using Xunit;

namespace Gcsb.Connect.SAP.Tests.Cases.Infrastructure.GF
{
    public class FtpFileUploadTest
    {
        [Fact]
        public void ShouldSendFile()
        {
            Environment.SetEnvironmentVariable("SFTP_HOST", "localhost");
            Environment.SetEnvironmentVariable("SFTP_PORT", "2224");
            Environment.SetEnvironmentVariable("SFTP_USER", "foo");
            Environment.SetEnvironmentVariable("SFTP_PASS", "pass");
            Environment.SetEnvironmentVariable("SFTP_PATH", "/dados/vivo77434/remessa");

            var upload = new FtpFileUpload();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //upload.Execute(string.Empty, "teste.TXT", path);
            //TODO: Criar teste unitário
        }
    }
}
