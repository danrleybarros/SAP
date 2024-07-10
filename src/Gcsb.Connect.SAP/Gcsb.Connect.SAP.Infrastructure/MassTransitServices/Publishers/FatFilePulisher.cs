using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.Repositories;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class FatFilePulisher : IPublisher<ProcessFile>
    {
        private readonly IBusControl bus;

        public FatFilePulisher(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task PublishAsync(ProcessFile objectFile)
            => await bus.Publish(objectFile);
    }
}
