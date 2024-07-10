using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers.GF
{
    public class ReturnNFPublisher : Application.Repositories.IPublisher<ReturnNFCsv>, Application.Repositories.IPublisher<ReturnNFFile>
    {
        private readonly IBusControl bus;

        public ReturnNFPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ReturnNFCsv objectFile)
            => await bus.Publish(objectFile);

        public async Task PublishAsync(ReturnNFFile objectFile)
           => await bus.Publish(objectFile);
    }
}
