using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.FAT.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using System;
using System.Linq;
using Domain = Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class GenerateFileAFaturarHandler : Handler, IGenerateFileHandler<Domain::FATaFaturarECM>
    {
        private readonly IFileGenerator<Domain::FATaFaturarECM> fileGenerator;
        private readonly string path;

        public GenerateFileAFaturarHandler(IFileGenerator<Domain::FATaFaturarECM> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH") ?? Environment.GetEnvironmentVariable("OUTPUT_SAP");
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Generating FAT a Faturar ECM Doc");

            request.Lines.Where(f => f.Key != Domain.JSDN.Stores.StoreType.Others).ToList().ForEach(f =>
            {
                request.Header = new Header(f.Key);
               
                var identification = new IdentificationRecordECM(request.SequenceFile, request.Cycle, f.Key);
                var file = new File::File(request.IdBillFeed, identification.FileName, TypeRegister.FATAFATURARECM, TypeProcess.Original, request.BillingCycleDate)
                {
                    InclusionDate = DateTime.UtcNow
                };

                file.Id = Guid.NewGuid();
                file.InclusionDate = DateTime.UtcNow;
                file.Logs = new System.Collections.Generic.List<Messaging.Messages.Log.Log>();
                var domain = new Domain::FATaFaturarECM(identification, request.Header, f.Value, file);

                if (fileGenerator.ValidateModel(domain))
                {
                    var doc = fileGenerator.Generate(domain);

                    fileGenerator.SaveFile(doc, path, file.FileName);
                    file.Status = Status.Success;
                }
                else file.Status = Status.Error;

                request.FATDomain.Add(domain);
                request.Files.Add(file);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
