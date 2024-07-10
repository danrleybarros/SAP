using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.MassTransitServices;
using Gcsb.Connect.SAP.Application.Repositories.Upload;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload.Handlers
{
    public class InsertQueueHandler : Handler<UploadUseCaseRequest>
    {
        private readonly IMassTransitService massTransitService;
        private readonly IInterfaceProgressRepository interfaceProgressRepository;

        public InsertQueueHandler(IMassTransitService massTransitService)
        {
            this.massTransitService = massTransitService;
        }
        public override void ProcessRequest(UploadUseCaseRequest request)
        {
            request.AddProcessingLog("InsertQueueHandler");

            switch (request.UploadType)
            {
                case Domain.Upload.Enum.UploadTypeEnum.Billfeed:
                    var billFeedCsv = new BillFeedCsv(request.FileName);
                    massTransitService.SendBillToProcess(billFeedCsv);
                    break;
                case Domain.Upload.Enum.UploadTypeEnum.PaymentFeedBoleto:
                    massTransitService.SendPaymentBoletoToProcess(new PaymentFeedBoletoTsv(request.FileName, TypePaymentMethod.Boleto));
                    break;
                case Domain.Upload.Enum.UploadTypeEnum.PaymentFeedCreditCard:
                    massTransitService.SendPaymentToProcess(new PaymentFeedTsv(request.FileName, TypePaymentMethod.CreditCard));
                    break;
                case Domain.Upload.Enum.UploadTypeEnum.ReturnNF:
                    massTransitService.SendReturnNFToProcess(new ReturnNFCsv(request.NfeFilesJSON));
                    break;
                default:
                    request.AddExceptionLog("Not implemented upload for this type", "Not implemented upload for this type");
                    return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
