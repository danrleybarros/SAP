using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime.RequestHandlers
{
    public class GenerateSpecialRegimeFileHandler : Handler
    {
        private readonly IFileGenerator<List<Domain.GF.SpecialRegime>> fileGenerator;
        private readonly string path;

        public GenerateSpecialRegimeFileHandler(IFileGenerator<List<Domain.GF.SpecialRegime>> fileGenerator)
        {
            this.fileGenerator = fileGenerator;

            path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH") ?? Environment.GetEnvironmentVariable("OUTPUT_SAP");
        }

        public override void ProcessRequest(SpecialRegimeRequest request)
        {
            request.RegimeFiles.ToList().ForEach(f =>
            {
                request.Logs.Add(Log.CreateProcessingLog(request.Service, f.Value, $"Generating content file - Special Regime {f.Key}"));

                var lines = request.SpecialRegimes.Where(w => w.StoreType.Equals(f.Key)).ToList();
                var specialRegimeText = fileGenerator.Generate(lines);

                fileGenerator.SaveFile(specialRegimeText, path, request.Files.Where(w => w.Id.Equals(f.Value)).First().FileName);
            });

            request.OutputSuccessfully = true;

            sucessor?.ProcessRequest(request);
        }
    }
}
