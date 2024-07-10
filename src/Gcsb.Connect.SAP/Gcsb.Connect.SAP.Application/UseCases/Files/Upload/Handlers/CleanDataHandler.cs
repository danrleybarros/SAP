using System.Linq;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.PaymentFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload.Handlers
{
    public class CleanDataHandler : Handler<UploadUseCaseRequest>
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IBillFeedWriteOnlyRepository billFeedWriteOnlyRepository;
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IPaymentFeedWriteOnlyRepository paymentFeedWriteOnlyRepository;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly ILogReadOnlyRepository logReadOnlyRepository;

        public CleanDataHandler(IFileReadOnlyRepository fileReadOnlyRepository, IBillFeedWriteOnlyRepository billFeedWriteOnlyRepository, IFileWriteOnlyRepository fileWriteOnlyRepository, 
            IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository, IPaymentFeedWriteOnlyRepository paymentFeedWriteOnlyRepository, ILogWriteOnlyRepository logWriteOnlyRepository,
            ILogReadOnlyRepository logReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
            this.billFeedWriteOnlyRepository = billFeedWriteOnlyRepository;
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
            this.invoiceWriteOnlyRepository = invoiceWriteOnlyRepository;
            this.paymentFeedWriteOnlyRepository = paymentFeedWriteOnlyRepository;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.logReadOnlyRepository = logReadOnlyRepository;
        }

        public override void ProcessRequest(UploadUseCaseRequest request)
        {
            request.AddProcessingLog("CleanDataHandler");

            var file = fileReadOnlyRepository.GetFile(s => s.FileName == request.FileName);
            if (file != null)
            {
                // Clear all possible data
                paymentFeedWriteOnlyRepository.DeleteBoleto(s => s.IdFile == file.Id);
                paymentFeedWriteOnlyRepository.DeleteCreditCard(s => s.IdFile == file.Id);
                billFeedWriteOnlyRepository.Delete(s => s.IdFile == file.Id);
                invoiceWriteOnlyRepository.DeleteCascade(s => s.IdFile == file.Id);

                var logDetails = logReadOnlyRepository.GetLogs(s => s.FileId == file.Id).SelectMany(s=>s.LogDetails.Select(x=>x.Id)).ToList();
                var logDetailsParent = logReadOnlyRepository.GetLogs(s => s.FileId == file.IdParent).SelectMany(s => s.LogDetails.Select(x => x.Id)).ToList();

                logWriteOnlyRepository.DeleteLogsDetails(s => logDetails.Contains(s.Id));
                logWriteOnlyRepository.DeleteLogsDetails(s => logDetailsParent.Contains(s.Id));

                logWriteOnlyRepository.DeleteLogs(s => s.FileId == file.Id);
                logWriteOnlyRepository.DeleteLogs(s => s.FileId == file.IdParent);
                fileWriteOnlyRepository.Delete(s => s.Id == file.Id);
                fileWriteOnlyRepository.Delete(s => s.IdParent == file.Id);
            }
            sucessor?.ProcessRequest(request);
        }
    }
}
