using System.Threading.Tasks;
using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers.GF
{
    public class ISIFilePublisher : Application.Repositories.IPublisher<ISIFile>
    {
        private IBusControl bus;

        public ISIFilePublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ISIFile objectFile)
            => await bus.Publish(objectFile);
    }
}
