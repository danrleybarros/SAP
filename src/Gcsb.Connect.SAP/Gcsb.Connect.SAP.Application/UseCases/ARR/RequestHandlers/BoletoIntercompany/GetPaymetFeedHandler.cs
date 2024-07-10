using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class GetPaymetFeedHandler : Handler<ARRBoletoInter>, IGetPaymetFeedHandler<ARRBoletoInter>
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;
        private readonly IJsdnRepository jsdnRepository;

        public GetPaymetFeedHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository, IJsdnRepository jsdnRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            request.AddProcessingLog("Consulting PaymentFeed - ARR Boleto Intercompany");

            var invoicesNumber = request.Services.Select(s => s.Invoice.InvoiceNumber).Distinct().ToList();

            request.AddProcessingLog($"Invoices Services - ARR Boleto Intercompany: {string.Join(", ", invoicesNumber)}");
            request.AddProcessingLog($"Invoices Services - ARR Boleto Intercompany: IdFile {request.IDPaymentFeed} Files: {string.Join(", ", request.Files.Select(f => f.IdParent).ToArray())}");

            request.paymentBoletos = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(s => invoicesNumber.Contains(s.InvoiceNumberJsdn) && s.IdFile == request.IDPaymentFeed);
            request.PaymentReports = jsdnRepository.GetPaymentReportsByInvoices(invoicesNumber);

            if (request.paymentBoletos.Count == 0 || request.PaymentReports.Count == 0)
                throw new ArgumentNullException("List of Payment Feed - Boleto Intercompany is empty");

            sucessor?.ProcessRequest(request);
        }
    }
}
