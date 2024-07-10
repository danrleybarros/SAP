namespace Gcsb.Connect.SAP.Infrastructure
{
    public class AccountNotFoundException : InfrastructureException
    {
        public AccountNotFoundException(string message)
            : base(message)
        {

        }
    }
}
