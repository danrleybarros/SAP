namespace Gcsb.Connect.SAP.Infrastructure
{
    public class CustomerNotFoundException : InfrastructureException
    {
        public CustomerNotFoundException(string message)
            : base(message)
        {

        }
    }
}
