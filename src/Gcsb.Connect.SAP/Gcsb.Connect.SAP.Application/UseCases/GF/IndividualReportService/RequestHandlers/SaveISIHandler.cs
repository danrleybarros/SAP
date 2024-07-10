using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class SaveISIHandler : Handler
    {
        private readonly IFileGenerator<ISIObj> fileGenerator;
        private readonly string path;

        public SaveISIHandler(IFileGenerator<ISIObj> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH") ?? Environment.GetEnvironmentVariable("OUTPUT_SAP");
        }

        public override void ProcessRequest(ISIChainRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.ISIFile.Id, "Saving Doc in folder output(SAP) - Report Service Interface"));
            fileGenerator.SaveFile(request.ISIDoc, path, request.ISIFileName);
            request.OutputSuccessfully = true;

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
