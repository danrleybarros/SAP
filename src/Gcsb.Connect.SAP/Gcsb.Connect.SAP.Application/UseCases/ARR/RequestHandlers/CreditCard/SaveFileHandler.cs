using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers
{
    public class SaveFileHandler : Handler<ARRCreditCard>, ISaveFileHandler<ARRCreditCard>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {
            request.AddProcessingLog("Saving File - ARR");
            request.Files.ForEach(f => fileWriteOnlyRepository.Add(f));

            sucessor?.ProcessRequest(request);
        }
    }
}
