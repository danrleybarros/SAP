using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class CreateClientHandler : Handler
    {
        private readonly IFileGenerator<ClientObj> fileGenerator;       

        public CreateClientHandler(IFileGenerator<ClientObj> filegenerator)
        {
            this.fileGenerator = filegenerator;           
        }

        public override void ProcessRequest(ClientChainRequest request)
        {            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, request.ClientFile.Id, "Generating content file - Client GF"));
            var clientObj = new ClientObj(request.Clients);
            request.ClientText = fileGenerator.Generate(clientObj);

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
