using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class PaymentFeedPublisher : Application.Repositories.IPublisher<PaymentFeedFile>
    {
        private IBusControl bus;

        public PaymentFeedPublisher(IBusControl bus)
        {
            this.bus = bus;
        }
        
        public async Task PublishAsync(PaymentFeedFile objectFile)
            => await bus.Publish(objectFile);
    }
}
