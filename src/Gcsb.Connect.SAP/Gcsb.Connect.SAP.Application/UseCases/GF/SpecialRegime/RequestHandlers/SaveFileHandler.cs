using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(SpecialRegimeRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Saving File - Special Regime"));

            request.SpecialRegimes.Select(s => s.StoreType)
                .Distinct()
                .ToList()
                .ForEach(f =>
                {
                    var file = new Messaging.Messages.File.File(Domain.GF.SpecialRegime.GetFileName(f, request.SpecialRegimes.Select(s => s.CycleFatDate).First()), TypeRegister.SPECIALREGIME);
                    file.IdParent = request.FileIdBillFeed;
                    request.RegimeFiles.Add(f, file.Id);
                    request.Files.Add(file);
                    fileWriteOnlyRepository.Add(file);
                });

            sucessor?.ProcessRequest(request);
        }
    }
}
