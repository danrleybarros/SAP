using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class SaveCISSHandler : Handler
    {
        private readonly IFileGenerator<CISSRequest> fileGenerator;
        private readonly string path;

        public SaveCISSHandler(IFileGenerator<CISSRequest> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH")??Environment.GetEnvironmentVariable("OUTPUT_SAP");
        }

        public override void ProcessRequest(CISSRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Saving File - CISS"));
            fileGenerator.SaveFile(request.CISSDoc, path, request.CISSFileName);

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
