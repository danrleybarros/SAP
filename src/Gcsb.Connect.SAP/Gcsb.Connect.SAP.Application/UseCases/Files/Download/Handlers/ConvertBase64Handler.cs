using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download.Handlers
{
    public class ConvertBase64Handler : Handler<DownloadUseCaseRequest>
    {    
        public override void ProcessRequest(DownloadUseCaseRequest request)
        {
            request.AddProcessingLog("ConvertBase64Handler");

            request.Base64 = Convert.ToBase64String(request.BytesZip);

            sucessor?.ProcessRequest(request);
        }
    }
}
