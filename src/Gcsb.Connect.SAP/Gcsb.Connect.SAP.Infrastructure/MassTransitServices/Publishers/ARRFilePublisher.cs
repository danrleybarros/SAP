
using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class ARRFilePublisher : Application.Repositories.IPublisher<ARRFile>
    {
        private IBusControl bus;

        public ARRFilePublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ARRFile objectFile)
            => await bus.Publish(objectFile);
    }
}
