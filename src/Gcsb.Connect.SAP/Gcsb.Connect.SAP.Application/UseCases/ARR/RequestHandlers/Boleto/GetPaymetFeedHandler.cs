using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class GetPaymetFeedHandler : Handler<ARRBoleto>, IGetPaymetFeedHandler<ARRBoleto>
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;
        private readonly IJsdnRepository jsdnRepository;

        public GetPaymetFeedHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository, IJsdnRepository jsdnRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Consulting PaymentFeed - ARR Boleto");

            var invoicesNumber = request.Services.Select(s => s.Invoice.InvoiceNumber).Distinct().ToList();

            request.AddProcessingLog($"Invoices Services - ARR Boleto : {string.Join(", ", invoicesNumber)}");
            request.AddProcessingLog($"Invoices Services - ARR Boleto : IdFile {request.IDPaymentFeed} Files: {string.Join(", ", request.Files.Select(f => f.IdParent).ToArray())}");

            request.paymentBoletos = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(s => invoicesNumber.Contains(s.InvoiceNumberJsdn) && s.IdFile == request.IDPaymentFeed);
            request.PaymentReports = jsdnRepository.GetPaymentReportsByInvoices(invoicesNumber);

            if (request.paymentBoletos.Count == 0 || request.PaymentReports.Count == 0)
                throw new ArgumentNullException("List of Payment Feed - Boleto is empty");

            sucessor?.ProcessRequest(request);
        }
    }
}
