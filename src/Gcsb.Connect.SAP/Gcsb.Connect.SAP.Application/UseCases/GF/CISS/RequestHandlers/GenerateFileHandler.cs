using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class GenerateFileHandler : Handler
    {
        private readonly IFileGenerator<CISSRequest> fileGenerator;
        private readonly string path;

        public GenerateFileHandler(IFileGenerator<CISSRequest> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public override void ProcessRequest(CISSRequest request)
        {           
            try
            {
                request.Logs.Add(Log.CreateProcessingLog(request.Service, $"Trying generate a output file"));
                request.CISSDoc = fileGenerator.Generate(request);
                fileGenerator.SaveFile(request.CISSDoc, path, request.CISSFileName);
            }
            catch (Exception ex)
            {
                request.Logs.Add(Log.CreateExceptionLog(request.Service, $"Occurred an error in GenerateOutputHandler: {ex.Message ?? ex.InnerException.Message}", ex.StackTrace));
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}