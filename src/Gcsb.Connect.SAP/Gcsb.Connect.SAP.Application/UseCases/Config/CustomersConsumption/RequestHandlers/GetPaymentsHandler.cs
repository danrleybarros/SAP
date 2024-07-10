using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption.RequestHandlers
{
    public class GetPaymentsHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentsHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(CustomersConsumptionRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();

            request.PaymentsCredit = paymentFeedReadOnlyRepository.GetPaymentFeedCredit(invoices);
            request.PaymentsBoleto = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(invoices);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
