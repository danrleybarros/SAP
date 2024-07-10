using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers
{
    public class GenerateFilePASHandler : Handler
    {
        private readonly IFileGenerator<Domain.PAS.PAS> fileGenerator;
        private readonly string path;

        public GenerateFilePASHandler(IFileGenerator<Domain.PAS.PAS> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }
        public override void ProcessRequest(PASChainRequest request)
        {
            request.Lines.ToList().ForEach(f =>
            {
                var domain = new Domain.PAS.PAS(DateTime.UtcNow, f.Value, f.Key);
                var fileName = domain.Header.GetFileName();
                var file = new Messaging.Messages.File.File(fileName, TypeRegister.PAS)
                {
                    IdParent = request.FilePaymentFeed.Id
                };

                if (fileGenerator.ValidateModel(domain))
                {
                    var doc = fileGenerator.Generate(domain);
                    file.Status = Status.Success;
                    fileGenerator.SaveFile(doc, path, fileName);
                }
                else
                {
                    file.Status = Status.Error;
                    var errosList = domain.Lines.Select(s => string.Join(";", s.ValidateModel().Select(x => $"{x.ErrorMessage}"))).ToList();
                    var errosString = string.Join(Environment.NewLine, errosList);
                    request.Logs.Add(Log.CreateExceptionLog(request.Service, "Model is invalid", errosString));
                }

                request.AddProcessingLog("Saving Doc in folder output(SAP) - PAS");
                request.PASFile.Add(file);

            });

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
