using Gcsb.Connect.SAP.MoveJsdnFile.Model;
using System.IO;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class ConnectionInformationBuilder
    {
        public string Host;
        public int Port;
        public string User;
        public string Password;
        public string SSHKeyFile;

        public static ConnectionInformationBuilder New()
        {
            var dir = Path.GetDirectoryName(typeof(ConnectionInformationBuilder).Assembly.Location);
            var pathShortSample = Path.Combine(dir, @"SFTPMock\mykeys\ssh_host_rsa_key.key");
            return new ConnectionInformationBuilder
            {
                Host = "localhost",
                Port = 2222,
                User = "foo",
                Password = "pass",
                SSHKeyFile = pathShortSample
            };
        }

        public ConnectionInformationBuilder WithHost(string host)
        {
            Host = host;
            return this;
        }

        public ConnectionInformationBuilder WithPort(int port)
        {
            Port = port;
            return this;
        }

        public ConnectionInformationBuilder WithUser(string user)
        {
            User = user;
            return this;
        }

        public ConnectionInformationBuilder WithPassword(string password)
        {
            Password = password;
            return this;
        }

        public ConnectionInformationBuilder WithSSHKeyFile(string sshkeyfile)
        {
            SSHKeyFile = sshkeyfile;
            return this;
        }

        public ConnectionInformation Builder()
        {
            return new ConnectionInformation(Host, Port, User, Password, SSHKeyFile);
        }
    }
}
