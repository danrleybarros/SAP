using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.ReadJsdnFile.Consumers
{
    public class PaymentFeedBoletoConsumer : IConsumer<PaymentFeedBoletoTsv>
    {        
        private readonly IPaymentFeedUseCase<PaymentBoleto> PaymentFeedBoletoUseCase;
        private readonly IReadFile readFile;
        private readonly string basePath;

        public PaymentFeedBoletoConsumer(IPaymentFeedUseCase<PaymentBoleto> paymentFeedBoletoUseCase, IReadFile readFile)
        {            
            this.PaymentFeedBoletoUseCase = paymentFeedBoletoUseCase;
            this.readFile = readFile;
            this.basePath = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }
        public async Task Consume(ConsumeContext<PaymentFeedBoletoTsv> context)
        {
            var paymentFeedBoletoTsv = context.Message;
            await Task.Run(() =>
            {
                var base64 = readFile.ToBase64($"{basePath}{paymentFeedBoletoTsv.FileName}");
                DocFeedRequest request = new DocFeedRequest(paymentFeedBoletoTsv.Type, paymentFeedBoletoTsv.FileName, base64);
                PaymentFeedBoletoUseCase.Execute(request);
            });
        }
    }
}
