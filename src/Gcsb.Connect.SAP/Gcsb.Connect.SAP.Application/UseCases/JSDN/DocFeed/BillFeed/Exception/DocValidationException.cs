using System;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.Exception
{
    public class DocValidationException : System.Exception
    {
        public Tuple<string, string> ErrorLine { get; private set; }

        public DocValidationException(Tuple<string, string> error)
        {
            ErrorLine = error;
        }
    }
}
