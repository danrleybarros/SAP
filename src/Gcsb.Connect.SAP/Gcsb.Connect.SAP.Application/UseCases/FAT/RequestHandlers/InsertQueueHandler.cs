using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<ProcessFile> publisher;
        public InsertQueueHandler(IPublisher<ProcessFile> publisher)
        {
            this.publisher = publisher;
        }
        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Inserting Queue - Process Next File");
            request.Files.ForEach(f =>
            {
                if (f.Status.Equals(Status.Success))
                {
                    var processFile = new ProcessFile(request.IdBillFeed, f.FileName, TypeRegister.BILL);
                    publisher.PublishAsync(processFile);
                }
            });
            sucessor?.ProcessRequest(request);
        }
    }
}