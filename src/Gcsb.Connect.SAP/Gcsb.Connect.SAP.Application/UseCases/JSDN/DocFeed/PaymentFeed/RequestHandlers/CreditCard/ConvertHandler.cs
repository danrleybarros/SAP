using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public class ConvertHandler : Handler, IConvertHandler<PaymentCreditCard>
    {
        private readonly IPaymentFeedConvertRepository<PaymentCreditCard> paymentFeedConvertRepository;
        private readonly IPublisher<ProcessFile> publisher;

        public ConvertHandler(IPaymentFeedConvertRepository<PaymentCreditCard> paymentFeedConvertRepository, IPublisher<ProcessFile> publisher)
        {
            this.paymentFeedConvertRepository = paymentFeedConvertRepository;
            this.publisher = publisher;
        }

        public override void ProcessRequest(DocFeedRequest request)
        {
            request.AddProcessingLog("PaymentFeed Ingest", "Converting csv file - PaymentFeed");

            if (string.IsNullOrEmpty(request.Base64String))
                throw new ArgumentException("DocFeed file required");

            var collection = paymentFeedConvertRepository.FromTsv(request.Base64String, request.File.Id,request.File.FileName);

            RemoveMicroPayments(collection);

            if (collection?.Count == 0)
            {
                request.AddProcessingLog("PaymentFeed Ingest", "PaymentFeed don't have lines");
                ProcessNextPayment(request);

                return;
            }

            request.DocFeed.AddRange(collection);

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private void ProcessNextPayment(DocFeedRequest request)
        {
            var processFile = new ProcessFile(request.File.Id, request.File.FileName, TypeRegister.PAYMENT);
            publisher.PublishAsync(processFile);
        }

        private void RemoveMicroPayments(ICollection<PaymentCreditCard> collection)
        {
            var microPayments = collection.ToList().Where(w => string.IsNullOrEmpty(w.InvoiceNumberJsdn) && w.TransactionAmount.Value.Equals(100)).ToList();
            microPayments.ForEach(f => collection.Remove(f));
        }
    }
}
