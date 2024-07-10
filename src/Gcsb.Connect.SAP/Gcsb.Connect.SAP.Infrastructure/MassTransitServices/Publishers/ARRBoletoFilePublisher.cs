using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class ARRBoletoFilePublisher : Application.Repositories.IPublisher<ARRBoletoFile>
    {
        private IBusControl bus;

        public ARRBoletoFilePublisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ARRBoletoFile objectFile)
            => await bus.Publish(objectFile);
    }
}
