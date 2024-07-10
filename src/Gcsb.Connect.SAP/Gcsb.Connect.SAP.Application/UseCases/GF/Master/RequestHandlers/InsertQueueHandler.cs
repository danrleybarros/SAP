using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers
{
    public class InsertQueueHandler : Handler<MasterRequest>, IInsertQueueHandler
    {
        private readonly IPublisher<MasterFile> publisher;

        public InsertQueueHandler(IPublisher<MasterFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(MasterRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Inserting Queue"));

            if (request.File.Status == Connect.Messaging.Messages.File.Enum.Status.Success)
                publisher.PublishAsync(new MasterFile(request.IdNFFile, request.File.FileName));

            sucessor?.ProcessRequest(request);
        }
    }
}
