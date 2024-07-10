using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Repositories;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class BillFeedCsvPublisher : IPublisher<BillFeedCsv>
    {
        private readonly IBusControl bus;

        public BillFeedCsvPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(BillFeedCsv objectFile)
            => await bus.Publish(objectFile);
    }
}
