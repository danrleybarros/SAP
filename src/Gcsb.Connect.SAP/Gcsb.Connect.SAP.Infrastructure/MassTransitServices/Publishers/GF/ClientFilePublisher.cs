using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers.GF
{
    public class ClientFilePublisher : Application.Repositories.IPublisher<ClientFile>
    {
        private IBusControl bus;

        public ClientFilePublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ClientFile objectFile)
            => await bus.Publish(objectFile);
    }
}
