using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class ProcessHandler : Handler
    {
        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Processing request axiliary book");

            if (request == null)
                throw new ArgumentException("Request invalid");

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
