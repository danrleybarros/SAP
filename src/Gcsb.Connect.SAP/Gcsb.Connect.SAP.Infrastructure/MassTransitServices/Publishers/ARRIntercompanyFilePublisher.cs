using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class ARRIntercompanyFilePublisher : Application.Repositories.IPublisher<ARRIntercompanyFile>
    {
        private IBusControl bus;

        public ARRIntercompanyFilePublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ARRIntercompanyFile objectFile)
            => await bus.Publish(objectFile);
    }
}
