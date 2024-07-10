using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers.GF
{
    public class MasterPublisher : Application.Repositories.IPublisher<MasterFile>
    {
        private readonly IBusControl bus;

        public MasterPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(MasterFile objectFile)
            => await bus.Publish(objectFile);
    }
}
