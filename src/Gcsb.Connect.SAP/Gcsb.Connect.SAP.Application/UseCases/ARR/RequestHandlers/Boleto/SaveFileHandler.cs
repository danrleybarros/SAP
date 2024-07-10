using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class SaveFileHandler : Handler<ARRBoleto>, ISaveFileHandler<ARRBoleto>
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Saving File - ARR Boleto");
            
            fileWriteOnlyRepository.AddRange(request.Files);

            sucessor?.ProcessRequest(request);
        }
    }
}
