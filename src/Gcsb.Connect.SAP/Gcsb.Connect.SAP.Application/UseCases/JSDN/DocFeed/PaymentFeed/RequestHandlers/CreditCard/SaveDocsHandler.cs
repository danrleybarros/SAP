using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public class SaveDocsHandler : Handler, ISaveDocsHandler<PaymentCreditCard>
    {
        private readonly IPaymentFeedWriteOnlyRepository paymentFeedWriteOnlyRepository;

        public SaveDocsHandler(IPaymentFeedWriteOnlyRepository paymentFeedWriteOnlyRepository)
        {
            this.paymentFeedWriteOnlyRepository = paymentFeedWriteOnlyRepository;
        }

        public override void ProcessRequest(DocFeedRequest request)
        {
            request.AddProcessingLog("PaymentFeed Ingest", "Saving data - PaymentFeed", request.File.Id);
            var paymentList = new List<Domain.JSDN.PaymentCreditCard>();
            request.DocFeed.ToList().ForEach(s => paymentList.Add(s as PaymentCreditCard));
            // Troca "" por null por conta da FK 
            paymentList.Where(s => s.InvoiceNumberJsdn == "").ToList().ForEach(s => s.InvoiceNumberJsdn = null); 
            request.TotalDocs = paymentFeedWriteOnlyRepository.Add(paymentList);

            if (request.TotalDocs < 1)
                throw new ApplicationException("SaveDocs");

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
