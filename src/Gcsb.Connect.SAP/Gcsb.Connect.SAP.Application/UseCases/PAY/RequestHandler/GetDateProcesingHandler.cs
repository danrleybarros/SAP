using Gcsb.Connect.SAP.Application.Repositories;
using System;
using System.Data.SqlTypes;

namespace Gcsb.Connect.SAP.Application.UseCases.PAY.RequestHandler
{
    public class GetDateProcesingHandler : Handler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;

        public GetDateProcesingHandler(IFileReadOnlyRepository fileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = fileReadOnlyRepository;
        }

        public override void ProcessRequest(CriticalRequest request)
        {
            request.AddLog("Getting InclusionDate payment boleto");

            var file = fileReadOnlyRepository.GetFile(x => x.Type.Equals(Messaging.Messages.File.Enum.TypeRegister.PAYMENTBOLETOTSV)
             && !x.Id.Equals(request.IDPaymentFeed));

            request.SetDate(file?.InclusionDate ?? SqlDateTime.MinValue.Value);
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);

        }
    }
}
