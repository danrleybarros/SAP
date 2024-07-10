using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.GF;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers
{
    public class GetLocalizationHandler : Handler
    {
        private readonly IDne dne;

        public GetLocalizationHandler(IDne dne)
        {
            this.dne = dne;
        }

        public override void ProcessRequest(IndividualReportRequestNF request)
        {
            var ceps = new List<string>();
             
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Get localization data by cep"));

            ceps.AddRange(GetCeps(request, s => s?.Customer?.MailingZIPcode));
            ceps.AddRange(GetCeps(request, s => s?.Customer?.BillingZIPcode));
            ceps = ceps.Distinct().ToList();

            var init = 0;
            var end = 1000;
            var total = ceps.Count;

            request.UfOutputs = new List<UfOutput>();
            request.Logradouros = new List<CepOutput>();

            while (init <= total)
            {
                request.UfOutputs.AddRange(GetUfs(ceps, init, end));
                request.Logradouros.AddRange(GetAddress(ceps, init, end));

                init += end;
            }

            sucessor?.ProcessRequest(request);
        }

        private List<string> GetCeps(IndividualReportRequestNF request, Func<Invoice, string> func)
           => request.Invoices.Select(func).ToList();

        private List<UfOutput> GetUfs(List<string> allCeps, int init, int end)
        {
            var ceps = allCeps?.Skip(init).Take(end).ToList();

            return dne.GetListUf(ceps).Result;
        }

        private List<CepOutput> GetAddress(List<string> allCeps, int init, int end)
        {
            var ceps = allCeps.Skip(init).Take(end).ToList();

            return dne.GetListLogradouro(ceps).Result;
        }
    }
}
