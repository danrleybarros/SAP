using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails.RequestHandlers
{
    public class GetPaymentsHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentsHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(InvoiceDetailsRequest request)
        {
            request.PaymentsCredit = paymentFeedReadOnlyRepository.GetPaymentFeedCredit(request.InvoiceNumbers);
            request.PaymentsBoleto = paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(request.InvoiceNumbers);

            sucessor?.ProcessRequest(request);
        }
    }
}
