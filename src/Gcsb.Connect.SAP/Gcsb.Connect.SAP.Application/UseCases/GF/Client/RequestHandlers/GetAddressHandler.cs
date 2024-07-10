using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Domain.GF;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Client.RequestHandlers
{
    public class GetAddressHandler : Handler
    {
        private readonly IDne dne;

        public GetAddressHandler(IDne dne)
        {
            this.dne = dne;
        }

        public override void ProcessRequest(ClientChainRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null.");

            request.Logs.Add(Log.CreateProcessingLog(request.Service, "The process will get address list from billing zip codes"));

            var ceps = request.Customers.Select(s => s.BillingZIPcode).Distinct().ToList();

            var init = 0;
            var end = 1000;
            var total = ceps.Count;

            request.Address = new List<CepOutput>();

            while (init <= total)
            {
                request.Address.AddRange(GetAddress(ceps, init, end));
                init += end;
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private List<CepOutput> GetAddress(List<string> allCeps, int init, int end)
        {
            var ceps = allCeps.Skip(init).Take(end).ToList();

            return dne.GetListLogradouro(ceps).Result;
        }
    }
}
