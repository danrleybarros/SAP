using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WriteJsdnFile.Consumers
{
    public class ARRBoletoIntercompanyConsumer : IConsumer<ARRBoletoFile>
    {
        private readonly IARRUseCase<ARRBoletoInter> arrUseCaseBoletoIntercompany;

        public ARRBoletoIntercompanyConsumer(IARRUseCase<ARRBoletoInter> arrUseCaseBoletoIntercompany)
        {
            this.arrUseCaseBoletoIntercompany = arrUseCaseBoletoIntercompany;
        }

        public async Task Consume(ConsumeContext<ARRBoletoFile> context)
        {
            await Task.Run(() =>
            {
                var requestBoletoInter = new ARRRequest<ARRBoletoInter>(TypeRegister.ARRBOLETOINTER, (Guid)context.Message.IdParent);
                arrUseCaseBoletoIntercompany.Execute(requestBoletoInter);
            });
        }
    }
}

