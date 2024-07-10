using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class CriticalFilePublisher : Application.Repositories.IPublisher<CriticalFile>
    {
        private IBusControl bus;

        public CriticalFilePublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(CriticalFile objectFile)
            => await bus.Publish(objectFile);
    }
}
