using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers.GF
{
    public class CISSPublisher : Application.Repositories.IPublisher<CISSFile>
    {
        private readonly IBusControl bus;

        public CISSPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(CISSFile objectFile)
            => await bus.Publish(objectFile);
    }
}
