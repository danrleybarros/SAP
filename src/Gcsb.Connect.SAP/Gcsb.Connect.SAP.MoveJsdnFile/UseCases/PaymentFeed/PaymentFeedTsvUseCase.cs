using System.Linq;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.PaymentFeed
{
    public class PaymentFeedTsvUseCase : IDownloadFilesUseCase
    {
        public TypeRegister TypeRegister => TypeRegister.PAYMENT;

        private readonly IDownloadService downloadService;
        private readonly IMassTransitService massTransitService;

        public PaymentFeedTsvUseCase(IDownloadService downloadService, IMassTransitService massTransitService)
        {
            this.downloadService = downloadService;
            this.massTransitService = massTransitService;
        }

        public void Execute(Configs configs)
            => MovePayment(configs.Interfaces.FirstOrDefault(c => c.Type == "PAYMENT"));

        private void MovePayment(Interface config)
        {
            var files = downloadService.DownloadFilesLocal(config.Search, config.Source, config.Dest, config.Process);
            files.ForEach(f => massTransitService.SendPaymentToProcess(new PaymentFeedTsv(f, TypePaymentMethod.CreditCard)));
        }
    }
}
