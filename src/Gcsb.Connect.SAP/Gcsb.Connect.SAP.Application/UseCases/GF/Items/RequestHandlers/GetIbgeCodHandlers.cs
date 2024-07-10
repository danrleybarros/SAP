using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Domain.GF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class GetIbgeCodHandlers : Handler
    {
        private readonly IDne dne;

        public GetIbgeCodHandlers(IDne dne)
        {
            this.dne = dne;
        }

        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");
            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "After get invoices, the process will get ibge cod list from zip code"));

            var ceps = request.Invoices.Select(s => s.Customer.MailingZIPcode).ToList();
            var init = 0;
            var end = 1000;
            var total = ceps.Count;

            var codIbge = new List<CodIbgeOutput>();

            while (init <= total)
            {
                request.CodIbgeOutputs.AddRange(GetCodIbge(ceps, init, end));
                init += end;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private List<CodIbgeOutput> GetCodIbge(List<string> allCeps, int init, int end)
        {
            var ceps = allCeps.Skip(init).Take(end).ToList();

            return dne.GetListIbge(ceps).Result;
        }
    }
}
