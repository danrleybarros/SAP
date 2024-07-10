using Gcsb.Connect.Messaging.Messages.File;
using MassTransit;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.MassTransitServices.Publishers
{
    public class FilePublisher : Application.Repositories.IPublisher<File>
    {
        private IBusControl bus;

        public FilePublisher(IBusControl bus)
        {
            this.bus = bus;
        }
        public async Task PublishAsync(File file)
        {
            if (file == null) return;
            await PublishAsync(new ReprocessingFile(file.Id, file.FileName, file.Type, file.InclusionDate, file.Status, file.Logs, file.CycleDate, file.IdParent));
        }

        public async Task PublishAsync(ReprocessingFile objectFile)
            => await bus.Publish(objectFile);
    }
}
