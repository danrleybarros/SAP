using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class PaymentFeedBoletoPublisher : Application.Repositories.IPublisher<PaymentFeedBoletoFile>
    {
        private IBusControl bus;

        public PaymentFeedBoletoPublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(PaymentFeedBoletoFile objectFile)
            => await bus.Publish(objectFile);
    }
}
