using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers.Boleto
{
    public class ConvertBoletoHandler : Handler, IConvertHandler<PaymentBoleto>
    {
        private readonly IPaymentFeedConvertRepository<PaymentBoleto> paymentFeedConvertRepository;
        private IInsertQueueHandler<PaymentBoleto> insertQueueHandler;
        private readonly IPublisher<ProcessFile> publisher;

        public ConvertBoletoHandler(IPaymentFeedConvertRepository<PaymentBoleto> paymentFeedConvertRepository, IPublisher<ProcessFile> publisher, IInsertQueueHandler<PaymentBoleto> insertQueueHandler)
        {
            this.paymentFeedConvertRepository = paymentFeedConvertRepository;
            this.publisher = publisher;
            this.insertQueueHandler = insertQueueHandler;
        }

        public override void ProcessRequest(DocFeedRequest request)
        {
            request.AddProcessingLog("PaymentFeed Boleto Ingest", "Converting csv file - PaymentFeed Boleto");
            if (request == null)
                throw new ArgumentNullException("request");

            if (string.IsNullOrEmpty(request.Base64String))
                throw new ArgumentException("DocFeed file required");

            var collection = paymentFeedConvertRepository.FromTsv(request.Base64String, request.File.Id, request.File.FileName);

            if (collection == null || collection?.Count == 0)
            {
                request.AddProcessingLog("PaymentFeed Boleto Ingest", "PaymentFeed don't have lines");
                ProcessNextPayment(request);              
                SetSucessor(insertQueueHandler);
            }
            else
            {
                List<IDoc> paymentFeed = new List<IDoc>();
                paymentFeed.AddRange(collection);
                request.DocFeed = paymentFeed;
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private void ProcessNextPayment(DocFeedRequest request)
        {
            var processFile = new ProcessFile(request.File.Id, request.File.FileName, TypeRegister.PAYMENTBOLETO);
            publisher.PublishAsync(processFile);
        }
    }
}

