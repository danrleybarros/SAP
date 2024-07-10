using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Domain.GF;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class GetAddressHandler : Handler
    {
        private IDne dne;

        public GetAddressHandler(IDne dne)
        {
            this.dne = dne;
        }

        public override void ProcessRequest(FATRequest request)
        {
            var ceps = request?.Invoices.Select(s => s.Customer?.BillingZIPcode).Distinct().ToList();

            var init = 0;
            var end = 1000;
            var total = ceps.Count;

            request.Address = new List<CepOutput>();

            while (init <= total)
            {
                request.Address.AddRange(GetAddress(ceps, init, end));
                init += end;
            }

            sucessor?.ProcessRequest(request);
        }

        private List<CepOutput> GetAddress(List<string> allCeps, int init, int end)
        {
            var ceps = allCeps.Skip(init).Take(end).ToList();

            return dne.GetListLogradouro(ceps).Result;
        }
    }
}
