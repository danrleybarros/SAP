using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Linq;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers
{
    public class SaveFileHandler : Handler
    {
        private readonly IFileWriteOnlyRepository fileWriteOnlyRepository;

        public SaveFileHandler(IFileWriteOnlyRepository fileWriteOnlyRepository)
        {
            this.fileWriteOnlyRepository = fileWriteOnlyRepository;
        }

        public override void ProcessRequest(IndividualReportRequestNF request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Saving File - Individual Report NFE"));

            request.IndividualReports.Select(s => s.StoreType)
                .Distinct()
                .ToList()
                .ForEach(f =>
                {
                    var name = f.Equals(StoreType.TBRA) ? $"EMISSAO-NF-IND-" : $"EMISSAO-{f}-NF-IND-";
                    var file = new File::File(Util.GetFileName(name, request.Invoices.SelectMany(s => s.Services).ToList(), "csv"), TypeRegister.INDIVIDUALREPORT);
                    file.IdParent = request.IdBillFeedFile;
                    request.IndividualFiles.Add(f, file.Id);
                    request.Files.Add(file);

                    fileWriteOnlyRepository.Add(file);
                });

            sucessor?.ProcessRequest(request);
        }
    }
}
