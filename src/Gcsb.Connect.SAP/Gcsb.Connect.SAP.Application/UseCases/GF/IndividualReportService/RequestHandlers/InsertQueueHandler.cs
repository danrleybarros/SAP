using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualReportService.RequestHandlers
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<ISIFile> publisher;

        public InsertQueueHandler(IPublisher<ISIFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(ISIChainRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.ISIFile.Id, "Inserting Queue - Individual Report Service"));
            
            if (request.ISIFile.Status == Connect.Messaging.Messages.File.Enum.Status.Success)
            {
                var isiFile = new ISIFile(request.IdFile, request.ISIFile.FileName);
                isiFile.IdParent = request.IdFile;
                publisher.PublishAsync(isiFile);
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
