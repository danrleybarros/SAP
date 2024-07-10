using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class PaymentFeedBoletoTsvPublisher : Application.Repositories.IPublisher<PaymentFeedBoletoTsv>
    {
        private IBusControl bus;

        public PaymentFeedBoletoTsvPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(PaymentFeedBoletoTsv objectFile)
            => await bus.Publish(objectFile);
    }
}
