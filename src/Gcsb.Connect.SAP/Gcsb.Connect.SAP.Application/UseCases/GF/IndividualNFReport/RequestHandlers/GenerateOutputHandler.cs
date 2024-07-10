using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;
using Gcsb.Connect.SAP.Domain.GF;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers
{
    public class GenerateOutputHandler : Handler
    {
        private readonly IFileGenerator<List<IndividualReportNF>> fileGenerator;
        private readonly IUploadFile uploadFile;
        private readonly string path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        private readonly string strUploadFile = Environment.GetEnvironmentVariable("FTP_NF");

        public GenerateOutputHandler(IFileGenerator<List<IndividualReportNF>> fileGenerator, IUploadFile uploadFile)
        {
            this.fileGenerator = fileGenerator;
            this.uploadFile = uploadFile;
        }

        public override void ProcessRequest(IndividualReportRequestNF request)
        {
            request.IndividualFiles.ToList().ForEach(f =>
            {
                request.Logs.Add(Log.CreateProcessingLog(request.Service, f.Value, $"Generating content file - IndividualReport {f.Key}"));

                var lines = request.IndividualReports.Where(w => w.StoreType.Equals(f.Key)).ToList();
                var individualReportText = fileGenerator.Generate(lines);
                var fileName = request.Files.Where(w => w.Id.Equals(f.Value)).First().FileName;

                fileGenerator.SaveFile(individualReportText, path, fileName);

                if (!string.IsNullOrEmpty(strUploadFile) && strUploadFile.Equals("true"))
                    request.UploadFile = uploadFile.Execute(individualReportText, fileName, path);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
