using System;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public class DocValidationException : Exception
    {
        public Tuple<string, string> ErrorLine { get; private set; }

        public DocValidationException(Tuple<string, string> error)
        {
            this.ErrorLine = error;
        }
    }
}
