using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler
{
    public class ValidatePaymentEmptyHandler : Handler
    {
        private readonly IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepositor;

        public ValidatePaymentEmptyHandler(IPaymentFeedReadOnlyRepository paymentFeedReadOnlyRepositor)
        {
            this.paymentFeedReadOnlyRepositor = paymentFeedReadOnlyRepositor;
        }

        public override void ProcessRequest(CriticalRequest request)
        {
            request.AddLog("Getting the payment boleto data on database");

            var paymentBoleto = paymentFeedReadOnlyRepositor.GetPaymentFeedBoleto(x => x.IdFile.Equals(request.IDPaymentFeed));

            if (paymentBoleto.Count() == 0 && request.Criticals.Count == 0)
            {
                request.AddLogError("Not found data of Payment boleto on database and critical on api pay");
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);

        }
    }
}
