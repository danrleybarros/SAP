using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices.RequestHandlers
{
    public class GetPaymentsHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentsHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(NewPendingInvoicesRequest request)
        {
            var invoices = request.UnPaidInvoicesCustomer.Select(s => s.InvoiceNumber).ToList();

            if (invoices.Count > 0)
            {
                request.PaymentsCredit = paymentFeedReadOnlyRepository.GetPaymentFeedCredit(invoices);
                request.PaymentsBoleto = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(invoices);
            }
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
