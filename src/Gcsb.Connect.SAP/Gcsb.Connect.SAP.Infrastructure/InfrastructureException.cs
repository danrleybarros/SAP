namespace Gcsb.Connect.SAP.Infrastructure
{
    using System;
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
