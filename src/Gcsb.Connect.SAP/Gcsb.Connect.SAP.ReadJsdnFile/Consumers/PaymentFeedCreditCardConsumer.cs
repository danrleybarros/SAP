using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.ReadJsdnFile.Consumers
{
    public class PaymentFeedCreditCardConsumer : IConsumer<PaymentFeedTsv>
    {
        private readonly IPaymentFeedUseCase<PaymentCreditCard> PaymentFeedUseCase;
        private readonly IReadFile readFile;
        private readonly string basePath;

        public PaymentFeedCreditCardConsumer(IPaymentFeedUseCase<PaymentCreditCard> paymentFeedUseCase, IReadFile readFile)
        {
            this.PaymentFeedUseCase = paymentFeedUseCase;
            this.readFile = readFile;
            this.basePath = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public async Task Consume(ConsumeContext<PaymentFeedTsv> context)
        {
            var paymentFeedCreditCardTsv = context.Message;
            await Task.Run(() =>
            {
                var base64 = readFile.ToBase64($"{basePath}{paymentFeedCreditCardTsv.FileName}");
                DocFeedRequest request = new DocFeedRequest(paymentFeedCreditCardTsv.Type, paymentFeedCreditCardTsv.FileName, base64);
                PaymentFeedUseCase.Execute(request);
            });
        }
    }
}
