using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.RequestHandler
{
    public class GetPaymentCreditHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentCreditHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(PaymentFeedRequest request)
        {
            var invoices = request.Invoices.Select(s => s.InvoiceNumber).ToList();
                       
            request.PaymentsCredit.AddRange(paymentFeedReadOnlyRepository.GetPaymentFeedCredit(w=> invoices.Contains(w.InvoiceNumberJsdn) &&
                w.ResultCode >= 0 && w.ResultCode <= 99 ));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
