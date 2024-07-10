using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class InsertQueueHandler : Handler<ARRBoletoInter>, IInsertQueueHandler<ARRBoletoInter>
    {
        private readonly IPublisher<ProcessFile> publisher;
        private readonly IInterfaceProgressUseCase interfaceProgressUseCase;

        public InsertQueueHandler(IPublisher<ProcessFile> publisher, IInterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.publisher = publisher;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            request.AddProcessingLog("Inserting Queue - Process Next File");

            if (request.Files.Any(s => s.Status.Equals(Status.Error)))
            {
                request.AddExceptionLog("The file object of ARR not exist", "");
                return;
            }

            var processFile = new ProcessFile(request.IDPaymentFeed, "", TypeRegister.PAYMENTBOLETO);

            publisher.PublishAsync(processFile);

            interfaceProgressUseCase.Successfully(new InterfaceProgressRequest(request.IDPaymentFeed, Domain.Upload.Enum.UploadTypeEnum.PaymentFeedBoleto));

            sucessor?.ProcessRequest(request);
        }
    }
}
