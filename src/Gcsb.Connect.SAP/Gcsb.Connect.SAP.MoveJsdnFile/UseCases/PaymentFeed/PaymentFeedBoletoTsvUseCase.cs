using System.Linq;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.PaymentFeed
{
    public class PaymentFeedBoletoTsvUseCase : IDownloadFilesUseCase
    {
        public TypeRegister TypeRegister => TypeRegister.PAYMENTBOLETO;

        private readonly IDownloadService downloadService;
        private readonly IMassTransitService massTransitService;

        public PaymentFeedBoletoTsvUseCase(IDownloadService downloadService, IMassTransitService massTransitService)
        {
            this.downloadService = downloadService;
            this.massTransitService = massTransitService;
        }

        public void Execute(Configs configs)
           => MovePaymentBoleto(configs.Interfaces.FirstOrDefault(c => c.Type == "PAYMENTBOLETO"));

        private void MovePaymentBoleto(Interface config)
        {
            var files = downloadService.DownloadFilesLocal(config.Search, config.Source, config.Dest, config.Process);
            files.ForEach(f => massTransitService.SendPaymentBoletoToProcess(new PaymentFeedBoletoTsv(f, TypePaymentMethod.Boleto)));
        }
    }
}
