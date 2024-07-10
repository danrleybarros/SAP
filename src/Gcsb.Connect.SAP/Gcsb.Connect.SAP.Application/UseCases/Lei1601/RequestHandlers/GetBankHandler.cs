using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601.RequestHandlers
{
    public class GetBankHandler : Handler
    {
        private readonly IDynamicService dynamicService;

        public GetBankHandler(IDynamicService dynamicService)
        {
            this.dynamicService = dynamicService;
        }

        public override void ProcessRequest(Lei1601Request request)
        {
            var bankCode = request.Lines.Where(w => w.PaymentMethod == Domain.Lei1601.PaymentMethod.Boleto).GroupBy(g=> g.BankCode).Select(s=> s.Key).ToList();
            var banks = dynamicService.GetParticipantCode(bankCode);

            request.Lines.ForEach(f =>
            {
                var partipantCode = banks.Where(w => w.Key == f.BankCode);

                if (partipantCode.Any())
                    f.SetParticipantCode(partipantCode.FirstOrDefault().Value);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
