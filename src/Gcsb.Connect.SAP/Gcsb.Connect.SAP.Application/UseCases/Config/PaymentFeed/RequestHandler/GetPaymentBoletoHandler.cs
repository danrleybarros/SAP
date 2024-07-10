using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeed.RequestHandler
{
    public class GetPaymentBoletoHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentBoletoHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(PaymentFeedRequest request)
        {
            var invoices = request.Invoices.Select(s => s.InvoiceNumber).ToList();
            request.PaymentsBoleto = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(invoices);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
