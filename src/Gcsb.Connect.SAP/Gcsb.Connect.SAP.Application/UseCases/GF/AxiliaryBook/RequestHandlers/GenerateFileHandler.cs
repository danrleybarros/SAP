using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class GenerateFileHandler : Handler
    {
        private readonly IFileGenerator<AxiliaryBookRequest> fileGenerator;
        private readonly string path;


        public GenerateFileHandler(IFileGenerator<AxiliaryBookRequest> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Generating Axiliary Book");

            var strOutput = fileGenerator.Generate(request);

            request.File.Status = Connect.Messaging.Messages.File.Enum.Status.Success;

            request.AddProcessingLog("Saving Axiliary Book on server");

            fileGenerator.SaveFile(strOutput, path, request.FileName);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
