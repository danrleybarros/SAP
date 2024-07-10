namespace Gcsb.Connect.SAP.MoveJsdnFile.Model
{
    public interface IConnectionInformation
    {
        string Host { get; }
        int Port { get; }
        string User { get; }
        string Password { get; }
        string SSHKeyFile { get; }
    }
}
