using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.GF.Client;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ClientConsumer : IConsumer<ReturnNFFile>
    {
        private readonly IClientUseCase clientUseCase;

        public ClientConsumer(IClientUseCase clientUseCase)
        {
            this.clientUseCase = clientUseCase;
        }

        public async Task Consume(ConsumeContext<ReturnNFFile> context)
        {
            ReturnNFFile returnNFFile = context.Message;

            await Task.Run(() =>
            {
                var request = new ClientRequest((Guid)returnNFFile.IdParent);
                clientUseCase.Execute(request);
            });
        }
    }
}
