using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.RequestHandlers
{
    public class GetStoresHandler : Handler
    {
        private readonly IJsdnStoreService jsdnStoreService;

        public GetStoresHandler(IJsdnStoreService jsdnStoreService)
        {
            this.jsdnStoreService = jsdnStoreService;
        }

        public override void ProcessRequest(AllCustomersRequest request)
        {
            var acronymns = request.Invoices.Select(s => s.StoreAcronym).Distinct().ToList();

            acronymns.ForEach(acronym =>
            {
                acronym = string.IsNullOrEmpty(acronym) ? "telerese" : acronym;
                request.Stores.Add(jsdnStoreService.GetStores(acronym));
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
