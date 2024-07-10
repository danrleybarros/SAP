using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class GenerateOutputHandler : Handler
    {
        private readonly IFileGenerator<ItemsRequest> fileGenerator;
        private readonly string path;

        public GenerateOutputHandler(IFileGenerator<ItemsRequest> fileGenerator)
        {
            this.fileGenerator = fileGenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH");
        }

        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");
                     
            request.Logs.Add(Log.CreateProcessingLog(request.Service, $"Trying generate a output file"));

            request.OutputFile = fileGenerator.Generate(request);
            fileGenerator.SaveFile(request.OutputFile, path, request.FileName);
            

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
