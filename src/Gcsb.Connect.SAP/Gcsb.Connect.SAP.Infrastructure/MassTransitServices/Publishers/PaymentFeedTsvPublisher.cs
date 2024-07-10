using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class PaymentFeedTsvPublisher : Application.Repositories.IPublisher<PaymentFeedTsv>
    {
        private IBusControl bus;

        public PaymentFeedTsvPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(PaymentFeedTsv objectFile)
            => await bus.Publish(objectFile);
    }
}
