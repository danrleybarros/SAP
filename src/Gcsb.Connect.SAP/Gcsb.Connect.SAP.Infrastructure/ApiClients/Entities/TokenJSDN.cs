namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.Entities
{
    public class TokenJSDN
    {
        public Access Access { get; set; }
    }

    public class Access
    {
        public Token Token { get; set; }
    }

    public class Token
    {
        public string Id { get; set; }
    }
}
