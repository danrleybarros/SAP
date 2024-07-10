using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<ReturnNFFile> publisherNF;
        private readonly IPublisher<ProcessFile> publisherProcess;

        public InsertQueueHandler(IPublisher<ReturnNFFile> publisherNF, IPublisher<ProcessFile> publisherProcess)
        {
            this.publisherNF = publisherNF;
            this.publisherProcess = publisherProcess;
        }

        public override void ProcessRequest(ReturnNFRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Inserting Queue"));

            if (request.File.Status == Messaging.Messages.File.Enum.Status.Success)
            {
                publisherNF.PublishAsync(new ReturnNFFile(request.File.Id, request.File.FileName, request.File.Type));
                publisherProcess.PublishAsync(new ProcessFile(request.File.Id, request.File.FileName, request.File.Type) { IdParent = request.File.IdParent });
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
