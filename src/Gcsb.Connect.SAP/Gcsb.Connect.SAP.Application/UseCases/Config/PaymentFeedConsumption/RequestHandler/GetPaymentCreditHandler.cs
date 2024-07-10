using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption.RequestHandler
{
    public class GetPaymentCreditHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentCreditHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(PaymentfeedConsumptionRequest request)
        {
            request.PaymentsCredit.AddRange(paymentFeedReadOnlyRepository.GetPaymentFeedCredit(request.InvoicesNumber));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
