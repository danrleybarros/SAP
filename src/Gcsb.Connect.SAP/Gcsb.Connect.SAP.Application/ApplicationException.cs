namespace Gcsb.Connect.SAP.Application
{
    using System;
    public class ApplicationException : Exception
    {
        public ApplicationException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
