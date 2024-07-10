using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<ClientFile> publisher;

        public InsertQueueHandler(IPublisher<ClientFile> pub)
        {
            this.publisher = pub;
        }

        public override void ProcessRequest(ClientChainRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.ClientFile.Id, "Inserting Queue"));
            if (request.ClientFile.Status == Connect.Messaging.Messages.File.Enum.Status.Success)
            {
                var clientFile = new ClientFile(request.IdFile, request.ClientFile.FileName);
                clientFile.IdParent = request.IdFile;                
                publisher.PublishAsync(clientFile);
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
