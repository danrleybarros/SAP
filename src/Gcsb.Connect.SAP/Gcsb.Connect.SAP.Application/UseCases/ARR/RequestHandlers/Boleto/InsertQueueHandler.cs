using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class InsertQueueHandler : Handler<ARRBoleto>, IInsertQueueHandler<ARRBoleto>
    {
        private readonly IPublisher<ARRBoletoFile> publisher;

        public InsertQueueHandler(IPublisher<ARRBoletoFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Inserting Queue - Process Next File");

            if (request.Files.Any(s => s.Status.Equals(Status.Error)))
            {
                request.AddExceptionLog("The file object of ARR Intercompany not exist", "");
                return;
            }

            publisher.PublishAsync(new ARRBoletoFile(request.IDPaymentFeed, ""));

            sucessor?.ProcessRequest(request);
        }
    }
}
