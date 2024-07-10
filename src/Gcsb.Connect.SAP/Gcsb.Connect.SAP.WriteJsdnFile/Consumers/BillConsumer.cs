using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport;
using Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime;
using Gcsb.Connect.SAP.Application.UseCases.InterestAndFine.BillFeed.SendBillFeedProcessed;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class BillConsumer : IConsumer<BillFeedFile>
    {
        private readonly IIndividualReportNFUseCase individualReportNF;
        private readonly ISpecialRegimeUseCase specialRegimeUseCase;
        private readonly ISendBillFeedProcessedUseCase sendBillFeedProcessedUseCase;

        public BillConsumer(
            IIndividualReportNFUseCase individualReportNF,
            ISpecialRegimeUseCase specialRegimeUseCase,
            ISendBillFeedProcessedUseCase sendBillFeedProcessedUseCase
        )
        {
            this.individualReportNF = individualReportNF;
            this.specialRegimeUseCase = specialRegimeUseCase;
            this.sendBillFeedProcessedUseCase = sendBillFeedProcessedUseCase;
        }

        public async Task Consume(ConsumeContext<BillFeedFile> context)
        {
            var billFeedFile = context.Message;


            switch (billFeedFile.TypeProcess)
            {
                case TypeProcess.Original:
                    await IndividualReportConsumer(billFeedFile);
                    await SpecialRegimeConsumer(billFeedFile);
                    await SendBillFeedProcessed(billFeedFile);
                    break;
                case TypeProcess.Reprocess:
                    await ReprocessFile(billFeedFile);
                    break;
            }
        }

        public async Task ReprocessFile(BillFeedFile billFeedFile)
        {
            switch (billFeedFile.Type)
            {
                case TypeRegister.INDIVIDUALREPORT:
                    await IndividualReportConsumer(billFeedFile);
                    break;
                case TypeRegister.SPECIALREGIME:
                    await SpecialRegimeConsumer(billFeedFile);
                    break;
            }
        }

        public async Task IndividualReportConsumer(BillFeedFile billFeedFile)
        {
            await Task.Run(() =>
            {
                var request = new IndividualReportRequestNF((Guid)billFeedFile.IdParent);
                individualReportNF.Execute(request);
            });
        }

        public async Task SpecialRegimeConsumer(BillFeedFile billFeedFile)
        {
            await Task.Run(() =>
            {
                var request = new SpecialRegimeRequest((Guid)billFeedFile.IdParent);
                specialRegimeUseCase.Execute(request);
            });
        }

        public async Task SendBillFeedProcessed(BillFeedFile billFeedFile)
        {
            await Task.Run(() =>
            {
                var cycle = billFeedFile.CycleDate.Value.ToString("MM/yyyy");
                var request = new SendBillFeedProcessedUcRequest(billFeedFile.FileName, cycle);

                sendBillFeedProcessedUseCase.Execute(request);
            });
        }

    }
}
