using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.PaymentFeed.RequestHandlers
{
    public class SaveFileHandler : Handler, ISaveFileHandler
    {
        private readonly IFileWriteOnlyRepository HeaderWriteRepo;
        private readonly InterfaceProgressUseCase interfaceProgressUseCase;

        public SaveFileHandler(IFileWriteOnlyRepository HeaderWriteRepo, InterfaceProgressUseCase interfaceProgressUseCase)
        {
            this.HeaderWriteRepo = HeaderWriteRepo;
            this.interfaceProgressUseCase = interfaceProgressUseCase;
        }

        public override void ProcessRequest(DocFeedRequest request)
        {
            request.AddProcessingLog("PaymentFeed Ingest", "Saving File - PaymentFeed");
            request.File.Status = Messaging.Messages.File.Enum.Status.Success;

            int ret = HeaderWriteRepo.Add(request.File);
            if (ret < 1)
                throw new ApplicationException("Header");

            interfaceProgressUseCase.Progress(new InterfaceProgressRequest(request.File.Id,
                    request.File.Type == TypeRegister.PAYMENTBOLETOTSV ? Domain.Upload.Enum.UploadTypeEnum.PaymentFeedBoleto : Domain.Upload.Enum.UploadTypeEnum.PaymentFeedCreditCard));

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
