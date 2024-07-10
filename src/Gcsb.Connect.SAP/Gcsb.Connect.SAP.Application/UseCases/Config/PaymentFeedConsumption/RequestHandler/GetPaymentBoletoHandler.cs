using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption.RequestHandler
{
    public class GetPaymentBoletoHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository;

        public GetPaymentBoletoHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepository)
        {
            this.paymentFeedReadOnlyRepository = paymentFeedReadOnlyRepository;
        }

        public override void ProcessRequest(PaymentfeedConsumptionRequest request)
        {
            request.PaymentsBoleto.AddRange(paymentFeedReadOnlyRepository.GetPaymentFeedBoleto(request.InvoicesNumber));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
