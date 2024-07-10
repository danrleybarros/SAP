using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler
{
    public class InsertQueueHandler : Handler
    {
        private readonly IPublisher<CriticalFile> publisher;

        public InsertQueueHandler(IPublisher<CriticalFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(CriticalRequest request)
        {
            request.AddLog("Inserting Queue CriticalFile");

            publisher.PublishAsync(new CriticalFile(request.IDPaymentFeed, TypeRegister.CRITICALFILE, TypeProcess.Original));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
