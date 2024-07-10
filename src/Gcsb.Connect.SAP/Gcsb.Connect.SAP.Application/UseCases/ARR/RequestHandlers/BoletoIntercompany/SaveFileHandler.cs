using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class SaveFileHandler : Handler<ARRBoletoInter>, ISaveFileHandler<ARRBoletoInter>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            request.AddProcessingLog("Saving File - ARR Boleto Intercompany");
            request.Files.ForEach(f => fileWriteOnlyRepository.Add(f));

            sucessor?.ProcessRequest(request);
        }
    }
}
