using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.UseCases.GF.Items;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ItemsConsumer : IConsumer<MasterFile>
    {
        private readonly IItemsUseCase itemsUseCase;

        public ItemsConsumer(IItemsUseCase itemsUseCase)
        {
            this.itemsUseCase = itemsUseCase;
        }

        public async Task Consume(ConsumeContext<MasterFile> context)
        {
            var masterFile = context.Message;

            await Task.Run(() =>
            {
                var request = new ItemsRequest((Guid)masterFile.IdParent);
                itemsUseCase.Execute(request);
            });
        }
    }
}
