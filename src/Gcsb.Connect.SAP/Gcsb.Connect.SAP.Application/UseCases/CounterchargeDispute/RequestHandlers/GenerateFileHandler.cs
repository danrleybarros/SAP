using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.AJU;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class GenerateFileHandler : Handler
    {
        private readonly IFileGenerator<Domain.AJU.AJU> fileGenerator;
        private readonly string path;

        public GenerateFileHandler(IFileGenerator<Domain.AJU.AJU> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Generating Interfaces");

            request.Lines.ToList().ForEach(f =>
            {
                var header = new Header(f.Key);
                var footer = new Footer(f.Value.Count, f.Value.Sum(s => s.LaunchValue));
                var identification = new IdentificationRegister(request.SequenceFile, request.DateTo, f.Key);
                var file = new Messaging.Messages.File.File(identification.FileName, TypeRegister.AJU);
                file.IdParent = request.InterfaceProgressIdParent;

                if (f.Key == Domain.JSDN.Stores.StoreType.TBRA)
                {
                    request.FileName = identification.FileName;
                    file.Id = request.InterfaceProgressIdParent;
                }

                var domain = new AJU(file, identification, header, f.Value, footer);

                if (fileGenerator.ValidateModel(domain))
                {
                    var strOutput = fileGenerator.Generate(domain);
                    file.Status = Status.Success;
                    fileGenerator.SaveFile(strOutput, path, identification.FileName);
                }
                else
                    file.Status = Status.Error;

                request.Files.Add(file);

            });

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
