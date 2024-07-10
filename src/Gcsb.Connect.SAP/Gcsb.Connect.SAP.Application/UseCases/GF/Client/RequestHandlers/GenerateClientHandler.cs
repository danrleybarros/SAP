using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class GenerateClientHandler : Handler
    {
        private readonly IFileGenerator<ClientObj> fileGenerator;
        private readonly string path;

        public GenerateClientHandler(IFileGenerator<ClientObj> filegenerator)
        {
            this.fileGenerator = filegenerator;
            this.path = Environment.GetEnvironmentVariable("DEST_LOCAL_PATH") ?? Environment.GetEnvironmentVariable("OUTPUT_SAP");
        }
        public override void ProcessRequest(ClientChainRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.ClientFile.Id, $"Saving SpecialRegime Report in folder output(SAP) - Local:{path} File:{request.FileName}"));
            fileGenerator.SaveFile(request.ClientText, path, request.FileName);
            request.OutputFileSuccessfully = true;

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
