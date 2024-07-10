using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers
{
    public class GetPaymentsHandler : Handler<GetOpenInvoicesRequest>
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentsHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(GetOpenInvoicesRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();

            var creditCard = paymentFeedReadOnlyRepository.GetPaymentFeedCredit(invoices);
            var boleto = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(invoices);

            request.Payments.AddRange(creditCard);
            request.Payments.AddRange(boleto);

            sucessor?.ProcessRequest(request);
        }
    }
}
