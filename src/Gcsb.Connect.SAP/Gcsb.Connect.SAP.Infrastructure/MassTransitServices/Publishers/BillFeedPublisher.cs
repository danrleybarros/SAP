
using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class BillFeedPublisher : Application.Repositories.IPublisher<BillFeedFile>
    {
        private IBusControl bus;

        public BillFeedPublisher(IBusControl bus)
        {
            this.bus = bus;
        }
        
        public async Task PublishAsync(BillFeedFile objectFile) 
            => await bus.Publish(objectFile);
    }
}