using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class CreateISIFileHandler : Handler
    {
        private readonly IFileGenerator<ISIObj> fileGenerator;

        public CreateISIFileHandler(IFileGenerator<ISIObj> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
        }

        public override void ProcessRequest(ISIChainRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.ISIFile.Id, "Create DocFile - Individual Report Service"));
            var list = new ISIObj(request.Lines);
            request.ISIDoc = fileGenerator.Generate(list);

                if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
