using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<ItemsFile> publisher;

        public InsertQueueHandler(IPublisher<ItemsFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");
           
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Inserting Queue"));
            if (request.File.Status == Connect.Messaging.Messages.File.Enum.Status.Success)
                publisher.PublishAsync(new ItemsFile(request.IdNFFile, request.File.FileName));            

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
