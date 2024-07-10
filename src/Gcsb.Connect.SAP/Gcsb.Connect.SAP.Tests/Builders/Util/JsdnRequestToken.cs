namespace Gcsb.Connect.SAP.Tests.Builders.Util
{
    public class PasswordCredentials
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class JsdnRequestToken
    {
        public Auth auth { get; set; }
    }

    public class Auth
    {
        public PasswordCredentials passwordCredentials { get; set; }
        public string tenantId { get; set; }
    }
}
