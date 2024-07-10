using System;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.LEI1601;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers
{
    public class GenerateFileHandler : Handler
    {
        private readonly IFileGenerator<Domain.LEI1601.Lei1601> fileGenerator;

        public GenerateFileHandler(IFileGenerator<Domain.LEI1601.Lei1601> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
        }

        public override void ProcessRequest(Lei1601Request request)
        {
            var path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");

            request.AddProcessingLog($"Reading enviromment to save file {path}");
            
            var identification = new IdentificationRegister(request.ReferenceDate, request.ProcessDate, request.Sequence);

            var file = new File::File(identification.FileName, TypeRegister.LEI1601);
            request.Lei = new Domain.LEI1601.Lei1601(file, identification, request.Lines);
            request.LeiDomain.Add(request.Lei);

            if (fileGenerator.ValidateModel(request.Lei))
            {
                request.AddProcessingLog("Generating data Lei 1601");

                var strOutput = fileGenerator.Generate(request.Lei);

                request.FileText = strOutput;

                file.Status = Status.Success;

                request.AddProcessingLog("Saving new File 1601");

                fileGenerator.SaveFile(strOutput, path, identification.FileName);

            }
            else
            {
                request.AddProcessingLog("Error write file Lei 1601");

                file.Status = Status.Error;
            }

            request.Files.Add(file);
            request.FileName = file.FileName;

            sucessor?.ProcessRequest(request);
        }
    }
}
