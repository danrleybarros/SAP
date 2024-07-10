using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class SaveFileHandler : Handler<ARRCreditCardInter>, ISaveFileHandler<ARRCreditCardInter>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            request.AddProcessingLog("Saving File - ARR Intercompany");
            request.Files.ForEach(f => fileWriteOnlyRepository.Add(f));

            sucessor?.ProcessRequest(request);
        }
    }
}
