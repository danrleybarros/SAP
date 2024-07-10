using System.Linq;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.MoveJsdnFile.Infraestructure.Service;
using Gcsb.Connect.SAP.MoveJsdnFile.Model;

namespace Gcsb.Connect.SAP.MoveJsdnFile.UseCases.BillFeed
{
    public class BillFeedCsvUseCase : IDownloadFilesUseCase
    {
        public TypeRegister TypeRegister => TypeRegister.BILL;

        private readonly IDownloadService downloadService;
        private readonly IMassTransitService massTransitService;

        public BillFeedCsvUseCase(IDownloadService downloadService, IMassTransitService massTransitService)
        {
            this.downloadService = downloadService;
            this.massTransitService = massTransitService;
        }

        public void Execute(Configs configs)
            => MoveBill(configs.Interfaces.FirstOrDefault(c => c.Type == "BILL"));

        private void MoveBill(Interface config)
        {
            var files = downloadService.DownloadFilesLocal(config.Search, config.Source, config.Dest, config.Process);
            files.ToList().ForEach(f => massTransitService.SendBillToProcess(new BillFeedCsv(f)));
        }
    }
}
