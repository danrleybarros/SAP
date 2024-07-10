using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers
{
    public class GetPaymentsHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentsHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(CustomerConsumptionRequest request)
        {
            var invoices = request.Customers.Select(s => s.InvoiceNumber).ToList();

            request.PaymentsCredit = paymentFeedReadOnlyRepository.GetPaymentFeedCredit(invoices);
            request.PaymentsBoleto = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(invoices);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
