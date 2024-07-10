using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.MoveJsdnFile.Model
{
    public class ConnectionInformation : IConnectionInformation
    {
        [Required]
        public string Host { get; private set; }
        [Required]
        public int Port { get; private set; }
        [Required]
        public string User { get; private set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public string SSHKeyFile { get; private set; }

        public ConnectionInformation(string host, int port, string user, string password, string sshkeyfile)
        {
            this.Host = host;
            this.Port = port;
            this.User = user;
            this.Password = password;
            this.SSHKeyFile = sshkeyfile;
        }

        public ConnectionInformation()
        {
            Host = Environment.GetEnvironmentVariable("SFTP_HOST"); 
            Port = Convert.ToInt16(Environment.GetEnvironmentVariable("SFTP_PORT"));
            User = Environment.GetEnvironmentVariable("SFTP_USER");
            Password = Environment.GetEnvironmentVariable("SFTP_PASS");
            SSHKeyFile = Environment.GetEnvironmentVariable("SFTP_SSHKEY");
        }
    }
}
