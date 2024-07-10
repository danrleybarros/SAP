using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers.GF
{
    public class ItemsPublisher : Application.Repositories.IPublisher<ItemsFile>
    {
        private readonly IBusControl bus;

        public ItemsPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ItemsFile objectFile) 
            => await bus.Publish(objectFile);
    }
}
