using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class ServicesHandler : Handler<ARRCreditCardInter>, IServicesHandler<ARRCreditCardInter>
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;
        private readonly IPublisher<ProcessFile> publisherProcessFile;

        public ServicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository, IPublisher<ProcessFile> publisherProcessFile)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
            this.publisherProcessFile = publisherProcessFile;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            request.AddProcessingLog("Consulting Services - ARR Intercompany");

            request.Services = serviceReadOnlyRepository.GetPaidServices(request.IDPaymentFeed).ToList();

            if (request.Services.Count == 0)
            {
                request.AddProcessingLog($"Not found any services with this paymentfeed: {request.IDPaymentFeed}");
                var processFile = new ProcessFile(request.IDPaymentFeed, "", TypeRegister.PAYMENT);
                publisherProcessFile.PublishAsync(processFile);
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
